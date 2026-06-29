namespace TemperatureAnalyser.Forms
{
    partial class VirtualGasCollectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VirtualGasCollectionForm));
            this.btnSaveButton = new DevExpress.XtraEditors.SimpleButton();
            this.tbRealCounter = new DevExpress.XtraEditors.TextEdit();
            this.tbVirtualCounter = new DevExpress.XtraEditors.TextEdit();
            this.dtCollectionDateTime = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbRealCounter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVirtualCounter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveButton
            // 
            this.btnSaveButton.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaveButton.ImageOptions.SvgImage")));
            this.btnSaveButton.Location = new System.Drawing.Point(12, 130);
            this.btnSaveButton.Name = "btnSaveButton";
            this.btnSaveButton.Size = new System.Drawing.Size(146, 50);
            this.btnSaveButton.TabIndex = 0;
            this.btnSaveButton.Text = "Zapisz";
            this.btnSaveButton.Click += new System.EventHandler(this.btnSaveButton_Click);
            // 
            // tbRealCounter
            // 
            this.tbRealCounter.Location = new System.Drawing.Point(12, 54);
            this.tbRealCounter.Name = "tbRealCounter";
            this.tbRealCounter.Size = new System.Drawing.Size(100, 20);
            this.tbRealCounter.TabIndex = 1;
            // 
            // tbVirtualCounter
            // 
            this.tbVirtualCounter.Location = new System.Drawing.Point(12, 95);
            this.tbVirtualCounter.Name = "tbVirtualCounter";
            this.tbVirtualCounter.Size = new System.Drawing.Size(100, 20);
            this.tbVirtualCounter.TabIndex = 2;
            // 
            // dtCollectionDateTime
            // 
            this.dtCollectionDateTime.EditValue = null;
            this.dtCollectionDateTime.Location = new System.Drawing.Point(12, 13);
            this.dtCollectionDateTime.Name = "dtCollectionDateTime";
            this.dtCollectionDateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCollectionDateTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCollectionDateTime.Size = new System.Drawing.Size(100, 20);
            this.dtCollectionDateTime.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(99, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Wartość rzeczywista";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 80);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(79, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Wartość podana";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnCancel.Location = new System.Drawing.Point(164, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 50);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // VirtualGasCollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 200);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dtCollectionDateTime);
            this.Controls.Add(this.tbVirtualCounter);
            this.Controls.Add(this.tbRealCounter);
            this.Controls.Add(this.btnSaveButton);
            this.MaximumSize = new System.Drawing.Size(325, 232);
            this.MinimumSize = new System.Drawing.Size(325, 232);
            this.Name = "VirtualGasCollectionForm";
            this.Text = "Rejestracja";
            this.Load += new System.EventHandler(this.VirtualGasCollectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbRealCounter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVirtualCounter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSaveButton;
        private DevExpress.XtraEditors.TextEdit tbRealCounter;
        private DevExpress.XtraEditors.TextEdit tbVirtualCounter;
        private DevExpress.XtraEditors.DateEdit dtCollectionDateTime;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}