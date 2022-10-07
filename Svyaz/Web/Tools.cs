using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Web;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using DevExpress.XtraBars;
using System.Text.RegularExpressions;
using Svyaz;

namespace Util {
   /// <summary>
   /// Набор вспомогательных статических методов
   /// </summary>
   public static class Tools {
      #region delegates
      /// <summary>
      /// Делегат возращиющий самого себя (для потокобезопасного вызова самого себя)
      /// </summary>
      public delegate Control GetControlDelegate(Control ctrl);

      /// <summary>
      /// Делегат для изменения любого булевого свойства элемента упрвления
      /// </summary>
      public delegate void ChangeBoolPropertyDelegate(Control ctrl, bool value);

      /// <summary>
      /// Делегат для изменения любого текстового свойства элемента упрвления
      /// </summary>
      public delegate void ChangeStringPropertyDelegate(Control ctrl, string text);

      /// <summary>
      /// Делегат для изменения любого целочисленного свойства элемента упрвления
      /// </summary>
      public delegate void ChangeIntPropertyDelegate(Control ctrl, int value);

      /// <summary>
      /// Делегат для изменения цвета элемента упрвления
      /// </summary>
      public delegate void ChangeColorPropertyDelegate(Control ctrl, Color color);

      /// <summary>
      /// Делегат для изменения размера элемента упрвления
      /// </summary>
      public delegate void ChangeSizePropertyDelegate(Control ctrl, Size size);

      /// <summary>
      /// Делегат для изменения местоположения элемента упрвления
      /// </summary>
      public delegate void ChangeLocationPropertyDelegate(Control ctrl, Point point);

      /// <summary>
      /// Делегат для изменения значения свойства RightToLeft элемента упрвления
      /// </summary>
      public delegate void ChangeRightToLeftPropertyDelegate(Control ctrl, RightToLeft value);

      /// <summary>
      /// Делегат для потокобезопасного использования элемента управления
      /// </summary>
      public delegate void UseControlDeleagte(Control ctrl);

      /// <summary>
      /// Делегат для добавления элемента упрвления parentCtyrl.Add(childCtrl)
      /// </summary>
      /// <param name="parentCtrl">Родиттельский элемент управления </param>
      /// <param name="childCtrl">Дочерний элемент упрвления</param>
      public delegate void AddControlDelegate(Control parentCtrl, Control childCtrl);

      /// <summary>
      /// Делегат для потокобезопасной смены TabPage
      /// </summary>
      public delegate void SelectTabDelegate(TabControl tab, TabPage page);

      /// <summary>
      /// Делегат для потокобезопасной перепривязки самих данных к источнику данных
      /// </summary>
      /// <param name="ctrl">Элемент упрвления который исползует bindingSource</param>
      /// <param name="bindingSrc"></param>
      public delegate void ResetBindingDelegate(Control ctrl, BindingSource bindingSrc);

      /// <summary>
      /// Делегат для потокобезопасного изменения стиля прогресс бара
      /// </summary>
      /// <param name="bar">Элемент ProgressBar</param>
      /// <param name="style">стиль</param>
      public delegate void ChangeProgressBarStyleDelegate(ProgressBar bar, ProgressBarStyle style);

      /// <summary>
      /// Делегат для потокобезопасного изменения значения прогресс бара
      /// </summary>
      /// <param name="bar">Элемент ProgressBar</param>
      /// <param name="value">значение</param>
      public delegate void ChangeProgressBarValueDelegate(ProgressBar bar, int value);
      #endregion

      #region Static Safe Threads Methods
      /// <summary>
      /// Потокобезопасное изменение свойства Text для указанного Control'а
      /// </summary>
      public static void ChangeText(Control ctrl, string text) {
         if (ctrl.InvokeRequired) {
            ChangeStringPropertyDelegate del = new ChangeStringPropertyDelegate(ChangeText);
            ctrl.Invoke(del, ctrl, text);
         } else {
            ctrl.Text = text;
         }
      }

      /// <summary>
      /// Потокобезопасное изменение свойства Enabled для указанного Control'а
      /// </summary>
      public static void ChangeEnabled(Control ctrl, bool enabled) {
         if (ctrl.InvokeRequired) {
            ChangeBoolPropertyDelegate del = new ChangeBoolPropertyDelegate(ChangeEnabled);
            ctrl.Invoke(del, ctrl, enabled);
         } else {
            ctrl.Enabled = enabled;
         }
      }

      /// <summary>
      /// Потокобезопасное изменение свойства Visible для указанного Control'а
      /// </summary>
      public static void ChangeVisible(Control ctrl, bool visible) {
         if (ctrl.InvokeRequired) {
            ChangeBoolPropertyDelegate del = new ChangeBoolPropertyDelegate(ChangeVisible);
            ctrl.Invoke(del, new object[] { ctrl, visible });
         } else {
            ctrl.Visible = visible;
         }
      }

