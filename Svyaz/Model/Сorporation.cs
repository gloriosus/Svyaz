using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Svyaz.Data;

namespace Svyaz.Model {
   /// <summary>
   /// Юридическое лицо, осуществляющее лицензируемую деятельность по оказанию услуг связи на территории области
   /// </summary>
   public class Corporation {
      #region Fields
      private string _name;
      private BaseOperatorInfo _operator;
      #endregion

      #region Properties
      /// <summary>
      /// Код юр. лица
      /// </summary>
      [Display(Name="Код")]
      [Required]
      public int ID { get; set; }

      /// <summary>
      /// Наименование юридческого лица
      /// </summary>
      [Display(Name="Полное наименование организации")]
      [Required]
      public string CorporateName {
         get { return _name; }
         set {
            if (value == null)
               return;
            if (_name != null)
               _operator.DeleteCorp(this);
            _name = value;
            _operator.AddCorp(this);
         }
      }

      /// <summary>
      /// Оператор связи
      /// </summary>
      [Display(Name="Оператор связи")]
      [Required]
      public BaseOperatorInfo Operator {
         get { return _operator; }
         set {
            if (value == null)
               return;
            if (_name != null)
               _operator.DeleteCorp(this);
            _operator = value;
            _operator.AddCorp(this);
         }
      }

      /// <summary>
      /// Услуги связи, осуществляющие юр. лицом
      /// </summary>
      public virtual HashSet<LicensedActivity> Activities { get; private set; }
      #endregion

      #region Ctors
      public Corporation() {
         _operator = Repository.UnknownOperator;
         Activities = new HashSet<LicensedActivity>();
      }

      public Corporation(string corpName, BaseOperatorInfo op):this() {
         _name = corpName;
         _operator = op;
         _operator.AddCorp(this);
      }
      #endregion

      #region Methods
      public override string ToString() {
         return string.Format("{0}", CorporateName);
      }

      public override int GetHashCode() {
         return CorporateName.GetHashCode();
      }

      public override bool Equals(object obj) {
         if (obj == null)
            return false;
         Corporation other = obj as Corporation;
         if (other == null)
            return false;
         return this.CorporateName.Equals(other.CorporateName);
      }

      #endregion
   }
}
