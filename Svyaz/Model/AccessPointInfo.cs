using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Svyaz.Model {
   /// <summary>
   /// Информация об операторах имеющих точки доступа
   /// </summary>
   public class AccessPointInfo : ICorp, IDataSrc {
      #region Fields
      private Corporation corp;
      private DataSrc _dataSrc;
      #endregion

      #region Properties
      [Browsable(false)]
      public string CorporateName { get; set; }

      /// <summary>
      /// Оператор связи
      /// </summary>
      [Display(Name = "Юр. лицо")]
      [JsonIgnore]
      public Corporation Corp {
         get { return corp; }
         set {
            corp = value;
            CorporateName = (corp != null) ? corp.CorporateName : null;
         }
      }
      /// <summary>
      /// Код населенного пункта
      /// </summary>
      [Display(Name = "Код")]
      [Browsable(false)]
      public int LocalityId { get; set; }

      /// <summary>
      /// Источник данных
      /// </summary>
      [Display(Name = "Источник данных")]
      [Browsable(false)]
      [JsonIgnore]
      public DataSrc DataSrc {
         get { return _dataSrc; }
         set {
            if (value != _dataSrc) {
               _dataSrc = value;
               CountData.DataSrc = value;
               MinRateData.DataSrc = value;
            }
         }
      }

      /// <summary>
      /// Данные о количестве
      /// </summary>
      [Browsable(false)]
      public IntData CountData { get; set; }
     
      /// <summary>
      /// Данные о мин скорости
      /// </summary>
      [Browsable(false)]
      public TransferData MinRateData { get; set; }

      /// <summary>
      /// Количество
      /// </summary>
      [Display(Name = "Кол.")]
      [JsonIgnore]
      public int Count {
         get { return CountData.Value; }
         set { CountData.Value = value; }
      }

      /// <summary>
      /// Минимальная скорость передачи данных
      /// </summary>
      [Display(Name = "мин. скорость")]
      [JsonIgnore]
      public DataRate MinRate {
         get { return MinRateData.Value; }
         set { MinRateData.Value = value; }
      }
      #endregion

      #region Ctors
      public AccessPointInfo() {
         _dataSrc = Svyaz.DataSrc.OpenData;
         CountData = new IntData();
         MinRateData = new TransferData();
      }

      public AccessPointInfo(Corporation corp):this(){
         Corp = corp;
      }
      #endregion

      #region Methods
      public override string ToString() {
         int space1Count = 30 - Corp.CorporateName.Length;  // 37
         int space2Count = 14 - Count.ToString().Length;    // 14
         int space3Count = 21 - MinRate.ToString().Length;  // 17
         string str = Corp.CorporateName + new string(' ', space1Count) + new string(' ', space2Count) + Count.ToString() + new string(' ', space3Count) + MinRate.ToString();
         return str;
      }
      #endregion
   }
}