      /// <summary>
      /// Потокобезопасное изменение цвета для указанного Control'а
      /// </summary>
      public static void ChangeForeColor(Control ctrl, Color color) {
         if (ctrl.InvokeRequired) {
            ChangeColorPropertyDelegate del = new ChangeColorPropertyDelegate(ChangeForeColor);
            ctrl.Invoke(del, ctrl, color);
         } else {
            ctrl.ForeColor = color;
         }
      }

      /// <summary>
      /// Потокобезопасное изменение цвета для указанного Control'а
      /// </summary>
      public static void ChangeBackColor(Control ctrl, Color color) {
         if (ctrl.InvokeRequired) {
            ChangeColorPropertyDelegate del = new ChangeColorPropertyDelegate(ChangeBackColor);
            ctrl.Invoke(del, ctrl, color);
         } else {
            ctrl.BackColor = color;
         }
      }

      /// <summary>
      /// Потокобезопасное изменение размера для указанного Control'а
      /// </summary>
      public static void ChangeSize(Control ctrl, Size size) {
         if (ctrl.InvokeRequired) {
            ChangeSizePropertyDelegate del = new ChangeSizePropertyDelegate(ChangeSize);
            ctrl.Invoke(del, ctrl, size);
         } else {
            ctrl.Size = size;
         }
      }

      /// <summary>
      /// Потокобезопасное изменение ширины для указанного Control'а
      /// </summary>
      public static void ChangeWidth(Control ctrl, int width) {
         if (ctrl.InvokeRequired) {
            ChangeIntPropertyDelegate del = new ChangeIntPropertyDelegate(ChangeWidth);
            ctrl.Invoke(del, ctrl, width);
         } else {
            ctrl.Width = width;
         }
      }

      /// <summary>
      /// Потокобезопасное изменение местоположения для указанного Control'а
      /// </summary>
      public static void ChangeLocation(Control ctrl, Point location) {
         if (ctrl.InvokeRequired) {
            ChangeLocationPropertyDelegate del = new ChangeLocationPropertyDelegate(ChangeLocation);
            ctrl.Invoke(del, ctrl, location);
         } else {
            ctrl.Location = location;
         }
      }

      /// <summary>
      /// Потокобезопасное изменение свойства RightToLeft для указанного Control'а
      /// </summary>
      public static void ChangeRightToLeft(Control ctrl, RightToLeft value) {
         if (ctrl.InvokeRequired) {
            ChangeRightToLeftPropertyDelegate del = new ChangeRightToLeftPropertyDelegate(ChangeRightToLeft);
            ctrl.Invoke(del, ctrl, value);
         } else {
            ctrl.RightToLeft = value;
         }
      }

      /// <summary>
      /// Потокобезоасное удаление всех элементов управления (Controls)
      /// </summary>
      public static void ClearControls(Control ctrl) {
         if (ctrl.InvokeRequired) {
            UseControlDeleagte del = new UseControlDeleagte(ClearControls);
            ctrl.Invoke(del, ctrl);
         } else {
            ctrl.Controls.Clear();
            ;
         }
      }

      /// <summary>
      /// Потокобезоасное добавление дочернего элемента управления к родительскому
      /// </summary>
      public static void AddControl(Control parentCtrl, Control childCtrl) {

         if (parentCtrl.InvokeRequired) {
            AddControlDelegate del = new AddControlDelegate(AddControl);
            parentCtrl.Invoke(del, new object[] { parentCtrl, childCtrl });
         } else {
            parentCtrl.Controls.Add(childCtrl);
         }
      }

      /// <summary>
      /// Потокобезопасное установка фокуса для элемента упрвления
      /// </summary>
      public static void SelectControl(Control ctrl) {
         if (ctrl.InvokeRequired) {
            UseControlDeleagte del = new UseControlDeleagte(SelectControl);
            ctrl.Invoke(del, ctrl);
         } else {
            ctrl.Select();
         }
      }

      /// <summary>
      /// Потокобезопасное перерисовка элемента управления
      /// </summary>
      public static void InvalidateControl(Control ctrl) {
         if (ctrl.InvokeRequired) {
            UseControlDeleagte del = new UseControlDeleagte(ClearControls);
            ctrl.Invoke(del, ctrl);
         } else {
            ctrl.Invalidate(true);
         }
      }

      /// <summary>
      /// Потокобезопасная смена страницы в элементе упрвления TabControl
      /// </summary>
      public static void SelectTab(TabControl tab, TabPage page) {
         if (tab.InvokeRequired) {
            SelectTabDelegate del = new SelectTabDelegate(SelectTab);
            tab.Invoke(del, tab, page);
         } else {
            tab.SelectedTab = page;
         }
      }

