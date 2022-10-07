using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.CustomEditor;
using Svyaz.Model;
using Svyaz;

namespace Svyaz.CustomEditors {
   public partial class DataRateEditor : XtraUserControl {
      public event EventHandler RateChanged;    // изменилась скорость передачи данных 
      private DataRate rate;

      #region Properties
      /// <summary>
      /// Значение скорости передачи данных
      /// </summary>
      public DataRate Rate {
         get {
            DataRate rate = new DataRate();
            rate.Rate = RateEditor;
            rate.Unit = UnitEditor;
            return rate;
         }
         set { InitDataRateGUI(value);  }
      }

      /// <summary>
      /// Значение скорости (без ед. изм)
      /// </summary>
      public decimal RateEditor {
         get { return spinEditRate.Value; }
         private set { spinEditRate.Value = value; }
      }

      /// <summary>
      /// Выбранная ед. изм. 
      /// </summary>
      public ModernDataRateUnit UnitEditor {
         get { return (ModernDataRateUnit)comboUnit.SelectedIndex; }
         private set { comboUnit.SelectedIndex = (int)value; }
      }

      public bool ReadOnly{
         get { return spinEditRate.Properties.ReadOnly; }
         set { spinEditRate.Properties.ReadOnly = value; }
      }
      #endregion

      #region Ctors
      public DataRateEditor() {
         InitializeComponent();
         InitDataRateGUI(null);
      }
      #endregion

      #region Methods
      /// <summary>
      /// Иницализировать визуальные элементы отображающие значнеие скорости передачи данных
      /// </summary>
      private void InitDataRateGUI(DataRate rate) {
         if (rate == null)
            rate = new DataRate() { Rate = 0m, Unit = ModernDataRateUnit.kbps };
         RateEditor = rate.Rate;
         UnitEditor = rate.Unit;
      }
      #endregion

      #region Events
      /// <summary>
      /// Загружается элемент управления
      /// </summary>
      private void DataRateEditor_Load(object sender, EventArgs e) {

      }

      /// <summary>
      /// Изм. значение скорости передачи данных
      /// </summary>
      private void spinEditRate_EditValueChanged(object sender, EventArgs e) {
         EventHandler handler = RateChanged;
         if (handler != null)
            handler(this, new EventArgs());
      }

      /// <summary>
      /// Изменили ед. изменения скорости предачи данных
      /// </summary>
      private void comboUnit_SelectedIndexChanged(object sender, EventArgs e) {
         if (spinEditRate.Properties.ReadOnly) {
            rate.Unit = UnitEditor;
            RateEditor = rate.Rate;
         }
         EventHandler handler = RateChanged;
         if (handler != null)
            handler(this, new EventArgs());
      }

      /// <summary>
      /// Изменишли значение ед. изм.
      /// </summary>
      private void spinEditRate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e) {
         decimal val = -10;
         bool ok = decimal.TryParse(e.NewValue.ToString(), out val);
         if (!ok || val < 0)
            e.Cancel = true;
      }

      /// <summary>
      /// Перекл. режиим ReadOnly при клике средней кнопки мышки
      /// </summary>
      private void spinEditRate_Properties_MouseUp(object sender, MouseEventArgs e) {
         if (e.Button == System.Windows.Forms.MouseButtons.Middle) {
            ReadOnly = !ReadOnly;
            if (ReadOnly) {
               rate = Rate;
            }
         }
      }
      #endregion
   }
}
