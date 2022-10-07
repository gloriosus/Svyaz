namespace Svyaz {
   partial class LocalitiesViewCtrl {
      /// <summary> 
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalitiesViewCtrl));
         DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
         Svyaz.Model.DataRate dataRate1 = new Svyaz.Model.DataRate();
         this.bindingSrc = new System.Windows.Forms.BindingSource(this.components);
         this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
         this.bar1 = new DevExpress.XtraBars.Bar();
         this.barBtnLeft = new DevExpress.XtraBars.BarButtonItem();
         this.barBtnToExcel = new DevExpress.XtraBars.BarButtonItem();
         this.barBtnInternet = new DevExpress.XtraBars.BarButtonItem();
         this.barBtnRefresh = new DevExpress.XtraBars.BarButtonItem();
         this.barBtnWww = new DevExpress.XtraBars.BarButtonItem();
         this.barComboSrc = new DevExpress.XtraBars.BarEditItem();
         this.riComboSrc = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
         this.barComboView = new DevExpress.XtraBars.BarEditItem();
         this.riComboView = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
         this.bar3 = new DevExpress.XtraBars.Bar();
         this.progressBarItem = new DevExpress.XtraBars.BarEditItem();
         this.riProgressBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
         this.statusItem = new DevExpress.XtraBars.BarStaticItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
         this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
         this.columnSelectorCtrl = new Svyaz.ColumnSelectorCtrl();
         this.gridControl1 = new DevExpress.XtraGrid.GridControl();
         this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColBorrougf = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColSettlement = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColLocality = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColIsAdmCenter = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColPopulationCount = new DevExpress.XtraGrid.Columns.GridColumn();
         this.riPopupContainerEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
         this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
         this.dataRateEditor1 = new Svyaz.CustomEditors.DataRateEditor();
         this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSrc)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.riComboSrc)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.riComboView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.riProgressBar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.riPopupContainerEdit1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
         this.popupContainerControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
         this.splitContainerControl1.SuspendLayout();
         this.SuspendLayout();
         // 
         // barManager1
         // 
         this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
         this.barManager1.DockControls.Add(this.barDockControlTop);
         this.barManager1.DockControls.Add(this.barDockControlBottom);
         this.barManager1.DockControls.Add(this.barDockControlLeft);
         this.barManager1.DockControls.Add(this.barDockControlRight);
         this.barManager1.Form = this;
         this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnLeft,
            this.barBtnToExcel,
            this.barBtnInternet,
            this.progressBarItem,
            this.statusItem,
            this.barBtnRefresh,
            this.barBtnWww,
            this.barComboSrc,
            this.barComboView});
         this.barManager1.MaxItemId = 9;
         this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riProgressBar,
            this.repositoryItemProgressBar1,
            this.riComboSrc,
            this.riComboView});
         this.barManager1.StatusBar = this.bar3;
         // 
         // bar1
         // 
         this.bar1.BarName = "Tools";
         this.bar1.DockCol = 0;
         this.bar1.DockRow = 0;
         this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnLeft),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnToExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnInternet),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnWww),
            new DevExpress.XtraBars.LinkPersistInfo(this.barComboSrc, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barComboView, true)});
         this.bar1.Text = "Tools";
         // 
         // barBtnLeft
         // 
         this.barBtnLeft.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
         this.barBtnLeft.Caption = "Показать/скрыть панель";
         this.barBtnLeft.Down = true;
         this.barBtnLeft.Id = 0;
         this.barBtnLeft.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnLeft.ImageOptions.Image")));
         this.barBtnLeft.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnLeft.ImageOptions.LargeImage")));
         this.barBtnLeft.Name = "barBtnLeft";
         this.barBtnLeft.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnLeft_ItemClick);
         // 
         // barBtnToExcel
         // 
         this.barBtnToExcel.Caption = "Экспорт в Excel";
         this.barBtnToExcel.Id = 1;
         this.barBtnToExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnToExcel.ImageOptions.Image")));
         this.barBtnToExcel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnToExcel.ImageOptions.LargeImage")));
         this.barBtnToExcel.Name = "barBtnToExcel";
         this.barBtnToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnToExcel_ItemClick);
         // 
         // barBtnInternet
         // 
         this.barBtnInternet.Caption = "Загрузить из реестра Роскомнадзора";
         this.barBtnInternet.Id = 2;
         this.barBtnInternet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnInternet.ImageOptions.Image")));
         this.barBtnInternet.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnInternet.ImageOptions.LargeImage")));
         this.barBtnInternet.Name = "barBtnInternet";
         this.barBtnInternet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnInternet_ItemClick);
         // 
         // barBtnRefresh
         // 
         this.barBtnRefresh.Caption = "Перечитать данные об услугах связи";
         this.barBtnRefresh.Id = 5;
         this.barBtnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnRefresh.ImageOptions.Image")));
         this.barBtnRefresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnRefresh.ImageOptions.LargeImage")));
         this.barBtnRefresh.Name = "barBtnRefresh";
         this.barBtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnRefresh_ItemClick);
         // 
         // barBtnWww
         // 
         this.barBtnWww.Caption = "открыть страницу на сайте Роскомнадзора";
         this.barBtnWww.Id = 6;
         this.barBtnWww.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnWww.ImageOptions.Image")));
         this.barBtnWww.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnWww.ImageOptions.LargeImage")));
         this.barBtnWww.Name = "barBtnWww";
         this.barBtnWww.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnWww_ItemClick);
         // 
         // barComboSrc
         // 
         this.barComboSrc.Caption = "Источник данных";
         this.barComboSrc.Edit = this.riComboSrc;
         this.barComboSrc.Id = 7;
         this.barComboSrc.Name = "barComboSrc";
         this.barComboSrc.Size = new System.Drawing.Size(210, 0);
         this.barComboSrc.EditValueChanged += new System.EventHandler(this.barComboSrc_EditValueChanged);
         // 
         // riComboSrc
         // 
         this.riComboSrc.AutoHeight = false;
         this.riComboSrc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.riComboSrc.Items.AddRange(new object[] {
            "Открытые данные Роскомнадзора",
            "Данные поставщиков услуг"});
         this.riComboSrc.Name = "riComboSrc";
         // 
         // barComboView
         // 
         this.barComboView.Caption = "Форма представления сводных данных";
         this.barComboView.Edit = this.riComboView;
         this.barComboView.Id = 8;
         this.barComboView.Name = "barComboView";
         this.barComboView.Size = new System.Drawing.Size(153, 0);
         this.barComboView.EditValueChanged += new System.EventHandler(this.barComboView_EditValueChanged);
         // 
         // riComboView
         // 
         this.riComboView.AutoHeight = false;
         this.riComboView.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.riComboView.Items.AddRange(new object[] {
            "По операторам связи",
            "По юридическим лицам"});
         this.riComboView.Name = "riComboView";
         // 
         // bar3
         // 
         this.bar3.BarName = "Status bar";
         this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
         this.bar3.DockCol = 0;
         this.bar3.DockRow = 0;
         this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
         this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.progressBarItem, "", false, true, true, 256),
            new DevExpress.XtraBars.LinkPersistInfo(this.statusItem)});
         this.bar3.OptionsBar.AllowQuickCustomization = false;
         this.bar3.OptionsBar.DrawDragBorder = false;
         this.bar3.OptionsBar.UseWholeRow = true;
         this.bar3.Text = "Status bar";
         // 
         // progressBarItem
         // 
         this.progressBarItem.Caption = "Обновление данных с сайта Роскомнадзора";
         this.progressBarItem.Edit = this.riProgressBar;
         this.progressBarItem.Id = 3;
         this.progressBarItem.Name = "progressBarItem";
         // 
         // riProgressBar
         // 
         this.riProgressBar.Maximum = 112;
         this.riProgressBar.Name = "riProgressBar";
         // 
         // statusItem
         // 
         this.statusItem.Caption = "...";
         this.statusItem.Id = 4;
         this.statusItem.Name = "statusItem";
         this.statusItem.TextAlignment = System.Drawing.StringAlignment.Near;
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Manager = this.barManager1;
         this.barDockControlTop.Size = new System.Drawing.Size(940, 31);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 543);
         this.barDockControlBottom.Manager = this.barManager1;
         this.barDockControlBottom.Size = new System.Drawing.Size(940, 25);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
         this.barDockControlLeft.Manager = this.barManager1;
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 512);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(940, 31);
         this.barDockControlRight.Manager = this.barManager1;
         this.barDockControlRight.Size = new System.Drawing.Size(0, 512);
         // 
         // repositoryItemProgressBar1
         // 
         this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
         // 
         // backgroundWorker
         // 
         this.backgroundWorker.WorkerReportsProgress = true;
         this.backgroundWorker.WorkerSupportsCancellation = true;
         this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
         this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
         this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
         // 
         // columnSelectorCtrl
         // 
         this.columnSelectorCtrl.AllowDrop = true;
         this.columnSelectorCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.columnSelectorCtrl.Location = new System.Drawing.Point(0, 0);
         this.columnSelectorCtrl.Name = "columnSelectorCtrl";
         this.columnSelectorCtrl.Size = new System.Drawing.Size(299, 512);
         this.columnSelectorCtrl.TabIndex = 0;
         // 
         // gridControl1
         // 
         this.gridControl1.AllowDrop = true;
         this.gridControl1.DataSource = this.bindingSrc;
         this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         gridLevelNode1.RelationName = "PhoneOn";
         this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
         this.gridControl1.Location = new System.Drawing.Point(0, 0);
         this.gridControl1.MainView = this.gridView1;
         this.gridControl1.Name = "gridControl1";
         this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riPopupContainerEdit1});
         this.gridControl1.Size = new System.Drawing.Size(636, 512);
         this.gridControl1.TabIndex = 0;
         this.gridControl1.UseEmbeddedNavigator = true;
         this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
         this.gridControl1.ViewRegistered += new DevExpress.XtraGrid.ViewOperationEventHandler(this.gridControl1_ViewRegistered);
         this.gridControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.gridControl1_DragDrop);
         this.gridControl1.DragEnter += new System.Windows.Forms.DragEventHandler(this.gridControl1_DragEnter);
         this.gridControl1.DragOver += new System.Windows.Forms.DragEventHandler(this.gridControl1_DragOver);
         // 
         // gridView1
         // 
         this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
         this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
         this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
         this.gridView1.ColumnPanelRowHeight = 32;
         this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColBorrougf,
            this.gridColSettlement,
            this.gridColLocality,
            this.gridColIsAdmCenter,
            this.gridColPopulationCount});
         this.gridView1.GridControl = this.gridControl1;
         this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CurrentPopulationCount", null, "{0} чел.", "1"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "CurrentPopulationCount", null, "{0:#0.00} %", "2"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PhoneOn", null, "Да: {0}", "3")});
         this.gridView1.Name = "gridView1";
         this.gridView1.OptionsBehavior.Editable = false;
         this.gridView1.OptionsBehavior.ReadOnly = true;
         this.gridView1.OptionsView.ColumnAutoWidth = false;
         this.gridView1.OptionsView.ShowFooter = true;
         this.gridView1.BeforePrintRow += new DevExpress.XtraGrid.Views.Base.BeforePrintRowEventHandler(this.gridView1_BeforePrintRow);
         this.gridView1.MasterRowExpanding += new DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventHandler(this.gridView1_MasterRowExpanding);
         this.gridView1.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.gridView1_MasterRowExpanded);
         this.gridView1.MasterRowCollapsing += new DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventHandler(this.gridView1_MasterRowCollapsing);
         this.gridView1.MasterRowCollapsed += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.gridView1_MasterRowCollapsed);
         this.gridView1.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.gridView1_MasterRowGetChildList);
         this.gridView1.MasterRowGetRelationName += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.gridView1_MasterRowGetRelationName);
         this.gridView1.MasterRowGetRelationDisplayCaption += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.gridView1_MasterRowGetRelationDisplayCaption);
         this.gridView1.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(this.gridView1_MasterRowGetRelationCount);
         this.gridView1.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.gridView1_ColumnWidthChanged);
         this.gridView1.GridMenuItemClick += new DevExpress.XtraGrid.Views.Grid.GridMenuItemClickEventHandler(this.gridView1_GridMenuItemClick);
         this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
         this.gridView1.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridView1_CustomSummaryCalculate);
         this.gridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyUp);
         this.gridView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseUp);
         this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
         // 
         // gridColBorrougf
         // 
         this.gridColBorrougf.Caption = "Район";
         this.gridColBorrougf.FieldName = "Borrough";
         this.gridColBorrougf.Name = "gridColBorrougf";
         this.gridColBorrougf.Visible = true;
         this.gridColBorrougf.VisibleIndex = 0;
         this.gridColBorrougf.Width = 144;
         // 
         // gridColSettlement
         // 
         this.gridColSettlement.Caption = "Поселение";
         this.gridColSettlement.FieldName = "Settlement";
         this.gridColSettlement.Name = "gridColSettlement";
         this.gridColSettlement.Visible = true;
         this.gridColSettlement.VisibleIndex = 1;
         this.gridColSettlement.Width = 178;
         // 
         // gridColLocality
         // 
         this.gridColLocality.Caption = "Населенный пункт";
         this.gridColLocality.FieldName = "FullName";
         this.gridColLocality.Name = "gridColLocality";
         this.gridColLocality.Visible = true;
         this.gridColLocality.VisibleIndex = 2;
         this.gridColLocality.Width = 105;
         // 
         // gridColIsAdmCenter
         // 
         this.gridColIsAdmCenter.Caption = "Адм. центр";
         this.gridColIsAdmCenter.FieldName = "IsAdmCenter";
         this.gridColIsAdmCenter.Name = "gridColIsAdmCenter";
         this.gridColIsAdmCenter.Visible = true;
         this.gridColIsAdmCenter.VisibleIndex = 3;
         this.gridColIsAdmCenter.Width = 43;
         // 
         // gridColPopulationCount
         // 
         this.gridColPopulationCount.Caption = "Жителей";
         this.gridColPopulationCount.FieldName = "CurrentPopulationCount";
         this.gridColPopulationCount.Name = "gridColPopulationCount";
         this.gridColPopulationCount.Visible = true;
         this.gridColPopulationCount.VisibleIndex = 4;
         // 
         // riPopupContainerEdit1
         // 
         this.riPopupContainerEdit1.AutoHeight = false;
         this.riPopupContainerEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.riPopupContainerEdit1.Name = "riPopupContainerEdit1";
         this.riPopupContainerEdit1.PopupControl = this.popupContainerControl1;
         this.riPopupContainerEdit1.PopupFormMinSize = new System.Drawing.Size(117, 26);
         this.riPopupContainerEdit1.PopupFormSize = new System.Drawing.Size(119, 28);
         this.riPopupContainerEdit1.PopupSizeable = false;
         this.riPopupContainerEdit1.ShowPopupCloseButton = false;
         this.riPopupContainerEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.riPopupContainerEdit1_Closed);
         this.riPopupContainerEdit1.BeforePopup += new System.EventHandler(this.riPopupContainerEdit1_BeforePopup);
         // 
         // popupContainerControl1
         // 
         this.popupContainerControl1.Controls.Add(this.dataRateEditor1);
         this.popupContainerControl1.Location = new System.Drawing.Point(324, 112);
         this.popupContainerControl1.Margin = new System.Windows.Forms.Padding(1);
         this.popupContainerControl1.Name = "popupContainerControl1";
         this.popupContainerControl1.Size = new System.Drawing.Size(117, 26);
         this.popupContainerControl1.TabIndex = 1;
         // 
         // dataRateEditor1
         // 
         this.dataRateEditor1.Location = new System.Drawing.Point(3, 3);
         this.dataRateEditor1.Name = "dataRateEditor1";
         dataRate1.Rate = new decimal(new int[] {
            0,
            0,
            0,
            196608});
         dataRate1.Unit = Svyaz.ModernDataRateUnit.kbps;
         this.dataRateEditor1.Rate = dataRate1;
         this.dataRateEditor1.ReadOnly = false;
         this.dataRateEditor1.Size = new System.Drawing.Size(111, 21);
         this.dataRateEditor1.TabIndex = 0;
         // 
         // splitContainerControl1
         // 
         this.splitContainerControl1.CaptionLocation = DevExpress.Utils.Locations.Top;
         this.splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
         this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
         this.splitContainerControl1.Location = new System.Drawing.Point(0, 31);
         this.splitContainerControl1.Name = "splitContainerControl1";
         this.splitContainerControl1.Panel1.Controls.Add(this.popupContainerControl1);
         this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
         this.splitContainerControl1.Panel1.Text = "Panel1";
         this.splitContainerControl1.Panel2.Controls.Add(this.columnSelectorCtrl);
         this.splitContainerControl1.Panel2.ShowCaption = true;
         this.splitContainerControl1.Panel2.Text = "Panel2";
         this.splitContainerControl1.ShowCaption = true;
         this.splitContainerControl1.Size = new System.Drawing.Size(940, 512);
         this.splitContainerControl1.SplitterPosition = 299;
         this.splitContainerControl1.TabIndex = 5;
         this.splitContainerControl1.Text = "splitContainerControl1";
         // 
         // LocalitiesViewCtrl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.splitContainerControl1);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Name = "LocalitiesViewCtrl";
         this.Size = new System.Drawing.Size(940, 568);
         this.Load += new System.EventHandler(this.LocalitiesViewCtrl_Load);
         ((System.ComponentModel.ISupportInitialize)(this.bindingSrc)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.riComboSrc)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.riComboView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.riProgressBar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.riPopupContainerEdit1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
         this.popupContainerControl1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
         this.splitContainerControl1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.BindingSource bindingSrc;
      private DevExpress.XtraBars.BarManager barManager1;
      private DevExpress.XtraBars.Bar bar1;
      private DevExpress.XtraBars.Bar bar3;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.BarButtonItem barBtnLeft;
      private DevExpress.XtraBars.BarButtonItem barBtnToExcel;
      private DevExpress.XtraBars.BarButtonItem barBtnInternet;
      private DevExpress.XtraBars.BarEditItem progressBarItem;
      private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar riProgressBar;
      private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
      private System.ComponentModel.BackgroundWorker backgroundWorker;
      private DevExpress.XtraBars.BarStaticItem statusItem;
      private DevExpress.XtraBars.BarButtonItem barBtnRefresh;
      private DevExpress.XtraBars.BarButtonItem barBtnWww;
      private DevExpress.XtraBars.BarEditItem barComboSrc;
      private DevExpress.XtraEditors.Repository.RepositoryItemComboBox riComboSrc;
      private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
      private DevExpress.XtraGrid.GridControl gridControl1;
      private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColBorrougf;
      private DevExpress.XtraGrid.Columns.GridColumn gridColSettlement;
      private DevExpress.XtraGrid.Columns.GridColumn gridColLocality;
      private DevExpress.XtraGrid.Columns.GridColumn gridColPopulationCount;
      private ColumnSelectorCtrl columnSelectorCtrl;
      private DevExpress.XtraBars.BarEditItem barComboView;
      private DevExpress.XtraEditors.Repository.RepositoryItemComboBox riComboView;
      private DevExpress.XtraGrid.Columns.GridColumn gridColIsAdmCenter;
      private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
      private CustomEditors.DataRateEditor dataRateEditor1;
      private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit riPopupContainerEdit1;
   }
}
