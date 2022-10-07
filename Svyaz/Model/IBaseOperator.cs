using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Svyaz.Model {
   /// <summary>
   /// Интерфейс для получения доступа к экземпляру информации об операторе связи (
   /// </summary>
   public interface IBaseOperator {
      /// <summary>
      /// Оператор связи
      /// </summary>
      BaseOperatorInfo Operator { get; set; }
   }
}
