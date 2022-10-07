namespace Svyaz {
   partial class SettingsCtrl {
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
         this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
         this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
         this.textProxyPort = new DevExpress.XtraEditors.TextEdit();
         this.layoutItemPort = new DevExpress.XtraLayout.LayoutControlItem();
         this.textProxyAddress = new DevExpress.XtraEditors.TextEdit();
         this.layoutItemProxy = new DevExpress.XtraLayout.LayoutControlItem();
         this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
         this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
         this.btnSave = new DevExpress.XtraEditors.SimpleButton();
         this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
         this.checkUseProxy = new DevExpress.XtraEditors.CheckEdit();
         this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
         this.layoutControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textProxyPort.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutItemPort)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textProxyAddress.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutItemProxy)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkUseProxy.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
         this.SuspendLayout();
         // 
         // layoutControl1
         // 
         this.layoutControl1.Controls.Add(this.checkUseProxy);
         this.layoutControl1.Controls.Add(this.btnSave);
         this.layoutControl1.Controls.Add(this.textProxyAddress);
         this.layoutControl1.Controls.Add(this.textProxyPort);
         this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.layoutControl1.Location = new System.Drawing.Point(0, 0);
         this.layoutControl1.Name = "layoutControl1";
         this.layoutControl1.Root = this.layoutControlGroup1;
         this.layoutControl1.Size = new System.Drawing.Size(397, 415);
         this.layoutControl1.TabIndex = 0;
         this.layoutControl1.Text = "layoutControl1";
         // 
         // layoutControlGroup1
         // 
         this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
         this.layoutControlGroup1.GroupBordersVisible = false;
         this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutItemPort,
            this.layoutItemProxy,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem4});
         this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
         this.layoutControlGroup1.Name = "layoutControlGroup1";
         this.layoutControlGroup1.Size = new System.Drawing.Size(397, 415);
         this.layoutControlGroup1.TextVisible = false;
         // 
         // textProxyPort
         // 
         this.textProxyPort.EditValue = "8080";
         this.textProxyPort.Location = new System.Drawing.Point(129, 59);
         this.textProxyPort.Name = "textProxyPort";
         this.textProxyPort.Size = new System.Drawing.Size(256, 20);
         this.textProxyPort.StyleController = this.layoutControl1;
         this.textProxyPort.TabIndex = 4;
         // 
         // layoutItemPort
         // 
         this.layoutItemPort.Control = this.textProxyPort;
         this.layoutItemPort.Location = new System.Drawing.Point(0, 47);
         this.layoutItemPort.Name = "layoutItemPort";
         this.layoutItemPort.Size = new System.Drawing.Size(377, 24);
         this.layoutItemPort.Text = "Порт:";
         this.layoutItemPort.TextSize = new System.Drawing.Size(113, 13);
         // 
         // textProxyAddress
         // 
         this.textProxyAddress.EditValue = "192.168.33.212";
         this.textProxyAddress.Location = new System.Drawing.Point(129, 35);
         this.textProxyAddress.Name = "textProxyAddress";
         this.textProxyAddress.Size = new System.Drawing.Size(256, 20);
         this.textProxyAddress.StyleController = this.layoutControl1;
         this.textProxyAddress.TabIndex = 5;
         // 
         // layoutItemProxy
         // 
         this.layoutItemProxy.Control = this.textProxyAddress;
         this.layoutItemProxy.Location = new System.Drawing.Point(0, 23);
         this.layoutItemProxy.Name = "layoutItemProxy";
         this.layoutItemProxy.Size = new System.Drawing.Size(377, 24);
         this.layoutItemProxy.Text = "HTTP прокси:";
         this.layoutItemProxy.TextSize = new System.Drawing.Size(113, 13);
         // 
         // emptySpaceItem1
         // 
         this.emptySpaceItem1.AllowHotTrack = false;
         this.emptySpaceItem1.Location = new System.Drawing.Point(0, 71);
         this.emptySpaceItem1.Name = "emptySpaceItem1";
         this.emptySpaceItem1.Size = new System.Drawing.Size(377, 298);
         this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
         // 
         // emptySpaceItem2
         // 
         this.emptySpaceItem2.AllowHotTrack = false;
         this.emptySpaceItem2.Location = new System.Drawing.Point(0, 369);
         this.emptySpaceItem2.Name = "emptySpaceItem2";
         this.emptySpaceItem2.Size = new System.Drawing.Size(284, 26);
         this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(296, 381);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(89, 22);
         this.btnSave.StyleController = this.layoutControl1;
         this.btnSave.TabIndex = 6;
         this.btnSave.Text = "Сохранить";
         this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // layoutControlItem3
         // 
         this.layoutControlItem3.Control = this.btnSave;
         this.layoutControlItem3.Location = new System.Drawing.Point(284, 369);
         this.layoutControlItem3.MaxSize = new System.Drawing.Size(93, 26);
         this.layoutControlItem3.MinSize = new System.Drawing.Size(93, 26);
         this.layoutControlItem3.Name = "layoutControlItem3";
         this.layoutControlItem3.Size = new System.Drawing.Size(93, 26);
         this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem3.TextVisible = false;
         // 
         // checkUseProxy
         // 
         this.checkUseProxy.Location = new System.Drawing.Point(129, 12);
         this.checkUseProxy.Name = "checkUseProxy";
         this.checkUseProxy.Properties.Caption = "";
         this.checkUseProxy.Size = new System.Drawing.Size(256, 19);
         this.checkUseProxy.StyleController = this.layoutControl1;
         this.checkUseProxy.TabIndex = 7;
         this.checkUseProxy.CheckedChanged += new System.EventHandler(this.checkUseProxy_CheckedChanged);
         // 
         // layoutControlItem4
         // 
         this.layoutControlItem4.Control = this.checkUseProxy;
         this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
         this.layoutControlItem4.Name = "layoutControlItem4";
         this.layoutControlItem4.Size = new System.Drawing.Size(377, 23);
         this.layoutControlItem4.Text = "Использовать прокси:";
         this.layoutControlItem4.TextSize = new System.Drawing.Size(113, 13);
         // 
         // SettingsCtrl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.layoutControl1);
         this.Name = "SettingsCtrl";
         this.Size = new System.Drawing.Size(397, 415);
         this.Load += new System.EventHandler(this.SettingsCtrl_Load);
         ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
         this.layoutControl1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textProxyPort.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutItemPort)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textProxyAddress.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutItemProxy)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkUseProxy.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraLayout.LayoutControl layoutControl1;
      private DevExpress.XtraEditors.CheckEdit checkUseProxy;
      private DevExpress.XtraEditors.SimpleButton btnSave;
      private DevExpress.XtraEditors.TextEdit textProxyAddress;
      private DevExpress.XtraEditors.TextEdit textProxyPort;
      private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
      private DevExpress.XtraLayout.LayoutControlItem layoutItemPort;
      private DevExpress.XtraLayout.LayoutControlItem layoutItemProxy;
      private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
      private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;

   }
}
