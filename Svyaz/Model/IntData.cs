using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Svyaz.Model {
   /// <summary>
   /// Целое чистло (int)
   /// </summary>
   public class IntData {
      #region Fields
      private DataSrc dataSource;
      [JsonProperty]
      private Dictionary<DataSrc, int> values;
      #endregion

      #region Propreties
      /// <summary>
      /// Значение типа int
      /// </summary>
      [JsonIgnore]
      [DisplayName("Значение")]
      public int Value {
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
      public IntData() {
         dataSource = Svyaz.DataSrc.OpenData;
         values = new Dictionary<DataSrc, int>();
         values.Add(DataSrc.OpenData, 0);
         values.Add(DataSrc.OperatorData, 0);
      }
      #endregion
   }
}
