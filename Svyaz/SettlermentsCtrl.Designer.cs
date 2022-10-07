namespace Svyaz {
   partial class SettlermentsCtrl {
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
         DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettlermentsCtrl));
         this.gvLocalities = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumnFullname = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridControl1 = new DevExpress.XtraGrid.GridControl();
         this.bindingSrc = new System.Windows.Forms.BindingSource(this.components);
         this.gvSettlements = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColBorrough = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColId = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColCategory = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColCenter = new DevExpress.XtraGrid.Columns.GridColumn();
         this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
         this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
         this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
         this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
         this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         ((System.ComponentModel.ISupportInitialize)(this.gvLocalities)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSrc)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gvSettlements)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
         this.bindingNavigator1.SuspendLayout();
         this.SuspendLayout();
         // 
         // gvLocalities
         // 
         this.gvLocalities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnFullname});
         this.gvLocalities.GridControl = this.gridControl1;
         this.gvLocalities.Name = "gvLocalities";
         this.gvLocalities.OptionsBehavior.Editable = false;
         this.gvLocalities.OptionsBehavior.ReadOnly = true;
         this.gvLocalities.OptionsCustomization.AllowGroup = false;
         this.gvLocalities.OptionsView.ShowGroupPanel = false;
         // 
         // gridColumnId
         // 
         this.gridColumnId.Caption = "Код";
         this.gridColumnId.FieldName = "Id";
         this.gridColumnId.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
         this.gridColumnId.Name = "gridColumnId";
         this.gridColumnId.Visible = true;
         this.gridColumnId.VisibleIndex = 0;
         // 
         // gridColumnFullname
         // 
         this.gridColumnFullname.Caption = "Название";
         this.gridColumnFullname.FieldName = "FullName";
         this.gridColumnFullname.Name = "gridColumnFullname";
         this.gridColumnFullname.Visible = true;
         this.gridColumnFullname.VisibleIndex = 1;
         // 
         // gridControl1
         // 
         this.gridControl1.DataSource = this.bindingSrc;
         this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         gridLevelNode1.LevelTemplate = this.gvLocalities;
         gridLevelNode1.RelationName = "Населенные пункты";
         this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
         this.gridControl1.Location = new System.Drawing.Point(0, 25);
         this.gridControl1.MainView = this.gvSettlements;
         this.gridControl1.Name = "gridControl1";
         this.gridControl1.Size = new System.Drawing.Size(636, 396);
         this.gridControl1.TabIndex = 1;
         this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSettlements,
            this.gvLocalities});
         // 
         // bindingSrc
         // 
         this.bindingSrc.AllowNew = false;
         // 
         // gvSettlements
         // 
         this.gvSettlements.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColBorrough,
            this.gridColId,
            this.gridColName,
            this.gridColCategory,
            this.gridColCenter});
         this.gvSettlements.GridControl = this.gridControl1;
         this.gvSettlements.Name = "gvSettlements";
         this.gvSettlements.OptionsBehavior.Editable = false;
         this.gvSettlements.OptionsBehavior.ReadOnly = true;
         this.gvSettlements.MasterRowGetLevelDefaultView += new DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventHandler(this.gvSettlemets_MasterRowGetLevelDefaultView);
         this.gvSettlements.MasterRowGetRelationDisplayCaption += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.gvSettlemets_MasterRowGetRelationDisplayCaption);
         this.gvSettlements.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(this.gvSettlemets_MasterRowGetRelationCount);
         // 
         // gridColBorrough
         // 
         this.gridColBorrough.Caption = "Район";
         this.gridColBorrough.FieldName = "Borrough";
         this.gridColBorrough.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
         this.gridColBorrough.Name = "gridColBorrough";
         this.gridColBorrough.Visible = true;
         this.gridColBorrough.VisibleIndex = 0;
         this.gridColBorrough.Width = 176;
         // 
         // gridColId
         // 
         this.gridColId.Caption = "Код";
         this.gridColId.FieldName = "Id";
         this.gridColId.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
         this.gridColId.Name = "gridColId";
         this.gridColId.Visible = true;
         this.gridColId.VisibleIndex = 1;
         this.gridColId.Width = 51;
         // 
         // gridColName
         // 
         this.gridColName.Caption = "Наименование";
         this.gridColName.FieldName = "Name";
         this.gridColName.Name = "gridColName";
         this.gridColName.Visible = true;
         this.gridColName.VisibleIndex = 2;
         this.gridColName.Width = 124;
         // 
         // gridColCategory
         // 
         this.gridColCategory.Caption = "Категория";
         this.gridColCategory.FieldName = "Category";
         this.gridColCategory.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
         this.gridColCategory.Name = "gridColCategory";
         this.gridColCategory.Visible = true;
         this.gridColCategory.VisibleIndex = 3;
         this.gridColCategory.Width = 90;
         // 
         // gridColCenter
         // 
         this.gridColCenter.Caption = "Адм. центр";
         this.gridColCenter.FieldName = "Center";
         this.gridColCenter.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
         this.gridColCenter.Name = "gridColCenter";
         this.gridColCenter.Visible = true;
         this.gridColCenter.VisibleIndex = 4;
         this.gridColCenter.Width = 175;
         // 
         // bindingNavigator1
         // 
         this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
         this.bindingNavigator1.BindingSource = this.bindingSrc;
         this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
         this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
         this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
         this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
         this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
         this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
         this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
         this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
         this.bindingNavigator1.Name = "bindingNavigator1";
         this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
         this.bindingNavigator1.Size = new System.Drawing.Size(636, 25);
         this.bindingNavigator1.TabIndex = 0;
         this.bindingNavigator1.Text = "bindingNavigator1";
         // 
         // bindingNavigatorAddNewItem
         // 
         this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorAddNewItem.Enabled = false;
         this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
         this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
         this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorAddNewItem.Text = "Add new";
         // 
         // bindingNavigatorCountItem
         // 
         this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
         this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
         this.bindingNavigatorCountItem.Text = "of {0}";
         this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
         // 
         // bindingNavigatorDeleteItem
         // 
         this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
         this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
         this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorDeleteItem.Text = "Delete";
         // 
         // bindingNavigatorMoveFirstItem
         // 
         this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
         this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
         this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMoveFirstItem.Text = "Move first";
         // 
         // bindingNavigatorMovePreviousItem
         // 
         this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
         this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
         this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMovePreviousItem.Text = "Move previous";
         // 
         // bindingNavigatorSeparator
         // 
         this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
         this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
         // 
         // bindingNavigatorPositionItem
         // 
         this.bindingNavigatorPositionItem.AccessibleName = "Position";
         this.bindingNavigatorPositionItem.AutoSize = false;
         this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
         this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
         this.bindingNavigatorPositionItem.Text = "0";
         this.bindingNavigatorPositionItem.ToolTipText = "Current position";
         // 
         // bindingNavigatorSeparator1
         // 
         this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
         this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // bindingNavigatorMoveNextItem
         // 
         this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
         this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
         this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMoveNextItem.Text = "Move next";
         // 
         // bindingNavigatorMoveLastItem
         // 
         this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
         this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
         this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMoveLastItem.Text = "Move last";
         // 
         // bindingNavigatorSeparator2
         // 
         this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
         this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // SettlermentsCtrl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.gridControl1);
         this.Controls.Add(this.bindingNavigator1);
         this.Name = "SettlermentsCtrl";
         this.Size = new System.Drawing.Size(636, 421);
         this.Load += new System.EventHandler(this.SettlermentsCtrl_Load);
         ((System.ComponentModel.ISupportInitialize)(this.gvLocalities)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSrc)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gvSettlements)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
         this.bindingNavigator1.ResumeLayout(false);
         this.bindingNavigator1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.BindingSource bindingSrc;
      private System.Windows.Forms.BindingNavigator bindingNavigator1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
      private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
      private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
      private DevExpress.XtraGrid.GridControl gridControl1;
      private DevExpress.XtraGrid.Views.Grid.GridView gvSettlements;
      private DevExpress.XtraGrid.Columns.GridColumn gridColId;
      private DevExpress.XtraGrid.Columns.GridColumn gridColName;
      private DevExpress.XtraGrid.Columns.GridColumn gridColCategory;
      private DevExpress.XtraGrid.Columns.GridColumn gridColCenter;
      private DevExpress.XtraGrid.Columns.GridColumn gridColBorrough;
      private DevExpress.XtraGrid.Views.Grid.GridView gvLocalities;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumnFullname;
   }
}
