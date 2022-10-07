using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Svyaz.Model {
   /// <summary>
   /// Источник данных
   /// </summary>
   public interface IDataSrc {
      /// <summary>
      /// Источник данных
      /// </summary>
      DataSrc DataSrc { get; set; }
   }
}
