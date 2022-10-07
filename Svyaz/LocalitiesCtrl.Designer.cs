namespace Svyaz {
   partial class LocalitiesCtrl {
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalitiesCtrl));
         DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
         this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
         this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
         this.bindingSrc = new System.Windows.Forms.BindingSource(this.components);
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
         this.gridControl1 = new DevExpress.XtraGrid.GridControl();
         this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
         this.gridColSettlement = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColId = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColFullName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColCategory = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColCurrentCount = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gvLocalities = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gvPopulations = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
         ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
         this.bindingNavigator1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSrc)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gvLocalities)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gvPopulations)).BeginInit();
         this.SuspendLayout();
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
         this.bindingNavigator1.Size = new System.Drawing.Size(638, 25);
         this.bindingNavigator1.TabIndex = 0;
         this.bindingNavigator1.Text = "bindingNavigator1";
         // 
         // bindingNavigatorAddNewItem
         // 
         this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
         this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
         this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorAddNewItem.Text = "Add new";
         // 
         // bindingSrc
         // 
         this.bindingSrc.AllowNew = false;
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
         this.bindingNavigatorDeleteItem.Enabled = false;
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
         // gridControl1
         // 
         this.gridControl1.DataSource = this.bindingSrc;
         this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         gridLevelNode1.LevelTemplate = this.gvPopulations;
         gridLevelNode1.RelationName = "Население";
         this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
         this.gridControl1.Location = new System.Drawing.Point(0, 25);
         this.gridControl1.MainView = this.gvLocalities;
         this.gridControl1.Name = "gridControl1";
         this.gridControl1.Size = new System.Drawing.Size(638, 344);
         this.gridControl1.TabIndex = 1;
         this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView1,
            this.gvLocalities,
            this.gvPopulations});
         this.gridControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gvLocalities_MouseUp);
         // 
         // cardView1
         // 
         this.cardView1.FocusedCardTopFieldIndex = 0;
         this.cardView1.GridControl = this.gridControl1;
         this.cardView1.Name = "cardView1";
         // 
         // gridColSettlement
         // 
         this.gridColSettlement.Caption = "Поселение";
         this.gridColSettlement.FieldName = "Settlement";
         this.gridColSettlement.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
         this.gridColSettlement.Name = "gridColSettlement";
         this.gridColSettlement.Visible = true;
         this.gridColSettlement.VisibleIndex = 0;
         this.gridColSettlement.Width = 250;
         // 
         // gridColId
         // 
         this.gridColId.Caption = "Код";
         this.gridColId.FieldName = "Id";
         this.gridColId.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
         this.gridColId.Name = "gridColId";
         this.gridColId.Visible = true;
         this.gridColId.VisibleIndex = 1;
         this.gridColId.Width = 48;
         // 
         // gridColFullName
         // 
         this.gridColFullName.Caption = "Наименование";
         this.gridColFullName.FieldName = "FullName";
         this.gridColFullName.Name = "gridColFullName";
         this.gridColFullName.Visible = true;
         this.gridColFullName.VisibleIndex = 2;
         this.gridColFullName.Width = 250;
         // 
         // gridColCategory
         // 
         this.gridColCategory.Caption = "Категория";
         this.gridColCategory.FieldName = "Category";
         this.gridColCategory.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
         this.gridColCategory.Name = "gridColCategory";
         this.gridColCategory.Visible = true;
         this.gridColCategory.VisibleIndex = 3;
         this.gridColCategory.Width = 68;
         // 
         // gridColCurrentCount
         // 
         this.gridColCurrentCount.Caption = "Чел. ";
         this.gridColCurrentCount.FieldName = "CurrentPopulationCount";
         this.gridColCurrentCount.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
         this.gridColCurrentCount.Name = "gridColCurrentCount";
         this.gridColCurrentCount.Visible = true;
         this.gridColCurrentCount.VisibleIndex = 4;
         this.gridColCurrentCount.Width = 49;
         // 
         // gvLocalities
         // 
         this.gvLocalities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColSettlement,
            this.gridColId,
            this.gridColFullName,
            this.gridColCategory,
            this.gridColCurrentCount});
         this.gvLocalities.GridControl = this.gridControl1;
         this.gvLocalities.Name = "gvLocalities";
         this.gvLocalities.OptionsBehavior.Editable = false;
         this.gvLocalities.OptionsBehavior.ReadOnly = true;
         this.gvLocalities.MasterRowGetLevelDefaultView += new DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventHandler(this.gvPopulations_MasterRowGetLevelDefaultView);
         this.gvLocalities.MasterRowGetRelationDisplayCaption += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.gvPopulations_MasterRowGetRelationDisplayCaption);
         this.gvLocalities.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(this.gvPopulations_MasterRowGetRelationCount);
         this.gvLocalities.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gvLocalities_KeyUp);
         this.gvLocalities.DoubleClick += new System.EventHandler(this.gvLocalities_DoubleClick);
         // 
         // gvPopulations
         // 
         this.gvPopulations.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
         this.gvPopulations.GridControl = this.gridControl1;
         this.gvPopulations.Name = "gvPopulations";
         this.gvPopulations.OptionsBehavior.Editable = false;
         this.gvPopulations.OptionsBehavior.ReadOnly = true;
         this.gvPopulations.OptionsCustomization.AllowGroup = false;
         this.gvPopulations.OptionsView.ShowGroupPanel = false;
         // 
         // gridColumn1
         // 
         this.gridColumn1.Caption = "Дата";
         this.gridColumn1.FieldName = "Date";
         this.gridColumn1.Name = "gridColumn1";
         this.gridColumn1.Visible = true;
         this.gridColumn1.VisibleIndex = 0;
         // 
         // gridColumn2
         // 
         this.gridColumn2.Caption = "Кол. проживающих";
         this.gridColumn2.FieldName = "Count";
         this.gridColumn2.Name = "gridColumn2";
         this.gridColumn2.Visible = true;
         this.gridColumn2.VisibleIndex = 1;
         // 
         // LocalitiesCtrl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.gridControl1);
         this.Controls.Add(this.bindingNavigator1);
         this.Name = "LocalitiesCtrl";
         this.Size = new System.Drawing.Size(638, 369);
         this.Load += new System.EventHandler(this.LocalitiesCtrl_Load);
         ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
         this.bindingNavigator1.ResumeLayout(false);
         this.bindingNavigator1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSrc)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gvLocalities)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gvPopulations)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

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
      private System.Windows.Forms.BindingSource bindingSrc;
      private DevExpress.XtraGrid.GridControl gridControl1;
      private DevExpress.XtraGrid.Views.Card.CardView cardView1;
      private DevExpress.XtraGrid.Views.Grid.GridView gvPopulations;
      private DevExpress.XtraGrid.Views.Grid.GridView gvLocalities;
      private DevExpress.XtraGrid.Columns.GridColumn gridColSettlement;
      private DevExpress.XtraGrid.Columns.GridColumn gridColId;
      private DevExpress.XtraGrid.Columns.GridColumn gridColFullName;
      private DevExpress.XtraGrid.Columns.GridColumn gridColCategory;
      private DevExpress.XtraGrid.Columns.GridColumn gridColCurrentCount;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
   }
}
