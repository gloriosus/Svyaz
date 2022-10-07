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
using Svyaz.Model;
using DevExpress.XtraLayout;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010;

namespace Svyaz {
   public partial class ComSrvCtrl : DevExpress.XtraEditors.XtraUserControl {
      private const int FlyoutLen = 116;        // длина строки в FlyoutPanel
      private CommunicationService commSrv;
      private DataSrc dataSrc;

      /// <summary>
      /// Доступность услуг связи
      /// </summary>
      public CommunicationService CommSrv {
         get { return commSrv; }
         set {
            commSrv = value;
            BindingData();
         }
      }

      #region Ctors
      public ComSrvCtrl() {
         InitializeComponent();
         dataSrc = DataSrc.OpenData;
      }
      #endregion

      #region Methods
      /// <summary>
      /// Выполнить привязку данных
      /// </summary>
      private void BindingData() {
         if (commSrv == null)
            return;
         //-- телефонная связь и услуги передачи данных
         togglePhone.EditValue = commSrv.PhoneOn;
         spinPayphoneCount.EditValue = commSrv.PayphoneCount;
         toggleIntraZonePhone.EditValue = commSrv.IntraZonePhoneOn;
         toggleLongDistancePhone.EditValue = commSrv.LongDistancePhoneOn;
         toggleDataTransfer.EditValue = commSrv.DataTransferOn;
         toggleTelematicService.EditValue = commSrv.TelematicServiceOn;
         //-- сотовая связь и мобильный интернет
         textGSM.EditValue = GsmTypeToString(commSrv.GsmOn);
         toggleUMTS.EditValue = commSrv.UmtsOn;
         toggleLTE.EditValue = commSrv.LteOn;
         toggleNMT.EditValue = commSrv.NmtOn;
         toggleCDMA.EditValue = commSrv.CdmaOn;
         //-- Телевидение и радиовещание
         toggleTv.EditValue = commSrv.TvOn;
         spinDigitalChanelCount.EditValue = commSrv.DigitalChanelCount;
         spinAnalogChanelCount.EditValue = commSrv.AnalogChanelCount;
         toggleBroadcasting.EditValue = commSrv.BroadcastingOn;
         spinDigitalChanelCount2.EditValue = commSrv.DigitalChanelCount2;
         spinAnalogChanelCount2.EditValue = commSrv.AnalogChanelCount2;
         spinCabelChanelCount.EditValue = commSrv.CabelChanelCount;
         //-- Почтовая связь
         togglePost.EditValue = commSrv.PostOn;
         spinPostCount.EditValue = commSrv.PostCount;
         spinPostOfficeCount.EditValue = commSrv.PostOfficeCount;
         spinPayphoneCount2.EditValue = commSrv.PayphoneCount2;
         //-- универсальные услуги связи
         spinCapsCount.EditValue = commSrv.CapsCount;
         spinCapsJobCount.EditValue = commSrv.CapsJobCount;
         toggleAccessPoint.EditValue = commSrv.AccessPointOn;
         spinAccessPointCount.EditValue = commSrv.AccessPointCount;
      }

      private static string GsmTypeToString(GsmType gt) {
         switch (gt) {
            case GsmType.Gsm_900_1800:
               return "900/1800";
            case GsmType.Gsm_1800:
               return "1800";
            case GsmType.Gsm_1800_900_1800:
               return "1800, 900/1800";
            case GsmType.None:
               return "Отсутствует";
            default:
               return "Отсутствует";
         }
      }

