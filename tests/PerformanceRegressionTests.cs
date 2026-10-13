using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TemperatureAnalyser;
using TemperatureAnalyser.DataCollector;

internal static class PerformanceRegressionTests
{
    private static readonly ApplicationConfig Config = new ApplicationConfig();

    private static int Main()
    {
        string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        string database = Path.Combine(directory, "baza.db");
        if (File.Exists(database))
            throw new InvalidOperationException("Refusing to overwrite an existing database: " + database);

        Directory.CreateDirectory(directory);
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("pl-PL");
        try
        {
            CreateSchema();
            TestTemperatureImport();
            TestBatchRollback();
            TestGasAndPrices();
            TestAverages();
            TestRestAsync().GetAwaiter().GetResult();
            Console.WriteLine("All performance regression checks passed.");
            return 0;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine(exception);
            return 1;
        }
        finally
        {
            SQLiteConnection.ClearAllPools();
            File.Delete(database);
            if (!Directory.EnumerateFileSystemEntries(directory).Any())
                Directory.Delete(directory);
        }
    }

    private static void CreateSchema()
    {
        Execute(@"CREATE TABLE TemperatureData
            (id INTEGER PRIMARY KEY, timestamp REAL UNIQUE, datetime TEXT, value REAL);
            CREATE TABLE GasDataCollection
            (id INTEGER PRIMARY KEY, collectiondatetime TEXT, value REAL CHECK(value <> -999),
             fireplace INTEGER CHECK(fireplace <> 9), createddatetime TEXT, zone1 REAL,
             zone2 REAL, automatic INTEGER, note TEXT);
            CREATE TABLE GasDataCollectionOld
            (id INTEGER PRIMARY KEY, collectiondatetime TEXT, value REAL,
             fireplace INTEGER, createddatetime TEXT, zone1 REAL, zone2 REAL,
             automatic INTEGER, note TEXT);
            CREATE TABLE Prices
            (id INTEGER PRIMARY KEY, key TEXT, value REAL CHECK(value <> -999),
             month INTEGER, year INTEGER, createdDatetime TEXT);
            CREATE TABLE GasDataCollectionImprooved
            (id INTEGER PRIMARY KEY, realcounter REAL, virtualcounter REAL, createddatetime TEXT);");
    }

    private static void TestTemperatureImport()
    {
        DateTime date = new DateTime(2026, 1, 1);
        var batch = Enumerable.Range(1, 1000).Select(index => new TemperaturesData
        {
            TimeStamp = index,
            DateAndTime = date.AddMinutes(index),
            Temperature = index % 20
        }).ToList();
        Config.InsertTemperatures(batch);
        Config.InsertTemperatures(batch);
        Assert(Scalar("SELECT COUNT(*) FROM TemperatureData") == 1000, "Incremental temperature import");
        Assert(Config.GetTemperaturesGPT().Count == 1000, "Temperature reader");

        var failing = Enumerable.Range(1001, 500).Select(index => new TemperaturesData
        {
            TimeStamp = index,
            DateAndTime = date.AddMinutes(index),
            Temperature = 10
        }).ToList();
        failing.Add(failing[0]);
        Expect<SQLiteException>(() => Config.InsertTemperatures(failing));
        Assert(Scalar("SELECT COUNT(*) FROM TemperatureData") == 1000,
            "Temperature failure must roll back 500 successful inserts");
        Config.InsertTemperatures(new List<TemperaturesData> { failing[0] });
        Assert(Scalar("SELECT COUNT(*) FROM TemperatureData") == 1001, "Import after rollback");
    }

    private static void TestBatchRollback()
    {
        var gas = new List<GasData>
        {
            Gas(new DateTime(2026, 1, 1), 10),
            Gas(new DateTime(2026, 1, 2), -999)
        };
        Expect<SQLiteException>(() => Config.InsertGasUsage(gas));
        Assert(Scalar("SELECT COUNT(*) FROM GasDataCollection") == 0, "Gas batch rollback");

        var prices = new List<Prices>
        {
            new Prices { key = "PALIWO", value = 3 },
            new Prices { key = "ABONAMENT", value = -999 }
        };
        Expect<SQLiteException>(() => Config.InsertPrices(prices, new DateTime(2026, 1, 1)));
        Assert(Scalar("SELECT COUNT(*) FROM Prices") == 0, "Prices batch rollback");
        Config.InsertGasUsage(new List<GasData>
        {
            Gas(new DateTime(2026, 1, 1), 10),
            Gas(new DateTime(2026, 1, 2), 20),
            Gas(new DateTime(2026, 1, 3), 30)
        });
        var updates = Config.GetGasUsage();
        updates[1].Fireplace = 1;
        updates[2].Fireplace = 9;
        Expect<SQLiteException>(() => Config.UpdateFireplace(updates));
        Assert(Scalar("SELECT SUM(fireplace) FROM GasDataCollection") == 0, "Fireplace batch rollback");
        Execute("DELETE FROM GasDataCollection");
    }

    private static void TestGasAndPrices()
    {
        var dates = new[] { new DateTime(2026, 1, 30), new DateTime(2026, 1, 31), new DateTime(2026, 2, 1) };
        Config.InsertGasUsage(new List<GasData> { Gas(dates[0], 100), Gas(dates[1], 110), Gas(dates[2], 125) });
        var gas = Config.GetGasUsage();
        Assert(gas[0].Usage == 10 && gas[1].Usage == 15 && gas[2].Usage == 0, "Existing usage assignment");
        Assert(Config.GetGasUsage(dates[0], dates[1]).Count == 2, "Range parameters are bound");
        Expect<InvalidOperationException>(() => Config.GasUsageAndPriceCalculation(dates[0]));
        Config.InsertPrices(new List<Prices>
        {
            new Prices { key = "DYSTRYBUCJA_ZMIENNA", value = 1 },
            new Prices { key = "PALIWO", value = 3 },
            new Prices { key = "ABONAMENT", value = 5 }
        }, dates[0]);
        var costs = Config.GasUsageAndPriceCalculation(dates[0]);
        Assert(costs.Count == 5, "Cost result shape");
        Assert(costs.Single(item => item.id == 1).value == 10, "Existing last-day boundary");
        Assert(costs.Single(item => item.id == 2).value == 12.5, "Positive-only usage average");
        Assert(costs.Single(item => item.id == 3).value == 1555, "Cost formula");
        Assert(costs.Single(item => item.id == 5).value == 125, "Current-counter maximum");
        Expect<InvalidOperationException>(() => Config.GasUsageAndPriceCalculation(new DateTime(2025, 1, 1)));

        gas[0].memoNote = "updated";
        Config.UpdateGasUsage(gas[0]);
        Config.UpdateGasUsage(gas[0]);
        Assert(Config.GetGasUsage().Any(item => item.memoNote == "updated"), "Repeated updates release connection");
        var balance = new GasImprooved();
        balance.InsertGasImproovement(10, 12, dates[0]);
        Assert(balance.GetDataImprooveds().Single().difference == 2, "Balance round trip");
        TestLegacyCostEquivalence();
    }

    private static void TestLegacyCostEquivalence()
    {
        Execute("DELETE FROM GasDataCollection; DELETE FROM GasDataCollectionOld; DELETE FROM Prices;");
        var batch = Enumerable.Range(1, 45).Select(index =>
            Gas(new DateTime(2024, 1, 25).AddDays(index), 100 + index * 3)).ToList();
        Config.InsertGasUsage(batch);
        var date = new DateTime(2024, 2, 15);
        Config.InsertPrices(new List<Prices>
        {
            new Prices { key = "DYSTRYBUCJA_ZMIENNA", value = 0.35 },
            new Prices { key = "PALIWO", value = 2.75 },
            new Prices { key = "ABONAMENT", value = 8 }
        }, date);
        var gas = Config.GetGasUsage();
        var monthly = gas.Where(item => item.Month == date.Month && item.Year == date.Year).ToList();
        DateTime previous = monthly.Min(item => item.CollectionDatetime).AddDays(-1);
        monthly.AddRange(gas.Where(item => item.CollectionDatetime == previous));
        monthly = monthly.OrderBy(item => item.CollectionDatetime).ToList();
        double average = monthly.Where(item => item.Usage > 0).Select(item => item.Usage).DefaultIfEmpty().Average();
        var expected = new[]
        {
            monthly.Where(item => item.CollectionDatetime < new DateTime(2024, 2, 29)).Sum(item => item.Usage),
            average, average * 29 * 0.35 + average * 29 * 2.75 + 8, average * 29, gas.Max(item => item.Value)
        };
        var actual = Config.GasUsageAndPriceCalculation(date);
        for (int index = 0; index < expected.Length; index++)
            Assert(Math.Abs(actual[index].value - expected[index]) < 1e-9, "Legacy cost equivalence " + index);
    }

    private static void TestAverages()
    {
        DateTime date = new DateTime(2026, 1, 1);
        var data = new List<TemperaturesData>
        {
            new TemperaturesData { Date = date.AddDays(1), Temperature = -2 },
            new TemperaturesData { Date = date, Temperature = 10 },
            new TemperaturesData { Date = date, Temperature = 20 }
        };
        var result = Config.AvarageTemperatures(data);
        Assert(result.Count == 2 && result[0].Date == date && result[0].AvarageDailyTemperature == 15,
            "Daily grouping and ordering");
        Assert(Config.AvarageTemperatures(new List<TemperaturesData>()).Count == 0, "Empty averages");
    }

    private static async Task TestRestAsync()
    {
        using (var client = new HttpClient(new FakeHandler()))
        {
            var rest = new RestInterfaceTemperatures(client);
            var result = await rest.GetTemperaturesFromSuplaAsync(CancellationToken.None);
            Assert(result.Count == 1 && result[0].Temperature == 5, "Asynchronous REST mapping");
        }
        using (var client = new HttpClient(new FakeHandler(HttpStatusCode.Unauthorized)))
        {
            bool failed = false;
            try { await new RestInterfaceTemperatures(client).GetTemperaturesFromSuplaAsync(CancellationToken.None); }
            catch (HttpRequestException) { failed = true; }
            Assert(failed, "HTTP errors propagate instead of returning empty success");
        }
        using (var cancellation = new CancellationTokenSource())
        using (var client = new HttpClient(new FakeHandler()))
        {
            cancellation.Cancel();
            bool cancelled = false;
            try { await new RestInterfaceTemperatures(client).GetTemperaturesFromSuplaAsync(cancellation.Token); }
            catch (OperationCanceledException) { cancelled = true; }
            Assert(cancelled, "REST cancellation");
        }
    }

    private sealed class FakeHandler : HttpMessageHandler
    {
        private readonly HttpStatusCode status;
        internal FakeHandler(HttpStatusCode status = HttpStatusCode.OK) { this.status = status; }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return Task.FromResult(new HttpResponseMessage(status)
            {
                Content = new StringContent("[{\"date_timestamp\":1678967485,\"temperature\":5}]")
            });
        }
    }

    private static GasData Gas(DateTime date, double value)
    {
        return new GasData { CollectionDatetime = date, Value = value, memoNote = null };
    }

    private static SQLiteConnection Open()
    {
        var connection = new SQLiteConnection("Data Source=" +
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\baza.db"));
        connection.Open();
        return connection;
    }

    private static void Execute(string sql)
    {
        using (var connection = Open())
        using (var command = new SQLiteCommand(sql, connection))
            command.ExecuteNonQuery();
    }

    private static long Scalar(string sql)
    {
        using (var connection = Open())
        using (var command = new SQLiteCommand(sql, connection))
            return Convert.ToInt64(command.ExecuteScalar());
    }

    private static void Expect<T>(Action action) where T : Exception
    {
        try { action(); }
        catch (T) { return; }
        throw new InvalidOperationException("Expected exception " + typeof(T).Name);
    }

    private static void Assert(bool condition, string name)
    {
        if (!condition)
            throw new InvalidOperationException("Failed: " + name);
        Console.WriteLine("PASS: " + name);
    }
}
