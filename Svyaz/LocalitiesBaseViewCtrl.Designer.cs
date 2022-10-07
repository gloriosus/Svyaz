namespace Svyaz {
   partial class LocalitiesBaseViewCtrl {
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
         this.gridControl1 = new DevExpress.XtraGrid.GridControl();
         this.bindingSrc = new System.Windows.Forms.BindingSource(this.components);
         this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColBorrougf = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColSettlement = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColLocality = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColPopulationCount = new DevExpress.XtraGrid.Columns.GridColumn();
         this.riPopupContainerEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSrc)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.riPopupContainerEdit1)).BeginInit();
         this.SuspendLayout();
         // 
         // gridControl1
         // 
         this.gridControl1.AllowDrop = true;
         this.gridControl1.DataSource = this.bindingSrc;
         this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gridControl1.Location = new System.Drawing.Point(0, 0);
         this.gridControl1.MainView = this.gridView1;
         this.gridControl1.Name = "gridControl1";
         this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riPopupContainerEdit1});
         this.gridControl1.Size = new System.Drawing.Size(347, 371);
         this.gridControl1.TabIndex = 1;
         this.gridControl1.UseEmbeddedNavigator = true;
         this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
         this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
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
            this.gridColPopulationCount});
         this.gridView1.GridControl = this.gridControl1;
         this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CurrentPopulationCount", null, "{0} чел.", "1"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "CurrentPopulationCount", null, "{0:#0.00} %", "2"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PhoneOn", null, "Да: {0}", "3")});
         this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
         this.gridView1.Name = "gridView1";
         this.gridView1.OptionsBehavior.Editable = false;
         this.gridView1.OptionsBehavior.ReadOnly = true;
         this.gridView1.OptionsView.ColumnAutoWidth = false;
         this.gridView1.OptionsView.ShowFooter = true;
         this.gridView1.OptionsView.ShowGroupPanel = false;
         // 
         // gridColBorrougf
         // 
         this.gridColBorrougf.Caption = "Район";
         this.gridColBorrougf.FieldName = "Borrough";
         this.gridColBorrougf.Name = "gridColBorrougf";
         this.gridColBorrougf.Visible = true;
         this.gridColBorrougf.VisibleIndex = 0;
         this.gridColBorrougf.Width = 61;
         // 
         // gridColSettlement
         // 
         this.gridColSettlement.Caption = "Поселение";
         this.gridColSettlement.FieldName = "Settlement";
         this.gridColSettlement.Name = "gridColSettlement";
         this.gridColSettlement.Visible = true;
         this.gridColSettlement.VisibleIndex = 1;
         this.gridColSettlement.Width = 61;
         // 
         // gridColLocality
         // 
         this.gridColLocality.Caption = "Населенный пункт";
         this.gridColLocality.FieldName = "FullName";
         this.gridColLocality.Name = "gridColLocality";
         this.gridColLocality.Visible = true;
         this.gridColLocality.VisibleIndex = 2;
         this.gridColLocality.Width = 116;
         // 
         // gridColPopulationCount
         // 
         this.gridColPopulationCount.Caption = "Жителей";
         this.gridColPopulationCount.FieldName = "CurrentPopulationCount";
         this.gridColPopulationCount.Name = "gridColPopulationCount";
         this.gridColPopulationCount.Visible = true;
         this.gridColPopulationCount.VisibleIndex = 3;
         this.gridColPopulationCount.Width = 41;
         // 
         // riPopupContainerEdit1
         // 
         this.riPopupContainerEdit1.AutoHeight = false;
         this.riPopupContainerEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.riPopupContainerEdit1.Name = "riPopupContainerEdit1";
         this.riPopupContainerEdit1.PopupFormMinSize = new System.Drawing.Size(117, 26);
         this.riPopupContainerEdit1.PopupFormSize = new System.Drawing.Size(119, 28);
         this.riPopupContainerEdit1.PopupSizeable = false;
         this.riPopupContainerEdit1.ShowPopupCloseButton = false;
         // 
         // LocalitiesBaseViewCtrl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.gridControl1);
         this.Name = "LocalitiesBaseViewCtrl";
         this.Size = new System.Drawing.Size(347, 371);
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSrc)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.riPopupContainerEdit1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraGrid.GridControl gridControl1;
      private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColBorrougf;
      private DevExpress.XtraGrid.Columns.GridColumn gridColSettlement;
      private DevExpress.XtraGrid.Columns.GridColumn gridColLocality;
      private DevExpress.XtraGrid.Columns.GridColumn gridColPopulationCount;
      private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit riPopupContainerEdit1;
      private System.Windows.Forms.BindingSource bindingSrc;
   }
}
