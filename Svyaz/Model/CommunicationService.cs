using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Svyaz.Model {
   /// <summary>
   /// Услуги связи в населенном пункте (Communication services)
   /// </summary>
   public class CommunicationService {
      #region Fields
      private DataSrc _dataSrc;
      #endregion

      #region Properties
      /// <summary>
      /// Код населенного пункта
      /// </summary>
      public int LocalityId { get; set; }

      /// <summary>
      /// Источник данных
      /// </summary>
      [Display(Name = "Источник данных")]
      [Browsable(false)]
      [JsonIgnore]
      public DataSrc DataSrc {
         get { return _dataSrc; }
         set {
            if (value != _dataSrc) {
               _dataSrc = value;
               SetDataSource(_dataSrc);
            }
         }
      }


      /// <summary>
      /// Населенный пункт
      /// </summary>
      [JsonIgnoreAttribute]
      [Display(Name = "Населеный пункт")]
      public virtual Locality Locality { get; set; }

      /// <summary>
      /// Доступность почтовой связи
      /// </summary>
      [JsonIgnoreAttribute]
      [Display(Name = "Почтовая связь")]
      public bool PostOn { get { return (PostOnDetail == null || PostOnDetail.Where(i => i.Availability == true).Count() < 1) ? false : true; } }

      /// <summary>
      /// Доступность местной телефонной связи
      /// </summary>
      [Display(Name = "Местная телеф. связь")]
      public bool PhoneOn { get { return (PhoneOnDetail == null || PhoneOnDetail.Where(i => i.Availability == true).Count() < 1) ? false : true; } }

      /// <summary>
      /// Количесство таксофонов
      /// </summary>
      [JsonIgnoreAttribute]
      [Display(Name = "Кол. таксофонов")]
      public int PayphoneCount {
         get {
            if (PayphoneDetail == null)
               return 0;
            int count = PayphoneDetail.Sum(i => i.Count);
            return count;
         }
      }

      /// <summary>
      /// Доступность внутризоновой телефонной связи
      /// </summary>
      [Display(Name = "Внутризоновая телеф. связь")]
      public bool IntraZonePhoneOn { get { return (IntraZonePhoneDetail == null || IntraZonePhoneDetail.Where(i => i.Availability == true).Count() < 1) ? false : true; } }

      /// <summary>
      /// Доступность междугородней и международной телефонной связи
      /// </summary>
      [Display(Name = "Междугородная и международная связь")]
      public bool LongDistancePhoneOn { get { return (LongDistancePhoneDetail == null || LongDistancePhoneDetail.Where(i => i.Availability == true).Count() < 1) ? false : true; } }

      /// <summary>
      /// Доступность услуг передачи данных, за исключением голосовой
      /// </summary>
      [Display(Name = "Услуги передачи данных")]
      public bool DataTransferOn { get { return (TransferDataDetails == null || TransferDataDetails.Where(i => i.MaxRateData.Value.Rate > 0m).Count() < 1) ? false : true; } }

      /// <summary>
      /// Доступность телематических услуг связи (доступ в интернет)
      /// </summary>
      [Display(Name = "Телематические услуги связи")]
      public bool TelematicServiceOn { get { return (TelematicDataDetails == null || TelematicDataDetails.Where(i => i.MaxRateData.Value.Rate > 0m).Count() < 1) ? false : true; } }

      /// <summary>
      /// Наличие (тип) состовй связи стандарта GSM
      /// </summary>
      [Display(Name = "GSM")]
      public GsmType GsmOn {
         get {
            if (GsmDetail == null || GsmDetail.Count < 1)
               return GsmType.None;
            int gsm_900_1800 = GsmDetail.Count(i => i.GSMType == GsmType.Gsm_900_1800);
            int gsm_1800 = GsmDetail.Count(i => i.GSMType == GsmType.Gsm_1800);
            if (gsm_900_1800 > 0 && gsm_1800 > 0)
               return GsmType.Gsm_1800_900_1800;
            else if (gsm_900_1800 > 0 && gsm_1800 == 0)
               return GsmType.Gsm_900_1800;
            else if (gsm_900_1800 == 0 && gsm_1800 > 0)
               return GsmType.Gsm_1800;
            return GsmType.None;
         }
      }

      /// <summary>
      /// Доступность сотовой связи стандарта UMTS
      /// </summary>
      [Display(Name = "UMTS")]
      public bool UmtsOn { get { return (UmtsDetail == null || UmtsDetail.Where(i => i.Availability == true).Count() < 1) ? false : true; } }

      /// <summary>
      /// Доступность сотовой связи стандарта LTE (4G)
      /// </summary>
      [Display(Name = "LTE")]
      public bool LteOn { get { return (LteDetail == null || LteDetail.Where(i => i.Availability == true).Count() < 1) ? false : true; } }

      /// <summary>
      /// Наличие  сотовой связи стандарта NMT-450
      /// </summary>
      [Display(Name = "NMT-450")]
      public bool NmtOn { get { return false; } }

      /// <summary>
      /// Наличие услуг радиосвязи стандарта IMT-MC-450 (CDMA)
      /// </summary>
      [Display(Name = "IMT-MC-450 (CDMA)")]
      public bool CdmaOn { get { return false; } }

      /// <summary>
      ///Доступноть эфирного телевидения
      /// </summary>
      [Display(Name = "Эфирное телевидение")]
      public bool TvOn { get { return (EtvChanelDetail == null || EtvChanelDetail.Count < 1) ? false : true; } }

      /// <summary>
      /// Количество цифровых каналов эфирного телевидения
      /// </summary>
      [Display(Name = "Кол. цифровых телеканалов")]
      public int DigitalChanelCount { 
         get {
            if (EtvDigitalChanelDetail == null || EtvDigitalChanelDetail.Count < 1)
               return 0;
            int max = EtvDigitalChanelDetail.Sum(i => i.Count);
            return max;
         } 
      }

      /// <summary>
      /// Количество аналоговых каналов эфирного телевидения
      /// </summary>
      [Display(Name = "Кол. аналоговых телеканалов")]
      public int AnalogChanelCount {
         get {
            if (EtvAnalogChanelDetail == null || EtvAnalogChanelDetail.Count < 1)
               return 0;
            int max = EtvAnalogChanelDetail.Sum(i => i.Count);
            return max;
         }
      }

      /// <summary>
      /// Доступность услуг радиовещания
      /// </summary>
      [Display(Name = "Радиовещание")]
      public bool BroadcastingOn { get { return (RvChanelDetail == null || RvChanelDetail.Count < 1) ? false : true; } }

      /// <summary>
      /// Количество цифровых радиоканалов
      /// </summary>
      [Display(Name = "Кол. цифровых радиоканалов")]
      public int DigitalChanelCount2 {
         get {
            if (RvDigitalChanelDetail == null || RvDigitalChanelDetail.Count < 1)
               return 0;
            int max = RvDigitalChanelDetail.Sum(i => i.Count);
            return max;
         }
      }

      /// <summary>
      /// Количество аналоговоых радиоканалов
      /// </summary>
      [Display(Name = "Кол. аналоговых радиоканалов")]
      public int AnalogChanelCount2 {
         get {
            if (RvAnalogChanelDetail == null || RvAnalogChanelDetail.Count < 1)
               return 0;
            int max = RvAnalogChanelDetail.Sum(i => i.Count);
            return max;
         }
      }

      /// <summary>
      /// Количество каналов кабельног телевидения (КТВ)
      /// </summary>
      [Display(Name = "Кол. каналов кабельного ТВ")]
      public int CabelChanelCount {
         get {
            if (CableChanelDetail == null || CableChanelDetail.Count < 1)
               return 0;
            int max = CableChanelDetail.Sum(i => i.Count);
            return max;
         }
      }

      /// <summary>
      /// Количество почтамптов
      /// </summary>
      [Display(Name = "Количество почтамтов")]
      public int PostCount { get; set; }

      /// <summary>
      /// Количество отделений почтовой связи
      /// </summary>
      [Display(Name = "Количество отделений почтовой связи")]
      public int PostOfficeCount {
         get {
            if (PostOfficeDetail == null || PostOfficeDetail.Count < 1)
               return 0;
            int sum = PostOfficeDetail.Sum(i => i.Count);
            return sum;
         }
      }

      /// <summary>
      /// Количество таксофонов (похоже, что речь идет об отделениях почты)
      /// </summary>
      [Display(Name = "Количество таксофонов")]
      public int PayphoneCount2 {
         get {
            if (PayphoneDetail2 == null || PayphoneDetail2.Count < 1)
               return 0;
            int sum = PayphoneDetail2.Sum(i => i.Count);
            return sum;
         }
      }

      /// <summary>
      /// количество пунктов коллективного доступа (community access points (caps) count)
      /// </summary>
      [Display(Name = "Количество ПКД")]
      public int CapsCount {
         get {
            if (CapsDetail == null || CapsDetail.Count < 1)
               return 0;
            int sum = CapsDetail.Sum(i => i.Count);
            return sum;
         }
      }

      /// <summary>
      /// Количество рабочик мест в пунктах коллективного доступа
      /// </summary>
      [Display(Name = "Количество рабочих мест в ПКД")]
      public int CapsJobCount {
         get {
            if (CapsJobDetail == null || CapsJobDetail.Count < 1)
               return 0;
            int sum = CapsJobDetail.Sum(i => i.Count);
            return sum;
         }
      }

      /// <summary>
      /// Доступность для населения точек доступа
      /// </summary>
      [Display(Name = "Точки доступа")]
      public bool AccessPointOn { get; set; }

      /// <summary>
      /// Количество точек доступа
      /// </summary>
      [Display(Name = "Количество точек доступа")]
      public int AccessPointCount {
         get {
            if (AccessPointCountDetail == null || AccessPointCountDetail.Count < 1)
               return 0;
            int sum = AccessPointCountDetail.Sum(i => i.Count);
            return sum;
         }
      }
      #endregion

      #region Данные
      /// <summary>
      /// Операторы предоставляющие услуги почтовой связи
      /// </summary>
      public virtual List<OperatorInfo> PostOnDetail { get; set; }

      /// <summary>
      /// Операторы предоставляющие услуги местной телефонной связи
      /// </summary>
      public virtual List<OperatorInfo> PhoneOnDetail { get; set; }

      /// <summary>
      /// Операторы имеющие таксофоны
      /// </summary>
      public virtual List<CountInfo> PayphoneDetail { get; set; }

      /// <summary>
      /// Операторы осуществляющие внутризоновую связь
      /// </summary>
      public virtual List<OperatorInfo> IntraZonePhoneDetail { get; set; }

      /// <summary>
      /// Операторы осуществляющие междугороднюю и международную связь
      /// </summary>
      public virtual List<OperatorInfo> LongDistancePhoneDetail { get; set; }

      /// <summary>
      /// Операторы осуществляющие услуги передачи данных (за исключением голоса) по собственным сетям
      /// </summary>
      public virtual List<TransferDataInfo> TransferDataDetails { get; set; }

      /// <summary>
      /// Операторы осуществляющие услуги телематики (доступ к сети Интренет)
      /// </summary>
      public virtual List<TransferDataInfo> TelematicDataDetails { get; set; }

      /// <summary>
      /// Операторы осуществляющие услуги сотовой связи в формате GSM
      /// </summary>
      public virtual List<GsmInfo> GsmDetail { get; set; }

      /// <summary>
      /// Операторы осуществляющие услуги сотовой связи в формате UMTS
      /// </summary>
      public virtual List<OperatorInfo> UmtsDetail { get; set; }

      /// <summary>
      /// Операторы осуществляющие услуги сотовой связи в формате LTE
      /// </summary>
      public virtual List<OperatorInfo> LteDetail { get; set; }

      /// <summary>
      /// Операторы осуществляющие эфирное телевизионное вещание
      /// </summary>
      public virtual List<ChanelCountInfo2> EtvChanelDetail { get; set; }

      /// <summary>
      /// Операторы осуществляющие вещание на цифровых каналах эфирного телевидения
      /// </summary>
      public virtual List<ChanelCountInfo> EtvDigitalChanelDetail { get; set; }

      /// <summary>
      /// Операторы осуществляющие вещание на аналоговых каналах эфирного телевидения
      /// </summary>
      public virtual List<ChanelCountInfo> EtvAnalogChanelDetail { get; set; }

      /// <summary>
      /// Операторы осуществляющие эфирное радиовещание
      /// </summary>
      public virtual List<ChanelCountInfo2> RvChanelDetail { get; set; }

      /// <summary>
      /// Операторы осуществляющие цифровое радиовещание
      /// </summary>
      public virtual List<ChanelCountInfo> RvDigitalChanelDetail { get; set; }

      /// <summary>
      /// Операторы осуществляющие аналоговое радиовещание
      /// </summary>
      public virtual List<ChanelCountInfo> RvAnalogChanelDetail { get; set; }

      /// <summary>
      /// Операторы осуществляющие кабельное вещание
      /// </summary>
      public virtual List<ChanelCountInfo> CableChanelDetail { get; set; }

      /// <summary>
      /// Операторы имеющие почтовые отделения
      /// </summary>
      public virtual List<CountInfo> PostOfficeDetail { get; set; }

      /// <summary>
      /// Операторы имеющие таксофоны в отделениях почты
      /// </summary>
      public virtual List<CountInfo> PayphoneDetail2 { get; set; }

      /// <summary>
      /// Операторы имеющие ПКД
      /// </summary>
      public virtual List<CountInfo> CapsDetail { get; set; }

      /// <summary>
      /// Кол. рабочих мест в ПКД по операторам
      /// </summary>
      public virtual List<CountInfo> CapsJobDetail { get; set; }

      /// <summary>
      /// Кол. точек доступа по операторам
      /// </summary>
      public virtual List<AccessPointInfo> AccessPointCountDetail { get; set; }
      #endregion

      #region ctors
      public CommunicationService() {
         _dataSrc = Svyaz.DataSrc.OpenData;

         PostOnDetail = new List<OperatorInfo>();
         PhoneOnDetail = new List<OperatorInfo>();

         PayphoneDetail = new List<CountInfo>();
         IntraZonePhoneDetail = new List<OperatorInfo>();
         LongDistancePhoneDetail = new List<OperatorInfo>();

         GsmDetail = new List<GsmInfo>();
         UmtsDetail = new List<OperatorInfo>();
         LteDetail = new List<OperatorInfo>();

         EtvDigitalChanelDetail = new List<ChanelCountInfo>();
         EtvAnalogChanelDetail = new List<ChanelCountInfo>();
         RvDigitalChanelDetail = new List<ChanelCountInfo>();
         RvAnalogChanelDetail = new List<ChanelCountInfo>();
         CableChanelDetail = new List<ChanelCountInfo>();
         PostOfficeDetail = new List<CountInfo>();
         PayphoneDetail2 = new List<CountInfo>();
         CapsDetail = new List<CountInfo>();
         CapsJobDetail = new List<CountInfo>();

         TransferDataDetails = new List<TransferDataInfo>();
         TelematicDataDetails = new List<TransferDataInfo>();
         EtvChanelDetail = new List<ChanelCountInfo2>();
         RvChanelDetail = new List<ChanelCountInfo2>();
         AccessPointCountDetail = new List<AccessPointInfo>();
      }
      #endregion

      #region Methods
      /// <summary>
      /// Вернуть словарь содержащий привязку имени свойства к коллекции детализирующей это свойство
      /// </summary>
      public IList GetMasterDetailInfo(DataSrc src, string detailName) {
         if (detailName == "PostOn") {
            PostOnDetail.ForEach(i => i.DataSrc = src);
            return PostOnDetail;
         }

         if (detailName == "PhoneOn") {
            PhoneOnDetail.ForEach(i => i.DataSrc = src);
            return PhoneOnDetail;
         }

         if (detailName == "PayphoneCount") {
            PayphoneDetail.ForEach(i => i.DataSrc = src);
            return PayphoneDetail;
         }

         if (detailName == "IntraZonePhoneOn") {
            IntraZonePhoneDetail.ForEach(i => i.DataSrc = src);
            return IntraZonePhoneDetail;
         }

         if (detailName == "LongDistancePhoneOn") {
            LongDistancePhoneDetail.ForEach(i => i.DataSrc = src);
            return LongDistancePhoneDetail;
         }

         if (detailName == "DataTransferOn") {
            TransferDataDetails.ForEach(i => i.DataSrc = src);
            return TransferDataDetails;
         }

         if (detailName == "TelematicServiceOn") {
            TelematicDataDetails.ForEach(i => i.DataSrc = src);
            return TelematicDataDetails;
         }

         if (detailName == "GsmOn") {
            GsmDetail.ForEach(i => i.DataSrc = src);
            return GsmDetail;
         }

         if (detailName == "UmtsOn") {
            UmtsDetail.ForEach(i => i.DataSrc = src);
            return UmtsDetail;
         }

         if (detailName == "LteOn") {

            LteDetail.ForEach(i => i.DataSrc = src);
            return LteDetail;
         }

         if (detailName == "TvOn") {
            EtvChanelDetail.ForEach(i => i.DataSrc = src);
            return EtvChanelDetail;
         }

         if (detailName == "DigitalChanelCount") {
            EtvDigitalChanelDetail.ForEach(i => i.DataSrc = src);
            return EtvDigitalChanelDetail;
         }

         if (detailName == "AnalogChanelCount") {
            EtvAnalogChanelDetail.ForEach(i => i.DataSrc = src);
            return EtvAnalogChanelDetail;
         }

         if (detailName == "BroadcastingOn") {
            RvChanelDetail.ForEach(i => i.DataSrc = src);
            return RvChanelDetail;
         }

         if (detailName == "DigitalChanelCount2") {
            RvDigitalChanelDetail.ForEach(i => i.DataSrc = src);
            return RvDigitalChanelDetail;
         }

         if (detailName == "AnalogChanelCount2") {
            RvAnalogChanelDetail.ForEach(i => i.DataSrc = src);
            return RvAnalogChanelDetail;
         }

         if (detailName == "CabelChanelCount") {
            CableChanelDetail.ForEach(i => i.DataSrc = src);
            return CableChanelDetail;
         }

         if (detailName == "PostOfficeCount") {
            PostOfficeDetail.ForEach(i => i.DataSrc = src);
            return PostOfficeDetail;
         }

         if (detailName == "PayphoneCount2") {
            PayphoneDetail2.ForEach(i => i.DataSrc = src);
            return PayphoneDetail2;
         }

         if (detailName == "CapsCount") {
            CapsDetail.ForEach(i => i.DataSrc = src);
            return CapsDetail;
         }

         if (detailName == "CapsJobCount") {
            CapsJobDetail.ForEach(i => i.DataSrc = src);
            return CapsJobDetail;
         }

         if (detailName == "AccessPointCount") {
            AccessPointCountDetail.ForEach(i => i.DataSrc = src);
            return AccessPointCountDetail;
         }

         return null;
      }

      public bool ExistCorp(string detailName, Corporation corp, DataSrc src = Svyaz.DataSrc.OpenData) {
         int cnt = 0;
         IList details = GetMasterDetailInfo(src, detailName);
         if (details != null)
            cnt = details.Cast<ICorp>().Where(c => c.Corp.CorporateName == corp.CorporateName).Count();
         return (cnt > 0);
      }

      public bool ExistCorp(string detailName, BaseOperatorInfo op, DataSrc src = Svyaz.DataSrc.OpenData) {
         int cnt = 0;
         IList details = GetMasterDetailInfo(src, detailName);
         if (details != null)
            cnt = details.Cast<ICorp>().Where(c => op.Corporations.Contains(c.Corp)).Count();
         return (cnt > 0);
      }

      /// <summary>
      /// Установить новое занчение для источника данных
      /// </summary>
      public void SetDataSource(DataSrc src){
         PostOnDetail.ForEach(i => i.DataSrc = src);
         PhoneOnDetail.ForEach(i => i.DataSrc = src);
         PayphoneDetail.ForEach(i => i.DataSrc = src);
         IntraZonePhoneDetail.ForEach(i => i.DataSrc = src);
         LongDistancePhoneDetail.ForEach(i => i.DataSrc = src);
         TransferDataDetails.ForEach(i => i.DataSrc = src);
         TelematicDataDetails.ForEach(i => i.DataSrc = src);
         GsmDetail.ForEach(i => i.DataSrc = src);
         UmtsDetail.ForEach(i => i.DataSrc = src);
         LteDetail.ForEach(i => i.DataSrc = src);
         EtvChanelDetail.ForEach(i => i.DataSrc = src);
         EtvDigitalChanelDetail.ForEach(i => i.DataSrc = src);
         EtvAnalogChanelDetail.ForEach(i => i.DataSrc = src);
         RvChanelDetail.ForEach(i => i.DataSrc = src);
         RvDigitalChanelDetail.ForEach(i => i.DataSrc = src);
         RvAnalogChanelDetail.ForEach(i => i.DataSrc = src);
         CableChanelDetail.ForEach(i => i.DataSrc = src);
         PostOfficeDetail.ForEach(i => i.DataSrc = src);
         PayphoneDetail2.ForEach(i => i.DataSrc = src);
         CapsDetail.ForEach(i => i.DataSrc = src);
         CapsJobDetail.ForEach(i => i.DataSrc = src);
         AccessPointCountDetail.ForEach(i => i.DataSrc = src);
      }

      /// <summary>
      /// Обновить содержимое списка, заданного типа
      /// </summary>
      /// <param name="srcList">Добавляемые или изменяемые данные</param>
      /// <param name="dstList">конечный список</param>
      private List<T> UpdateList<T>(IList srcList, List<T> dstList) {
         List<T> list = srcList as List<T>;
         IEnumerable<T> collection = dstList.Union(list);
         dstList = new List<T>(collection);
         return dstList;
      }

      /// <summary>
      /// Вернуть список имен свойств, которые имеют детализирующие их коллекции
      /// </summary>
      public static List<string> GetCollectionPropNames() {
         List<string> collPropNames = new List<string>() {
            "PostOn", "PhoneOn", "PayphoneCount", "IntraZonePhoneOn", "LongDistancePhoneOn", "DataTransferOn", "TelematicServiceOn", 
            "GsmOn", "UmtsOn", "LteOn", "TvOn",  "DigitalChanelCount", "AnalogChanelCount", "BroadcastingOn", "DigitalChanelCount2", 
            "AnalogChanelCount2", "CabelChanelCount", "PostOfficeCount", "PayphoneCount2", "CapsCount", "CapsJobCount", "AccessPointCount"
         };

         return collPropNames;
      }

      public override string ToString() {
         return string.Format("id = {0}, PostOn = {1}, PostOnDetail = {2}", LocalityId, PostOn, PostOnDetail.Count);
      }

      public override int GetHashCode() {
         return LocalityId.GetHashCode();
      }

      public override bool Equals(object obj) {
         if (obj == null)
            return false;
         CommunicationService other = obj as CommunicationService;
         if (other == null)
            return false;
         return this.GetHashCode() == other.GetHashCode();
      }
      #endregion
   }
}
