using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Svyaz.Data;

namespace Svyaz.Model {
   /// <summary>
   /// Постоянная часть для отображения реестра услуг связи в разрезе населенных пукнтов области
   /// </summary>
   public class PivotHeader {
      /// <summary>
      /// Поселение
      /// </summary>
      public Borrough Borrough { get; set; }

      /// <summary>
      /// Поселение
      /// </summary>
      public Settlement Settlement { get; set; }

      public int Id { get; set; }

      public Locality FullName { get; set; }

      /// <summary>
      /// Численность населения
      /// </summary>
      public int CurrentPopulationCount { get; set; }

      /// <summary>
      /// Признак административного центра (Рег. центр, райцентр, центр поселения)
      /// </summary>
      public bool IsAdmCenter { get; set; }

      public static IEnumerable<PivotHeader> GetPivotHeader() {
         Repository repo = Repository.GetRepository();
         IEnumerable<PivotHeader> header = null;
         header = (from l in repo.Localities
                   join s in repo.Settlements on l.SettlementId equals s.Id into gj
                   from subSettlement in gj.DefaultIfEmpty()
                   select new PivotHeader() {
                      Borrough = (subSettlement == null ? null : subSettlement.Borrough),
                      Id = l.Id,
                      Settlement = l.Settlement,
                      FullName = l,
                      IsAdmCenter = (subSettlement != null && subSettlement.Borrough.CenterId == l.Id) ||
                                    (l.Settlement != null && l.Settlement.CenterId == l.Id) ||
                                     subSettlement == null || l.Settlement == null ? true : false,
                      CurrentPopulationCount = l.CurrentPopulationCount,
                   }).OrderBy(i => i.Borrough).ThenBy(i => i.Settlement);
         return header;
      }
   }
}
