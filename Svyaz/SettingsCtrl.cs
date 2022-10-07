using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Svyaz {
   public partial class SettingsCtrl : XtraUserControl {
      #region Properties
      /// <summary>
      /// Использовать http прокси
      /// </summary>
      public bool UseProxy {
         get { return checkUseProxy.Checked; }
         set { checkUseProxy.Checked = value; }
      }

      /// <summary>
      /// адрес http прокси
      /// </summary>
      public string ProxyAddress {
         get { return textProxyAddress.Text; }
         set { textProxyAddress.Text = value; }
      }

      /// <summary>
      /// порт http прокси
      /// </summary>
      public int ProxyPort {
         get { return Convert.ToInt32(textProxyPort.Text); }
         set { textProxyPort.Text = value.ToString(); }
      }
      #endregion

      #region Constructors
      public SettingsCtrl() {
         InitializeComponent();
         this.Dock = DockStyle.Fill;
      }
      #endregion

      #region Methods
      /// <summary>
      /// Обновить доступность элементов интерфейса
      /// </summary>
      private void UpdateUI() {
         layoutItemProxy.Enabled = UseProxy;
         layoutItemPort.Enabled = UseProxy;
      }
      #endregion

      #region Events
      private void SettingsCtrl_Load(object sender, EventArgs e) {
         UpdateUI();
         UseProxy = Svyaz.Properties.Settings.Default.UseProxy;
         ProxyAddress = Svyaz.Properties.Settings.Default.ProxyAddress;
         ProxyPort = Svyaz.Properties.Settings.Default.ProxyPort;
      }

      private void checkUseProxy_CheckedChanged(object sender, EventArgs e) {
         UpdateUI();
      }

      private void btnSave_Click(object sender, EventArgs e) {
         Svyaz.Properties.Settings.Default.UseProxy = UseProxy;
         Svyaz.Properties.Settings.Default.Save();
      }
      #endregion
   }
}
