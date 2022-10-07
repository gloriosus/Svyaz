using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SvyazUnitTests {
   public class OpInfo {
      [Display(Name = "Оператор связи")]
      public Corporation Corp { get; set; }

      /// <summary>
      /// Код населенного пункта
      /// </summary>
      [Display(Name = "Код")]
      [Browsable(false)]
      public int LocalityId { get; set; }

      /// <summary>
      /// Доступность услуги
      /// </summary>
      [Display(Name = "Доступность")]
      public bool Availability { get; set; }
   }
}
