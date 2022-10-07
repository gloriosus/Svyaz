namespace Svyaz.CustomEditors {
   partial class DataRateEditor {
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
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.spinEditRate = new DevExpress.XtraEditors.SpinEdit();
         this.comboUnit = new DevExpress.XtraEditors.ComboBoxEdit();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spinEditRate.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.comboUnit.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.ColumnCount = 2;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
         this.tableLayoutPanel1.Controls.Add(this.spinEditRate, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.comboUnit, 1, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 1;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(98, 20);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // spinEditRate
         // 
         this.spinEditRate.Dock = System.Windows.Forms.DockStyle.Fill;
         this.spinEditRate.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.spinEditRate.Location = new System.Drawing.Point(0, 0);
         this.spinEditRate.Margin = new System.Windows.Forms.Padding(0);
         this.spinEditRate.Name = "spinEditRate";
         this.spinEditRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spinEditRate.Properties.DisplayFormat.FormatString = "###0";
         this.spinEditRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.spinEditRate.Properties.EditFormat.FormatString = "###0";
         this.spinEditRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.spinEditRate.Properties.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this.spinEditRate.Properties.Mask.EditMask = "####0";
         this.spinEditRate.Properties.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spinEditRate_Properties_MouseUp);
         this.spinEditRate.Size = new System.Drawing.Size(48, 20);
         this.spinEditRate.TabIndex = 0;
         this.spinEditRate.EditValueChanged += new System.EventHandler(this.spinEditRate_EditValueChanged);
         this.spinEditRate.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.spinEditRate_EditValueChanging);
         // 
         // comboUnit
         // 
         this.comboUnit.Dock = System.Windows.Forms.DockStyle.Fill;
         this.comboUnit.Location = new System.Drawing.Point(49, 0);
         this.comboUnit.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
         this.comboUnit.Name = "comboUnit";
         this.comboUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.comboUnit.Properties.Items.AddRange(new object[] {
            "отсутствует",
            "б/с",
            "Кб/с",
            "Мб/с",
            "Гб/с",
            "Тб/с"});
         this.comboUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
         this.comboUnit.Size = new System.Drawing.Size(49, 20);
         this.comboUnit.TabIndex = 1;
         this.comboUnit.SelectedIndexChanged += new System.EventHandler(this.comboUnit_SelectedIndexChanged);
         // 
         // DataRateEditor
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tableLayoutPanel1);
         this.Name = "DataRateEditor";
         this.Size = new System.Drawing.Size(98, 20);
         this.Load += new System.EventHandler(this.DataRateEditor_Load);
         this.tableLayoutPanel1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.spinEditRate.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.comboUnit.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private DevExpress.XtraEditors.SpinEdit spinEditRate;
      private DevExpress.XtraEditors.ComboBoxEdit comboUnit;

   }
}
