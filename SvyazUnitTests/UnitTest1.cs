using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Svyaz;
using Svyaz.Data;
using Svyaz.Model;

namespace SvyazUnitTests {
   [TestClass]
   public class UnitTest1 {

      [TestMethod]
      public void DeserializeCorps() {
         string path = Path.Combine(Utils.DataCatalog, "corporations.json");
         List<Corporation> corps = Utils.DeserializeCollection<Corporation>(path);

         Assert.AreEqual(6, corps.Count);
      }

      [TestMethod]
      public void DeserializeCorpsDoubles() {
         string path = Path.Combine(Utils.DataCatalog, "corporations2.json");
         List<Corporation> corps = Utils.DeserializeCollection<Corporation>(path);

         Assert.AreEqual(6, corps.Count);
      }

      [TestMethod]
      public void SerializeCorps() {
         List<Corporation> corps = Utils.CreateCorporations();
         string path = Path.Combine(Utils.DataCatalog, "corporations.json");
         Utils.SerializeCollection<Corporation>(corps, path);

         bool ok = File.Exists(path);
         Assert.IsTrue(ok);
      }

      [TestMethod]
      public void SerializeCorpsDoubles() {
         List<Corporation> corps = Utils.CreateCorporationsWithDoubles();
         string path = Path.Combine(Utils.DataCatalog, "corporations2.json");
         Utils.SerializeCollection<Corporation>(corps, path);

         bool ok = File.Exists(path);
         Assert.IsTrue(ok);
      }

      [TestMethod]
      public void RemoveDoubleCorps() {
         string path = Path.Combine(Utils.DataCatalog, "corporations2.json");
         List<Corporation> corps = Utils.DeserializeCollection<Corporation>(path);
         HashSet<Corporation> hash = new HashSet<Corporation>(corps);

         Assert.AreEqual(3, hash.Count);
      }

      [TestMethod]
      public void SrializeHashCorps() {
         List<Corporation> corps = Utils.CreateCorporationsWithDoubles();
         HashSet<Corporation> hash = new HashSet<Corporation>(corps);
         string path = Path.Combine(Utils.DataCatalog, "hashSetCorps.json");
         Utils.SerializeHashSet<Corporation>(hash, path);

         bool ok = File.Exists(path);
         Assert.IsTrue(ok);
      }

      [TestMethod]
      public void DeserializeHashCorps() {
         string path = Path.Combine(Utils.DataCatalog, "hashSetCorps.json");
         HashSet<Corporation> hash = Utils.DeserializeHashSet<Corporation>(path);

         Assert.AreEqual(3, hash.Count);
      }

      [TestMethod]
      public void FluentLinqTest() {
         Repository repo = Repository.GetRepository();
         var q = repo.Localities
                     .Select( l => new {
                        Settlement = (l.SettlementId !=null)? repo.Settlements.FirstOrDefault(s => s.Id == l.SettlementId): null,
                        Id = l.Id,
                        FullName = l,
                        CurrentPopulationCount = l.CurrentPopulationCount
                     });
         var q2 = q.Select(i => new {
                     Settlement = i.Settlement,
                     Borrought = (i.Settlement != null)? repo.Borrougts.FirstOrDefault(b => b.Id == i.Settlement.BorroughId) : null,
                     Id = i.Id,
                     FullName =i.FullName,
                     CurrentPopulationCount = i.CurrentPopulationCount
                  });

         Assert.AreEqual(112, q2.Count());
      }

      [TestMethod]
      public void AdmCenterQueryTest() {
         Repository repo = Repository.GetRepository();
         //IEnumerable<PivotHeader> header = null;
         var header = (from l in repo.Localities
                   join s in repo.Settlements on l.SettlementId equals s.Id into gj
                   from subSettlement in gj.DefaultIfEmpty()
                   select new { 
                      Borrough = (subSettlement == null ? null : subSettlement.Borrough),
                      l.Settlement,
                      l.Id,
                      FullName = l,
                      IsAdmCenter = (subSettlement != null && subSettlement.Borrough.CenterId == l.Id) ||
                                  (l.Settlement != null && l.Settlement.CenterId == l.Id) ||
                                  subSettlement == null || l.Settlement == null ? true : false,
                      CurrentPopulationCount = l.CurrentPopulationCount
                   }
                   ).OrderBy(i => i.Borrough).ThenBy(i => i.Settlement);
         var adm = header.Where(h => h.IsAdmCenter == true);

         Assert.AreEqual(112, header.Count());
         Assert.AreEqual(28, adm.Count());
      }
   }
}
