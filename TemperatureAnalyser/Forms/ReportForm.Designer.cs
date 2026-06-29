namespace TemperatureAnalyser.Forms
{
    partial class ReportForm
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
            DevExpress.XtraEditors.RangeControlRange rangeControlRange1 = new DevExpress.XtraEditors.RangeControlRange();
            this.rangeControl1 = new DevExpress.XtraEditors.RangeControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.dateTimeChartRangeControlClient1 = new DevExpress.XtraEditors.DateTimeChartRangeControlClient();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.rangeControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeChartRangeControlClient1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rangeControl1
            // 
            this.rangeControl1.Client = this.chartControl1;
            this.rangeControl1.Location = new System.Drawing.Point(18, 16);
            this.rangeControl1.Name = "rangeControl1";
            rangeControlRange1.Maximum = new System.DateTime(2022, 3, 10, 0, 0, 0, 0);
            rangeControlRange1.Minimum = new System.DateTime(2022, 3, 1, 0, 0, 0, 0);
            rangeControlRange1.Owner = this.rangeControl1;
            this.rangeControl1.SelectedRange = rangeControlRange1;
            this.rangeControl1.SelectionType = DevExpress.XtraEditors.RangeControlSelectionType.ThumbAndFlag;
            this.rangeControl1.Size = new System.Drawing.Size(844, 85);
            this.rangeControl1.TabIndex = 0;
            this.rangeControl1.Text = "rangeControl1";
            // 
            // chartControl1
            // 
            this.chartControl1.Location = new System.Drawing.Point(18, 3);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl1.Size = new System.Drawing.Size(844, 393);
            this.chartControl1.TabIndex = 1;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(12, 12);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.chartControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.rangeControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(995, 582);
            this.splitContainerControl1.SplitterPosition = 444;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 649);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ReportForm";
            this.Text = "Wykres temperatury i zużycia gazu";
            this.MaximumSizeChanged += new System.EventHandler(this.ReportForm_MaximumSizeChanged);
            this.MinimumSizeChanged += new System.EventHandler(this.ReportForm_MinimumSizeChanged);
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.ResizeEnd += new System.EventHandler(this.ReportForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.ReportForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.rangeControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeChartRangeControlClient1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.DateTimeChartRangeControlClient dateTimeChartRangeControlClient1;
        private DevExpress.XtraEditors.RangeControl rangeControl1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}