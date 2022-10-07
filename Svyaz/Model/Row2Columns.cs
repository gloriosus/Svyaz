using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svyaz.Data;
using Util;

namespace Svyaz.Model {
   /// <summary>
   /// Строка таблицы содержащая 2 строковые колонки
   /// </summary>
   public class Row2Columns {
      public string Column1 { get; set; }

      public string Column2 { get; set; }

      /// <summary>
      /// Преобразовать список формата Row2Columns в список формата CountInfo
      /// </summary>
      public static List<CountInfo> ToCountInfo(int localityId, List<Row2Columns> source) {
         List<CountInfo> destination = new List<CountInfo>();
         foreach (Row2Columns rowSrc in source) {
            string name = rowSrc.Column1;
            int count = Convert.ToInt32(rowSrc.Column2);
            Repository repo = Repository.GetRepository();
            Corporation corp = repo.GetCorporation(name);
            CountInfo rowDst = new CountInfo(corp) {LocalityId = localityId, Count = count };
            destination.Add(rowDst);
         }
         return destination;
      }

      /// <summary>
      /// Преобразовать список формата Row2Columns в список формата ChanelCountInfo
      /// </summary>
      public static List<ChanelCountInfo> ToChanelCountInfo(int localityId, List<Row2Columns> source) {
         List<ChanelCountInfo> destination = new List<ChanelCountInfo>();
         foreach (Row2Columns rowSrc in source) {
            string name = rowSrc.Column1;
            int count = Convert.ToInt32(rowSrc.Column2);
            Repository repo = Repository.GetRepository();
            Corporation corp = repo.GetCorporation(name);
            ChanelCountInfo rowDst = new ChanelCountInfo(corp) { LocalityId = localityId, Count = count };
            destination.Add(rowDst);
         }
         return destination;
      }

      /// <summary>
      /// Преобразовать список формата Row2Columns в список формата GsmInfo
      /// </summary>
      public static List<GsmInfo> ToGsmInfo(int localityId, List<Row2Columns> source) {
         List<GsmInfo> destination = new List<GsmInfo>();
         foreach (Row2Columns rowSrc in source) {
            string name = rowSrc.Column1;
            GsmType gsmtype = Tools.GsmTypeFromString(rowSrc.Column2);
            Repository repo = Repository.GetRepository();
            Corporation corp = repo.GetCorporation(name);
            GsmInfo rowDst = new GsmInfo(corp) { LocalityId = localityId, GSMType = gsmtype };
            destination.Add(rowDst);
         }
         return destination;
      }

   }
}
