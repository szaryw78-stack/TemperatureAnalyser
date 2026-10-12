namespace TemperatureAnalyser
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer dockingContainer1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer();
            DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer dockingContainer2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer();
            this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.document3 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.document2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.document4 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.documentGroup2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnGetTemperatures = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnLoadData = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddGasCounter = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnPricesSettings = new DevExpress.XtraBars.BarButtonItem();
            this.btnReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditData = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddVirtualGasCollection = new DevExpress.XtraBars.BarButtonItem();
            this.dtFrom = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.dtTo = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dgwAvarageTemperatures = new DevExpress.XtraGrid.GridControl();
            this.dgwAvarageTemperaturesView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c1CollectionDatetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c1Temperature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c1GasUsage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c1Fireplace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c1Month = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c1Year = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c1Zone1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c1Zone2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c1Automatic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c1MemoNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dgwSourceData = new DevExpress.XtraGrid.GridControl();
            this.dgwSourceDataView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c2DateAndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c2Temperature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dockPanel3 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dgwCosts = new DevExpress.XtraGrid.GridControl();
            this.dgwCostsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c3Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c3Value = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dpBalance = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel4_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dgwBalance = new DevExpress.XtraGrid.GridControl();
            this.dgwBalanceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c4CreatedDatetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c4RealCounter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c4VirtualCounter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c4Difference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.xtraOpenFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAvarageTemperatures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAvarageTemperaturesView)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSourceData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSourceDataView)).BeginInit();
            this.dockPanel3.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwCosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwCostsView)).BeginInit();
            this.dpBalance.SuspendLayout();
            this.dockPanel4_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwBalanceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // documentGroup1
            // 
            this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.document3,
            this.document2,
            this.document4});
            // 
            // document3
            // 
            this.document3.Caption = "Średnie zuzycie gazu oraz temperatura dzienna";
            this.document3.ControlName = "dockPanel1";
            this.document3.FloatLocation = new System.Drawing.Point(44, 290);
            this.document3.FloatSize = new System.Drawing.Size(200, 200);
            this.document3.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document3.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document3.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document2
            // 
            this.document2.Caption = "Dane źródłowe";
            this.document2.ControlName = "dockPanel2";
            this.document2.FloatLocation = new System.Drawing.Point(635, 230);
            this.document2.FloatSize = new System.Drawing.Size(200, 200);
            this.document2.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document2.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document2.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document4
            // 
            this.document4.Caption = "Bilans";
            this.document4.ControlName = "dpBalance";
            this.document4.FloatLocation = new System.Drawing.Point(471, 267);
            this.document4.FloatSize = new System.Drawing.Size(200, 200);
            this.document4.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document4.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document4.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // documentGroup2
            // 
            this.documentGroup2.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.document1});
            // 
            // document1
            // 
            this.document1.Caption = "Podsumowanie";
            this.document1.ControlName = "dockPanel3";
            this.document1.FloatLocation = new System.Drawing.Point(704, 531);
            this.document1.FloatSize = new System.Drawing.Size(200, 200);
            this.document1.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnGetTemperatures,
            this.barButtonItem1,
            this.btnLoadData,
            this.btnAddGasCounter,
            this.btnClose,
            this.btnPricesSettings,
            this.btnReport,
            this.btnEditData,
            this.btnAddVirtualGasCollection,
            this.dtFrom,
            this.dtTo});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 12;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2});
            this.ribbonControl1.Size = new System.Drawing.Size(1347, 158);
            // 
            // btnGetTemperatures
            // 
            this.btnGetTemperatures.Caption = "Import temperatur";
            this.btnGetTemperatures.Id = 1;
            this.btnGetTemperatures.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGetTemperatures.ImageOptions.SvgImage")));
            this.btnGetTemperatures.Name = "btnGetTemperatures";
            this.btnGetTemperatures.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGetTemperatures_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "TEST";
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Caption = "Wczytaj dane";
            this.btnLoadData.Id = 3;
            this.btnLoadData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLoadData.ImageOptions.SvgImage")));
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoadData_ItemClick);
            // 
            // btnAddGasCounter
            // 
            this.btnAddGasCounter.Caption = "Dodaj stan licznika";
            this.btnAddGasCounter.Id = 4;
            this.btnAddGasCounter.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddGasCounter.ImageOptions.SvgImage")));
            this.btnAddGasCounter.Name = "btnAddGasCounter";
            this.btnAddGasCounter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddGasCounter_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Zamknij";
            this.btnClose.Id = 5;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // btnPricesSettings
            // 
            this.btnPricesSettings.Caption = "Ceny";
            this.btnPricesSettings.Id = 6;
            this.btnPricesSettings.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPricesSettings.ImageOptions.SvgImage")));
            this.btnPricesSettings.Name = "btnPricesSettings";
            this.btnPricesSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPricesSettings_ItemClick);
            // 
            // btnReport
            // 
            this.btnReport.Caption = "Raport";
            this.btnReport.Id = 7;
            this.btnReport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnReport.ImageOptions.SvgImage")));
            this.btnReport.Name = "btnReport";
            this.btnReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReport_ItemClick);
            // 
            // btnEditData
            // 
            this.btnEditData.Caption = "Edycja";
            this.btnEditData.Id = 8;
            this.btnEditData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEditData.ImageOptions.SvgImage")));
            this.btnEditData.Name = "btnEditData";
            this.btnEditData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditData_ItemClick);
            // 
            // btnAddVirtualGasCollection
            // 
            this.btnAddVirtualGasCollection.Caption = "Virtual gas collection";
            this.btnAddVirtualGasCollection.Id = 9;
            this.btnAddVirtualGasCollection.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddVirtualGasCollection.ImageOptions.SvgImage")));
            this.btnAddVirtualGasCollection.Name = "btnAddVirtualGasCollection";
            this.btnAddVirtualGasCollection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddVirtualGasCollection_ItemClick);
            // 
            // dtFrom
            // 
            this.dtFrom.Edit = this.repositoryItemDateEdit1;
            this.dtFrom.EditHeight = 30;
            this.dtFrom.EditWidth = 130;
            this.dtFrom.Id = 10;
            this.dtFrom.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("dtFrom.ImageOptions.SvgImage")));
            this.dtFrom.Name = "dtFrom";
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
            // dtTo
            // 
            this.dtTo.Edit = this.repositoryItemDateEdit2;
            this.dtTo.EditHeight = 30;
            this.dtTo.EditWidth = 130;
            this.dtTo.Id = 11;
            this.dtTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("dtTo.ImageOptions.SvgImage")));
            this.dtTo.Name = "dtTo";
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Ogólne";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLoadData);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAddGasCounter);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEditData);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnGetTemperatures);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPricesSettings);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAddVirtualGasCollection);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Ogólne";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.dtFrom);
            this.ribbonPageGroup2.ItemLinks.Add(this.dtTo);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnReport);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Raport";
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dockPanel2,
            this.dockPanel3,
            this.dpBalance});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.DockedAsTabbedDocument = true;
            this.dockPanel1.FloatLocation = new System.Drawing.Point(44, 290);
            this.dockPanel1.ID = new System.Guid("2ec78aff-5789-4a82-bcb6-ca869b186724");
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(463, 200);
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.SavedMdiDocument = true;
            this.dockPanel1.SavedMdiDocumentIndex = 2;
            this.dockPanel1.Text = "Średnie zuzycie gazu oraz temperatura dzienna";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.dgwAvarageTemperatures);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(912, 645);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dgwAvarageTemperatures
            // 
            this.dgwAvarageTemperatures.Location = new System.Drawing.Point(9, 4);
            this.dgwAvarageTemperatures.MainView = this.dgwAvarageTemperaturesView;
            this.dgwAvarageTemperatures.MenuManager = this.ribbonControl1;
            this.dgwAvarageTemperatures.Name = "dgwAvarageTemperatures";
            this.dgwAvarageTemperatures.Size = new System.Drawing.Size(887, 616);
            this.dgwAvarageTemperatures.TabIndex = 0;
            this.dgwAvarageTemperatures.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgwAvarageTemperaturesView});
            // 
            // dgwAvarageTemperaturesView
            // 
            this.dgwAvarageTemperaturesView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c1CollectionDatetime,
            this.c1Temperature,
            this.c1GasUsage,
            this.c1Fireplace,
            this.c1Month,
            this.c1Year,
            this.c1Zone1,
            this.c1Zone2,
            this.c1Automatic,
            this.c1MemoNote});
            this.dgwAvarageTemperaturesView.GridControl = this.dgwAvarageTemperatures;
            this.dgwAvarageTemperaturesView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "AvarageDailyTemperature", null, "Średnia temperatura={0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "Usage", null, "Średnie zużycie gazu={0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Usage", null, "Suma zużycia gazu={0:n2}")});
            this.dgwAvarageTemperaturesView.Name = "dgwAvarageTemperaturesView";
            this.dgwAvarageTemperaturesView.OptionsBehavior.Editable = false;
            // 
            // c1CollectionDatetime
            // 
            this.c1CollectionDatetime.Caption = "Data";
            this.c1CollectionDatetime.FieldName = "CollectionDatetime";
            this.c1CollectionDatetime.Name = "c1CollectionDatetime";
            this.c1CollectionDatetime.Visible = true;
            this.c1CollectionDatetime.VisibleIndex = 0;
            // 
            // c1Temperature
            // 
            this.c1Temperature.Caption = "Średnia temperatura";
            this.c1Temperature.DisplayFormat.FormatString = "n2";
            this.c1Temperature.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.c1Temperature.FieldName = "AvarageDailyTemperature";
            this.c1Temperature.Name = "c1Temperature";
            this.c1Temperature.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "AvarageDailyTemperature", "Średnia temperatura={0:n2}")});
            this.c1Temperature.Visible = true;
            this.c1Temperature.VisibleIndex = 1;
            // 
            // c1GasUsage
            // 
            this.c1GasUsage.Caption = "Zużycie gazu";
            this.c1GasUsage.FieldName = "Usage";
            this.c1GasUsage.Name = "c1GasUsage";
            this.c1GasUsage.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "Usage", "Śrenie zużycie gazu={0:0.##}")});
            this.c1GasUsage.Visible = true;
            this.c1GasUsage.VisibleIndex = 2;
            // 
            // c1Fireplace
            // 
            this.c1Fireplace.Caption = "Kominek";
            this.c1Fireplace.FieldName = "Fireplace";
            this.c1Fireplace.Name = "c1Fireplace";
            this.c1Fireplace.Visible = true;
            this.c1Fireplace.VisibleIndex = 3;
            // 
            // c1Month
            // 
            this.c1Month.Caption = "Miesiąc";
            this.c1Month.FieldName = "Month";
            this.c1Month.Name = "c1Month";
            this.c1Month.Visible = true;
            this.c1Month.VisibleIndex = 6;
            // 
            // c1Year
            // 
            this.c1Year.Caption = "Rok";
            this.c1Year.FieldName = "Year";
            this.c1Year.Name = "c1Year";
            this.c1Year.Visible = true;
            this.c1Year.VisibleIndex = 7;
            // 
            // c1Zone1
            // 
            this.c1Zone1.Caption = "Podłogówka";
            this.c1Zone1.FieldName = "Zone1";
            this.c1Zone1.Name = "c1Zone1";
            this.c1Zone1.Visible = true;
            this.c1Zone1.VisibleIndex = 4;
            // 
            // c1Zone2
            // 
            this.c1Zone2.Caption = "Grzejniki";
            this.c1Zone2.FieldName = "Zone2";
            this.c1Zone2.Name = "c1Zone2";
            this.c1Zone2.Visible = true;
            this.c1Zone2.VisibleIndex = 5;
            // 
            // c1Automatic
            // 
            this.c1Automatic.Caption = "Automatyczna kalkulacja zuzycia";
            this.c1Automatic.FieldName = "automatic";
            this.c1Automatic.Name = "c1Automatic";
            this.c1Automatic.Visible = true;
            this.c1Automatic.VisibleIndex = 8;
            // 
            // c1MemoNote
            // 
            this.c1MemoNote.Caption = "Notatka";
            this.c1MemoNote.FieldName = "memoNote";
            this.c1MemoNote.Name = "c1MemoNote";
            this.c1MemoNote.Visible = true;
            this.c1MemoNote.VisibleIndex = 9;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.DockedAsTabbedDocument = true;
            this.dockPanel2.FloatLocation = new System.Drawing.Point(635, 230);
            this.dockPanel2.FloatVertical = true;
            this.dockPanel2.ID = new System.Guid("c24a4650-bafa-413f-894e-5795718a7d11");
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 282);
            this.dockPanel2.Text = "Dane źródłowe";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.dgwSourceData);
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(912, 645);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // dgwSourceData
            // 
            this.dgwSourceData.Location = new System.Drawing.Point(4, 4);
            this.dgwSourceData.MainView = this.dgwSourceDataView;
            this.dgwSourceData.MenuManager = this.ribbonControl1;
            this.dgwSourceData.Name = "dgwSourceData";
            this.dgwSourceData.Size = new System.Drawing.Size(1294, 506);
            this.dgwSourceData.TabIndex = 0;
            this.dgwSourceData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgwSourceDataView});
            // 
            // dgwSourceDataView
            // 
            this.dgwSourceDataView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c2DateAndTime,
            this.c2Temperature});
            this.dgwSourceDataView.GridControl = this.dgwSourceData;
            this.dgwSourceDataView.Name = "dgwSourceDataView";
            this.dgwSourceDataView.OptionsBehavior.Editable = false;
            // 
            // c2DateAndTime
            // 
            this.c2DateAndTime.Caption = "Data rejestracji";
            this.c2DateAndTime.DisplayFormat.FormatString = "g";
            this.c2DateAndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.c2DateAndTime.FieldName = "DateAndTime";
            this.c2DateAndTime.Name = "c2DateAndTime";
            this.c2DateAndTime.Visible = true;
            this.c2DateAndTime.VisibleIndex = 0;
            // 
            // c2Temperature
            // 
            this.c2Temperature.Caption = "Temperatura";
            this.c2Temperature.DisplayFormat.FormatString = "n2";
            this.c2Temperature.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.c2Temperature.FieldName = "Temperature";
            this.c2Temperature.Name = "c2Temperature";
            this.c2Temperature.Visible = true;
            this.c2Temperature.VisibleIndex = 1;
            // 
            // dockPanel3
            // 
            this.dockPanel3.Controls.Add(this.dockPanel3_Container);
            this.dockPanel3.DockedAsTabbedDocument = true;
            this.dockPanel3.FloatLocation = new System.Drawing.Point(704, 531);
            this.dockPanel3.ID = new System.Guid("8b34afd1-9467-45ac-8c35-0e1967f76bc8");
            this.dockPanel3.Name = "dockPanel3";
            this.dockPanel3.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel3.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel3.SavedIndex = 2;
            this.dockPanel3.Text = "Podsumowanie";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.dgwCosts);
            this.dockPanel3_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(417, 645);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // dgwCosts
            // 
            this.dgwCosts.Location = new System.Drawing.Point(4, 30);
            this.dgwCosts.MainView = this.dgwCostsView;
            this.dgwCosts.MenuManager = this.ribbonControl1;
            this.dgwCosts.Name = "dgwCosts";
            this.dgwCosts.Size = new System.Drawing.Size(400, 606);
            this.dgwCosts.TabIndex = 0;
            this.dgwCosts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgwCostsView});
            // 
            // dgwCostsView
            // 
            this.dgwCostsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c3Description,
            this.c3Value});
            this.dgwCostsView.GridControl = this.dgwCosts;
            this.dgwCostsView.Name = "dgwCostsView";
            this.dgwCostsView.OptionsBehavior.Editable = false;
            this.dgwCostsView.OptionsView.ShowGroupPanel = false;
            // 
            // c3Description
            // 
            this.c3Description.Caption = "Opis";
            this.c3Description.FieldName = "description";
            this.c3Description.Name = "c3Description";
            this.c3Description.Visible = true;
            this.c3Description.VisibleIndex = 0;
            // 
            // c3Value
            // 
            this.c3Value.Caption = "Wartość";
            this.c3Value.DisplayFormat.FormatString = "n2";
            this.c3Value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.c3Value.FieldName = "value";
            this.c3Value.Name = "c3Value";
            this.c3Value.Visible = true;
            this.c3Value.VisibleIndex = 1;
            // 
            // dpBalance
            // 
            this.dpBalance.Controls.Add(this.dockPanel4_Container);
            this.dpBalance.DockedAsTabbedDocument = true;
            this.dpBalance.FloatLocation = new System.Drawing.Point(471, 267);
            this.dpBalance.ID = new System.Guid("0f5f6af0-ace9-40a7-9c64-6a25f57d624c");
            this.dpBalance.Name = "dpBalance";
            this.dpBalance.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpBalance.SavedIndex = 3;
            this.dpBalance.SavedMdiDocument = true;
            this.dpBalance.SavedMdiDocumentIndex = 2;
            this.dpBalance.Text = "Bilans";
            // 
            // dockPanel4_Container
            // 
            this.dockPanel4_Container.Controls.Add(this.dgwBalance);
            this.dockPanel4_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel4_Container.Name = "dockPanel4_Container";
            this.dockPanel4_Container.Size = new System.Drawing.Size(912, 645);
            this.dockPanel4_Container.TabIndex = 0;
            // 
            // dgwBalance
            // 
            this.dgwBalance.Location = new System.Drawing.Point(3, 16);
            this.dgwBalance.MainView = this.dgwBalanceView;
            this.dgwBalance.MenuManager = this.ribbonControl1;
            this.dgwBalance.Name = "dgwBalance";
            this.dgwBalance.Size = new System.Drawing.Size(899, 420);
            this.dgwBalance.TabIndex = 0;
            this.dgwBalance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgwBalanceView});
            // 
            // dgwBalanceView
            // 
            this.dgwBalanceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c4CreatedDatetime,
            this.c4RealCounter,
            this.c4VirtualCounter,
            this.c4Difference});
            this.dgwBalanceView.GridControl = this.dgwBalance;
            this.dgwBalanceView.Name = "dgwBalanceView";
            this.dgwBalanceView.OptionsBehavior.Editable = false;
            this.dgwBalanceView.OptionsView.ShowFooter = true;
            // 
            // c4CreatedDatetime
            // 
            this.c4CreatedDatetime.Caption = "Data odczytu";
            this.c4CreatedDatetime.FieldName = "createdDatetime";
            this.c4CreatedDatetime.Name = "c4CreatedDatetime";
            this.c4CreatedDatetime.Visible = true;
            this.c4CreatedDatetime.VisibleIndex = 0;
            // 
            // c4RealCounter
            // 
            this.c4RealCounter.Caption = "Odczyt rzeczywisty";
            this.c4RealCounter.DisplayFormat.FormatString = "n2";
            this.c4RealCounter.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.c4RealCounter.FieldName = "realcounter";
            this.c4RealCounter.Name = "c4RealCounter";
            this.c4RealCounter.Visible = true;
            this.c4RealCounter.VisibleIndex = 1;
            // 
            // c4VirtualCounter
            // 
            this.c4VirtualCounter.Caption = "Odczyt zarejestrowany";
            this.c4VirtualCounter.DisplayFormat.FormatString = "n2";
            this.c4VirtualCounter.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.c4VirtualCounter.FieldName = "virtualcounter";
            this.c4VirtualCounter.Name = "c4VirtualCounter";
            this.c4VirtualCounter.Visible = true;
            this.c4VirtualCounter.VisibleIndex = 2;
            // 
            // c4Difference
            // 
            this.c4Difference.Caption = "Różnica";
            this.c4Difference.DisplayFormat.FormatString = "n2";
            this.c4Difference.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.c4Difference.FieldName = "difference";
            this.c4Difference.Name = "c4Difference";
            this.c4Difference.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "difference", "SUM={0:0.##}")});
            this.c4Difference.Visible = true;
            this.c4Difference.VisibleIndex = 3;
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] {
            this.documentGroup1,
            this.documentGroup2});
            this.tabbedView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.document2,
            this.document3,
            this.document1,
            this.document4});
            dockingContainer1.Element = this.documentGroup1;
            dockingContainer1.Length.UnitValue = 1.3705926481620405D;
            dockingContainer2.Element = this.documentGroup2;
            dockingContainer2.Length.UnitValue = 0.62940735183795948D;
            this.tabbedView1.RootContainer.Nodes.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer[] {
            dockingContainer1,
            dockingContainer2});
            // 
            // xtraOpenFileDialog1
            // 
            this.xtraOpenFileDialog1.FileName = "xtraOpenFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 832);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Form1.IconOptions.SvgImage")));
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Rejestracja temperatury oraz stanu licznika gazu";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwAvarageTemperatures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAvarageTemperaturesView)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwSourceData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSourceDataView)).EndInit();
            this.dockPanel3.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwCosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwCostsView)).EndInit();
            this.dpBalance.ResumeLayout(false);
            this.dockPanel4_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwBalanceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraGrid.GridControl dgwSourceData;
        private DevExpress.XtraGrid.Views.Grid.GridView dgwSourceDataView;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl dgwAvarageTemperatures;
        private DevExpress.XtraGrid.Views.Grid.GridView dgwAvarageTemperaturesView;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraBars.BarButtonItem btnGetTemperatures;
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog1;
        private DevExpress.XtraGrid.Columns.GridColumn c1CollectionDatetime;
        private DevExpress.XtraGrid.Columns.GridColumn c1Temperature;
        private DevExpress.XtraGrid.Columns.GridColumn c2DateAndTime;
        private DevExpress.XtraGrid.Columns.GridColumn c2Temperature;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnLoadData;
        private DevExpress.XtraGrid.Columns.GridColumn c1GasUsage;
        private DevExpress.XtraGrid.Columns.GridColumn c1Fireplace;
        private DevExpress.XtraBars.BarButtonItem btnAddGasCounter;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document3;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document2;
        private DevExpress.XtraGrid.Columns.GridColumn c1Month;
        private DevExpress.XtraGrid.Columns.GridColumn c1Year;
        private DevExpress.XtraGrid.Columns.GridColumn c1Zone1;
        private DevExpress.XtraGrid.Columns.GridColumn c1Zone2;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel3;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup2;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
        private DevExpress.XtraGrid.GridControl dgwCosts;
        private DevExpress.XtraGrid.Views.Grid.GridView dgwCostsView;
        private DevExpress.XtraGrid.Columns.GridColumn c3Description;
        private DevExpress.XtraGrid.Columns.GridColumn c3Value;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarButtonItem btnPricesSettings;
        private DevExpress.XtraBars.BarButtonItem btnReport;
        private DevExpress.XtraBars.BarButtonItem btnEditData;
        private DevExpress.XtraGrid.Columns.GridColumn c1Automatic;
        private DevExpress.XtraBars.BarButtonItem btnAddVirtualGasCollection;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document4;
        private DevExpress.XtraBars.Docking.DockPanel dpBalance;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel4_Container;
        private DevExpress.XtraGrid.GridControl dgwBalance;
        private DevExpress.XtraGrid.Views.Grid.GridView dgwBalanceView;
        private DevExpress.XtraGrid.Columns.GridColumn c4CreatedDatetime;
        private DevExpress.XtraGrid.Columns.GridColumn c4RealCounter;
        private DevExpress.XtraGrid.Columns.GridColumn c4VirtualCounter;
        private DevExpress.XtraGrid.Columns.GridColumn c4Difference;
        private DevExpress.XtraGrid.Columns.GridColumn c1MemoNote;
        private DevExpress.XtraBars.BarEditItem dtFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem dtTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}
