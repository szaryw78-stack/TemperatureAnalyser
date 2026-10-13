using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace TemperatureAnalyser.Forms
{
    public partial class VirtualGasCollectionForm : DevExpress.XtraEditors.XtraForm
    {
        public VirtualGasCollectionForm()
        {
            InitializeComponent();
        }

        private void VirtualGasCollectionForm_Load(object sender, EventArgs e)
        {
            dtCollectionDateTime.EditValue = DateTime.Now;
            tbRealCounter.Text = "0";
            tbVirtualCounter.Text = "0";
        }

        private void btnSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var gi = new GasImprooved();
                gi.InsertGasImproovement(Convert.ToDouble(tbRealCounter.Text),
                    Convert.ToDouble(tbVirtualCounter.Text), ((DateTime)dtCollectionDateTime.EditValue).Date);
                XtraMessageBox.Show("Dane zostały zapisane.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Nie udało się zapisać danych. " + ex.Message,
                    "BŁĄD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}