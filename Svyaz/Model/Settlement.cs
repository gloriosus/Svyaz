using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Svyaz.Model {
   /// <summary>
   /// Район области
   /// </summary>
   public class Settlement: IComparable<Settlement>, IComparable {
      #region Properties
      /// <summary>
      /// Код района
      /// </summary>
      [Display(Name = "Код")]
      public int Id { get; set; }

      /// <summary>
      /// Наименование района
      /// </summary>
      [Display(Name = "Поселение")]
      public string Name { get; set; }

      /// <summary>
      /// Категория поселения (городское | сельсое)
      /// </summary>
      public SettlmentCategory Category { get; set; }

      /// <summary>
      /// Код цента поселения
      /// </summary>
      public int?  CenterId { get; set; }

      /// <summary>
      /// Районный центр
      /// </summary>
      [JsonIgnoreAttribute]
      [Display(Name = "Администр. центр")]
      public virtual Locality Center { get; set; }

      /// <summary>
      /// Код Района
      /// </summary>
      public int? BorroughId { get; set; }

      /// <summary>
      /// Район
      /// </summary>
      [JsonIgnoreAttribute]
      [Display(Name = "Район")]
      public Borrough Borrough { get; set; }

      /// <summary>
      /// Населены пункты входящие в состав поселения
      /// </summary>
      [JsonIgnoreAttribute]
      public virtual List<Locality> Localities { get; private set; }
      #endregion

      #region Ctors
      public Settlement() {
         Localities = new List<Locality>();
      }
      #endregion

      #region Methods
      public override string ToString() {
         return Name;
      }

      public override int GetHashCode() {
         return Id;
      }

      public override bool Equals(object obj) {
         if (obj == null) return false;

         Settlement settlement = obj as Settlement;
         if (settlement == null) return false;

         return (this.Id == settlement.Id);
      }
      #endregion

      #region Реализация IComparable<T>, IComparable
      public int CompareTo(Settlement other) {
         if (other == null)
            return 1;
         if (this.Equals(other))
            return 0;
         return this.Name.CompareTo(other.Name);
      }

      public int CompareTo(object obj) {
         if (obj == null)
            return 1;
         Settlement other = obj as Settlement;
         return this.CompareTo(other);
      }
      #endregion
   }
}
