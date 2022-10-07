using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Svyaz.Model {
   /// <summary>
   /// значение DataRate
   /// </summary>
   public class TransferData {
      #region Fields
      private DataSrc dataSource;
      [JsonProperty]
      private Dictionary<DataSrc, DataRate> values;
      #endregion

      #region Propreties
      /// <summary>
      /// Значение типа int
      /// </summary>
      [JsonIgnore]
      [DisplayName("Значение")]
      public DataRate Value {
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
      public TransferData() {
         dataSource = Svyaz.DataSrc.OpenData;
         values = new Dictionary<DataSrc, DataRate>();
         values.Add(DataSrc.OpenData, new DataRate());
         values.Add(DataSrc.OperatorData, new DataRate());
      }
      #endregion
   }
}
