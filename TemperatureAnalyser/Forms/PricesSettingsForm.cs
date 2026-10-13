using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TemperatureAnalyser.Forms
{
    public partial class PricesSettingsForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ApplicationConfig apc = new ApplicationConfig();
        public bool PricesChanged { get; private set; }

        public PricesSettingsForm()
        {
            InitializeComponent();
        }

        private void btnRefreshPrices_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                dgwPrices.DataSource = apc.GetPrices((DateTime)dtPriceDate.EditValue);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void PricesSettingsForm_Load(object sender, EventArgs e)
        {
            dgwPrices.Dock = DockStyle.Fill;
            dtPriceDate.EditValue = DateTime.Now.Date;
            Point point = new Point(btnAddPrices.Size.Width, btnAddPrices.Size.Height);
            toolTipController1.ShowHint("Przed zapisem zaznacz wszystkie rekordy na grid",
                ToolTipLocation.Fixed, PointToScreen(point));
        }

        private void btnAddPrices_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var prices = new List<DataCollector.Prices>();
                foreach (int handle in dgwPricesView.GetSelectedRows())
                {
                    var price = dgwPricesView.GetRow(handle) as DataCollector.Prices;
                    if (price != null)
                        prices.Add(price);
                }
                if (prices.Count == 0)
                {
                    XtraMessageBox.Show("Zaznacz ceny do zapisu.", "INFO",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                apc.InsertPrices(prices, (DateTime)dtPriceDate.EditValue);
                PricesChanged = true;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private static void ShowError(Exception exception)
        {
            XtraMessageBox.Show("Nie udało się wykonać operacji na cenach. " + exception.Message,
                "BŁĄD", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}
