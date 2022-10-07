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
   /// Информация о количестве цифровых и аналоговых каналов
   /// </summary>
   public class ChanelCountInfo2 : ICorp, IDataSrc {
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
               DigitalCountData.DataSrc = value;
               AnalogCountData.DataSrc = value;
            }
         }
      }

      /// <summary>
      /// Данные о кол. цифровых каналов
      /// </summary>
      [Browsable(false)]
      public IntData DigitalCountData { get; set; }

      /// <summary>
      /// Данные о кол. аналоговых каналов
      /// </summary>
      [Browsable(false)]
      public IntData AnalogCountData { get; set; }

      /// <summary>
      /// Количество цифровых каналов
      /// </summary>
      [Display(Name = "Цифр.Каналов")]
      [JsonIgnore]
      public int DigitalCount {
         get { return DigitalCountData.Value; }
         set { DigitalCountData.Value = value; }
      }

      /// <summary>
      /// Количество аналоговых каналов
      /// </summary>
      [Display(Name = "Аналог.Каналов")]
      [JsonIgnore]
      public int AnalogCount {
         get { return AnalogCountData.Value; }
         set { AnalogCountData.Value = value; }
      }
      #endregion

      #region Ctors
      public ChanelCountInfo2() {
         _dataSrc = Svyaz.DataSrc.OpenData;
         DigitalCountData = new IntData();
         AnalogCountData = new IntData();
      }

      public ChanelCountInfo2(Corporation corp):this() {
         Corp = corp;
      }
      #endregion

      #region Methods
      public override string ToString() {
         int space1Count = 38 - Corp.CorporateName.Length;
         int space2Count = 14 - DigitalCount.ToString().Length;
         int space3Count = 14 - AnalogCount.ToString().Length;
         string str = Corp.CorporateName + new string(' ', space1Count) + new string(' ', space2Count) + DigitalCount.ToString() + new string(' ', space3Count) + AnalogCount.ToString();
         return str;
      }
      #endregion
   }
}
