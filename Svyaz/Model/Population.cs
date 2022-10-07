using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svyaz.Model {
   /// <summary>
   /// Население
   /// </summary>
   public class Population: IComparable<Population>, IComparable {
      #region Properties
      /// <summary>
      /// Дата
      /// </summary>
      public DateTime Date { get; set; }

      /// <summary>
      /// Количество жителей
      /// </summary>
      public int Count { get; set; }
      #endregion


      public override string ToString() {
         return string.Format("{0} чел.", Count);
      }

      public override bool Equals(object obj) {
         if (obj == null)
            return false;

         Population other = obj as Population;
         if (other == null)
            return false;

         if (this.Date != other.Date)
            return false;

         return (this.Count == other.Count);
      }

      public override int GetHashCode() {
         return base.GetHashCode();
      }

      public int CompareTo(Population other) {
         if (other == null)
            return 1;
         if (this.Equals(other))
            return 0;
         if (this.Date > other.Date)
            return 1;
         else if (this.Date < other.Date)
            return -1;
         if (this.Count > other.Count)
            return 1;
         return -1;
      }

      public int CompareTo(object obj) {
         if (obj == null)
            return 1;
         Population other = obj as Population;
         return this.CompareTo(other);
      }
   }
}