      /// <summary>
      /// Настроить возможность изменения данных пользователем
      /// </summary>
      public void EnableEditData(DataSrc DataSrc) {
         dataSrc = DataSrc.OpenData;
         bool ok = (DataSrc == DataSrc.OpenData) ? true : false;
         togglePhone.Properties.ReadOnly = ok;
         // телефонная связь и услуги передачи данных
         spinPayphoneCount.Properties.ReadOnly = ok;
         toggleIntraZonePhone.Properties.ReadOnly = ok;
         toggleLongDistancePhone.Properties.ReadOnly = ok;
         toggleDataTransfer.Properties.ReadOnly = ok;
         toggleTelematicService.Properties.ReadOnly = ok;
         // Сотовая связь и мобильный интернет
         textGSM.Properties.ReadOnly = ok;
         toggleUMTS.Properties.ReadOnly = ok;
         toggleLTE.Properties.ReadOnly = ok;
         toggleNMT.Properties.ReadOnly = ok;
         toggleCDMA.Properties.ReadOnly = ok;
         // Телевидение и радиовещание
         toggleTv.Properties.ReadOnly = ok;
         spinDigitalChanelCount.Properties.ReadOnly = ok;
         spinAnalogChanelCount.Properties.ReadOnly = ok;
         toggleBroadcasting.Properties.ReadOnly = ok;
         spinDigitalChanelCount2.Properties.ReadOnly = ok;
         spinAnalogChanelCount2.Properties.ReadOnly = ok;
         // Почтовая связь
         togglePost.Properties.ReadOnly = ok;
         spinPostCount.Properties.ReadOnly = ok;
         spinPostOfficeCount.Properties.ReadOnly = ok;
         spinPayphoneCount2.Properties.ReadOnly = ok;
         // Универсальные услуги связи
         spinCapsCount.Properties.ReadOnly = ok;
         spinCapsJobCount.Properties.ReadOnly = ok;
         toggleAccessPoint.Properties.ReadOnly = ok;
         spinAccessPointCount.Properties.ReadOnly = ok;
      }

      /// <summary>
      /// Сохранить изменения
      /// </summary>
      public void Save() {
         throw new NotImplementedException();
      }

      private Point GetHotPoint(Control ctrl) {
         Point pt = ctrl.PointToScreen(new Point(ctrl.Width / 2, 0));
         return pt;
      }

