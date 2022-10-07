using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Svyaz.Model {
   /// <summary>
   /// Муниципальный район
   /// </summary>
   public class Borrough: IComparable<Borrough>, IComparable {
      #region Properties
      /// <summary>
      /// Код района
      /// </summary>
      public int Id { get; set; }

      /// <summary>
      /// Наименование района
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Код районного центра
      /// </summary>
      public int? CenterId { get; set; }

      /// <summary>
      /// Районный центр
      /// </summary>
      [JsonIgnoreAttribute]
      public virtual Locality Center { get; set; }

      /// <summary>
      /// Поселения входящие в состав района
      /// </summary>
      [JsonIgnoreAttribute]
      public virtual List<Settlement> Settlements { get; private set; }
      #endregion

      #region Ctors
      public Borrough() {
         Settlements = new List<Settlement>();
      }
      #endregion

      #region Methods
      public override string ToString() {
         return Name;
      }

      public override int GetHashCode() {
         return this.Id;
      }

      public override bool Equals(object obj) {
         if (obj == null)
            return false;
         
         Borrough other = obj as Borrough;
         if (other == null)
            return false;

         return (this.Id == other.Id);
      }
      #endregion

      #region Реализация IComparable<T>, IComparable
      public int CompareTo(Borrough other) {
         if (this.Equals(other))
            return 0;

         if (other == null)
            return 1;

         return this.Name.CompareTo(other.Name);
      }

      public int CompareTo(object obj) {
         if (obj == null)
            return 1;
         Borrough other = obj as Borrough;

         return this.CompareTo(other);
      }
      #endregion
   }
}
