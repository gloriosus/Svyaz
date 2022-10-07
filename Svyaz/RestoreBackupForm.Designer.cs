namespace Svyaz {
   partial class RestoreBackupForm {
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
         this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.btnOK = new DevExpress.XtraEditors.SimpleButton();
         this.labelDescr = new DevExpress.XtraEditors.LabelControl();
         this.listBoxZipData = new DevExpress.XtraEditors.CheckedListBoxControl();
         this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
         this.btnEdit1 = new DevExpress.XtraEditors.ButtonEdit();
         this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
         this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
         this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
         this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
         this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
         this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
         this.layoutControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.listBoxZipData)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.btnEdit1.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
         this.SuspendLayout();
         // 
         // layoutControl1
         // 
         this.layoutControl1.Controls.Add(this.toggleSwitch1);
         this.layoutControl1.Controls.Add(this.btnCancel);
         this.layoutControl1.Controls.Add(this.btnOK);
         this.layoutControl1.Controls.Add(this.labelDescr);
         this.layoutControl1.Controls.Add(this.listBoxZipData);
         this.layoutControl1.Controls.Add(this.textEdit1);
         this.layoutControl1.Controls.Add(this.btnEdit1);
         this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.layoutControl1.Location = new System.Drawing.Point(0, 0);
         this.layoutControl1.Name = "layoutControl1";
         this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(723, 131, 250, 350);
         this.layoutControl1.Root = this.layoutControlGroup1;
         this.layoutControl1.Size = new System.Drawing.Size(531, 333);
         this.layoutControl1.TabIndex = 0;
         this.layoutControl1.Text = "layoutControl1";
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(413, 299);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(106, 22);
         this.btnCancel.StyleController = this.layoutControl1;
         this.btnCancel.TabIndex = 9;
         this.btnCancel.Text = "Отмена";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnOK
         // 
         this.btnOK.Location = new System.Drawing.Point(305, 299);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(104, 22);
         this.btnOK.StyleController = this.layoutControl1;
         this.btnOK.TabIndex = 8;
         this.btnOK.Text = "Восстановить";
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // labelDescr
         // 
         this.labelDescr.Location = new System.Drawing.Point(12, 252);
         this.labelDescr.Name = "labelDescr";
         this.labelDescr.Size = new System.Drawing.Size(12, 13);
         this.labelDescr.StyleController = this.layoutControl1;
         this.labelDescr.TabIndex = 7;
         this.labelDescr.Text = "...";
         // 
         // listBoxZipData
         // 
         this.listBoxZipData.Location = new System.Drawing.Point(12, 88);
         this.listBoxZipData.Name = "listBoxZipData";
         this.listBoxZipData.Size = new System.Drawing.Size(507, 160);
         this.listBoxZipData.StyleController = this.layoutControl1;
         this.listBoxZipData.TabIndex = 6;
         this.listBoxZipData.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxControl1_SelectedIndexChanged);
         // 
         // textEdit1
         // 
         this.textEdit1.Location = new System.Drawing.Point(120, 36);
         this.textEdit1.Name = "textEdit1";
         this.textEdit1.Size = new System.Drawing.Size(399, 20);
         this.textEdit1.StyleController = this.layoutControl1;
         this.textEdit1.TabIndex = 5;
         // 
         // btnEdit1
         // 
         this.btnEdit1.Location = new System.Drawing.Point(120, 12);
         this.btnEdit1.Name = "btnEdit1";
         this.btnEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
         this.btnEdit1.Size = new System.Drawing.Size(399, 20);
         this.btnEdit1.StyleController = this.layoutControl1;
         this.btnEdit1.TabIndex = 4;
         this.btnEdit1.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEdit1_ButtonPressed);
         // 
         // layoutControlGroup1
         // 
         this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
         this.layoutControlGroup1.GroupBordersVisible = false;
         this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem7});
         this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
         this.layoutControlGroup1.Name = "Root";
         this.layoutControlGroup1.Size = new System.Drawing.Size(531, 333);
         this.layoutControlGroup1.TextVisible = false;
         // 
         // layoutControlItem1
         // 
         this.layoutControlItem1.Control = this.btnEdit1;
         this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
         this.layoutControlItem1.Name = "layoutControlItem1";
         this.layoutControlItem1.Size = new System.Drawing.Size(511, 24);
         this.layoutControlItem1.Text = "Резервная копия";
         this.layoutControlItem1.TextSize = new System.Drawing.Size(105, 13);
         // 
         // layoutControlItem2
         // 
         this.layoutControlItem2.Control = this.textEdit1;
         this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
         this.layoutControlItem2.Name = "layoutControlItem2";
         this.layoutControlItem2.Size = new System.Drawing.Size(511, 24);
         this.layoutControlItem2.Text = "Описание архива";
         this.layoutControlItem2.TextSize = new System.Drawing.Size(105, 13);
         // 
         // layoutControlItem3
         // 
         this.layoutControlItem3.Control = this.listBoxZipData;
         this.layoutControlItem3.Location = new System.Drawing.Point(0, 76);
         this.layoutControlItem3.Name = "layoutControlItem3";
         this.layoutControlItem3.Size = new System.Drawing.Size(511, 164);
         this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem3.TextVisible = false;
         // 
         // layoutControlItem4
         // 
         this.layoutControlItem4.Control = this.labelDescr;
         this.layoutControlItem4.Location = new System.Drawing.Point(0, 240);
         this.layoutControlItem4.Name = "layoutControlItem4";
         this.layoutControlItem4.Size = new System.Drawing.Size(511, 17);
         this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem4.TextVisible = false;
         // 
         // layoutControlItem5
         // 
         this.layoutControlItem5.Control = this.btnOK;
         this.layoutControlItem5.Location = new System.Drawing.Point(293, 287);
         this.layoutControlItem5.Name = "layoutControlItem5";
         this.layoutControlItem5.Size = new System.Drawing.Size(108, 26);
         this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem5.TextVisible = false;
         // 
         // layoutControlItem6
         // 
         this.layoutControlItem6.Control = this.btnCancel;
         this.layoutControlItem6.Location = new System.Drawing.Point(401, 287);
         this.layoutControlItem6.Name = "layoutControlItem6";
         this.layoutControlItem6.Size = new System.Drawing.Size(110, 26);
         this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem6.TextVisible = false;
         // 
         // emptySpaceItem1
         // 
         this.emptySpaceItem1.AllowHotTrack = false;
         this.emptySpaceItem1.Location = new System.Drawing.Point(0, 257);
         this.emptySpaceItem1.Name = "emptySpaceItem1";
         this.emptySpaceItem1.Size = new System.Drawing.Size(511, 30);
         this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
         // 
         // emptySpaceItem2
         // 
         this.emptySpaceItem2.AllowHotTrack = false;
         this.emptySpaceItem2.Location = new System.Drawing.Point(0, 287);
         this.emptySpaceItem2.Name = "emptySpaceItem2";
         this.emptySpaceItem2.Size = new System.Drawing.Size(293, 26);
         this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
         // 
         // toggleSwitch1
         // 
         this.toggleSwitch1.Location = new System.Drawing.Point(120, 60);
         this.toggleSwitch1.Name = "toggleSwitch1";
         this.toggleSwitch1.Properties.OffText = "Выкл.";
         this.toggleSwitch1.Properties.OnText = "Вкл.";
         this.toggleSwitch1.Size = new System.Drawing.Size(399, 24);
         this.toggleSwitch1.StyleController = this.layoutControl1;
         this.toggleSwitch1.TabIndex = 10;
         // 
         // layoutControlItem7
         // 
         this.layoutControlItem7.Control = this.toggleSwitch1;
         this.layoutControlItem7.Location = new System.Drawing.Point(0, 48);
         this.layoutControlItem7.Name = "layoutControlItem7";
         this.layoutControlItem7.Size = new System.Drawing.Size(511, 28);
         this.layoutControlItem7.Text = "Режим олной замены";
         this.layoutControlItem7.TextSize = new System.Drawing.Size(105, 13);
         // 
         // RestoreBackupForm
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(531, 333);
         this.ControlBox = false;
         this.Controls.Add(this.layoutControl1);
         this.Name = "RestoreBackupForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Восстановить данные из резервной копии";
         this.Load += new System.EventHandler(this.RestoreBackupForm_Load);
         ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
         this.layoutControl1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.listBoxZipData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.btnEdit1.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraLayout.LayoutControl layoutControl1;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnOK;
      private DevExpress.XtraEditors.LabelControl labelDescr;
      private DevExpress.XtraEditors.CheckedListBoxControl listBoxZipData;
      private DevExpress.XtraEditors.TextEdit textEdit1;
      private DevExpress.XtraEditors.ButtonEdit btnEdit1;
      private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
      private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
      private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
      private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
   }
}