using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svyaz.Data;
using Util;

namespace Svyaz.Model {
   /// <summary>
   /// Строка таблицы содержащая 3 строковые колонки
   /// </summary>
   public class Row3Columns {
      public string Column1 { get; set; }

      public string Column2 { get; set; }

      public string Column3 { get; set; }

      /// <summary>
      /// Преобразовать список формата Row3Columns в список формата TransferDataInfo
      /// </summary>
      public static List<TransferDataInfo> ToTransferDataInfo(int localityId, List<Row3Columns> source) {
         List<TransferDataInfo> destination = new List<TransferDataInfo>();
         foreach (Row3Columns rowSrc in source) {
            string name = rowSrc.Column1;
            DataRate min = DataRate.ConvertFromString(rowSrc.Column2);
            DataRate max = DataRate.ConvertFromString(rowSrc.Column3);
            Repository repo = Repository.GetRepository();
            Corporation corp = repo.GetCorporation(name);
            TransferDataInfo rowDst = new TransferDataInfo(corp) { LocalityId = localityId, MinRate = min, MaxRate = max };
            destination.Add(rowDst);
         }
         return destination;
      }

      /// <summary>
      /// Преобразовать список формата Row3Columns в список формата ChanelCountInfo2
      /// </summary>
      public static List<ChanelCountInfo2> ToChanelCountInfo(int localityId, List<Row3Columns> source) {
         List<ChanelCountInfo2> destination = new List<ChanelCountInfo2>();
         foreach (Row3Columns rowSrc in source) {
            string name = rowSrc.Column1;
            int digitalCount = Tools.IntFromString(rowSrc.Column2);
            int analgCount = Tools.IntFromString(rowSrc.Column3);
            Repository repo = Repository.GetRepository();
            Corporation corp = repo.GetCorporation(name);
            ChanelCountInfo2 rowDst = new ChanelCountInfo2(corp) { LocalityId = localityId, AnalogCount = analgCount, DigitalCount = digitalCount };
            destination.Add(rowDst);
         }
         return destination;
      }

      /// <summary>
      /// Преобразовать список формата Row3Columns в список формата AccessPointInfo
      /// </summary>
      public static List<AccessPointInfo> ToAccessPointInfo(int localityId, List<Row3Columns> source) {
         List<AccessPointInfo> destination = new List<AccessPointInfo>();
         foreach (Row3Columns rowSrc in source) {
            string name = rowSrc.Column1;
            int count = Tools.IntFromString(rowSrc.Column2);
            DataRate min = DataRate.ConvertFromString(rowSrc.Column3);

            Repository repo = Repository.GetRepository();
            Corporation corp = repo.GetCorporation(name);
            AccessPointInfo rowDst = new AccessPointInfo(corp) { LocalityId = localityId, Count = count, MinRate = min };
            destination.Add(rowDst);
         }
         return destination;
      }
   }
}
