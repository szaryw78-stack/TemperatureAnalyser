using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperatureAnalyser.Forms
{
    public partial class ReportForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly ApplicationConfig apc = new ApplicationConfig();
        private CancellationTokenSource loadingCancellation;
        private bool closeRequested;
        public DateTime dStartDate ;
        public DateTime dEndDate; 
        public ReportForm()
        {
            InitializeComponent();
            FormClosing += ReportForm_FormClosing;
        }

        private async void ReportForm_Load(object sender, EventArgs e)
        {
            splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;


            chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            rangeControl1.Dock = System.Windows.Forms.DockStyle.Fill;

            splitContainerControl1.SplitterPosition = (this.Height * 80) / 100;
            splitContainerControl1.IsSplitterFixed = true;
            using (var cancellation = new CancellationTokenSource())
            {
                loadingCancellation = cancellation;
                UseWaitCursor = true;
                try
                {
                    var data = await Task.Run(() =>
                    {
                        var temperatures = apc.GetTemperatures(dStartDate, dEndDate);
                        var gas = apc.GetGasUsage(dStartDate, dEndDate);
                        return new
                        {
                            Temperatures = temperatures,
                            Gas = gas,
                            Averages = apc.AvarageTemperatures(temperatures)
                        };
                    }, cancellation.Token);
                    cancellation.Token.ThrowIfCancellationRequested();
                    DrawChart(data.Temperatures, data.Gas, data.Averages);
                }
                catch (OperationCanceledException) when (cancellation.IsCancellationRequested)
                {
                    // Wait for the database operation before closing the form.
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Nie udało się wczytać raportu. " + ex.Message, "BŁĄD",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    closeRequested = true;
                }
                finally
                {
                    loadingCancellation = null;
                    UseWaitCursor = false;
                    if (closeRequested)
                        Close();
                }
            }
        }

        private void ReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loadingCancellation == null)
                return;

            closeRequested = true;
            e.Cancel = true;
            loadingCancellation.Cancel();
        }

        private void DrawChart(List<DataCollector.TemperaturesData> temperarutesData,
            List<DataCollector.GasData> gasUsage, List<DataCollector.TemperaturesData> avaragesTemp)
        {


            ChartTitle cTitle = new ChartTitle();
            cTitle.Text = "Wykres temperatury i zużycia gazu";
            chartControl1.Titles.Add(cTitle);

            Series tempSeries = new Series("Temperatura", ViewType.Line);
            Series gasSeries = new Series("Gas", ViewType.Line);
            Series avaragesTempSeries = new Series("Średnia temperatura", ViewType.Line);

            foreach (var item in temperarutesData)
            {
                tempSeries.Points.Add(new SeriesPoint(item.DateAndTime, item.Temperature));

            }
            foreach (var item in gasUsage)
            {
                gasSeries.Points.Add(new SeriesPoint(item.CollectionDatetime, item.Usage));
            }

            foreach (var item in avaragesTemp)
            {
                avaragesTempSeries.Points.Add(new SeriesPoint(item.Date, item.AvarageDailyTemperature));
            }

            tempSeries.ArgumentScaleType = ScaleType.DateTime;
            gasSeries.ArgumentScaleType = ScaleType.DateTime;
            avaragesTempSeries.ArgumentScaleType = ScaleType.DateTime;

            tempSeries.ArgumentDataMember = "DateAndTime";
            gasSeries.ArgumentDataMember = "CollectionDatetime";
            avaragesTempSeries.ArgumentDataMember = "Date";
            tempSeries.ShowInLegend = true;
            gasSeries.ShowInLegend = true;
            avaragesTempSeries.ShowInLegend = true;


            chartControl1.Series.Add(tempSeries);
            chartControl1.Series.Add(gasSeries);
            chartControl1.Series.Add(avaragesTempSeries);
            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Hour;


        }

        private void ReportForm_ResizeEnd(object sender, EventArgs e)
        {
            splitContainerControl1.IsSplitterFixed = false;
            splitContainerControl1.SplitterPosition = (this.Height * 80) / 100;
            splitContainerControl1.IsSplitterFixed = true;

        }

        private void ReportForm_MinimumSizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.IsSplitterFixed = false;
            splitContainerControl1.SplitterPosition = (this.Height * 80) / 100;
            splitContainerControl1.IsSplitterFixed = true;

        }

        private void ReportForm_MaximumSizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.IsSplitterFixed = false;
            splitContainerControl1.SplitterPosition = (this.Height * 80) / 100;
            splitContainerControl1.IsSplitterFixed = true;

        }

        private void ReportForm_SizeChanged(object sender, EventArgs e)
        {
            splitContainerControl1.IsSplitterFixed = false;
            splitContainerControl1.SplitterPosition = (this.Height * 80) / 100;
            splitContainerControl1.IsSplitterFixed = true;
        }
    }
}