      /// <summary>
      /// Потокобезопасная перепривязка данных к источнику
      /// </summary>
      /// <param name="ctrl">элемент упрвленя который использет источник данных</param>
      /// <param name="bindingSrc">сам источник данных</param>
      public static void ResetBindingSource(Control ctrl, BindingSource bindingSrc) {
         if (ctrl.InvokeRequired) {
            ResetBindingDelegate del = new ResetBindingDelegate(ResetBindingSource);
            ctrl.Invoke(del, ctrl, bindingSrc);
         } else {
            bindingSrc.ResetBindings(false);
         }
      }

      /// <summary>
      /// Потокобезопасная очистка набора данных привязанного к элементу упрвления
      /// </summary>
      /// <param name="ctrl">Элпемент упрвления к которому привязан (binding) набор данных</param>
      /// <param name="ds">Собственно набор данных</param>
      public static void ClearDataSet(Control ctrl, DataSet ds) {
         if (ctrl.InvokeRequired) {
            ctrl.Invoke((MethodInvoker)delegate { ds.Clear(); });
         } else {
            ds.Clear();
         }
      }

      /// <summary>
      /// Потокобезопасное слияние наборов данных
      /// </summary>
      /// <param name="ctrl">Элемент упрвления, к которому привязан исходный набор данных</param>
      /// <param name="dsSrc">исходный набор данных</param>
      /// <param name="dsTrg">набор данных, с котороым буем производить слияние</param>
      public static void MergeDataSet(Control ctrl, DataSet dsSrc, DataSet dsTrg) {
         if (ctrl.InvokeRequired) {
            ctrl.Invoke((MethodInvoker)delegate { dsSrc.Merge(dsTrg); });
         } else {
            dsSrc.Merge(dsTrg);
         }
      }

      /// <summary>
      /// Устарновить значение свойства Enabled для элемента контекстного меню формы
      /// </summary>
      public static void ChangeToolStripItemEnabled(Form f, ToolStripItem item, bool enabled) {
         if (f != null && f.InvokeRequired) {
            f.Invoke((MethodInvoker)delegate { item.Enabled = enabled; });
         } else {
            item.Enabled = enabled;
         }
      }

      /// <summary>
      /// Устарновить значение свойства Text для элемента ToolStripItem
      /// </summary>
      public static void ChangeToolStripItemText(Form f, ToolStripItem item, string text) {
         if (f != null && item != null && f.InvokeRequired) {
            f.Invoke((MethodInvoker)delegate { item.Text = text; });
         } else {
            item.Text = text;
         }
      }

      /// <summary>
      /// Устарновить значение свойства Caption для элемента BarStaticItem
      /// </summary>
      public static void ChangeBarStaticItemCaption(Control ctrl, BarStaticItem item, string text) {
         if (ctrl != null && item != null && ctrl.InvokeRequired) {
            ctrl.Invoke((MethodInvoker)delegate { item.Caption = text; });
         } else {
            item.Caption = text;
         }
      }

      /// <summary>
      /// Потокобезопасное удаление всех узлов в TreeView
      /// </summary>
      public static void ClearTreeViewNodes(Control tv) {
         if (tv.InvokeRequired) {
            UseControlDeleagte del = new UseControlDeleagte(ClearTreeViewNodes);
            tv.Invoke(del, tv);
         } else {
            TreeView treeView = tv as TreeView;
            if (treeView != null)
               treeView.Nodes.Clear();
         }
      }

      /// <summary>
      /// Потокобезопасное изменение свойства Style для указанного элемента ProgressBar
      /// </summary>
      public static void ChangeProgressBarStyle(ProgressBar bar, ProgressBarStyle style) {
         if (bar.InvokeRequired) {
            ChangeProgressBarStyleDelegate del = new ChangeProgressBarStyleDelegate(ChangeProgressBarStyle);
            bar.Invoke(del, bar, style);
         } else {
            bar.Style = style;
         }
      }

      /// <summary>
      /// Потокобезопасное изменение значения для указанного элемента ProgressBar
      /// </summary>
      public static void ChangeProgressBarValue(ProgressBar bar, int value) {
         if (bar.InvokeRequired) {
            ChangeProgressBarValueDelegate del = new ChangeProgressBarValueDelegate(ChangeProgressBarValue);
            bar.Invoke(del, bar, value);
         } else {
            bar.Value = value;
         }
      }

      /// <summary>
      /// Потокобезопасное добавление текста в RichTextBox
      /// </summary>
      public static void AppendTextRichTextBox(RichTextBox rtb, string text) {
         if (rtb.InvokeRequired) {
            ChangeStringPropertyDelegate del = new ChangeStringPropertyDelegate(ChangeText);
            rtb.Invoke(del, rtb, text);
         } else {
            rtb.AppendText(text);
         }
      }

