using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Svyaz.Model;

namespace Svyaz.Data {
   public class Repository: IReloadData {
      #region Fields
      private static string dataCatalog = Path.Combine(Environment.CurrentDirectory, "Data\\");
      private static BaseOperatorInfo unknownOperator = new BaseOperatorInfo() { OperatorName = BaseOperatorInfo.UnknownName
                                                                               , DefaultName = BaseOperatorInfo.UnknownName };

      private object lockObj;
      private static JsonSerializerSettings settings = null;

      private List<Borrough> borrougts;               // районы
      private List<Settlement> settlements;           // поселения
      private List<Locality> localities;              // населенные пункты
      private List<LicensedActivity> licActivities;   // лицензируемая деятельность (услуги)
      private List<ColumnInfo> columns;               // инф. о колонках в своде
      private HashSet<Corporation> corps;             // юридические лица оказывающе услуги связи 
      private List<BaseOperatorInfo> operators;       // операторы связи
      private List<CommunicationService> commSrvs;    // инф. о доступности услуг связи

      private Dictionary<string, string> dataFileDescr;  // словарь с картким описанием файлов данных
      #endregion

      #region Properties
      /// <summary>
      /// Неизвестный оператор связи
      /// </summary>
      public static BaseOperatorInfo UnknownOperator {
         get { return unknownOperator; }
      }

      /// <summary>
      /// Районы
      /// </summary>
      public List<Borrough> Borrougts {
         get { return borrougts; }
      }

      /// <summary>
      /// Поселения
      /// </summary>
      public List<Settlement> Settlements {
         get { return settlements; }
      }

      /// <summary>
      /// Населенные пункты
      /// </summary>
      public List<Locality> Localities {
         get { return localities; }
      }

      /// <summary>
      /// Лицензируемая деятельность (услуги) 
      /// </summary>
      public List<LicensedActivity> LicActivities {
         get { return licActivities; }
      }

      /// <summary>
      /// Колонки для отображения свода 
      /// </summary>
      public List<ColumnInfo> Columns {
         get { return columns; }
      }

      /// <summary>
      /// Юридические лица оказывающие услуги связи
      /// </summary>
      public HashSet<Corporation> Corps {
         get { return corps; }
         set { corps = value; }
      }

      /// <summary>
      /// Операторы связи
      /// </summary>
      public List<BaseOperatorInfo> Operators {
         get { return operators; }
         set { operators = value; }
      }

      /// <summary>
      /// Информация о доступности услуг связи
      /// </summary>
      public List<CommunicationService> CommSrvs {
         get { return commSrvs; }
      }
      #endregion

      #region Ctors
      static Repository() {
         settings = new JsonSerializerSettings();
         settings.Converters.Add(new CoporationConverter());
      }

      private Repository() {
         lockObj = new object();

         LoadData();
         CreateDataFileDescr();
      }
      #endregion

      #region Singleton
      private static Repository instance;

      /// <summary>
      /// Вернуть репозиторий данных
      /// </summary>
      public static Repository GetRepository() {
         if (instance == null) {
            instance = new Repository();
         }
         return instance;
      }
      #endregion

      #region Methods
      /// <summary>
      /// Перезагрузить данные с диска заново
      /// </summary>
      public void LoadData() {
         borrougts = new List<Borrough>();
         settlements = new List<Settlement>();
         localities = new List<Locality>();
         columns = new List<ColumnInfo>();
         commSrvs = new List<CommunicationService>();
         corps = new HashSet<Corporation>();
         operators = new List<BaseOperatorInfo>();

         Deserialize();
      }

      /// <summary>
      /// Сохранить все
      /// </summary>
      public void SaveAll() {
         // инф. о лицензируемой деятельности (услугах)
         string path = Path.Combine(dataCatalog, "licActivities.json");
         SerializeCollection<LicensedActivity>(licActivities, path);

         // инф. о юридических лицах
         path = Path.Combine(dataCatalog, "corps.json");
         SerializeHashSet<Corporation>(corps, path);
         
         // колонки для отображения кода
         path = Path.Combine(dataCatalog, "columns.json");
         SerializeCollection<ColumnInfo>(columns, path);

         // Населенные пункты
         path = Path.Combine(dataCatalog, "localities.json");
         SerializeCollection<Locality>(localities, path);

         // Данные об услугах связи
         commSrvs.Clear();
         foreach (Locality item in localities) {
            commSrvs.Add(item.CommSrv);
         }
         path = Path.Combine(dataCatalog, "commsrvs.json");
         SerializeCollection<CommunicationService>(commSrvs, path);
      }

