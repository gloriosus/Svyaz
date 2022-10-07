using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Svyaz.Model {
   public class GsmInfo : ICorp, IDataSrc {
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
               GSMTypeData.DataSrc = value;
            }
         }
      }

      /// <summary>
      /// значение типа GSM стандарта
      /// </summary>
      [Browsable(false)]
      public GsmData GSMTypeData { get; set; }
      
      /// <summary>
      /// Тип GSM стандарта
      /// </summary>
      [Display(Name = "Тип")]
      [JsonIgnore]
      public GsmType GSMType {
         get { return GSMTypeData.Value; }
         set { GSMTypeData.Value = value; }
      }
      #endregion

      #region Ctors
      public GsmInfo() {
         _dataSrc = Svyaz.DataSrc.OpenData;
         corp = null;
         GSMTypeData = new GsmData();
      }

      public GsmInfo(Corporation corp):this(){
         Corp = corp;
      }
      #endregion

      #region Methods
      public override string ToString() {
         string strGsmType = ToString(GSMType);
         int spaceCount = 116 - Corp.CorporateName.Length - strGsmType.Length;

         string str = Corp.CorporateName + new string(' ', spaceCount) + strGsmType;
         return str;
      }

      private string ToString(GsmType gsmType) {
         switch (gsmType) {
            case GsmType.Gsm_1800:
               return "1800";
            case GsmType.Gsm_900_1800:
               return "900/1800";
            case GsmType.Gsm_1800_900_1800:
               return "1800, 900/1800";
            default:
               return "";
         }
      }
      #endregion
   }
}
