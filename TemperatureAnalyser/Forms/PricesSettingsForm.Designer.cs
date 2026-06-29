namespace TemperatureAnalyser.Forms
{
    partial class PricesSettingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PricesSettingsForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnRefreshPrices = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddPrices = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.dtPriceDate = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dgwPrices = new DevExpress.XtraGrid.GridControl();
            this.dgwPricesView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c1Key = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c1Value = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c1Month = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c1Year = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPricesView)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnRefreshPrices,
            this.btnAddPrices,
            this.barButtonItem1,
            this.dtPriceDate,
            this.btnClose});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.ribbon.Size = new System.Drawing.Size(704, 158);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnRefreshPrices
            // 
            this.btnRefreshPrices.Caption = "Wczytaj ceny";
            this.btnRefreshPrices.Id = 1;
            this.btnRefreshPrices.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefreshPrices.ImageOptions.SvgImage")));
            this.btnRefreshPrices.Name = "btnRefreshPrices";
            this.btnRefreshPrices.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefreshPrices_ItemClick);
            // 
            // btnAddPrices
            // 
            this.btnAddPrices.Caption = "Dodaj nowe ceny";
            this.btnAddPrices.Id = 2;
            this.btnAddPrices.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddPrices.ImageOptions.SvgImage")));
            this.btnAddPrices.Name = "btnAddPrices";
            this.btnAddPrices.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddPrices_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // dtPriceDate
            // 
            this.dtPriceDate.Edit = this.repositoryItemDateEdit1;
            this.dtPriceDate.EditHeight = 30;
            this.dtPriceDate.EditWidth = 140;
            this.dtPriceDate.Id = 4;
            this.dtPriceDate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("dtPriceDate.ImageOptions.SvgImage")));
            this.dtPriceDate.Name = "dtPriceDate";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Zamknij";
            this.btnClose.Id = 5;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefreshPrices);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAddPrices);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.dtPriceDate);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 496);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(704, 24);
            // 
            // dgwPrices
            // 
            this.dgwPrices.Location = new System.Drawing.Point(13, 165);
            this.dgwPrices.MainView = this.dgwPricesView;
            this.dgwPrices.MenuManager = this.ribbon;
            this.dgwPrices.Name = "dgwPrices";
            this.dgwPrices.Size = new System.Drawing.Size(648, 311);
            this.dgwPrices.TabIndex = 2;
            this.dgwPrices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgwPricesView});
            // 
            // dgwPricesView
            // 
            this.dgwPricesView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c1Key,
            this.c1Value,
            this.c1Month,
            this.c1Year});
            this.dgwPricesView.GridControl = this.dgwPrices;
            this.dgwPricesView.Name = "dgwPricesView";
            this.dgwPricesView.OptionsSelection.MultiSelect = true;
            // 
            // c1Key
            // 
            this.c1Key.Caption = "Opis";
            this.c1Key.FieldName = "key";
            this.c1Key.Name = "c1Key";
            this.c1Key.OptionsColumn.AllowEdit = false;
            this.c1Key.Visible = true;
            this.c1Key.VisibleIndex = 0;
            // 
            // c1Value
            // 
            this.c1Value.Caption = "Wartość";
            this.c1Value.FieldName = "value";
            this.c1Value.Name = "c1Value";
            this.c1Value.Visible = true;
            this.c1Value.VisibleIndex = 1;
            // 
            // c1Month
            // 
            this.c1Month.Caption = "Miesiąc";
            this.c1Month.FieldName = "month";
            this.c1Month.Name = "c1Month";
            this.c1Month.OptionsColumn.AllowEdit = false;
            this.c1Month.Visible = true;
            this.c1Month.VisibleIndex = 2;
            // 
            // c1Year
            // 
            this.c1Year.Caption = "Rok";
            this.c1Year.FieldName = "year";
            this.c1Year.Name = "c1Year";
            this.c1Year.OptionsColumn.AllowEdit = false;
            this.c1Year.Visible = true;
            this.c1Year.VisibleIndex = 3;
            // 
            // PricesSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 520);
            this.Controls.Add(this.dgwPrices);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "PricesSettingsForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "PricesSettingsForm";
            this.Load += new System.EventHandler(this.PricesSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPricesView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnRefreshPrices;
        private DevExpress.XtraBars.BarButtonItem btnAddPrices;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarEditItem dtPriceDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraGrid.GridControl dgwPrices;
        private DevExpress.XtraGrid.Views.Grid.GridView dgwPricesView;
        private DevExpress.XtraGrid.Columns.GridColumn c1Key;
        private DevExpress.XtraGrid.Columns.GridColumn c1Value;
        private DevExpress.XtraGrid.Columns.GridColumn c1Month;
        private DevExpress.XtraGrid.Columns.GridColumn c1Year;
        private DevExpress.Utils.ToolTipController toolTipController1;
    }
}