namespace Svyaz {
   partial class OperatorsCtrl {
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperatorsCtrl));
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.rightPanel = new DevExpress.XtraEditors.PanelControl();
         this.listBoxUnknown = new DevExpress.XtraEditors.ListBoxControl();
         this.bindingUnknown = new System.Windows.Forms.BindingSource(this.components);
         this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
         this.gridControl1 = new DevExpress.XtraGrid.GridControl();
         this.bindingOperators = new System.Windows.Forms.BindingSource(this.components);
         this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
         this.leftPanel = new DevExpress.XtraEditors.PanelControl();
         this.listBoxCorp = new DevExpress.XtraEditors.ListBoxControl();
         this.bindingCorps = new System.Windows.Forms.BindingSource(this.components);
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.splitterControl3 = new DevExpress.XtraEditors.SplitterControl();
         this.licActivitiesCtrl1 = new Svyaz.LicActivitiesCtrl();
         this.defaultToolTipCotroller = new DevExpress.Utils.DefaultToolTipController(this.components);
         this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
         this.popupCopy = new DevExpress.XtraBars.BarButtonItem();
         this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         ((System.ComponentModel.ISupportInitialize)(this.rightPanel)).BeginInit();
         this.rightPanel.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.listBoxUnknown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingUnknown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingOperators)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.leftPanel)).BeginInit();
         this.leftPanel.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.listBoxCorp)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingCorps)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
         this.SuspendLayout();
         // 
         // labelControl1
         // 
         this.labelControl1.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
         this.labelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
         this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
         this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
         this.labelControl1.Location = new System.Drawing.Point(2, 2);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(231, 24);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "Не распределнные юр. лица";
         this.labelControl1.ToolTip = "Захватите мышкой и перетащиете выбранную запись в <b>юр. лица Оператора</b>";
         // 
         // rightPanel
         // 
         this.defaultToolTipCotroller.SetAllowHtmlText(this.rightPanel, DevExpress.Utils.DefaultBoolean.Default);
         this.rightPanel.Controls.Add(this.listBoxUnknown);
         this.rightPanel.Controls.Add(this.labelControl1);
         this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
         this.rightPanel.Location = new System.Drawing.Point(618, 0);
         this.rightPanel.Name = "rightPanel";
         this.rightPanel.Size = new System.Drawing.Size(235, 502);
         this.rightPanel.TabIndex = 1;
         // 
         // listBoxUnknown
         // 
         this.listBoxUnknown.AllowDrop = true;
         this.listBoxUnknown.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
         this.listBoxUnknown.DataSource = this.bindingUnknown;
         this.listBoxUnknown.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listBoxUnknown.Location = new System.Drawing.Point(2, 26);
         this.listBoxUnknown.Name = "listBoxUnknown";
         this.listBoxUnknown.Size = new System.Drawing.Size(231, 474);
         this.listBoxUnknown.TabIndex = 1;
         this.listBoxUnknown.ToolTip = "Захватите мышкой и перетащиете выбранную запись в <b>юр. лица Оператора</b>";
         this.listBoxUnknown.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxUnknown_DragDrop);
         this.listBoxUnknown.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxUnknown_DragEnter);
         this.listBoxUnknown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxUnknown_MouseDown);
         this.listBoxUnknown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxUnknown_MouseMove);
         this.listBoxUnknown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBoxControl_MouseUp);
         // 
         // splitterControl1
         // 
         this.defaultToolTipCotroller.SetAllowHtmlText(this.splitterControl1, DevExpress.Utils.DefaultBoolean.Default);
         this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right;
         this.splitterControl1.Location = new System.Drawing.Point(613, 0);
         this.splitterControl1.Name = "splitterControl1";
         this.splitterControl1.Size = new System.Drawing.Size(5, 502);
         this.splitterControl1.TabIndex = 2;
         this.splitterControl1.TabStop = false;
         // 
         // gridControl1
         // 
         this.gridControl1.DataSource = this.bindingOperators;
         this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
         this.gridControl1.Location = new System.Drawing.Point(0, 0);
         this.gridControl1.MainView = this.gridView1;
         this.gridControl1.Name = "gridControl1";
         this.gridControl1.Size = new System.Drawing.Size(258, 502);
         this.gridControl1.TabIndex = 3;
         this.gridControl1.UseEmbeddedNavigator = true;
         this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
         // 
         // bindingOperators
         // 
         this.bindingOperators.PositionChanged += new System.EventHandler(this.bindingOperators_PositionChanged);
         // 
         // gridView1
         // 
         this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
         this.gridView1.GridControl = this.gridControl1;
         this.gridView1.Name = "gridView1";
         this.gridView1.OptionsCustomization.AllowGroup = false;
         this.gridView1.OptionsDetail.EnableMasterViewMode = false;
         this.gridView1.OptionsView.ShowGroupPanel = false;
         this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
         this.gridView1.ShownEditor += new System.EventHandler(this.gridView1_ShownEditor);
         this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
         // 
         // gridColumn1
         // 
         this.gridColumn1.Caption = "Оператор";
         this.gridColumn1.FieldName = "OperatorName";
         this.gridColumn1.Name = "gridColumn1";
         this.gridColumn1.Visible = true;
         this.gridColumn1.VisibleIndex = 0;
         // 
         // splitterControl2
         // 
         this.defaultToolTipCotroller.SetAllowHtmlText(this.splitterControl2, DevExpress.Utils.DefaultBoolean.Default);
         this.splitterControl2.Location = new System.Drawing.Point(258, 0);
         this.splitterControl2.Name = "splitterControl2";
         this.splitterControl2.Size = new System.Drawing.Size(5, 502);
         this.splitterControl2.TabIndex = 4;
         this.splitterControl2.TabStop = false;
         // 
         // leftPanel
         // 
         this.defaultToolTipCotroller.SetAllowHtmlText(this.leftPanel, DevExpress.Utils.DefaultBoolean.Default);
         this.leftPanel.Controls.Add(this.listBoxCorp);
         this.leftPanel.Controls.Add(this.labelControl2);
         this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
         this.leftPanel.Location = new System.Drawing.Point(263, 0);
         this.leftPanel.Name = "leftPanel";
         this.leftPanel.Size = new System.Drawing.Size(251, 502);
         this.leftPanel.TabIndex = 5;
         // 
         // listBoxCorp
         // 
         this.listBoxCorp.AllowDrop = true;
         this.listBoxCorp.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
         this.listBoxCorp.DataSource = this.bindingCorps;
         this.listBoxCorp.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listBoxCorp.Location = new System.Drawing.Point(2, 26);
         this.listBoxCorp.Name = "listBoxCorp";
         this.listBoxCorp.Size = new System.Drawing.Size(247, 474);
         this.listBoxCorp.TabIndex = 3;
         this.listBoxCorp.ToolTip = "Захватите мышкой и перетащиете выбранную запись в <b>Не распределенные юр. лица</" +
    "b>";
         this.listBoxCorp.SelectedIndexChanged += new System.EventHandler(this.listBoxCorp_SelectedIndexChanged);
         this.listBoxCorp.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxCorp_DragDrop);
         this.listBoxCorp.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxCorp_DragEnter);
         this.listBoxCorp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxCorp_MouseDown);
         this.listBoxCorp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxCorp_MouseMove);
         this.listBoxCorp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBoxControl_MouseUp);
         // 
         // labelControl2
         // 
         this.labelControl2.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
         this.labelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
         this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
         this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
         this.labelControl2.Location = new System.Drawing.Point(2, 2);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(247, 24);
         this.labelControl2.TabIndex = 2;
         this.labelControl2.Text = "юр. лица Оператора";
         this.labelControl2.ToolTip = "Захватите мышкой и перетащиете выбранную запись в <b>Не распределенные юр. лица</" +
    "b>";
         // 
         // splitterControl3
         // 
         this.defaultToolTipCotroller.SetAllowHtmlText(this.splitterControl3, DevExpress.Utils.DefaultBoolean.Default);
         this.splitterControl3.Location = new System.Drawing.Point(514, 0);
         this.splitterControl3.Name = "splitterControl3";
         this.splitterControl3.Size = new System.Drawing.Size(5, 502);
         this.splitterControl3.TabIndex = 6;
         this.splitterControl3.TabStop = false;
         // 
         // licActivitiesCtrl1
         // 
         this.defaultToolTipCotroller.SetAllowHtmlText(this.licActivitiesCtrl1, DevExpress.Utils.DefaultBoolean.Default);
         this.licActivitiesCtrl1.Corp = null;
         this.licActivitiesCtrl1.DataViewBy = Svyaz.DataView.ByCorporatiions;
         this.licActivitiesCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.licActivitiesCtrl1.Location = new System.Drawing.Point(519, 0);
         this.licActivitiesCtrl1.Name = "licActivitiesCtrl1";
         this.licActivitiesCtrl1.Size = new System.Drawing.Size(94, 502);
         this.licActivitiesCtrl1.TabIndex = 7;
         this.licActivitiesCtrl1.DragEnter += new System.Windows.Forms.DragEventHandler(this.licActivitiesCtrl1_DragEnter);
         // 
         // popupMenu1
         // 
         this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.popupCopy)});
         this.popupMenu1.Manager = this.barManager1;
         this.popupMenu1.Name = "popupMenu1";
         this.popupMenu1.CloseUp += new System.EventHandler(this.popupMenu1_CloseUp);
         // 
         // popupCopy
         // 
         this.popupCopy.Caption = "Копировать";
         this.popupCopy.Description = "Копировать";
         this.popupCopy.Glyph = ((System.Drawing.Image)(resources.GetObject("popupCopy.Glyph")));
         this.popupCopy.Id = 2;
         this.popupCopy.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("popupCopy.LargeGlyph")));
         this.popupCopy.Name = "popupCopy";
         this.popupCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.popupCopy_ItemClick);
         // 
         // barManager1
         // 
         this.barManager1.DockControls.Add(this.barDockControlTop);
         this.barManager1.DockControls.Add(this.barDockControlBottom);
         this.barManager1.DockControls.Add(this.barDockControlLeft);
         this.barManager1.DockControls.Add(this.barDockControlRight);
         this.barManager1.Form = this;
         this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.popupCopy});
         this.barManager1.MaxItemId = 4;
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Size = new System.Drawing.Size(853, 0);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 502);
         this.barDockControlBottom.Size = new System.Drawing.Size(853, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 502);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(853, 0);
         this.barDockControlRight.Size = new System.Drawing.Size(0, 502);
         // 
         // OperatorsCtrl
         // 
         this.defaultToolTipCotroller.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.licActivitiesCtrl1);
         this.Controls.Add(this.splitterControl3);
         this.Controls.Add(this.leftPanel);
         this.Controls.Add(this.splitterControl2);
         this.Controls.Add(this.gridControl1);
         this.Controls.Add(this.splitterControl1);
         this.Controls.Add(this.rightPanel);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Name = "OperatorsCtrl";
         this.Size = new System.Drawing.Size(853, 502);
         this.Load += new System.EventHandler(this.BrandsCtrl_Load);
         ((System.ComponentModel.ISupportInitialize)(this.rightPanel)).EndInit();
         this.rightPanel.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.listBoxUnknown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingUnknown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingOperators)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.leftPanel)).EndInit();
         this.leftPanel.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.listBoxCorp)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingCorps)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.PanelControl rightPanel;
      private DevExpress.XtraEditors.ListBoxControl listBoxUnknown;
      private DevExpress.XtraEditors.SplitterControl splitterControl1;
      private DevExpress.XtraGrid.GridControl gridControl1;
      private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraEditors.SplitterControl splitterControl2;
      private System.Windows.Forms.BindingSource bindingOperators;
      private DevExpress.XtraEditors.PanelControl leftPanel;
      private DevExpress.XtraEditors.ListBoxControl listBoxCorp;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.SplitterControl splitterControl3;
      private LicActivitiesCtrl licActivitiesCtrl1;
      private DevExpress.Utils.DefaultToolTipController defaultToolTipCotroller;
      private System.Windows.Forms.BindingSource bindingUnknown;
      private System.Windows.Forms.BindingSource bindingCorps;
      private DevExpress.XtraBars.PopupMenu popupMenu1;
      private DevExpress.XtraBars.BarButtonItem popupCopy;
      private DevExpress.XtraBars.BarManager barManager1;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
   }
}
