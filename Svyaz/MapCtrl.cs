using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraMap;

namespace Svyaz {
   public partial class MapCtrl:DevExpress.XtraEditors.XtraUserControl {

      #region Ctors
      public MapCtrl() {
         InitializeComponent();
         this.Dock = DockStyle.Fill;
      }
      #endregion

      /// <summary>
      /// Загрузить зону покрытия Мегафон
      /// </summary>
      private void barToggleMegafon_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
         if(kmlFileDataAdapter1.FileUri == null) {
            kmlFileDataAdapter1.FileUri = new Uri(Application.StartupPath + "\\Data\\МегаФон.kml", UriKind.Absolute);
         }
         megafonKlmLayer.Visible = barToggleMegafon.Checked;
      }

      /// <summary>
      /// Загрузить зону покрытия Билайн
      /// </summary>
      private void barToggleBeeline_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
         if(kmlFileDataAdapter3.FileUri == null) {
            kmlFileDataAdapter3.FileUri = new Uri(Application.StartupPath + "\\Data\\ВымпелКом.kml", UriKind.Absolute);
         }
         beelineKlmLayer.Visible = barToggleBeeline.Checked;
      }

      /// <summary>
      /// Загрузить зону покрытия МТС
      /// </summary>
      private void barToggleMts_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
         if(kmlFileDataAdapter2.FileUri == null) {
            kmlFileDataAdapter2.FileUri = new Uri(Application.StartupPath + "\\Data\\МТС.kml", UriKind.Absolute);
         }
         mtsKlmLayer.Visible = barToggleMts.Checked;
      }
   }
}
