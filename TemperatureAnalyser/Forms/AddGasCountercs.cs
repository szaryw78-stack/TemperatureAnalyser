using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;

namespace TemperatureAnalyser.Forms
{
    public partial class AddGasCountercs : DevExpress.XtraEditors.XtraForm
    {
        ApplicationConfig apc = new ApplicationConfig();
        public bool edit = false;
        public DataCollector.GasData row = null;
        public AddGasCountercs()
        {
            InitializeComponent();
        }

        private void AddGasCountercs_Load(object sender, EventArgs e)
        {
            radioGroup1.SelectedIndex = 0;
            textEdit1.Text = "0";
            dateEdit1.EditValue = DateTime.Now.Date;
            var temperaturesSettings = apc.GetTemperatureSettings();
            textEdit2.Text = temperaturesSettings.Zone1.ToString();
            textEdit3.Text = temperaturesSettings.Zone2.ToString();
            memoNote.Text = string.Empty;


            EditData();
            // var k = ShiftStartTime((int)rgShiftSelector.Properties.Items[rgShiftSelector.SelectedIndex].Value);

        }

        private void EditData()
        {
            if (edit)
            {
                dateEdit1.EditValue = row.CollectionDatetime;
                textEdit1.Text = row.Value.ToString();

                radioGroup1.EditValue = radioGroup1.Properties.Items[row.Fireplace].Value;

                textEdit2.Text = row.Zone1.ToString();
                textEdit3.Text = row.Zone2.ToString();
                memoNote.Text = row.memoNote;

            }

        }


        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

            if (!Decimal.TryParse(textEdit1.Text, out decimal result))
            {
                textEdit1.Text = "0";
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var result = new List<DataCollector.GasData>();
            try
            {


                DateTime dt = ((DateTime)(dateEdit1.EditValue)).Date;
                double gasCounter = Convert.ToDouble(textEdit1.Text);
                int fireplace = (int)(radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value);
                double zone1 = Convert.ToDouble(textEdit2.Text);
                double zone2 = Convert.ToDouble(textEdit3.Text);
                string mNote =  memoNote.Text.ToString();

                if (!edit)
                {
                    result = apc.CalculateUsage(dt, gasCounter, fireplace, zone1, zone2,mNote);
                    //result.Add(new DataCollector.GasData { CollectionDatetime = dt, Value = gasCounter, Fireplace = fireplace, Zone1 = zone1, Zone2 = zone2 });
                    apc.InsertGasUsage(result);
                    XtraMessageBox.Show("Stan licznika został zapisany");
                }
                else
                {
                    var data = new DataCollector.GasData();
                    data.CollectionDatetime = dt;
                    data.Value = gasCounter;
                    data.Fireplace = fireplace;
                    data.Zone1 = zone1;
                    data.Zone2 = zone2;
                    data.Id = row.Id;
                    data.memoNote = mNote;
                    apc.UpdateGasUsage(data);
                    XtraMessageBox.Show("Dane zostały zaktualizowane");

                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Nie udało się zapisać odczytu. " + ex.Message,
                    "BŁĄD", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}