using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Svyaz.Model {
   /// <summary>
   /// Базовая информация о поставщике услуг (операторе)
   /// </summary>
   public class BaseOperatorInfo {
      #region Fields
      private string operatorName;  // Бренд (МТС, Билайн и т.д.)
      private string defaultName;   // наименование (Вымпел Коммуникации)
      #endregion

      #region Properties
      public static string UnknownName {
         get { return "Unknown"; }
      }

      /// <summary>
      /// Бренд оператора связи (МТС, Билайн и т.д.)
      /// </summary>
      [Display(Name = "Оператор связи")]
      public string OperatorName {
         get { return operatorName; }
         set {
            if (operatorName != value) {
               operatorName = value;
               if (string.IsNullOrEmpty(defaultName))
                  defaultName = value;
            }
         }
      }

      /// <summary>
      /// Наименование оператора связи (Вымпел Коммуникации)
      /// </summary>
      public string DefaultName {
         get { return defaultName; }
         set {
            if (defaultName != value) {
               defaultName = value;
               if (string.IsNullOrEmpty(operatorName) || operatorName == defaultName)
                  operatorName = value;
            }
         }
      }

      /// <summary>
      /// Список юридических лиц стоящих за оператором связи
      /// </summary>
      [Display(Name = "Юр. лица")]
      [JsonIgnoreAttribute]
      public virtual HashSet<Corporation> Corporations { get; set; }

      /// <summary>
      /// Услуги связи, осуществляющие оператором
      /// </summary>
      public virtual HashSet<OperatorActivity> Activities { get; private set; }
      #endregion
       
      #region Ctor
      public BaseOperatorInfo() {
         defaultName = string.Empty;
         operatorName = string.Empty;
         Corporations = new HashSet<Corporation>();
         Activities = new HashSet<OperatorActivity>();
      }
      #endregion

      #region Methods
      public override string ToString() {
         return string.IsNullOrEmpty(DefaultName)? OperatorName : DefaultName;
      }

      public override int GetHashCode() {
         return OperatorName.GetHashCode();
      }

      public override bool Equals(object obj) {
         if (obj == null)
            return false;
         BaseOperatorInfo other = obj as BaseOperatorInfo;
         if (other == null)
            return false;
         return this.OperatorName.Equals(other.OperatorName);
      }

      /// <summary>
      /// Добавить юр. лицо в список юр. лиц
      /// </summary>
      public bool AddCorp(Corporation corporation) {
         bool contains = Corporations.Contains(corporation);
         if (!contains) {
            Corporations.Add(corporation);
            if (corporation.CorporateName != null) {
               if (corporation.Operator != this)
                  corporation.Operator = this;
            }
         }
         return !contains;
      }

      /// <summary>
      /// Исключить указанное юр. лицо из спска рю. лиц
      /// </summary>
      public bool DeleteCorp(Corporation corporation) {
         bool contains = Corporations.Contains(corporation);
         if (contains) {
            Corporations.Remove(corporation);
         }
         return contains;
      }
      #endregion
   }
}
