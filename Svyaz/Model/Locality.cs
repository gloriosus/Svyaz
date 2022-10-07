using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Svyaz.Data;
using Svyaz.Web;
using Util;

namespace Svyaz.Model {
   /// <summary>
   /// Населенный пункт
   /// </summary>
   public class Locality:IComparable<Locality>, IComparable {
      private CommunicationService _commSrv;

      #region Properties
      /// <summary>
      /// Код населенного пункта
      /// </summary>
      [Display(Name = "Код")]
      public int Id { get; set; }

      /// <summary>
      /// Категория населенного пункта
      /// </summary>
      public SettlementCategory Category { get; set; }

      /// <summary>
      /// Наименование поселения
      /// </summary>
      [Display(Name = "Название")]
      public string Name { get; set; }

      /// <summary>
      /// Полное наименование
      /// </summary>
      [Display(Name = "Нас. пункт")]
      public string FullName {
         get { return string.Format("{0}. {1}", Category, Name); }
      }

      /// <summary>
      /// Код поселения
      /// </summary>
      public int? SettlementId { get; set; }

      /// <summary>
      /// поселение
      /// </summary>
      [JsonIgnoreAttribute]
      [Display(Name = "Поселение")]
      public virtual Settlement Settlement { get; set; }

      /// <summary>
      /// Текущая популяция (кол. жителей) в населенном пункте
      /// </summary>
      [JsonIgnoreAttribute]
      [Display(Name = "Данные о численносит (чел.)")]
      public Population CurrentPopulation {
         get { return GetCurrentPopulation(); }
      }

      /// <summary>
      /// Кол. жителей в нас. пункте на данных момент
      /// </summary>
      [JsonIgnoreAttribute]
      [Display(Name = "Проживает (чел.)")]
      public int CurrentPopulationCount {
         get {
            Population poplulation = GetCurrentPopulation();
            return (poplulation != null) ? poplulation.Count : 0;
         }
      }

      /// <summary>
      /// Информация о доступности услуг связи
      /// </summary>
      [JsonIgnoreAttribute]
      [Display(Name = "Доступность услуг связи")]
      public CommunicationService CommSrv { 
         get {return _commSrv;}
         set {
            _commSrv = value;
            _commSrv.LocalityId = Id;
            _commSrv.Locality = this;
         } 
      }

      /// <summary>
      /// Количество жителей
      /// </summary>
      public virtual List<Population> Populations { get; private set; }
      #endregion

      #region Ctors
      public Locality() {
         Populations = new List<Population>();
         CommSrv = new CommunicationService();
      }
      #endregion

      #region Methods
      public override string ToString() {
         return FullName;
      }

      public override int GetHashCode() {
         return (int)Id;
      }

      public override bool Equals(object obj) {
         if (obj == null)
            return false;

         Locality other = obj as Locality;
         if (other == null)
            return false;

         return (this.Id == other.Id);
      }

      /// <summary>
      /// Вернуть актуальное значение популяции ( на самую позднюю дату)
      /// </summary>
      private Population GetCurrentPopulation() {
         Population population = (from p in Populations
                                  where p.Date == Populations.Max(p1 => p1.Date)
                                  select p).SingleOrDefault();
         return population;
      }

      /// <summary>
      /// Загрзуить с сайта Роскомнадзора данныые о доступности услуг связи
      /// </summary>
      public void DownloadCommSrv() {
         Parser parser = new Parser();
         CommunicationService commSrv = parser.DownloadCommSrv(Id);
         if (commSrv != null) {
            this.CommSrv = commSrv;
            Repository repo = Repository.GetRepository();
            if (!repo.CommSrvs.Contains(commSrv))
               repo.CommSrvs.Add(commSrv);
         }
      }
      #endregion

      #region Реализация IComparable<T>, IComparable
      public int CompareTo(Locality other) {
         if (other == null)
            return 1;
         if (this.Equals(other))
            return 0;

         int thisHachCode = this.Name.GetHashCode();
         int otherHashCode = other.Name.GetHashCode();
         if (thisHachCode > otherHashCode)
            return 1;
         if (thisHachCode < otherHashCode)
            return -1;


         return this.Id.CompareTo(other.Id);
      }

      public int CompareTo(object obj) {
         if (obj == null)
            return 1;
         Locality other = obj as Locality;
         return this.CompareTo(other);
      }
      #endregion
   }
}