      /// <summary>
      /// Потокобезопасная очистка текста в RichTextBox
      /// </summary>
      public static void ClearRichtextBox(RichTextBox rtb) {
         if (rtb.InvokeRequired) {
            UseControlDeleagte del = new UseControlDeleagte(ClearControls);
            rtb.Invoke(del, rtb);
         } else {
            rtb.Clear();
         }
      }

      /// <summary>
      /// Потокобезопасная установка свойства Checked в CheckBox
      /// </summary>
      public static void CheckedCheckBox(CheckBox checkBox, bool value) {
         if (checkBox.InvokeRequired) {
            checkBox.Invoke((MethodInvoker)delegate { checkBox.Checked = value; });
         } else {
            checkBox.Checked = value;
         }
      }
      #endregion

      #region Static Methods
      /// <summary>
      /// Получить размер текста в элементе упрвления
      /// </summary>
      static public SizeF GetSizeControllText(Control ctrl) {
         Graphics g = ctrl.CreateGraphics();
         SizeF size = g.MeasureString(ctrl.Text, ctrl.Font);
         g.Dispose();
         g = null;
         return size;
      }

      /***************************************************************************************************
       *  int listenerId = Trace.Listeners.Add(new TextWriterTraceListener("xyz.log"));
       *  Trace.AutoFlush = true;
       * ************************************************************************************************/
      /// <summary>
      /// Записать сообщение в лог
      /// </summary>
      internal static void WriteLog(string Msg) {
         DateTime now = DateTime.Now;
         string txt = string.Format("{0} {1}", now, Msg);
         Trace.WriteLine(txt);
      }

      #endregion

      /// <summary>
      /// Создать параметр callback -  для выполнения запросов в tune.yandex.ru/region/
      /// </summary>
      public static string createCallback() {
         string callback = "jQuery";
         callback += getJQueryVersion();
         string random = getRandom();
         callback += random;
         callback = callback.Replace(".", "");
         return callback;
      }

      /// <summary>
      /// Псевдослучайное число в виде строки в диапазоне 0 - 1
      /// </summary>
      private static string getRandom() {
         Random random = new Random();
         double retval = random.NextDouble();
         return retval.ToString(CultureInfo.InvariantCulture);
      }

      /// <summary>
      /// Вернуть версию библиотеки jQuery, используемой в Yandex Market 
      /// </summary>
      /// <returns></returns>
      public static string getJQueryVersion() {
         return "1.6.2";
      }

      /// <summary>
      /// Значение времени в мСек, начиная с 01.01.1970
      /// аналог getTime из jscript
      /// </summary>
      public static long getTime() {
         DateTime first = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
         TimeSpan time = DateTime.UtcNow.Subtract(first);
         return (long)time.TotalMilliseconds;
      }

      public static bool BoolFromString(string td) {
         return (td == "да") ? true : false;
      }

      public static int IntFromString(string td) {
         int result = 0;
         bool ok = Int32.TryParse(td, out result);
         return (ok) ? result : 0;
      }

      /// <summary>
      /// Вернуть URL на страницу доступности услуг  связи для указанного населенного пункта
      /// </summary>
      /// <param name="localityId">код населенного пункта в реестре связи Роскомнадзора</param>
      /// <returns></returns>
      public static string GetReestrSvyazUrl(int localityId) {
         string url = string.Format("http://reestr-svyaz.rkn.gov.ru/place/{0}.htm", localityId);
         return url;
      }

      /// <summary>
      /// Убрать из наименования оператора форму собственности (ЗАО, ПАО АО) и ковычки
      /// </summary>
      /// <param name="srcOperator">наименование оператора связи полученное с сайта роскомнадзора</param>
      public static string ClearOperatorName(string srcOperator) {
         string dstOperator = srcOperator;
         string pattern = "^(.*?)\\s+\"?(.*?)\"?$";
         Regex regex = new Regex(pattern, RegexOptions.Multiline);
         Match match = regex.Match(srcOperator);
         dstOperator = match.Groups[2].Value;
         dstOperator = dstOperator.Replace("ТелеКом", "Телеком");
         dstOperator = dstOperator.Replace("\"", "");
         dstOperator = dstOperator.Replace("«", "");
         dstOperator = dstOperator.Replace("»", "");
         dstOperator = dstOperator.Trim();

         return dstOperator;
      }


      /// <summary>
      /// Преобразовать строковое значение типа GSM в элемент перечисления GsmType
      /// </summary>
      public static GsmType GsmTypeFromString(string str) {
         if (str == "1800, 900/1800")
            return GsmType.Gsm_1800_900_1800;
         if (str == "1800")
            return GsmType.Gsm_1800;
         if (str == "900/1800")
            return GsmType.Gsm_900_1800;
         return GsmType.None;
      }

   }
}