      /// <summary>
      /// Создать 2 кнопки во всплывающей панели
      /// </summary>
      private void Create2Buttons(FlyoutPanel fly, string btn1Caption = "Оператор") {
         System.ComponentModel.ComponentResourceManager resources = new ComponentResourceManager(typeof(ComSrvCtrl));
         int btn1Len = FlyoutLen;      // ширина 1-й кнопки
         btn1Caption = CreateBtnCaption(btn1Caption, HorizontalAlignment.Left, btn1Len);

         // пересоздать кнопки
         fly.OptionsButtonPanel.Buttons.Clear();
         fly.OptionsButtonPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.Utils.PeekFormButton("Оператор", "", DevExpress.XtraEditors.ButtonPanel.ImageLocation.Default, ButtonStyle.PushButton, "", true, -1, true, null, true, false, true, null, null, -1, true),
            new DevExpress.Utils.PeekFormButton("Закрыть", ((System.Drawing.Image)(resources.GetObject("flyoutPanel2.OptionsButtonPanel.Buttons"))), false, true, "")});

      }

      /// <summary>
      /// Создать 3 кнопки во всплывающей панели
      /// </summary>
      private void Create3Buttons(FlyoutPanel fly, string btn1Caption, string btn2Caption) {
         System.ComponentModel.ComponentResourceManager resources = new ComponentResourceManager(typeof(ComSrvCtrl));
         int btn1Len = 115;  // ширина 1-й кнопки
         int btn2Len = 16;   // ширина 2-й кнопки

         btn1Caption = CreateBtnCaption(btn1Caption, HorizontalAlignment.Left, btn1Len);
         btn2Caption = CreateBtnCaption(btn2Caption, HorizontalAlignment.Right, btn2Len);

         // пересоздать  кнопки
         fly.OptionsButtonPanel.Buttons.Clear();
         this.flyoutPanel2.OptionsButtonPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.Utils.PeekFormButton("Оператор", "", DevExpress.XtraEditors.ButtonPanel.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", true, -1, true, null, true, false, true, null, null, -1, true),
            new DevExpress.Utils.PeekFormButton(btn2Caption, null),
            new DevExpress.Utils.PeekFormButton("Закрыть", ((System.Drawing.Image)(resources.GetObject("flyoutPanel2.OptionsButtonPanel.Buttons"))), false, true, "")});
      }

      /// <summary>
      /// Создать на всплывающей панели 4 кнопки
      /// </summary>
      private void Create4Buttons(FlyoutPanel fly, string btn1Caption, int btn1Len, string btn2Caption, int btn2Len, string btn3Caption, int btn3Len) {
         System.ComponentModel.ComponentResourceManager resources = new ComponentResourceManager(typeof(ComSrvCtrl));
         btn1Caption = CreateBtnCaption(btn1Caption, HorizontalAlignment.Left, btn1Len);
         btn2Caption = CreateBtnCaption(btn2Caption, HorizontalAlignment.Left, btn2Len);
         btn3Caption = CreateBtnCaption(btn3Caption, HorizontalAlignment.Right, btn3Len);

         // пересоздать кнопки
         fly.OptionsButtonPanel.Buttons.Clear();
         fly.OptionsButtonPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.Utils.PeekFormButton(btn1Caption, null),
            new DevExpress.Utils.PeekFormButton(btn2Caption, null),
            new DevExpress.Utils.PeekFormButton(btn3Caption, null),
            new DevExpress.Utils.PeekFormButton("Закрыть", ((System.Drawing.Image)(resources.GetObject("flyoutPanel2.OptionsButtonPanel.Buttons"))), false, true, "")});
      }

      /// <summary>
      /// Создать заголовок кнопки FlyoutPanel
      /// </summary>
      /// <param name="text">текст</param>
      /// <param name="horizontalAlignment">выравнивание</param>
      /// <param name="len">Ширина кнопки</param>
      private static string CreateBtnCaption(string text, HorizontalAlignment horizontalAlignment, int len) {
         int spaceCount = len - text.Length;
         string caption = "";
         if (horizontalAlignment == HorizontalAlignment.Left)
            caption += text + new string(' ', spaceCount);
         else if (horizontalAlignment == HorizontalAlignment.Right)
            caption += new string(' ', spaceCount) + text;
         else {
            int spaceBefore = spaceCount / 2;
            int spaceAfter = spaceCount - spaceBefore;
            caption = new string(' ', spaceBefore) + text + new string(' ', spaceAfter);
         }
         return caption;
      }
      #endregion

      #region Events

      private void ComSrvCtrl_Load(object sender, EventArgs e) {
      }

      private void flyoutPanel2_ButtonClick(object sender, DevExpress.Utils.FlyoutPanelButtonClickEventArgs e) {
         flyoutPanel2.HideBeakForm();
      }

      /// <summary>
      /// Кликнули мышкой на псевдо-url
      /// </summary>
      private void layoutControlItem_Click(object sender, EventArgs e) {
         Point pt = Cursor.Position;
         Console.WriteLine(pt);
         LayoutControlItem item = sender as LayoutControlItem;
         listBoxControl1.Items.Clear();
         if (commSrv == null) {
            listBoxControl1.Items.Add(item.CustomizationFormText);
            flyoutPanel2.ShowBeakForm(pt);
            return;
         }

         // Таблица из одной колонки (2 кнопки)
         Create2Buttons(flyoutPanel2);
         if (item.Name == "itemPhoneOn") {
            listBoxControl1.Items.AddRange(commSrv.PhoneOnDetail.ToArray());
         } else if (item.Name == "itemIntraZonePhoneOn") {
            listBoxControl1.Items.AddRange(commSrv.IntraZonePhoneDetail.ToArray());
         } else if (item.Name == "itemLongDistancePhoneOn") {
            listBoxControl1.Items.AddRange(commSrv.LongDistancePhoneDetail.ToArray());
         } else if (item.Name == "itemUMTS") {
            listBoxControl1.Items.AddRange(commSrv.UmtsDetail.ToArray());
         } else if (item.Name == "itemLTE") {
            listBoxControl1.Items.AddRange(commSrv.LteDetail.ToArray());
         } else if (item.Name == "itemPostOn") {
            listBoxControl1.Items.AddRange(commSrv.PostOnDetail.ToArray());
         } else {                // Таблица из двух колонок ( 3 нопки)
            if (item.Name == "itemPayphoneCount") {
               Create3Buttons(flyoutPanel2, "Оператор", "Таксофонов");
               listBoxControl1.Items.AddRange(commSrv.PayphoneDetail.ToArray());
            } else if (item.Name == "itemGSM") {
               Create3Buttons(flyoutPanel2, "Оператор", "Тип");
               listBoxControl1.Items.AddRange(commSrv.GsmDetail.ToArray());
            } else if (item.Name == "itemDigitalChanelCount") {
               Create3Buttons(flyoutPanel2, "Оператор", "Каналов");
               listBoxControl1.Items.AddRange(commSrv.EtvDigitalChanelDetail.ToArray());
            } else if (item.Name == "itemAnalogChanelCount") {
               Create3Buttons(flyoutPanel2, "Оператор", "Каналов");
               listBoxControl1.Items.AddRange(commSrv.EtvAnalogChanelDetail.ToArray());
            } else if (item.Name == "itemDigitalChanelCount2") {
               Create3Buttons(flyoutPanel2, "Оператор", "Каналов");
               listBoxControl1.Items.AddRange(commSrv.RvDigitalChanelDetail.ToArray());
            } else if (item.Name == "itemAnalogChanelCount2") {
               Create3Buttons(flyoutPanel2, "Оператор", "Каналов");
               listBoxControl1.Items.AddRange(commSrv.RvAnalogChanelDetail.ToArray());
            } else if (item.Name == "itemCabelChanelCount") {
               Create3Buttons(flyoutPanel2, "Оператор", "Каналов");
               listBoxControl1.Items.AddRange(commSrv.CableChanelDetail.ToArray());
            } else if (item.Name == "itemPostOfficeCount") {
               Create3Buttons(flyoutPanel2, "Оператор", "Кол.");
               listBoxControl1.Items.AddRange(commSrv.PostOfficeDetail.ToArray());
            } else if (item.Name == "itemPayphoneCount2") {
               Create3Buttons(flyoutPanel2, "Оператор", "Кол.");
               listBoxControl1.Items.AddRange(commSrv.PayphoneDetail2.ToArray());
            } else if (item.Name == "itemCapsCount") {
               Create3Buttons(flyoutPanel2, "Оператор", "Кол.");
               listBoxControl1.Items.AddRange(commSrv.CapsDetail.ToArray());
            } else if (item.Name == "itemCapsJobCount") {
               Create3Buttons(flyoutPanel2, "Оператор", "Кол.");
               listBoxControl1.Items.AddRange(commSrv.CapsJobDetail.ToArray());
            } else {            // Таблица из 3 колонок (4 кнопки)
               if (item.Name == "itemDataTransferOn") {
                  Create4Buttons(flyoutPanel2, "Оператор", 79, "Мин скорость", 13, "Макс скорость", 24);
                  listBoxControl1.Items.AddRange(commSrv.TransferDataDetails.ToArray());
               } else if (item.Name == "itemTelematicService") {
                  Create4Buttons(flyoutPanel2, "Оператор", 79, "Мин скорость", 13, "Макс скорость", 24);
                  listBoxControl1.Items.AddRange(commSrv.TelematicDataDetails.ToArray());
               } else if (item.Name == "itemTvOn") {
                  Create4Buttons(flyoutPanel2, "Оператор", 83, "Цифр. каналов", 15, "Аналог. каналов", 15);
                  listBoxControl1.Items.AddRange(commSrv.EtvChanelDetail.ToArray());
               } else if (item.Name == "itemBroadcastingOn") {
                  Create4Buttons(flyoutPanel2, "Оператор", 83, "Цифр. каналов", 15, "Аналог. каналов", 15);
                  listBoxControl1.Items.AddRange(commSrv.RvChanelDetail.ToArray());
               } else if (item.Name == "itemAccessPointCount") {
                  Create4Buttons(flyoutPanel2, "Оператор", 86, "Кол.", 5, "Мин. скоростоcть", 30);
                  listBoxControl1.Items.AddRange(commSrv.AccessPointCountDetail.ToArray());
               } else {
                  listBoxControl1.Items.Add(item.CustomizationFormText);
               }
            }
         }

         flyoutPanel2.ShowBeakForm(pt, false, layoutControl1);
      }
      #endregion
   }
}
