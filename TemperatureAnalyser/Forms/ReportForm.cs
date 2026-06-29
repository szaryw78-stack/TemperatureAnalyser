using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;

namespace TemperatureAnalyser.Forms
{
    public partial class ReportForm : DevExpress.XtraEditors.XtraForm
    {
        ApplicationConfig apc = new ApplicationConfig();
        public DateTime dStartDate ;
        public DateTime dEndDate; 
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;


            chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            rangeControl1.Dock = System.Windows.Forms.DockStyle.Fill;

            splitContainerControl1.SplitterPosition = (this.Height * 80) / 100;
            splitContainerControl1.IsSplitterFixed = true;
            var temperatureData = apc.GetTemperatures(dStartDate,dEndDate);
            var gasData = apc.GetGasUsage(dStartDate,dEndDate);

            DrawChart(temperatureData, gasData);

        }

        private void DrawChart(List<DataCollector.TemperaturesData> temperarutesData, List<DataCollector.GasData> gasUsage)
        {


            ChartTitle cTitle = new ChartTitle();
            cTitle.Text = "Wykres temperatury i zużycia gazu";
            chartControl1.Titles.Add(cTitle);

            Series tempSeries = new Series("Temperatura", ViewType.Line);
            Series gasSeries = new Series("Gas", ViewType.Line);
            Series avaragesTempSeries = new Series("Średnia temperatura", ViewType.Line);

            var avaragesTemp = apc.AvarageTemperatures(temperarutesData);

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