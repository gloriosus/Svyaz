using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Svyaz.Model {
   /// <summary>
   /// Логическое значение
   /// </summary>
   public class BoolData {
      #region Fields
      private DataSrc dataSource;
      [JsonProperty]
      private Dictionary<DataSrc, bool> values;
      #endregion

      #region Propreties


      /// <summary>
      /// Значение типа bool
      /// </summary>
      [JsonIgnore]
      [DisplayName("Значение")]
      public bool Value {
         get { return values[dataSource]; }
         set { values[dataSource] = value; }
      }

      /// <summary>
      /// Источник данных (реестр или данные поставщика услуг)
      /// </summary>
      [Display(Name = "Источник данных")]
      [Browsable(false)]
      [JsonIgnore]
      public DataSrc DataSrc {
         get { return dataSource; }
         set {
            if (dataSource != value) {
               dataSource = value;
            }
         }
      }
      #endregion

      #region Ctors
      public BoolData() {
         dataSource = Svyaz.DataSrc.OpenData;
         values = new Dictionary<DataSrc, bool>();
         values.Add(DataSrc.OpenData, false);
         values.Add(DataSrc.OperatorData, false);
      }
      #endregion
   }
}
