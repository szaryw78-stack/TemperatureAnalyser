using DevExpress.Utils;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TemperatureAnalyser.Forms
{
    public partial class PricesSettingsForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        ApplicationConfig apc = new ApplicationConfig();
        public PricesSettingsForm()
        {
            InitializeComponent();
        }

        private void btnRefreshPrices_ItemClick(object sender, ItemClickEventArgs e)
        {
            var prices = apc.GetPrices((DateTime)dtPriceDate.EditValue);

            dgwPrices.DataSource = prices;




        }

        private void PricesSettingsForm_Load(object sender, EventArgs e)
        {
            dgwPrices.Dock = DockStyle.Fill;
            dtPriceDate.EditValue = DateTime.Now.Date;
            Point p = new Point(btnAddPrices.Size.Width, btnAddPrices.Size.Height);
            this.toolTipController1.ShowHint("Przed zapisem zaznacz wszystkie rekordy na grid", ToolTipLocation.Fixed, this.PointToScreen(p));
        }
        private List<DataCollector.Prices> GetSelectedRows(DevExpress.XtraGrid.GridControl gridControl, DevExpress.XtraGrid.Views.Grid.GridView gridControlView)
        {

            DataCollector.Prices row = null;
            var result = new List<DataCollector.Prices>();
            if (dgwPricesView.GetSelectedRows().Count() == 0)
            {
                return null;
            }

            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView _gd = gridControl.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
                for (int i = 0; i < _gd.DataRowCount; i++)
                {
                    if (_gd.IsRowSelected(i))
                    {
                        row = _gd.GetRow(i) as DataCollector.Prices;//ridControlView.FocusedRowHandle) as DataCollector.PersonalBudget;
                        result.Add(row);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
                //rwdll.Log(DateTime.Now + ";Wystąpił błąd w metodzie GetSelectedRows().Wyjątek:" + ex.Message + ";" + ApplicationConfig.ExeptionType.Exeption + "\n");
                //iual.InsertExceptionLogData(ex, this);
                //XtraMessageBox.Show("Wystąpił błąd w metodzie GetSelectedRows():" + ex.Message);

            }

            return result;

        }

        private void btnAddPrices_ItemClick(object sender, ItemClickEventArgs e)
        {

            var data = GetSelectedRows(dgwPrices, dgwPricesView);
            apc.InsertPrices(data, (DateTime)dtPriceDate.EditValue);
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}