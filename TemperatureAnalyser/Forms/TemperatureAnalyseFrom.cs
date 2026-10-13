using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperatureAnalyser
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ApplicationConfig apc = new ApplicationConfig();
        private readonly RestInterfaceTemperatures rst = new RestInterfaceTemperatures();
        private CancellationTokenSource operationCancellation;
        private bool closeRequested;

        public Form1()
        {
            InitializeComponent();
            dgwAvarageTemperaturesView.FocusedRowChanged += dgwAvarageTemperaturesView_FocusedRowChanged;
            FormClosing += Form1_FormClosing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtFrom.EditValue = DateTime.Now.Date.AddDays(-30);
            dtTo.EditValue = DateTime.Now.Date.AddDays(1);
            dgwAvarageTemperatures.Dock = DockStyle.Fill;
            dgwSourceData.Dock = DockStyle.Fill;
            dgwCosts.Dock = DockStyle.Fill;
            dgwBalance.Dock = DockStyle.Fill;
            ConvertIntToBoolOnGridView();
            Text = "Rejestracja temperatury oraz stanu licznika gazu | version:" +
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void ConvertIntToBoolOnGridView()
        {
            var checkEdit = new RepositoryItemCheckEdit
            {
                ValueChecked = 1,
                ValueUnchecked = 0,
                ValueGrayed = 2
            };
            dgwAvarageTemperatures.RepositoryItems.Add(checkEdit);
            dgwAvarageTemperaturesView.Columns["Fireplace"].ColumnEdit = checkEdit;
        }

        private async Task RunOperationAsync(Func<CancellationToken, Task> operation)
        {
            if (operationCancellation != null)
                return;

            using (var cancellation = new CancellationTokenSource())
            {
                operationCancellation = cancellation;
                ribbonControl1.Enabled = false;
                dgwAvarageTemperatures.Enabled = false;
                UseWaitCursor = true;
                try
                {
                    await operation(cancellation.Token);
                }
                catch (OperationCanceledException) when (cancellation.IsCancellationRequested)
                {
                    // Closing the form cancels the pending request.
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Nie udało się wykonać operacji. " + ex.Message,
                        "BŁĄD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    UseWaitCursor = false;
                    ribbonControl1.Enabled = true;
                    dgwAvarageTemperatures.Enabled = true;
                    operationCancellation = null;
                    if (closeRequested)
                        Close();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (operationCancellation == null)
                return;

            closeRequested = true;
            e.Cancel = true;
            operationCancellation.Cancel();
        }

        private async void btnGetTemperatures_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await ImportAndRefreshAsync();
        }

        private Task ImportAndRefreshAsync()
        {
            return RunOperationAsync(async token =>
            {
                await GetDataFromSuplaAsync(token);
                await UpdateDataAsync(token);
            });
        }

        private async Task GetDataFromSuplaAsync(CancellationToken token)
        {
            var data = await rst.GetTemperaturesFromSuplaAsync(token);
            if (data.Count == 0)
            {
                XtraMessageBox.Show("Brak danych do zapisu", "INFO",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await Task.Run(() => apc.InsertTemperatures(data), token);
            token.ThrowIfCancellationRequested();
            XtraMessageBox.Show("Import danych zakończony pomyślnie", "INFO",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task UpdateDataAsync(CancellationToken token)
        {
            var snapshot = await Task.Run(() =>
            {
                token.ThrowIfCancellationRequested();
                var temperatures = apc.GetTemperaturesGPT();
                var gasUsage = apc.GetGasUsage();
                gasUsage.AddRange(apc.GetGasUsageBevorConterExchange());
                var averages = apc.AvarageTemperatures(temperatures)
                    .ToDictionary(item => item.Date.Date, item => item.AvarageDailyTemperature);
                foreach (var item in gasUsage)
                {
                    double average;
                    item.AvarageDailyTemperature =
                        averages.TryGetValue(item.CollectionDatetime.Date, out average) ? average : 0;
                }

                return new
                {
                    Temperatures = temperatures,
                    GasUsage = gasUsage.OrderByDescending(item => item.CollectionDatetime).ToList(),
                    Balance = new GasImprooved().GetDataImprooveds()
                };
            }, token);

            token.ThrowIfCancellationRequested();
            dgwAvarageTemperatures.DataSource = snapshot.GasUsage;
            dgwSourceData.DataSource = snapshot.Temperatures;
            dgwBalance.DataSource = snapshot.Balance;
            await RefreshCostsAsync(token);
        }

        private async void btnLoadData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await ImportAndRefreshAsync();
        }

        private async void btnAddGasCounter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var form = new Forms.AddGasCountercs())
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return;
            }

            await RunOperationAsync(async token =>
            {
                // A failed network import must not hide a successfully saved gas reading.
                await UpdateDataAsync(token);
                await GetDataFromSuplaAsync(token);
                await UpdateDataAsync(token);
            });
        }

        private DataCollector.GasData GetSelectedRow()
        {
            return dgwAvarageTemperaturesView.GetFocusedRow() as DataCollector.GasData;
        }

        private async Task RefreshCostsAsync(CancellationToken token)
        {
            var row = GetSelectedRow();
            dgwCosts.DataSource = null;
            if (row == null)
                return;

            DateTime date = row.CollectionDatetime;
            var costs = await Task.Run(() => apc.GasUsageAndPriceCalculation(date), token);
            token.ThrowIfCancellationRequested();
            dgwCosts.DataSource = costs;
        }

        private async void dgwAvarageTemperaturesView_FocusedRowChanged(
            object sender, FocusedRowChangedEventArgs e)
        {
            await RunOperationAsync(RefreshCostsAsync);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private async void btnPricesSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var form = new Forms.PricesSettingsForm())
            {
                form.ShowDialog();
                if (form.PricesChanged)
                    await RunOperationAsync(RefreshCostsAsync);
            }
        }

        private void btnReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var form = new Forms.ReportForm
            {
                dStartDate = (DateTime)dtFrom.EditValue,
                dEndDate = (DateTime)dtTo.EditValue
            })
            {
                form.ShowDialog();
            }
        }

        private async void btnEditData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = GetSelectedRow();
            if (row == null)
            {
                XtraMessageBox.Show("Zaznacz rekord do skorygowania");
                return;
            }
            using (var form = new Forms.AddGasCountercs { edit = true, row = row })
            {
                if (form.ShowDialog() == DialogResult.OK)
                    await RunOperationAsync(UpdateDataAsync);
            }
        }

        private async void btnAddVirtualGasCollection_ItemClick(
            object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var form = new Forms.VirtualGasCollectionForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    await RunOperationAsync(UpdateDataAsync);
            }
        }
    }
}
