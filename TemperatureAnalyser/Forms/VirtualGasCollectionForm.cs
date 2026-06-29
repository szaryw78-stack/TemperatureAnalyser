using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            GasImprooved gi = new GasImprooved();
            //double realCounter = Double.TryParse(tbRealCounter.Text, out double result);

            gi.InsertGasImproovement(Convert.ToDouble(tbRealCounter.Text), Convert.ToDouble(tbVirtualCounter.Text), ((DateTime)dtCollectionDateTime.EditValue).Date);
            XtraMessageBox.Show("Koniec");



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}