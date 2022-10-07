using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Svyaz.Model {
   public interface ICorp {
      /// <summary>
      /// Юридическое лицо
      /// </summary>
      Corporation Corp { get; set; }
   }
}
