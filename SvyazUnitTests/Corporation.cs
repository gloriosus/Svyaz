using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SvyazUnitTests {
   public class Corporation {
      #region Properties
      [Required]
      public string CorporateName { get; set; }
      #endregion

      #region Constructors
      private Corporation() {
      }

      public Corporation(string name) {
         CorporateName = name;
      }
      #endregion

      #region Methods
      public override string ToString() {
         return CorporateName;
      }

      public override int GetHashCode() {
         return CorporateName.GetHashCode();
      }

      public override bool Equals(object obj) {
         if (obj == null)
            return false;
         Corporation other = obj as Corporation;
         if (obj == null)
            return false;
         return (this.CorporateName == other.CorporateName);
      }
      #endregion
   }
}
