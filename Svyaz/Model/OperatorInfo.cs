using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Svyaz.Model {
   public class OperatorInfo : ICorp, IDataSrc {
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
               AvailabilityData.DataSrc = value;
            }
         }
      }
     
      /// <summary>
      /// Данные о доступности услуги
      /// </summary>
      [Browsable(false)]
      public BoolData AvailabilityData { get; set; }

      /// <summary>
      /// Доступность услуги
      /// </summary>
      [Display(Name = "Доступность")]
      [JsonIgnore]
      public bool Availability {
         get { return AvailabilityData.Value; }
         set { AvailabilityData.Value = value; }
      }
      #endregion

      #region Ctors
      public OperatorInfo() {
         this.corp = null;
         this._dataSrc = Svyaz.DataSrc.OpenData;
         AvailabilityData = new BoolData();
      }

      public OperatorInfo(Corporation corp): this() {
         Corp = corp;
      }
      #endregion

      #region Methods
      public override string ToString() {
         if (Corp != null)
            return Corp.CorporateName;
         return CorporateName;
      }

      public override int GetHashCode() {
         return string.Format("{0}{1}", Corp, LocalityId).GetHashCode();
      }

      public override bool Equals(object obj) {
         if (obj == null)
            return false;
         OperatorInfo other = obj as OperatorInfo;
         if (other == null)
            return false;
         return (this.GetHashCode() == other.GetHashCode());
      }
      #endregion
   }
}