      /// <summary>
      /// Загрузить данные с диска
      /// </summary>
      private void Deserialize() {
         string path = "";

         // лицензируемая деятельность (услуги)
         path = Path.Combine(dataCatalog, "licActivities.json");
         if (File.Exists(path)) {
            licActivities = DeserializeCollection<LicensedActivity>(path);
         } else
            licActivities = CreateLicensedActivities();

         // колонки для отображения свода
         path = Path.Combine(dataCatalog, "columns.json");
         if (File.Exists(path)) {
            columns = DeserializeCollection<ColumnInfo>(path);
         } else
            columns = CreateColumns();

         // юридические лица
         path = Path.Combine(dataCatalog, "corps.json");
         if (File.Exists(path)) {
            corps = DeserializeHashSet<Corporation>(path);
         }

         // операторы связи
         operators = CreateOperators();
         foreach (Corporation corp in corps) {
            BaseOperatorInfo op = corp.Operator;
            int idx = operators.IndexOf(op);
            if (idx < 0)
               operators.Add(op);
            else {
               op = operators[idx];
               corp.Operator = op;
            }
         }

         // привязать юр. лица к "неизвестному" оператору связи
         var unk = operators.SingleOrDefault(o => o.OperatorName == BaseOperatorInfo.UnknownName);
         if (unk != null) {
            unk.Corporations.ToList().ForEach(c => c.Operator = unk);
            unknownOperator = unk;
         }

         // данные о досупности услуг связи
         path = Path.Combine(dataCatalog, "commsrvs.json");
         commSrvs = DeserializeCollection<CommunicationService>(path);
         if (corps.Count == 0) {   // если список юр. лиц не был загружен    
            CreateDefaultCorps();  // создать список юр. лиц по инф. содержаещейся в commSrvs 
         }
         InitCommSrvs();

         // насленные пункты
         path = Path.Combine(dataCatalog, "localities.json");
         localities = DeserializeCollection<Locality>(path);

         // поселения
         path = Path.Combine(dataCatalog, "settlements.json");
         settlements = DeserializeCollection<Settlement>(path);

         // районы
         path = Path.Combine(dataCatalog, "borroughts.json");
         borrougts = DeserializeCollection<Borrough>(path);

         // инициализируем объект Доступность услуг связи для каждого населенного пункта
         foreach (Locality locality in localities) {
            CommunicationService commSrv = GetCommSrv(locality.Id);
            locality.CommSrv = commSrv;
         }

         // инициализируем объект Поселение для каждого населенного пункта
         Parallel.ForEach(settlements, settlement => {
            var query = from l in localities
                        where (l.SettlementId == settlement.Id)
                        select l;
            foreach (Locality locality in query) {
               locality.Settlement = settlement;
            }
            settlement.Localities.AddRange(query); // добавим к поселению список населенных пунктов
         });

         // инициализируем объектs Center и Borrough  для каждого поселения
         foreach (Settlement item in settlements) {
            if (item.CenterId != null) {
               Locality center = GetLocality((int)item.CenterId);
               item.Center = center;

               Borrough borrough = GetBorrough((int)item.BorroughId);
               item.Borrough = borrough;
            }
         }

         // инициализируем загрузку райцентров для каждого из районов
         foreach (Borrough item in borrougts) {
            if (item.CenterId == null)
               continue;
            int id = (int)item.CenterId;
            Locality center = (from l in localities
                               where l.Id == id
                               select l).SingleOrDefault();
            item.Center = center;
         }

         // инициализируем загрузку списка поселений для каждого из районов
         foreach (Borrough item in borrougts) {
            int borroughId = item.Id;
            List<Settlement> _settlements = (from s in settlements
                                             where s.BorroughId == borroughId
                                             select s).ToList();
            item.Settlements.AddRange(_settlements);
         }
      }

