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
   /// Информация о количестве цифровых/аналоговых каналов
   /// </summary>
   public class ChanelCountInfo :ICorp, IDataSrc {
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
            }
         }
      }

      /// <summary>
      /// Данные о количестве таксофонов
      /// </summary>
      [Browsable(false)]
      public IntData CountData { get; set; }

      /// <summary>
      /// Количество каналов
      /// </summary>
      [Display(Name = "Каналов")]
      [JsonIgnore]
      public int Count {
         get { return CountData.Value; }
         set { CountData.Value = value; }
      }
      #endregion

      #region Ctors
      public ChanelCountInfo() {
         _dataSrc = Svyaz.DataSrc.OpenData;
         CountData = new IntData();
      }

      public ChanelCountInfo(Corporation corp):this() {
         Corp = corp;
      }
      #endregion

      #region methods
      public override string ToString() {
         int spaceCount = 66 - Corp.CorporateName.Length - Count.ToString().Length;
         string str = Corp.CorporateName + new string(' ', spaceCount) + Count.ToString();
         return str;
      }
      #endregion
   }
}
