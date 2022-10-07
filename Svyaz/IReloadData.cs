using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Svyaz {
   /// <summary>
   /// Перезагрузить данные
   /// </summary>
   public interface IReloadData {
      /// <summary>
      /// Загрузить данные с диска заново
      /// </summary>
      void LoadData();
   }
}
