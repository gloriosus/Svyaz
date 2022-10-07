using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Svyaz.Model {
   /// <summary>
   /// Лицензируемая деятельность
   /// </summary>
   public class LicensedActivity {
      #region Properties
      /// <summary>
      /// Код родительской деятельность
      /// </summary>
      [Display(Name = "Код родителя", Order=2)]
      public int? ParentID { get; set; }

      /// <summary>
      /// Код лицензируемой деятельности
      /// </summary>
      [Key]
      [Display(Name = "Код", Order=1)]
      public int ID { get; set; }

      /// <summary>
      /// Наименование (заголовок) лицензируемой деятельности
      /// </summary>
      [Required]
      [Display(Name = "Наименовние", Order = 4)]
      public string Name { get; set; }

      /// <summary>
      /// имя свойства из CommunicationService
      /// </summary>
      [Required]
      [Display(Name = "Имя свойства", Order = 3)]
      public string Property { get; set; }
      #endregion

      #region Ctors
      public LicensedActivity() {
      }

      public LicensedActivity(int id, int parentid, string name, string property): this() {
         ID = id;
         ParentID = parentid;
         Name = name;
         Property = property;
      }
      #endregion

      #region Methods
      public override string ToString() {
         return string.Format("{0} ({1})", Name, Property);
      }

      public override int GetHashCode() {
         return ID.GetHashCode();
      }

      public override bool Equals(object obj) {
         bool ok = base.Equals(obj);
         if (!ok) {
            if (obj == null)
               return false;
            LicensedActivity other = obj as LicensedActivity;
            if (other == null)
               return false;
            ok = (GetHashCode() == other.GetHashCode());
         }
         return ok;
      }
      #endregion
   }
}
