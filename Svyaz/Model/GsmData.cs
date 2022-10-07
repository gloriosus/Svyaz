using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Svyaz.Model {
   /// <summary>
   /// GsmType значение
   /// </summary>
   public class GsmData {
      #region Fields
      private DataSrc dataSource;
      [JsonProperty]
      private Dictionary<DataSrc, GsmType> values;
      #endregion

      #region Propreties
      /// <summary>
      /// Значение типа int
      /// </summary>
      [JsonIgnore]
      [DisplayName("Значение")]
      public GsmType Value {
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
      public GsmData() {
         dataSource = Svyaz.DataSrc.OpenData;
         values = new Dictionary<DataSrc, GsmType>();
         values.Add(DataSrc.OpenData, GsmType.None);
         values.Add(DataSrc.OperatorData, GsmType.None);
      }
      #endregion
   }
}
