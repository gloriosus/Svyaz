namespace Svyaz {
   partial class MapCtrl {
      /// <summary> 
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if(disposing && (components != null)) {
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
         this.barManager1 = new DevExpress.XtraBars.BarManager();
         this.bar1 = new DevExpress.XtraBars.Bar();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.mapControl1 = new DevExpress.XtraMap.MapControl();
         this.osmLayer = new DevExpress.XtraMap.ImageLayer();
         this.openStreetMapDataProvider1 = new DevExpress.XtraMap.OpenStreetMapDataProvider();
         this.megafonKlmLayer = new DevExpress.XtraMap.VectorItemsLayer();
         this.kmlFileDataAdapter1 = new DevExpress.XtraMap.KmlFileDataAdapter();
         this.mtsKlmLayer = new DevExpress.XtraMap.VectorItemsLayer();
         this.kmlFileDataAdapter2 = new DevExpress.XtraMap.KmlFileDataAdapter();
         this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
         this.barToggleMegafon = new DevExpress.XtraBars.BarToggleSwitchItem();
         this.barToggleBeeline = new DevExpress.XtraBars.BarToggleSwitchItem();
         this.barToggleMts = new DevExpress.XtraBars.BarToggleSwitchItem();
         this.beelineKlmLayer = new DevExpress.XtraMap.VectorItemsLayer();
         this.kmlFileDataAdapter3 = new DevExpress.XtraMap.KmlFileDataAdapter();
         ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).BeginInit();
         this.SuspendLayout();
         // 
         // barManager1
         // 
         this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
         this.barManager1.DockControls.Add(this.barDockControlTop);
         this.barManager1.DockControls.Add(this.barDockControlBottom);
         this.barManager1.DockControls.Add(this.barDockControlLeft);
         this.barManager1.DockControls.Add(this.barDockControlRight);
         this.barManager1.Form = this;
         this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barCheckItem1,
            this.barToggleMegafon,
            this.barToggleBeeline,
            this.barToggleMts});
         this.barManager1.MaxItemId = 6;
         // 
         // bar1
         // 
         this.bar1.BarName = "Tools";
         this.bar1.DockCol = 0;
         this.bar1.DockRow = 0;
         this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barToggleMegafon),
            new DevExpress.XtraBars.LinkPersistInfo(this.barToggleBeeline),
            new DevExpress.XtraBars.LinkPersistInfo(this.barToggleMts)});
         this.bar1.OptionsBar.UseWholeRow = true;
         this.bar1.Text = "Tools";
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Manager = this.barManager1;
         this.barDockControlTop.Size = new System.Drawing.Size(685, 33);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 608);
         this.barDockControlBottom.Manager = this.barManager1;
         this.barDockControlBottom.Size = new System.Drawing.Size(685, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 33);
         this.barDockControlLeft.Manager = this.barManager1;
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 575);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(685, 33);
         this.barDockControlRight.Manager = this.barManager1;
         this.barDockControlRight.Size = new System.Drawing.Size(0, 575);
         // 
         // mapControl1
         // 
         this.mapControl1.CenterPoint = new DevExpress.XtraMap.GeoPoint(48.79284D, 132.91998D);
         this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.mapControl1.Layers.Add(this.osmLayer);
         this.mapControl1.Layers.Add(this.megafonKlmLayer);
         this.mapControl1.Layers.Add(this.mtsKlmLayer);
         this.mapControl1.Layers.Add(this.beelineKlmLayer);
         this.mapControl1.Location = new System.Drawing.Point(0, 33);
         this.mapControl1.Name = "mapControl1";
         this.mapControl1.NavigationPanelOptions.ShowMilesScale = false;
         this.mapControl1.Size = new System.Drawing.Size(685, 575);
         this.mapControl1.TabIndex = 4;
         this.mapControl1.ZoomLevel = 9D;
         this.osmLayer.DataProvider = this.openStreetMapDataProvider1;
         this.osmLayer.MinZoomLevel = 8;
         this.megafonKlmLayer.Data = this.kmlFileDataAdapter1;
         this.megafonKlmLayer.Name = "Мегафон";
         this.megafonKlmLayer.Visible = false;
         this.kmlFileDataAdapter1.FileUri = new System.Uri("C:\\Users\\Bobylev\\Source\\Repos\\Svyaz\\Svyaz\\Data\\МегаФон.kml", System.UriKind.Absolute);
         this.mtsKlmLayer.Data = this.kmlFileDataAdapter2;
         this.mtsKlmLayer.Name = "МТС";
         this.mtsKlmLayer.Visible = false;
         this.kmlFileDataAdapter2.FileUri = new System.Uri("C:\\Users\\Bobylev\\Source\\Repos\\Svyaz\\Svyaz\\Data\\МТС.kml", System.UriKind.Absolute);
         // 
         // barCheckItem1
         // 
         this.barCheckItem1.Caption = "Мегафон";
         this.barCheckItem1.Id = 0;
         this.barCheckItem1.Name = "barCheckItem1";
         // 
         // barToggleMegafon
         // 
         this.barToggleMegafon.Caption = "Мегафон";
         this.barToggleMegafon.Id = 3;
         this.barToggleMegafon.Name = "barToggleMegafon";
         this.barToggleMegafon.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barToggleMegafon_CheckedChanged);
         // 
         // barToggleBeeline
         // 
         this.barToggleBeeline.Caption = "Билайн";
         this.barToggleBeeline.Id = 4;
         this.barToggleBeeline.Name = "barToggleBeeline";
         this.barToggleBeeline.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barToggleBeeline_CheckedChanged);
         // 
         // barToggleMts
         // 
         this.barToggleMts.Caption = "МТС";
         this.barToggleMts.Id = 5;
         this.barToggleMts.Name = "barToggleMts";
         this.barToggleMts.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barToggleMts_CheckedChanged);
         this.beelineKlmLayer.Data = this.kmlFileDataAdapter3;
         this.beelineKlmLayer.Name = "Билайн";
         // 
         // MapCtrl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.mapControl1);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Name = "MapCtrl";
         this.Size = new System.Drawing.Size(685, 608);
         ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.BarManager barManager1;
      private DevExpress.XtraBars.Bar bar1;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraMap.MapControl mapControl1;
      private DevExpress.XtraMap.ImageLayer osmLayer;
      private DevExpress.XtraMap.OpenStreetMapDataProvider openStreetMapDataProvider1;
      private DevExpress.XtraMap.VectorItemsLayer megafonKlmLayer;
      private DevExpress.XtraMap.KmlFileDataAdapter kmlFileDataAdapter1;
      private DevExpress.XtraMap.VectorItemsLayer mtsKlmLayer;
      private DevExpress.XtraMap.KmlFileDataAdapter kmlFileDataAdapter2;
      private DevExpress.XtraBars.BarCheckItem barCheckItem1;
      private DevExpress.XtraBars.BarToggleSwitchItem barToggleMegafon;
      private DevExpress.XtraBars.BarToggleSwitchItem barToggleBeeline;
      private DevExpress.XtraBars.BarToggleSwitchItem barToggleMts;
      private DevExpress.XtraMap.VectorItemsLayer beelineKlmLayer;
      private DevExpress.XtraMap.KmlFileDataAdapter kmlFileDataAdapter3;
   }
}
