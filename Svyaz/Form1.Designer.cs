namespace Svyaz {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.tabFormControl1 = new DevExpress.XtraBars.TabFormControl();
            this.skinBarSubItem = new DevExpress.XtraBars.SkinBarSubItem();
            this.barRefMenu = new DevExpress.XtraBars.BarSubItem();
            this.barBtnRefBorroughts = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSettlements = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnLocalities = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnLicActivities = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnBrand = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnMap = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnLocalitiesView = new DevExpress.XtraBars.BarButtonItem();
            this.barPagesMenu = new DevExpress.XtraBars.BarSubItem();
            this.barBtnSettings = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnBackup = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRestore = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnReload = new DevExpress.XtraBars.BarButtonItem();
            this.tabFormDefaultManager1 = new DevExpress.XtraBars.TabFormDefaultManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Svyaz.WaitForm1), true, true);
            this.defaultToolTipController1 = new DevExpress.Utils.DefaultToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabFormControl1
            // 
            this.tabFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.skinBarSubItem,
            this.barRefMenu,
            this.barBtnRefBorroughts,
            this.barBtnSettlements,
            this.barBtnLocalities,
            this.barPagesMenu,
            this.barBtnLocalitiesView,
            this.barBtnSettings,
            this.barButtonItem1,
            this.barBtnLicActivities,
            this.barBtnBrand,
            this.barBtnBackup,
            this.barBtnRestore,
            this.barBtnReload,
            this.barBtnMap});
            this.tabFormControl1.Location = new System.Drawing.Point(0, 0);
            this.tabFormControl1.Manager = this.tabFormDefaultManager1;
            this.tabFormControl1.Name = "tabFormControl1";
            this.tabFormControl1.ShowAddPageButton = false;
            this.tabFormControl1.Size = new System.Drawing.Size(1161, 50);
            this.tabFormControl1.TabForm = this;
            this.tabFormControl1.TabIndex = 0;
            this.tabFormControl1.TabStop = false;
            this.tabFormControl1.TitleItemLinks.Add(this.skinBarSubItem);
            this.tabFormControl1.TitleItemLinks.Add(this.barPagesMenu);
            this.tabFormControl1.TitleItemLinks.Add(this.barRefMenu);
            this.tabFormControl1.TitleItemLinks.Add(this.barBtnReload);
            this.tabFormControl1.TitleItemLinks.Add(this.barBtnBackup);
            this.tabFormControl1.TitleItemLinks.Add(this.barBtnRestore);
            this.tabFormControl1.TitleItemLinks.Add(this.barBtnSettings, true);
            this.tabFormControl1.PageCreated += new DevExpress.XtraBars.PageCreatedEventHandler(this.tabFormControl1_PageCreated);
            this.tabFormControl1.PageCollectionChanged += new System.EventHandler(this.tabFormControl1_PageCollectionChanged);
            // 
            // skinBarSubItem
            // 
            this.skinBarSubItem.Caption = "Оформление";
            this.skinBarSubItem.Hint = "Оформление";
            this.skinBarSubItem.Id = 0;
            this.skinBarSubItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("skinBarSubItem.ImageOptions.Image")));
            this.skinBarSubItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("skinBarSubItem.ImageOptions.LargeImage")));
            this.skinBarSubItem.Name = "skinBarSubItem";
            this.skinBarSubItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // barRefMenu
            // 
            this.barRefMenu.Caption = "Справочники";
            this.barRefMenu.Id = 4;
            this.barRefMenu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barRefMenu.ImageOptions.Image")));
            this.barRefMenu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barRefMenu.ImageOptions.LargeImage")));
            this.barRefMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnRefBorroughts),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSettlements),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnLocalities),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnLicActivities, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnBrand),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.barBtnMap, false),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnLocalitiesView, true)});
            this.barRefMenu.Name = "barRefMenu";
            this.barRefMenu.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // barBtnRefBorroughts
            // 
            this.barBtnRefBorroughts.Caption = "Районы";
            this.barBtnRefBorroughts.Id = 5;
            this.barBtnRefBorroughts.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnRefBorroughts.ImageOptions.Image")));
            this.barBtnRefBorroughts.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnRefBorroughts.ImageOptions.LargeImage")));
            this.barBtnRefBorroughts.Name = "barBtnRefBorroughts";
            superToolTip1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem1.Text = "Спаравочник районов области";
            superToolTip1.Items.Add(toolTipItem1);
            this.barBtnRefBorroughts.SuperTip = superToolTip1;
            this.barBtnRefBorroughts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnRefBorroughts_ItemClick);
            // 
            // barBtnSettlements
            // 
            this.barBtnSettlements.Caption = "Поселения";
            this.barBtnSettlements.Id = 6;
            this.barBtnSettlements.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnSettlements.ImageOptions.Image")));
            this.barBtnSettlements.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnSettlements.ImageOptions.LargeImage")));
            this.barBtnSettlements.Name = "barBtnSettlements";
            this.barBtnSettlements.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSettlements_ItemClick);
            // 
            // barBtnLocalities
            // 
            this.barBtnLocalities.Caption = "Населеные пункты";
            this.barBtnLocalities.Id = 7;
            this.barBtnLocalities.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnLocalities.ImageOptions.Image")));
            this.barBtnLocalities.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnLocalities.ImageOptions.LargeImage")));
            this.barBtnLocalities.Name = "barBtnLocalities";
            this.barBtnLocalities.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnLocalities_ItemClick);
            // 
            // barBtnLicActivities
            // 
            this.barBtnLicActivities.Caption = "Лицензируемая деятельность";
            this.barBtnLicActivities.Id = 19;
            this.barBtnLicActivities.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnLicActivities.ImageOptions.Image")));
            this.barBtnLicActivities.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnLicActivities.ImageOptions.LargeImage")));
            this.barBtnLicActivities.Name = "barBtnLicActivities";
            this.barBtnLicActivities.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnLicActivities_ItemClick);
            // 
            // barBtnBrand
            // 
            this.barBtnBrand.Caption = "Операторы связи";
            this.barBtnBrand.Id = 20;
            this.barBtnBrand.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnBrand.ImageOptions.Image")));
            this.barBtnBrand.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnBrand.ImageOptions.LargeImage")));
            this.barBtnBrand.Name = "barBtnBrand";
            this.barBtnBrand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnBrand_ItemClick);
            // 
            // barBtnMap
            // 
            this.barBtnMap.Caption = "Карта покрытия";
            this.barBtnMap.Id = 24;
            this.barBtnMap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnMap.ImageOptions.Image")));
            this.barBtnMap.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnMap.ImageOptions.LargeImage")));
            this.barBtnMap.Name = "barBtnMap";
            this.barBtnMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnMap_ItemClick);
            // 
            // barBtnLocalitiesView
            // 
            this.barBtnLocalitiesView.Caption = "Свод";
            this.barBtnLocalitiesView.Id = 14;
            this.barBtnLocalitiesView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnLocalitiesView.ImageOptions.Image")));
            this.barBtnLocalitiesView.Name = "barBtnLocalitiesView";
            this.barBtnLocalitiesView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnLocalitiesView_ItemClick);
            // 
            // barPagesMenu
            // 
            this.barPagesMenu.Caption = "Закладки";
            this.barPagesMenu.Hint = "Открытые закладки";
            this.barPagesMenu.Id = 9;
            this.barPagesMenu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barPagesMenu.ImageOptions.Image")));
            this.barPagesMenu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barPagesMenu.ImageOptions.LargeImage")));
            this.barPagesMenu.Name = "barPagesMenu";
            this.barPagesMenu.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            toolTipTitleItem1.Text = "Закладки";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Список открытых закладок.\r\nДля перехода к нужной заклдаке просто выберите ее из в" +
    "ыпадающего меню";
            superToolTip2.Items.Add(toolTipTitleItem1);
            superToolTip2.Items.Add(toolTipItem2);
            this.barPagesMenu.SuperTip = superToolTip2;
            // 
            // barBtnSettings
            // 
            this.barBtnSettings.Caption = "Настройки";
            this.barBtnSettings.Id = 16;
            this.barBtnSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnSettings.ImageOptions.Image")));
            this.barBtnSettings.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnSettings.ImageOptions.LargeImage")));
            this.barBtnSettings.Name = "barBtnSettings";
            this.barBtnSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSettings_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 18;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barBtnBackup
            // 
            this.barBtnBackup.Caption = "Сделать резервную копию данных";
            this.barBtnBackup.Id = 21;
            this.barBtnBackup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnBackup.ImageOptions.Image")));
            this.barBtnBackup.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnBackup.ImageOptions.LargeImage")));
            this.barBtnBackup.Name = "barBtnBackup";
            this.barBtnBackup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnBackup_ItemClick);
            // 
            // barBtnRestore
            // 
            this.barBtnRestore.Caption = "Восстановить данные из резервной копии";
            this.barBtnRestore.Id = 22;
            this.barBtnRestore.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnRestore.ImageOptions.Image")));
            this.barBtnRestore.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnRestore.ImageOptions.LargeImage")));
            this.barBtnRestore.Name = "barBtnRestore";
            this.barBtnRestore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnRestore_ItemClick);
            // 
            // barBtnReload
            // 
            this.barBtnReload.Caption = "Перезагрузить данные";
            this.barBtnReload.Id = 23;
            this.barBtnReload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnReload.ImageOptions.Image")));
            this.barBtnReload.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnReload.ImageOptions.LargeImage")));
            this.barBtnReload.Name = "barBtnReload";
            this.barBtnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnReload_ItemClick);
            // 
            // tabFormDefaultManager1
            // 
            this.tabFormDefaultManager1.DockControls.Add(this.barDockControlTop);
            this.tabFormDefaultManager1.DockControls.Add(this.barDockControlBottom);
            this.tabFormDefaultManager1.DockControls.Add(this.barDockControlLeft);
            this.tabFormDefaultManager1.DockControls.Add(this.barDockControlRight);
            this.tabFormDefaultManager1.DockingEnabled = false;
            this.tabFormDefaultManager1.Form = this;
            this.tabFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.skinBarSubItem,
            this.barRefMenu,
            this.barBtnRefBorroughts,
            this.barBtnSettlements,
            this.barBtnLocalities,
            this.barPagesMenu,
            this.barBtnLocalitiesView,
            this.barBtnSettings,
            this.barButtonItem1,
            this.barBtnLicActivities,
            this.barBtnBrand,
            this.barBtnBackup,
            this.barBtnRestore,
            this.barBtnReload,
            this.barBtnMap});
            this.tabFormDefaultManager1.MaxItemId = 25;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = null;
            this.barDockControlTop.Size = new System.Drawing.Size(1161, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 672);
            this.barDockControlBottom.Manager = null;
            this.barDockControlBottom.Size = new System.Drawing.Size(1161, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = null;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 672);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1161, 0);
            this.barDockControlRight.Manager = null;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 672);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // Form1
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 672);
            this.Controls.Add(this.tabFormControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.TabFormControl = this.tabFormControl1;
            this.Text = "Связь ЕАО ver. 0.0.00.00";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraBars.TabFormControl tabFormControl1;
    private DevExpress.XtraBars.TabFormDefaultManager tabFormDefaultManager1;
    private DevExpress.XtraBars.BarDockControl barDockControlTop;
    private DevExpress.XtraBars.BarDockControl barDockControlBottom;
    private DevExpress.XtraBars.BarDockControl barDockControlLeft;
    private DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraBars.SkinBarSubItem skinBarSubItem;
    private DevExpress.XtraBars.BarSubItem barRefMenu;
    private DevExpress.XtraBars.BarButtonItem barBtnRefBorroughts;
    private DevExpress.XtraBars.BarButtonItem barBtnSettlements;
    private DevExpress.XtraBars.BarButtonItem barBtnLocalities;
    private DevExpress.XtraBars.BarSubItem barPagesMenu;
    private DevExpress.XtraBars.BarButtonItem barBtnLocalitiesView;
    private DevExpress.XtraBars.BarButtonItem barBtnSettings;
    private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    private DevExpress.XtraBars.BarButtonItem barBtnLicActivities;
    private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    private DevExpress.XtraBars.BarButtonItem barBtnBrand;
    private DevExpress.Utils.DefaultToolTipController defaultToolTipController1;
    private DevExpress.XtraBars.BarButtonItem barBtnBackup;
    private DevExpress.XtraBars.BarButtonItem barBtnRestore;
    private DevExpress.XtraBars.BarButtonItem barBtnReload;
      private DevExpress.XtraBars.BarButtonItem barBtnMap;
   }
}
