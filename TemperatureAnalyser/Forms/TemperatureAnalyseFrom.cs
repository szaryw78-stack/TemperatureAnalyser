using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace TemperatureAnalyser
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ApplicationConfig apc = new ApplicationConfig();
        RestInterfaceTemperatures rst = new RestInterfaceTemperatures();
        GasImprooved gi = new GasImprooved();
        public Form1()
        {
            InitializeComponent();
            dgwAvarageTemperaturesView.FocusedRowChanged += dgwAvarageTemperaturesView_FocusedRowChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtFrom.EditValue = DateTime.Now.Date.AddDays(-30);
            dtTo.EditValue = DateTime.Now.Date.Date.AddDays(1);
            dgwAvarageTemperatures.Dock = System.Windows.Forms.DockStyle.Fill;
            dgwSourceData.Dock = System.Windows.Forms.DockStyle.Fill;
            dgwCosts.Dock = DockStyle.Fill;
            dgwBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            ConvertIntToBoolOnGridView();

            this.Text = "Rejestracja temperatury oraz stanu licznika gazu | version:"+System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

        }
        private void ConvertIntToBoolOnGridView()
        {
            //Zamiana int na bool na grid
            RepositoryItemCheckEdit ri = new RepositoryItemCheckEdit();
            ri.ValueChecked = 1;
            ri.ValueUnchecked = 0;
            ri.ValueGrayed = 2;

            //  dgwUserSettingsView.Columns["is_rated"].ColumnEdit = ri;
            dgwAvarageTemperaturesView.Columns["Fireplace"].ColumnEdit = ri;
            //   dgwMeasurementDataView.Columns["is_active"].ColumnEdit = ri;

        }


        private void btnGetTemperatures_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //xtraOpenFileDialog1.ShowDialog();
            //string file = xtraOpenFileDialog1.FileName;
            //var data = rst.GetTemperaturesFromSupla();
            //if (data.Count > 0)
            //{
            //    apc.InsertTemperatures(data);
            //    var avarage = apc.AvarageTemperatures(data);
            //    XtraMessageBox.Show("Import danych zakończony pomyślnie", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //}
            //else
            //{
            //    XtraMessageBox.Show("Brak danych do zapisu", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            GetDataFromSupla();

            UpdateData();


            //dgwSourceData.DataSource = data;
            //dgwAvarageTemperatures.DataSource = avarage;
        }
        private void GetDataFromSupla()
        {
           // bool status = false;
            try
            {

          
            var data = rst.GetTemperaturesFromSupla();
            if (data.Count > 0)
            {
                apc.InsertTemperatures(data);
                var avarage = apc.AvarageTemperatures(data);
                XtraMessageBox.Show("Import danych zakończony pomyślnie", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                XtraMessageBox.Show("Brak danych do zapisu", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //  var temp = rst.GetTemperaturesFromSupla();
            //DateTime dt = DateTime.Now;
            //double date_timestamp = 1644511590.0;

            //System.Globalization.Calendar calendar = new GregorianCalendar();

            //var DateAndTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, new GregorianCalendar()).AddSeconds(date_timestamp);
            // TimeZoneInfo tz = new TimeZoneInfo() ;
            // bool isSummerTime = new DateTime(2022, 5, 9).IsDaylightSavingTime();
            //    var p = apc.GasUsageAndPriceCalculation(new DateTime(2022, 1, 15));

            //GoogleDrive gd = new GoogleDrive();
            //gd.Connect();
            /// var p = apc.GetTemperatures();
            /// 
            //var data = new List<DataCollector.TemperaturesData>();

            ////  var gas = apc.GetGasUsageFromFile(@"c:\TEMP\POMIAR_TEMPERATURY\gas.csv");
            //// apc.InsertGasUsage(gas);
            //var gas = apc.GetGasUsage();
            //apc.UpdateFireplace(gas);
            //   var kk = apc.GetMaxTimeStampId();

            //        data.Add(new DataCollector.TemperaturesData { TimeStamp = 34684873648236, DateAndTime = DateTime.Now, Temperature = -5.1 });
            //     apc.InsertTemperatures(data);
            //ts 1678967485.0
            double ts = 1678967485;
            DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local).AddSeconds(ts).AddHours(1).ToLocalTime();
            string dt = "30.05.2022 12:42:42";
            //string dt3 = "2022-05-30 11:42:41";
            //DateTime dt2;
          //  string[] formats = { "yyyy-MM-dd hh:mm:ss", "dd.MM.yyyy hh:mm:ss", "dd.MM.yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "dd.MM.yyyy HH:MM:ss" };
            string[] formats = { "yyyy-MM-dd hh:mm:ss", "dd.MM.yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "dd.MM.yyyy HH:MM:ss" };

            DateTime dt11 = DateTime.ParseExact(dt,
                                                  formats,
                                                  new CultureInfo("pl-PL"),
                                                  DateTimeStyles.AssumeLocal);


        }

        private void UpdateData()
        {
            //   var tGPT = apc.GetTemperaturesGPT();
            //DateTime dStart, dEnd;
            //dStart = DateTime.Now;
            var temperatures =  apc.GetTemperaturesGPT(); //apc.GetTemperatures();

            //dEnd = DateTime.Now;
            //var dif = (dEnd- dStart).TotalSeconds;

            var gasUsage = apc.GetGasUsage();
            var gasUsageBevoreCounterExchange = apc.GetGasUsageBevorConterExchange();
            var avaragesTem = apc.AvarageTemperatures(temperatures);
            var balance = gi.GetDataImprooveds();
            gasUsage.AddRange(gasUsageBevoreCounterExchange);
            var averagesByDate = avaragesTem.ToDictionary(item => item.Date.Date, item => item.AvarageDailyTemperature);
            foreach (var i in gasUsage)
            {
                double average;
                if (averagesByDate.TryGetValue(i.CollectionDatetime.Date, out average))
                {
                    i.AvarageDailyTemperature = average;
                }
            }

            dgwAvarageTemperatures.DataSource = gasUsage.OrderByDescending(i => i.CollectionDatetime).ToList();
            dgwSourceData.DataSource = temperatures;
            dgwBalance.DataSource = balance;
        }

        private void btnLoadData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
            GetDataFromSupla();
            UpdateData();

        }

        private void btnAddGasCounter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.AddGasCountercs frm = new Forms.AddGasCountercs();
            frm.ShowDialog();
            GetDataFromSupla();
         DialogResult res =   XtraMessageBox.Show("Czy chcesz przeliczyć ponowanie dane", "PYTANIE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                UpdateData();
            }
            
       
        }

        private DataCollector.GasData GetSelectedRow(DevExpress.XtraGrid.GridControl gridControl, DevExpress.XtraGrid.Views.Grid.GridView gridControlView)
        {

            DataCollector.GasData row = null;

            if (gridControlView.GetSelectedRows().Count() == 0)
            {

                return null;
            }

            try
            {

                DevExpress.XtraGrid.Views.Grid.GridView _gd = gridControl.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
                row = _gd.GetRow(gridControlView.FocusedRowHandle) as DataCollector.GasData;
            }
            catch (Exception ex)
            {
                // rwdll.Log(DateTime.Now + ";Wystąpił błąd w metodzie GetSelectedRow().Wyjątek:" + ex.Message + ";" + ApplicationConfig.ExeptionType.Exeption + "\n");
                // iual.InsertExceptionLogData(ex, this);
                XtraMessageBox.Show("Wystąpił błąd w metodzie GetSelectedRow().Wyjątek:" + ex.Message);

            }

            return row;

        }


        private void dgwAvarageTemperaturesView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var row = dgwAvarageTemperaturesView.GetRow(e.FocusedRowHandle) as DataCollector.GasData;
            if (row != null)
            {
                var data = apc.GasUsageAndPriceCalculation(row.CollectionDatetime);
                dgwCosts.DataSource = data;
            }
            else
            {
                dgwCosts.DataSource = null;
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnPricesSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.PricesSettingsForm ps = new Forms.PricesSettingsForm();
            ps.ShowDialog();

        }

        private void btnReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Forms.ReportForm frm = new Forms.ReportForm()
            {
                dStartDate = (DateTime)dtFrom.EditValue,
                dEndDate = (DateTime)dtTo.EditValue

            };
            frm.ShowDialog();







        }

        private void btnEditData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = GetSelectedRow(dgwAvarageTemperatures, dgwAvarageTemperaturesView);

            if (row != null)
            {
                Forms.AddGasCountercs frm = new Forms.AddGasCountercs()
                {
                    edit = true,
                    row = row
                };
                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Zaznacz rekord do skorygowania");
            }
        }

        private void btnAddVirtualGasCollection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.VirtualGasCollectionForm frm = new Forms.VirtualGasCollectionForm();
            frm.ShowDialog();
        }
    }
}
