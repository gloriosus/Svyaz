namespace Svyaz {
   partial class LicActivitiesCtrl {
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
         this.treeList1 = new DevExpress.XtraTreeList.TreeList();
         this.treeListColID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColParentID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColProperty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.bindingSrc = new System.Windows.Forms.BindingSource(this.components);
         this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
         this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
         this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
         this.localitiesBaseViewCtrl1 = new Svyaz.LocalitiesBaseViewCtrl();
         ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSrc)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
         this.groupControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // treeList1
         // 
         this.treeList1.Caption = "Лицензируемая деятельность (услуги связи)";
         this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColID,
            this.treeListColParentID,
            this.treeListColName,
            this.treeListColProperty});
         this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
         this.treeList1.DataSource = this.bindingSrc;
         this.treeList1.Dock = System.Windows.Forms.DockStyle.Left;
         this.treeList1.Location = new System.Drawing.Point(0, 69);
         this.treeList1.Name = "treeList1";
         this.treeList1.OptionsBehavior.AutoPopulateColumns = false;
         this.treeList1.OptionsBehavior.Editable = false;
         this.treeList1.OptionsBehavior.ReadOnly = true;
         this.treeList1.OptionsView.AutoWidth = false;
         this.treeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
         this.treeList1.OptionsView.ShowCheckBoxes = true;
         this.treeList1.Size = new System.Drawing.Size(344, 335);
         this.treeList1.TabIndex = 0;
         this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
         // 
         // treeListColID
         // 
         this.treeListColID.Caption = "Код";
         this.treeListColID.FieldName = "ID";
         this.treeListColID.MinWidth = 34;
         this.treeListColID.Name = "treeListColID";
         this.treeListColID.Visible = true;
         this.treeListColID.VisibleIndex = 0;
         this.treeListColID.Width = 78;
         // 
         // treeListColParentID
         // 
         this.treeListColParentID.Caption = "Родитель";
         this.treeListColParentID.FieldName = "ParentID";
         this.treeListColParentID.Name = "treeListColParentID";
         this.treeListColParentID.Width = 72;
         // 
         // treeListColName
         // 
         this.treeListColName.Caption = "Наименование лиц. деятельности (услуги)";
         this.treeListColName.FieldName = "Name";
         this.treeListColName.Name = "treeListColName";
         this.treeListColName.Visible = true;
         this.treeListColName.VisibleIndex = 1;
         this.treeListColName.Width = 246;
         // 
         // treeListColProperty
         // 
         this.treeListColProperty.Caption = "Имя свойства";
         this.treeListColProperty.FieldName = "Property";
         this.treeListColProperty.Name = "treeListColProperty";
         this.treeListColProperty.Width = 183;
         // 
         // groupControl1
         // 
         this.groupControl1.Controls.Add(this.radioGroup1);
         this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
         this.groupControl1.Location = new System.Drawing.Point(0, 0);
         this.groupControl1.Name = "groupControl1";
         this.groupControl1.Size = new System.Drawing.Size(575, 69);
         this.groupControl1.TabIndex = 1;
         this.groupControl1.Text = "Отображать услуги связи";
         // 
         // radioGroup1
         // 
         this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.radioGroup1.EditValue = 1;
         this.radioGroup1.Location = new System.Drawing.Point(2, 20);
         this.radioGroup1.Name = "radioGroup1";
         this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "По юридическому лицу"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "По оператору связи")});
         this.radioGroup1.Size = new System.Drawing.Size(571, 47);
         this.radioGroup1.TabIndex = 0;
         this.radioGroup1.EditValueChanged += new System.EventHandler(this.radioGroup1_EditValueChanged);
         // 
         // splitterControl1
         // 
         this.splitterControl1.Location = new System.Drawing.Point(344, 69);
         this.splitterControl1.Name = "splitterControl1";
         this.splitterControl1.Size = new System.Drawing.Size(5, 335);
         this.splitterControl1.TabIndex = 2;
         this.splitterControl1.TabStop = false;
         // 
         // localitiesBaseViewCtrl1
         // 
         this.localitiesBaseViewCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.localitiesBaseViewCtrl1.Location = new System.Drawing.Point(349, 69);
         this.localitiesBaseViewCtrl1.Name = "localitiesBaseViewCtrl1";
         this.localitiesBaseViewCtrl1.Size = new System.Drawing.Size(226, 335);
         this.localitiesBaseViewCtrl1.TabIndex = 3;
         // 
         // LicActivitiesCtrl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.localitiesBaseViewCtrl1);
         this.Controls.Add(this.splitterControl1);
         this.Controls.Add(this.treeList1);
         this.Controls.Add(this.groupControl1);
         this.Name = "LicActivitiesCtrl";
         this.Size = new System.Drawing.Size(575, 404);
         this.Load += new System.EventHandler(this.LicActivitiesCtrl_Load);
         ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSrc)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
         this.groupControl1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraTreeList.TreeList treeList1;
      private System.Windows.Forms.BindingSource bindingSrc;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColID;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColParentID;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColName;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColProperty;
      private DevExpress.XtraEditors.GroupControl groupControl1;
      private DevExpress.XtraEditors.RadioGroup radioGroup1;
      private DevExpress.XtraEditors.SplitterControl splitterControl1;
      private LocalitiesBaseViewCtrl localitiesBaseViewCtrl1;

   }
}