      /// <summary>
      /// Выполнить инициализацию услуг связи. Добавить список юр. лиц оказыывающих услуги
      /// </summary>
      /// <param name="commSrvs">услуги связи</param>
      /// <param name="corpSrvs">привязка юр. лиц к услугам связи</param>
      private void InitCommSrvs() {
         foreach (var commSrv in commSrvs) {
            // OperatorInfo
            if (commSrv.PostOnDetail.Count > 0) {
               commSrv.PostOnDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.PostOnDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("PostOn").GetActivity()));
            }
            if (commSrv.PhoneOnDetail.Count > 0) {
               commSrv.PhoneOnDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.PhoneOnDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("PhoneOn").GetActivity()));
            }
            if (commSrv.IntraZonePhoneDetail.Count > 0) {
               commSrv.IntraZonePhoneDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.IntraZonePhoneDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("IntraZonePhoneOn").GetActivity()));
            }
            if (commSrv.LongDistancePhoneDetail.Count > 0) {
               commSrv.LongDistancePhoneDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.LongDistancePhoneDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("LongDistancePhoneOn").GetActivity()));
            }
            if (commSrv.UmtsDetail.Count > 0) {
               commSrv.UmtsDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.UmtsDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("UmtsOn").GetActivity()));
            }
            if (commSrv.LteDetail.Count > 0) {
               commSrv.LteDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.LteDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("LteOn").GetActivity()));
            }
            // CountInfo
            if (commSrv.PayphoneDetail.Count > 0) {
               commSrv.PayphoneDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.PayphoneDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("PayphoneCount").GetActivity()));
            }
            if (commSrv.PostOfficeDetail.Count > 0) {
               commSrv.PostOfficeDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.PostOfficeDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("PostOfficeCount").GetActivity()));
            }
            if (commSrv.PayphoneDetail2.Count > 0) {
               commSrv.PayphoneDetail2.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.PayphoneDetail2.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("PayphoneCount2").GetActivity()));
            }
            if (commSrv.CapsDetail.Count > 0) {
               commSrv.CapsDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.CapsDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("CapsCount").GetActivity()));
            }
            if (commSrv.CapsJobDetail.Count > 0) {
               commSrv.CapsJobDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.CapsJobDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("CapsJobCount").GetActivity()));
            }
            // TransferDataInfo
            if (commSrv.TransferDataDetails.Count > 0) {
               commSrv.TransferDataDetails.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.TransferDataDetails.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("DataTransferOn").GetActivity()));
            }
            if (commSrv.TelematicDataDetails.Count > 0) {
               commSrv.TelematicDataDetails.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.TelematicDataDetails.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("TelematicServiceOn").GetActivity()));
            }
            // GsmInfo
            if (commSrv.GsmDetail.Count > 0) {
               commSrv.GsmDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.GsmDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("GsmOn").GetActivity()));
            }
            // ChanelCountInfo2
            if (commSrv.EtvChanelDetail.Count > 0) {
               commSrv.EtvChanelDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.EtvChanelDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("TvOn").GetActivity()));
            }
            if (commSrv.RvChanelDetail.Count > 0) {
               commSrv.RvChanelDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.RvChanelDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("BroadcastingOn").GetActivity()));
            }
            // ChanelCountInfo
            if (commSrv.EtvDigitalChanelDetail.Count > 0) {
               commSrv.EtvDigitalChanelDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.EtvDigitalChanelDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("DigitalChanelCount").GetActivity()));
            }
            if (commSrv.EtvAnalogChanelDetail.Count > 0) {
               commSrv.EtvAnalogChanelDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.EtvAnalogChanelDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("AnalogChanelCount").GetActivity()));
            }
            if (commSrv.RvDigitalChanelDetail.Count > 0) {
               commSrv.RvDigitalChanelDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.RvDigitalChanelDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("DigitalChanelCount2").GetActivity()));
            }
            if (commSrv.RvAnalogChanelDetail.Count > 0) {
               commSrv.RvAnalogChanelDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.RvAnalogChanelDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("AnalogChanelCount2").GetActivity()));
            }
            if (commSrv.CableChanelDetail.Count > 0) {
               commSrv.CableChanelDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.CableChanelDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("CabelChanelCount").GetActivity()));
            }
            // AccessPointInfo
            if (commSrv.AccessPointCountDetail.Count > 0) {
               commSrv.AccessPointCountDetail.ForEach(i => i.Corp = corps.Single(c => c.CorporateName == i.CorporateName));
               commSrv.AccessPointCountDetail.ForEach(i => i.Corp.Activities.Add(FindColumnInfo("AccessPointCount").GetActivity()));
            }
         }
      }

      /// <summary>
      /// Сохранить коллекцию на диск
      /// </summary>
      private static void SerializeCollection<T>(List<T> collection, string path) {
         string json = JsonConvert.SerializeObject(collection, Formatting.Indented);
         File.WriteAllText(path, json);
      }

      /// <summary>
      /// Сохранить hashset на диск
      /// </summary>
      private static void SerializeHashSet<T>(HashSet<T> collection, string path) {
         string json = JsonConvert.SerializeObject(collection, Formatting.Indented);
         File.WriteAllText(path, json);
      }

      /// <summary>
      /// Загрузить коллекцию с диска
      /// </summary>
      private static List<T> DeserializeCollection<T>(string path) {
         List<T> collection = new List<T>();
         if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            collection = JsonConvert.DeserializeObject<List<T>>(json);
         }
         return collection;
      }

      /// <summary>
      /// Загрузить HashSet с диска
      /// </summary>
      private static HashSet<T> DeserializeHashSet<T>(string path) {
         HashSet<T> collection = new HashSet<T>();
         if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            collection = JsonConvert.DeserializeObject<HashSet<T>>(json, settings);
         }
         return collection;
      }

      /// <summary>
      /// Найти населенный пункт по заданному коду (Id)
      /// </summary>
      public Locality GetLocality(int id) {
         Locality locality = null;
         locality = (from l in localities
                     where l.Id == id
                     select l).SingleOrDefault();

         return locality;
      }

      /// <summary>
      /// Найти объект "Услуги связи" для указанного населенного пункта
      /// </summary>
      public CommunicationService GetCommSrv(int id) {
         CommunicationService commSrv = null;
         commSrv = (from c in commSrvs
                    where c.LocalityId == id
                    select c).SingleOrDefault();
         if (commSrv == null)
            commSrv = new CommunicationService();
         return commSrv;
      }

      /// <summary>
      /// Найти поселение по заданному коду (Id)
      /// </summary>
      public Settlement GetSettlement(int id) {
         Settlement settlement = null;
         settlement = (from s in settlements
                       where s.Id == id
                       select s).SingleOrDefault();

         return settlement;
      }

      /// <summary>
      /// Найти район по заданному коду (Id)
      /// </summary>
      public Borrough GetBorrough(int id) {
         Borrough borrough = null;
         borrough = (from b in borrougts
                     where b.Id == id
                     select b).SingleOrDefault();

         return borrough;
      }

      /// <summary>
      /// Создать список колонок для отображения в своде (по умолчанию)
      /// </summary>
      private static List<ColumnInfo> CreateColumns() {
         List<ColumnInfo> lst = new List<ColumnInfo>();
         lst.Add(new ColumnInfo(-1, -1, -1, "Район", "Borrough") { IsTreeColumn = false });
         lst.Add(new ColumnInfo(-1, -2, -2, "Поселение", "Settlement") { IsTreeColumn = false });
         lst.Add(new ColumnInfo(-1, -3, -3, "Населенный пункт", "FullName") { IsTreeColumn = false });
         lst.Add(new ColumnInfo(-1, -4, -4, "Адм центр", "IsAdmCenter") { IsTreeColumn = false });
         lst.Add(new ColumnInfo(-1, -5, -5, "Жителей", "CurrentPopulationCount") { IsTreeColumn = false });

         lst.Add(new ColumnInfo(0, 1, 0, "Телефонная связь и услуги передачи данных", "PhoneOn,PayphoneCount,IntraZonePhoneOn,LongDistancePhoneOn,DataTransferOn,TelematicServiceOn"));
         lst.Add(new ColumnInfo(1, 2, 1, "Местная телеф. связь", "PhoneOn"));
         lst.Add(new ColumnInfo(7, 46, 2, "Операторы", "PhoneOnDetail"));
         lst.Add(new ColumnInfo(1, 3, 1, "Количество таксофонов", "PayphoneCount"));
         lst.Add(new ColumnInfo(1, 4, 1, "Внутризоновая телеф. связь", "IntraZonePhoneOn"));
         lst.Add(new ColumnInfo(7, 48, 4, "Операторы", "IntraZonePhoneDetail"));
         lst.Add(new ColumnInfo(1, 5, 1, "Междугородняя и международная связь", "LongDistancePhoneOn"));
         lst.Add(new ColumnInfo(7, 49, 5, "Операторы", "LongDistancePhoneDetail"));

         lst.Add(new ColumnInfo(1, 6, 1, "Услуги передачи данных", "DataTransferOn"));
         lst.Add(new ColumnInfo(7, 50, 6, "Операторы", "TransferDataDetails"));
         lst.Add(new ColumnInfo(1, 7, 1, "Телематические услуги связи", "TelematicServiceOn"));
         lst.Add(new ColumnInfo(7, 61, 7, "Операторы", "TelematicServiceDetail"));

         lst.Add(new ColumnInfo(0, 8, 0, "Сотовая связь и мобильный интернет", "GsmOn,UmtsOn,LteOn,NmtOn,CdmaOn"));
         lst.Add(new ColumnInfo(1, 9, 8, "GSM (2G)", "GsmOn"));
         lst.Add(new ColumnInfo(7, 51, 9, "Операторы", "GsmDetail"));
         lst.Add(new ColumnInfo(1, 10, 8, "UMTS (3G)", "UmtsOn"));
         lst.Add(new ColumnInfo(7, 52, 10, "Операторы", "UmtsDetail"));
         lst.Add(new ColumnInfo(1, 11, 8, "LTE (4G)", "LteOn"));
         lst.Add(new ColumnInfo(7, 53, 11, "Операторы", "LteDetail"));
         lst.Add(new ColumnInfo(1, 12, 8, "NMT-450", "NmtOn"));
         lst.Add(new ColumnInfo(1, 13, 8, "IMT-MC-450(CDMA)", "CdmaOn"));

         lst.Add(new ColumnInfo(0, 14, 0, "Телевидение и радиовещание", "TvOn,DigitalChanelCount,AnalogChanelCount,BroadcastingOn,DigitalChanelCount2,AnalogChanelCount2,CabelChanelCount"));
         lst.Add(new ColumnInfo(1, 15, 14, "Эфирное телевидение", "TvOn"));
         lst.Add(new ColumnInfo(7, 54, 15, "Операторы", "EtvChanelDetail"));
         lst.Add(new ColumnInfo(1, 16, 14, "Кол. цифровых телеканалов", "DigitalChanelCount"));
         lst.Add(new ColumnInfo(7, 55, 16, "Операторы", "EtvDigitalChanelDetail"));
         lst.Add(new ColumnInfo(1, 17, 14, "Кол. аналоговых телеканалов", "AnalogChanelCount"));
         lst.Add(new ColumnInfo(7, 56, 17, "Операторы", "EtvAnalogChanelDetail"));

         lst.Add(new ColumnInfo(1, 18, 14, "Радиовещание", "BroadcastingOn"));
         lst.Add(new ColumnInfo(7, 57, 18, "Операторы", "RvChanelDetail"));
         lst.Add(new ColumnInfo(1, 19, 14, "Кол. цифровых радиоканалов", "DigitalChanelCount2"));
         lst.Add(new ColumnInfo(7, 58, 19, "Операторы", "RvDigitalChanelDetail"));
         lst.Add(new ColumnInfo(1, 20, 14, "Кол. аналоговых радиоканалов", "AnalogChanelCount2"));
         lst.Add(new ColumnInfo(7, 59, 20, "Операторы", "RvAnalogChanelDetail"));
         lst.Add(new ColumnInfo(1, 21, 14, "Кол. каналов кабельного ТВ", "CabelChanelCount"));
         lst.Add(new ColumnInfo(7, 60, 21, "Операторы", "CableChanelDetail"));

         lst.Add(new ColumnInfo(0, 22, 0, "Услги почтовой связи", "PostOn,PostCount,PostOfficeCount,PayphoneCount2"));
         lst.Add(new ColumnInfo(1, 23, 22, "Почтовая связь", "PostOn"));
         lst.Add(new ColumnInfo(1, 24, 22, "Количество почтамптов", "PostCount"));
         lst.Add(new ColumnInfo(1, 25, 22, "Количество отделений", "PostOfficeCount"));
         lst.Add(new ColumnInfo(1, 26, 22, "Количество таксофонов", "PayphoneCount2"));

         lst.Add(new ColumnInfo(0, 27, 0, "Универсальные услуги связи", "CapsCount,CapsJobCount,AccessPointOn,AccessPointCount"));
         lst.Add(new ColumnInfo(1, 28, 27, "Количество ПКД (пунктов колл. доступа)", "CapsCount"));
         lst.Add(new ColumnInfo(1, 29, 27, "Количество рабочих мест в ПКД", "CapsJobCount"));
         lst.Add(new ColumnInfo(1, 30, 27, "Точки доступа", "AccessPointOn"));
         lst.Add(new ColumnInfo(1, 31, 27, "Количество точек доступа", "AccessPointCount"));

         return lst;
      }

      /// <summary>
      /// Вернуть список лицензируемой деятельность (Услуг связи)
      /// </summary>
      /// <returns></returns>
      private static List<LicensedActivity> CreateLicensedActivities() {
         List<LicensedActivity> lst = new List<LicensedActivity>();
         lst.Add(new LicensedActivity(1, 0, "Телефонная связь и услуги передачи данных", "PhoneOn,PayphoneCount,IntraZonePhoneOn,LongDistancePhoneOn,DataTransferOn,TelematicServiceOn"));
         lst.Add(new LicensedActivity(2, 1, "Местная телеф. связь", "PhoneOn"));
         lst.Add(new LicensedActivity(3, 1, "Количество таксофонов", "PayphoneCount"));
         lst.Add(new LicensedActivity(4, 1, "Внутризоновая телеф. связь", "IntraZonePhoneOn"));
         lst.Add(new LicensedActivity(5, 1, "Междугородняя и международная связь", "LongDistancePhoneOn"));
         lst.Add(new LicensedActivity(6, 1, "Услуги передачи данных", "DataTransferOn"));
         lst.Add(new LicensedActivity(7, 1, "Телематические услуги связи", "TelematicServiceOn"));

         lst.Add(new LicensedActivity(8, 0, "Сотовая связь и мобильный интернет", "GsmOn,UmtsOn,LteOn,NmtOn,CdmaOn"));
         lst.Add(new LicensedActivity(9, 8, "GSM (2G)", "GsmOn"));
         //lst.Add(new LicensedActivity(51, 9, "Операторы", "GsmDetail"));
         lst.Add(new LicensedActivity(10, 8, "UMTS (3G)", "UmtsOn"));
         lst.Add(new LicensedActivity(11, 8, "LTE (4G)", "LteOn"));
         lst.Add(new LicensedActivity(12, 8, "NMT-450", "NmtOn"));
         lst.Add(new LicensedActivity(13, 8, "IMT-MC-450(CDMA)", "CdmaOn"));

         lst.Add(new LicensedActivity(14, 0, "Телевидение и радиовещание", "TvOn,DigitalChanelCount,AnalogChanelCount,BroadcastingOn,DigitalChanelCount2,AnalogChanelCount2,CabelChanelCount"));
         lst.Add(new LicensedActivity(15, 14, "Эфирное телевидение", "TvOn"));
         lst.Add(new LicensedActivity(16, 14, "Кол. цифровых телеканалов", "DigitalChanelCount"));
         lst.Add(new LicensedActivity(17, 14, "Кол. аналоговых телеканалов", "AnalogChanelCount"));
         lst.Add(new LicensedActivity(18, 14, "Радиовещание", "BroadcastingOn"));
         lst.Add(new LicensedActivity(19, 14, "Кол. цифровых радиоканалов", "DigitalChanelCount2"));
         lst.Add(new LicensedActivity(20, 14, "Кол. аналоговых радиоканалов", "AnalogChanelCount2"));
         lst.Add(new LicensedActivity(21, 14, "Кол. каналов кабельного ТВ", "CabelChanelCount"));

         lst.Add(new LicensedActivity(22, 0, "Услги почтовой связи", "PostOn,PostCount,PostOfficeCount,PayphoneCount2"));
         lst.Add(new LicensedActivity(23, 22, "Почтовая связь", "PostOn"));
         lst.Add(new LicensedActivity(24, 22, "Количество почтамптов", "PostCount"));
         lst.Add(new LicensedActivity(25, 22, "Количество отделений", "PostOfficeCount"));
         lst.Add(new LicensedActivity(26, 22, "Количество таксофонов", "PayphoneCount2"));

         lst.Add(new LicensedActivity(27, 0, "Универсальные услуги связи", "CapsCount,CapsJobCount,AccessPointOn,AccessPointCount"));
         lst.Add(new LicensedActivity(28, 27, "Количество ПКД (пунктов колл. доступа)", "CapsCount"));
         lst.Add(new LicensedActivity(29, 27, "Количество рабочих мест в ПКД", "CapsJobCount"));
         lst.Add(new LicensedActivity(30, 27, "Точки доступа", "AccessPointOn"));
         lst.Add(new LicensedActivity(31, 27, "Количество точек доступа", "AccessPointCount"));

         return lst;
      }

      /// <summary>
      /// Вернуть экземпляр юр. лица (найти или создать новый)
      /// </summary>
      /// <param name="corpName">наименование юр. лица</param>
      public Corporation GetCorporation(string corpName) {
         Corporation corp = corps.SingleOrDefault(c => c.CorporateName == corpName);
         if (corp == null) {
            lock (lockObj) {
               int id = corps.Count + 1;
               corp = new Corporation() { ID = id, CorporateName = corpName};
               corps.Add(corp);
            }
         }
         return corp;
      }

      /// <summary>
      /// Вернуть список операторов связи, который содержит "неизветного оператора"
      /// </summary>
      /// <returns></returns>
      private List<BaseOperatorInfo> CreateOperators() {
         List<BaseOperatorInfo> operators = new List<BaseOperatorInfo>();
         return operators;
      }

      /// <summary>
      /// создать коллекция юр. лиц по данным загруженным с сайта в инф. об услугах связи
      /// </summary>
      private void CreateDefaultCorps() {
         // получить наименования всех юр. лиц.
         List<string> corpnames = new List<string>(); // наименования всех юр. лиц
         corpnames.AddRange(commSrvs.SelectMany(c => c.PostOnDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.PhoneOnDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.IntraZonePhoneDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.LongDistancePhoneDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.UmtsDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.LteDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.PayphoneDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.PostOfficeDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.PayphoneDetail2.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.CapsDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.CapsJobDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.TransferDataDetails.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.TelematicDataDetails.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.GsmDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.EtvChanelDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.RvChanelDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.EtvDigitalChanelDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.EtvAnalogChanelDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.RvDigitalChanelDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.RvAnalogChanelDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.CableChanelDetail.Select(d => d.CorporateName)));
         corpnames.AddRange(commSrvs.SelectMany(c => c.AccessPointCountDetail.Select(d => d.CorporateName)));
         corpnames = corpnames.Distinct().ToList();
         // Создать коллекцию всех юр. лиц
         corps = new HashSet<Corporation>();
         corpnames.ForEach(c => corps.Add(new Corporation(c, unknownOperator)));
      }

      /// <summary>
      /// Найти оператора связи по наименованию его юр. лицу
      /// </summary>
      /// <param name="CorporateName">Наименование юр. лицо оператора связи</param>
      public BaseOperatorInfo FindOperator(string CorporateName) {
         BaseOperatorInfo opInfo = operators.SingleOrDefault(o => o.Corporations.SingleOrDefault(c => c.CorporateName == CorporateName) != null );
         return opInfo;
      }

      /// <summary>
      /// Найти оператора связи по юр. лицу
      /// </summary>
      public BaseOperatorInfo FindOperator(Corporation corp) {
         BaseOperatorInfo op = operators.SingleOrDefault(o => o.Corporations.SingleOrDefault(c => c == corp) != null);
         return op;
      }

      /// <summary>
      /// Найти колонку для отображения в своде по свойству
      /// </summary>
      public ColumnInfo FindColumnInfo(string propName) {
         ColumnInfo col = (from ci in columns
                           where ci.Property == propName
                           select ci).SingleOrDefault();
         return col;
      }

      /// <summary>
      /// Добавить колонку
      /// </summary>
      public ColumnInfo AddColumnInfo(string name, string property) {
         ColumnInfo ci = new ColumnInfo() { Name = name, Property = property };
         ci.ID = GetMinColumnInfoID() - 1;
         ci.ParentID = -1;
         ci.ImageIndex = -1;
         ci.IsTreeColumn = false;
         columns.Add(ci);

         return ci;
      }

      /// <summary>
      /// Вернуть мин. значение ID для коллекции колонок
      /// </summary>
      /// <returns></returns>
      private int GetMinColumnInfoID() {
         int min = (from ci in columns
                    select ci.ID).Min();
         return min;
      }

      /// <summary>
      /// Вернуть список колонок отображаемых дереве
      /// </summary>
      public List<ColumnInfo> GetTreeColumns() {
         List<ColumnInfo> columns = (from ci in this.columns
                                     where ci.IsTreeColumn == true
                                     select ci).ToList();
         return columns;
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих услуги местной тел. связи)
      /// LongDistanceDetail
      /// </summary>
      public List<ColumnInfo> GetPhoneOnDetailColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions) {
            q = (from c in CommSrvs
                 from td in c.PhoneOnDetail
                 select td.Corp.CorporateName).Distinct().ToList();
         }
         if (viewBy == DataView.ByOperators) {
            q = (from c in CommSrvs
                 from td in c.PhoneOnDetail
                 select td.Corp.Operator.OperatorName).Distinct().ToList();
         }

         return ColumnInfo.CreateList(q, "Ph_");
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих услуги внутризоновой тел. связи)
      /// LongDistanceDetail
      /// </summary>
      public List<ColumnInfo> GetIntraZonePhoneDetailColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions) {
            q = (from c in CommSrvs
                 from td in c.IntraZonePhoneDetail
                 select td.Corp.CorporateName).Distinct().ToList();
         }
         if (viewBy == DataView.ByOperators) {
            q = (from c in CommSrvs
                 from td in c.IntraZonePhoneDetail
                 select td.Corp.Operator.OperatorName).Distinct().ToList();
         }

         return ColumnInfo.CreateList(q, "Iz_");
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих услуги междугородней или международней тел. связи)
      /// LongDistanceDetail
      /// </summary>
      public List<ColumnInfo> GetLongDistanceDetailColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions) {
            q = (from c in CommSrvs
                 from td in c.LongDistancePhoneDetail
                 select td.Corp.CorporateName).Distinct().ToList();
         }
         if (viewBy == DataView.ByOperators) {
            q = (from c in CommSrvs
                 from td in c.LongDistancePhoneDetail
                 select td.Corp.Operator.OperatorName).Distinct().ToList();
         }

         return ColumnInfo.CreateList(q, "ld_");
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих услуги передачи данных по собственным сетям)
      /// TransferDataDetails
      /// </summary>
      public List<ColumnInfo> GetTransferDetailsColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions) {
            q = (from c in CommSrvs
                 from td in c.TransferDataDetails
                 select td.Corp.CorporateName).Distinct().ToList();
         }
         if (viewBy == DataView.ByOperators) {
            q = (from c in CommSrvs
                 from td in c.TransferDataDetails
                 select td.Corp.Operator.OperatorName).Distinct().ToList();
         }

         return ColumnInfo.CreateList(q, "td_");
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих телематические услуги связи)
      /// TelematicDataDetails
      /// </summary>
      public List<ColumnInfo> GetTelematicDetailsColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions) {
            q = (from c in CommSrvs
                 from td in c.TelematicDataDetails
                 select td.Corp.CorporateName).Distinct().ToList();
         }
         if (viewBy == DataView.ByOperators) {
            q = (from c in CommSrvs
                 from td in c.TelematicDataDetails
                 select td.Corp.Operator.OperatorName).Distinct().ToList();
         }

         return ColumnInfo.CreateList(q, "td_");
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих услуги сотовой связи стандарта GSM)
      /// GsmDetail
      /// </summary>
      public List<ColumnInfo> GetGsmDetailColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions) {
            q = (from c in CommSrvs
                 from gsm in c.GsmDetail
                 select gsm.Corp.CorporateName).Distinct().ToList();
         }
         if (viewBy == DataView.ByOperators) {
            q = (from c in CommSrvs
                 from gsm in c.GsmDetail
                 select gsm.Corp.Operator.OperatorName).Distinct().ToList();
         }
         return ColumnInfo.CreateList(q, "gsm_");
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих услуги сотовой связи стандарта Umts)
      /// UmtsDetail
      /// </summary>
      public List<ColumnInfo> GetUmtsDetailColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions) {
            q = (from c in CommSrvs
                 from umts in c.UmtsDetail
                 select umts.Corp.CorporateName).Distinct().ToList();
         }
         if (viewBy == DataView.ByOperators) {
            q = (from c in CommSrvs
                 from umts in c.UmtsDetail
                 select umts.Corp.Operator.OperatorName).Distinct().ToList();
         }
         return ColumnInfo.CreateList(q, "umts_");
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих услуги сотовой связи стандарта Lte)
      /// LteDetail
      /// </summary>
      public List<ColumnInfo> GetLteDetailColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions) {
            q = (from c in CommSrvs
                 from lte in c.LteDetail
                 select lte.Corp.CorporateName).Distinct().ToList();
         }
         if (viewBy == DataView.ByOperators) {
            q = (from c in CommSrvs
                 from lte in c.LteDetail
                 select lte.Corp.Operator.OperatorName).Distinct().ToList();
         }

         return ColumnInfo.CreateList(q, "lte_");
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих эфирное телевещение)
      /// EtvChanelDetail
      /// </summary>
      public List<ColumnInfo> GetEtvChanelDetailColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions) {
            q = CommSrvs.SelectMany(c => c.EtvChanelDetail.Select(i => i.Corp.CorporateName)).Distinct().ToList();
         }
         if (viewBy == DataView.ByOperators) {
            q = CommSrvs.SelectMany(c => c.EtvChanelDetail.Select(i => i.Corp.Operator.OperatorName)).Distinct().ToList();
         }

         return ColumnInfo.CreateList(q, "tv_");
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих цифровое эфирное телевещение)
      /// EtvDigitalChanelDetail
      /// </summary>
      public List<ColumnInfo> GetEtvDigitalChanelDetailColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions) 
            q = CommSrvs.SelectMany(c => c.EtvDigitalChanelDetail.Select(i => i.Corp.CorporateName)).Distinct().ToList();
         
         if (viewBy == DataView.ByOperators) 
            q = CommSrvs.SelectMany(c => c.EtvDigitalChanelDetail.Select(i => i.Corp.Operator.OperatorName)).Distinct().ToList();
         
         return ColumnInfo.CreateList(q, "tvd_");
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих аналоговое эфирное телевещение)
      /// EtvAnalogChanelDetail
      /// </summary>
      public List<ColumnInfo> GetEtvAnalogChanelDetailColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions)
            q = CommSrvs.SelectMany(c => c.EtvAnalogChanelDetail.Select(i => i.Corp.CorporateName)).Distinct().ToList();

         if (viewBy == DataView.ByOperators)
            q = CommSrvs.SelectMany(c => c.EtvAnalogChanelDetail.Select(i => i.Corp.Operator.OperatorName)).Distinct().ToList();

         return ColumnInfo.CreateList(q, "tva_");
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих эфирное радиовещание)
      /// RvChanelDetail
      /// </summary>
      public List<ColumnInfo> GetRvChanelDetailColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions) {
            q = CommSrvs.SelectMany(c => c.RvChanelDetail.Select(i => i.Corp.CorporateName)).Distinct().ToList();
         }
         if (viewBy == DataView.ByOperators) {
            q = CommSrvs.SelectMany(c => c.RvChanelDetail.Select(i => i.Corp.Operator.OperatorName)).Distinct().ToList();
         }

         return ColumnInfo.CreateList(q, "rv_");
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих цифровое эфирное радиовещение)
      /// RvDigitalChanelDetail
      /// </summary>
      public List<ColumnInfo> GetRvDigitalChanelDetailColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions)
            q = CommSrvs.SelectMany(c => c.RvDigitalChanelDetail.Select(i => i.Corp.CorporateName)).Distinct().ToList();

         if (viewBy == DataView.ByOperators)
            q = CommSrvs.SelectMany(c => c.RvDigitalChanelDetail.Select(i => i.Corp.Operator.OperatorName)).Distinct().ToList();

         return ColumnInfo.CreateList(q, "rvd_");
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих аналоговое эфирное телевещение)
      /// RvAnalogChanelDetail
      /// </summary>
      public List<ColumnInfo> GetRvAnalogChanelDetailColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions)
            q = CommSrvs.SelectMany(c => c.RvAnalogChanelDetail.Select(i => i.Corp.CorporateName)).Distinct().ToList();

         if (viewBy == DataView.ByOperators)
            q = CommSrvs.SelectMany(c => c.RvAnalogChanelDetail.Select(i => i.Corp.Operator.OperatorName)).Distinct().ToList();

         return ColumnInfo.CreateList(q, "rva_");
      }

      /// <summary>
      /// Вернуть список доп. колонок (список операторов связи осуществляющих кабельное телевещание)
      /// CableChanelDetail
      /// </summary>
      public List<ColumnInfo> GetCableChanelDetailColumns(DataView viewBy) {
         List<string> q = null;
         if (viewBy == DataView.ByCorporatiions) {
            q = CommSrvs.SelectMany(c => c.CableChanelDetail.Select(i => i.Corp.CorporateName)).Distinct().ToList();
         }
         if (viewBy == DataView.ByOperators) {
            q = CommSrvs.SelectMany(c => c.CableChanelDetail.Select(i => i.Corp.Operator.OperatorName)).Distinct().ToList();
         }

         return ColumnInfo.CreateList(q, "ktv_");
      }

      /// <summary>
      /// Расчитать общее количество населения области
      /// </summary>
      public decimal GetTotalPopulation() {
         int total = localities.Sum(l => l.CurrentPopulationCount);
         return (decimal)total;
      }

      /// <summary>
      /// Создать словарь с кратким описанием файлов данных
      /// </summary>
      private void CreateDataFileDescr() {
         dataFileDescr = new Dictionary<string, string>();
         dataFileDescr.Add("borroughts", "Справочники районов");
         dataFileDescr.Add("settlements", "Справочник поселений");
         dataFileDescr.Add("localities", "Справочник населенных пунктов");
         dataFileDescr.Add("commsrvs", "Данные об услугах связи в населенных пунктах");
         dataFileDescr.Add("corps", "Данные об юридических лицах");
         dataFileDescr.Add("columns", "Перечень услуг, выбираемых для отображения в Своде");
         dataFileDescr.Add("licActivities", "Список услуг связи, отображаемых в реестре");
         dataFileDescr.Add("operators", "Список операторов связи, оказывающих услуги");
      }

      /// <summary>
      /// Вернуть описание для указанного файла данных
      /// </summary>
      /// <param name="dataFile">имя файла данных (без расширения)</param>
      public string GetDataFileDescription(string dataFile) {
         string msg = "...";
         if (dataFileDescr.ContainsKey(dataFile))
            msg = dataFileDescr[dataFile];
         return msg;
      }
      #endregion
   }
}
