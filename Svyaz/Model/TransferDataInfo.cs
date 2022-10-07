using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Svyaz.Model {
   /// <summary>
   /// Информация о скорости передачи данных
   /// </summary>
   public class TransferDataInfo : ICorp, IDataSrc {
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
               MinRateData.DataSrc = value;
               MaxRateData.DataSrc = value;
            }
         }
      }

      /// <summary>
      /// Данные о мин скорости
      /// </summary>
      [Browsable(false)]
      public TransferData MinRateData { get; set; }

      /// <summary>
      /// Данные о макс скорости
      /// </summary>
      [Browsable(false)]
      public TransferData MaxRateData { get; set; }

      /// <summary>
      /// Минимальная скорость передачи данных
      /// </summary>
      [Display(Name = "мин. скорость")]
      [JsonIgnore]
      public DataRate MinRate {
         get { return MinRateData.Value; }
         set {MinRateData.Value = value;}
      }

      /// <summary>
      /// Максимальная скорость передачи данных
      /// </summary>
      [Display(Name = "макс. скорость")]
      [JsonIgnore]
      public DataRate MaxRate {
         get { return MaxRateData.Value; }
         set { MaxRateData.Value = value; }
      }
      #endregion

      #region Ctors
      public TransferDataInfo() {
         _dataSrc = Svyaz.DataSrc.OpenData;
         MinRateData = new TransferData();
         MaxRateData = new TransferData();
      }

      public TransferDataInfo(Corporation corp):this() {
         Corp = corp;
      }
      #endregion

      #region Methods
      public override string ToString() {
         int space1Count = 37 - Corp.CorporateName.Length;
         int space2Count = 12 - MinRate.ToString().Length;
         int space3Count = 17 - MaxRate.ToString().Length;
         string str = Corp.CorporateName + new string(' ', space1Count)+ new string(' ',space2Count) + MinRate.ToString() + new string(' ', space3Count) + MaxRate.ToString();
         return str;
      }
      #endregion
   }
}
