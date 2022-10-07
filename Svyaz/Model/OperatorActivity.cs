using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Svyaz.Model {
   /// <summary>
   /// Услуга (деятельность) которую может оказывать оператор
   /// </summary>
   public class OperatorActivity : LicensedActivity, IBaseOperator {
      #region Properties
      /// <summary>
      /// Оператор связи
      /// </summary>
      [Display (Name = "Оператор связи")]
      public BaseOperatorInfo Operator { get; set; }
      #endregion

      #region Ctors
      public OperatorActivity() {
         Operator = new BaseOperatorInfo();
      }
      #endregion

      #region Methods
      public override string ToString() {
         return string.Format("{0} - {1} ({2})", Operator, Property, Name);
      }
      #endregion
   }
}
