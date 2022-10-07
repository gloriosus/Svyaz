namespace Svyaz {
   partial class ColumnSelectorCtrl {
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColumnSelectorCtrl));
         this.treeList1 = new DevExpress.XtraTreeList.TreeList();
         this.treeListColNode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
         this.SuspendLayout();
         // 
         // treeList1
         // 
         this.treeList1.AllowDrop = true;
         this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColNode});
         this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.treeList1.Location = new System.Drawing.Point(0, 0);
         this.treeList1.Name = "treeList1";
         this.treeList1.OptionsBehavior.Editable = false;
         this.treeList1.OptionsBehavior.ReadOnly = true;
         this.treeList1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
         this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
         this.treeList1.OptionsView.ShowCheckBoxes = true;
         this.treeList1.OptionsView.ShowColumns = false;
         this.treeList1.OptionsView.ShowHorzLines = false;
         this.treeList1.OptionsView.ShowIndicator = false;
         this.treeList1.OptionsView.ShowVertLines = false;
         this.treeList1.SelectImageList = this.imageCollection;
         this.treeList1.Size = new System.Drawing.Size(214, 366);
         this.treeList1.TabIndex = 0;
         this.treeList1.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList1_NodeCellStyle);
         this.treeList1.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList1_AfterCheckNode);
         this.treeList1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeList1_DragOver);
         this.treeList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDown);
         this.treeList1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseMove);
         // 
         // treeListColNode
         // 
         this.treeListColNode.Caption = "Node";
         this.treeListColNode.FieldName = "Name";
         this.treeListColNode.MinWidth = 70;
         this.treeListColNode.Name = "treeListColNode";
         this.treeListColNode.Visible = true;
         this.treeListColNode.VisibleIndex = 0;
         // 
         // imageCollection
         // 
         this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
         this.imageCollection.Images.SetKeyName(0, "applications.png");
         this.imageCollection.Images.SetKeyName(1, "edit-code.png");
         this.imageCollection.Images.SetKeyName(2, "application-run.png");
         this.imageCollection.Images.SetKeyName(3, "edit-rule.png");
         this.imageCollection.Images.SetKeyName(4, "application-tree.png");
         this.imageCollection.Images.SetKeyName(5, "application-split.png");
         this.imageCollection.Images.SetKeyName(6, "application-sidebar.png");
         this.imageCollection.Images.SetKeyName(7, "document-page-previous.png");
         this.imageCollection.Images.SetKeyName(8, "edit-outdent.png");
         // 
         // ColumnSelectorCtrl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.treeList1);
         this.Name = "ColumnSelectorCtrl";
         this.Size = new System.Drawing.Size(214, 366);
         ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColNode;
      private DevExpress.Utils.ImageCollection imageCollection;
      protected internal DevExpress.XtraTreeList.TreeList treeList1;
   }
}
