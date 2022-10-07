using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Svyaz.Data;
using Svyaz.Model;
using Util;

namespace Svyaz.Web {
   public class Parser {
      #region Fields
      private string referer;
      private CookieContainer cookies; // куки
      private object lockObj;
      private Repository repo;
      #endregion

      #region Properties
      /// <summary>
      /// результат http запроса
      /// </summary>
      public string PageHtml { get; set; }
      #endregion

      #region Constructors
      public Parser() {
         cookies = new CookieContainer();
         lockObj = new object();
         repo = Repository.GetRepository();
      }
      #endregion

      #region Methods
      /// <summary>
      /// Загрзуить с сайта Роскомнадзора данныые о доступности услуг связи
      /// </summary>
      public CommunicationService DownloadCommSrv(int localityId) {
         CommunicationService commSrv = null;
         bool ok = GetReestrSvyaz(localityId);
         if (ok) {
            ok = ParseCommunicationService(PageHtml, out commSrv);
            if (ok) {
               string tbl = ParseHtmlTable(PageHtml, "is_local_station");   // местная ТС
               List<string> lst = ParseTable1Columns(tbl);
               List<OperatorInfo> operators = ToOperatorInfo(localityId, lst);
               commSrv.PhoneOnDetail.AddRange(operators);

               tbl = ParseHtmlTable(PageHtml, "local_station_payphone_count");     // количество таксофонов
               List<Row2Columns> lst2 = ParseTable2Columns(tbl);
               List<CountInfo> cnt = Row2Columns.ToCountInfo(localityId, lst2);
               commSrv.PayphoneDetail.AddRange(cnt);

               tbl = ParseHtmlTable(PageHtml, "is_vnz");     // внутризоновая связь
               lst = ParseTable1Columns(tbl);
               operators = ToOperatorInfo(localityId, lst);
               commSrv.IntraZonePhoneDetail.AddRange(operators);

               tbl = ParseHtmlTable(PageHtml, "is_mgmn");    // междугородная и международная связь
               lst = ParseTable1Columns(tbl);
               operators = ToOperatorInfo(localityId, lst);
               commSrv.LongDistancePhoneDetail.AddRange(operators);

               tbl = ParseHtmlTable(PageHtml, "is_pd");      // передача данных
               List<Row3Columns> lst3 = ParseTable3Columns(tbl);
               List<TransferDataInfo> transferData = Row3Columns.ToTransferDataInfo(localityId, lst3);
               commSrv.TransferDataDetails.AddRange(transferData);

               tbl = ParseHtmlTable(PageHtml, "is_tm");      // телематические услуги связи
               lst3 = ParseTable3Columns(tbl);
               List<TransferDataInfo> telematicData = Row3Columns.ToTransferDataInfo(localityId, lst3);
               commSrv.TelematicDataDetails.AddRange(telematicData);

               tbl = ParseHtmlTable(PageHtml, "gsm_type");   // GSM
               lst2 = ParseTable2Columns(tbl);
               List<GsmInfo> gi = Row2Columns.ToGsmInfo(localityId, lst2);
               commSrv.GsmDetail.AddRange(gi);

               tbl = ParseHtmlTable(PageHtml, "is_umts");     // UMTS
               lst = ParseTable1Columns(tbl);
               operators = ToOperatorInfo(localityId, lst);
               commSrv.UmtsDetail.AddRange(operators);

               tbl = ParseHtmlTable(PageHtml, "is_lte");     // LTE
               lst = ParseTable1Columns(tbl);
               operators = ToOperatorInfo(localityId, lst);
               commSrv.LteDetail.AddRange(operators);

               tbl = ParseHtmlTable(PageHtml, "is_etv");      // эфирное телевидение
               lst3 = ParseTable3Columns(tbl);
               List<ChanelCountInfo2> chanel = Row3Columns.ToChanelCountInfo(localityId, lst3);
               commSrv.EtvChanelDetail.AddRange(chanel);

               tbl = ParseHtmlTable(PageHtml, "etv_d_channel_cnt");     // Количество цифровых телеканалов
               lst2 = ParseTable2Columns(tbl);
               List<ChanelCountInfo> d_chanel = Row2Columns.ToChanelCountInfo(localityId, lst2);
               commSrv.EtvDigitalChanelDetail.AddRange(d_chanel);

               tbl = ParseHtmlTable(PageHtml, "etv_a_channel_cnt");     // Количество аналоговых телеканалов
               lst2 = ParseTable2Columns(tbl);
               List<ChanelCountInfo> a_chanel = Row2Columns.ToChanelCountInfo(localityId, lst2);
               commSrv.EtvAnalogChanelDetail.AddRange(a_chanel);

               tbl = ParseHtmlTable(PageHtml, "is_rv");      // радиовещание
               lst3 = ParseTable3Columns(tbl);
               chanel = Row3Columns.ToChanelCountInfo(localityId, lst3);
               commSrv.RvChanelDetail.AddRange(chanel);

               tbl = ParseHtmlTable(PageHtml, "rv_d_channel_cnt");     // Количество цифровых радиоканалов
               lst2 = ParseTable2Columns(tbl);
               d_chanel = Row2Columns.ToChanelCountInfo(localityId, lst2);
               commSrv.RvDigitalChanelDetail.AddRange(d_chanel);

               tbl = ParseHtmlTable(PageHtml, "rv_a_channel_cnt");     // Количество аналоговых радиоканалов
               lst2 = ParseTable2Columns(tbl);
               a_chanel = Row2Columns.ToChanelCountInfo(localityId, lst2);
               commSrv.RvAnalogChanelDetail.AddRange(a_chanel);

               tbl = ParseHtmlTable(PageHtml, "ktv_channel_cnt");     // Количество каналов кабельного ТВ
               lst2 = ParseTable2Columns(tbl);
               a_chanel = Row2Columns.ToChanelCountInfo(localityId, lst2);
               commSrv.CableChanelDetail.AddRange(a_chanel);

               tbl = ParseHtmlTable(PageHtml, "is_ps");               // Почтовая связь
               lst = ParseTable1Columns(tbl);
               operators = ToOperatorInfo(localityId, lst);
               commSrv.PostOnDetail.AddRange(operators);


               tbl = ParseHtmlTable(PageHtml, "ps_com_dep_cnt");      // Количество почтовых отделений
               lst2 = ParseTable2Columns(tbl);
               cnt = Row2Columns.ToCountInfo(localityId, lst2);
               commSrv.PostOfficeDetail.AddRange(cnt);

               tbl = ParseHtmlTable(PageHtml, "payphone_count");     // количество таксофонов в отделениях почты
               lst2 = ParseTable2Columns(tbl);
               cnt = Row2Columns.ToCountInfo(localityId, lst2);
               commSrv.PayphoneDetail2.AddRange(cnt);

               tbl = ParseHtmlTable(PageHtml, "pkd_count");     // количество ПКД
               lst2 = ParseTable2Columns(tbl);
               cnt = Row2Columns.ToCountInfo(localityId, lst2);
               commSrv.CapsDetail.AddRange(cnt);

               tbl = ParseHtmlTable(PageHtml, "pdk_job_cnt");     // количество рабочих мест в ПКД
               lst2 = ParseTable2Columns(tbl);
               cnt = Row2Columns.ToCountInfo(localityId, lst2);
               commSrv.CapsJobDetail.AddRange(cnt);

               tbl = ParseHtmlTable(PageHtml, "ap_cnt");          // Количество точек доступа
               lst3 = ParseTable3Columns(tbl);
               List<AccessPointInfo> apinfo = Row3Columns.ToAccessPointInfo(localityId, lst3);
               commSrv.AccessPointCountDetail.AddRange(apinfo);
            }
         }
         return commSrv;
      }

      /// <summary>
      /// Запрос страницы сайта для населенного пункта с заданным id
      /// </summary>
      private bool GetReestrSvyaz(int localityId) {
         bool ok = false;
         bool useProxy = Svyaz.Properties.Settings.Default.UseProxy;
         string proxyAddress = Svyaz.Properties.Settings.Default.ProxyAddress;
         int port = Svyaz.Properties.Settings.Default.ProxyPort;

         string url = Tools.GetReestrSvyazUrl(localityId);
         WebProxy proxy = null;
         if (useProxy) {
            proxy = new WebProxy(proxyAddress, port);
         }
         PageHtml = HttpTools.RequestGetHtml(ref url, proxy, cookies);
         ok = (PageHtml != "");
         if (ok) {
            referer = url;
         }
         return ok;
      }

      private bool ParseCommunicationService(string html, out CommunicationService commSrv) {
         commSrv = new CommunicationService();
         bool ok = false;

         // выделить фрагмент содержащий таблицу доступности услуг связи
         string pattern = "\n\t<table class=\"TblList\">(.*?)</table>";
         Regex regex = new Regex(pattern, RegexOptions.Singleline);
         Match match = regex.Match(html);
         string tbl = match.Groups[1].Value;

         // разбираем таблицу на строки {header, data}
         pattern = "<tr><th.*?>(.*?)</t[h|d]><td>(?:.*?>)?(.*?)(?:<.*?>)?</td></tr>";
         regex = new Regex(pattern, RegexOptions.Multiline);
         MatchCollection matches = regex.Matches(tbl);
         int dcnt = 1;  // счетчик повторов заголовка "количество цифровых каналов" или "количество таксофонов"
         int acnt = 1;  // который повторяется 2 раза для телевидения и радиовещания
         int pcnt = 1;
         foreach (Match m in matches) {
            string th = m.Groups[1].Value;   // header
            string td = m.Groups[2].Value;   // data

            if (th == "количество таксофонов")
               th = string.Format("{0}{1}", th, pcnt++);
            if (th == "количество цифровых каналов")
               th = string.Format("{0}{1}", th, dcnt++);
            if (th == "количество аналоговых каналов")
               th = string.Format("{0}{1}", th, acnt++);

            ok = ParseTableRow(th, td, commSrv);
            if (!ok)
               break;
         }

         return ok;
      }

      /// <summary>
      /// Сформировать список операторов оказывающих услуги связи в формате OperatorInfo из списка формата string
      /// </summary>
      private List<OperatorInfo> ToOperatorInfo(int localityID, List<string> src) {
         List<OperatorInfo> dst = new List<OperatorInfo>();
         Repository repo = Repository.GetRepository();
         foreach (string name in src) {
            Corporation corp = repo.GetCorporation(name);
            OperatorInfo opInfo = new OperatorInfo(corp) { LocalityId = localityID, Availability = true };
            if (!dst.Contains(opInfo))
               dst.Add(opInfo);
         }
         return dst;
      }

      /// <summary>
      /// Распарсить html, выделив строку содержащую разметку указанной таблицы 
      /// </summary>
      private string ParseHtmlTable(string html, string tblId) {
         string lines;
         string pattern = string.Format("<div id=\"{0}\">.*?<table class=\"TblList\">(.*?)</table", tblId);
         Regex regex = new Regex(pattern, RegexOptions.Singleline);
         Match match = regex.Match(html);
         lines = match.Groups[1].Value;

         return lines;
      }

      /// <summary>
      /// Распарсить таблицу содержащую одну колонку
      /// </summary>
      private List<string> ParseTable1Columns(string tbl) {
         List<string> result = new List<string>();
         string pattern = "<tr><td.*?>(.*?)</td>";
         Regex regex = new Regex(pattern, RegexOptions.Singleline);
         MatchCollection matches = regex.Matches(tbl);
         foreach (Match m in matches) {
            string item = m.Groups[1].Value;
            result.Add(item);
         }

         return result;
      }

      /// <summary>
      /// Распарсить таблицу содержащую две колонки
      /// </summary>
      private List<Row2Columns> ParseTable2Columns(string tbl) {
         List<Row2Columns> result = new List<Row2Columns>();
         string pattern = "<tr><td.*?>(.*?)</td><td.*?>(.*?)</td>";
         Regex regex = new Regex(pattern, RegexOptions.Singleline);
         MatchCollection matches = regex.Matches(tbl);
         foreach (Match m in matches) {
            string item1 = m.Groups[1].Value;
            string item2 = m.Groups[2].Value;
            //item1 = Tools.ClearOperatorName(item1);   // убрать мусор из наименования оператора
            Row2Columns row = new Row2Columns() { Column1 = item1, Column2 = item2 };

            result.Add(row);
         }
         return result;
      }

      /// <summary>
      /// Распарсить таблицу содержащую трм колонки
      /// </summary>
      private List<Row3Columns> ParseTable3Columns(string tbl) {
         List<Row3Columns> result = new List<Row3Columns>();
         string pattern = "<tr><td.*?>(.*?)</td><td.*?>(.*?)</td><td.*?>(.*?)</td>";
         Regex regex = new Regex(pattern, RegexOptions.Singleline);
         MatchCollection matches = regex.Matches(tbl);
         foreach (Match m in matches) {
            string item1 = m.Groups[1].Value;   // Как правило оператор
            string item2 = m.Groups[2].Value;
            string item3 = m.Groups[3].Value;
            //item1 = Tools.ClearOperatorName(item1);   // убрать мусор из наименования оператора
            Row3Columns row = new Row3Columns() { Column1 = item1, Column2 = item2, Column3 = item3 };

            result.Add(row);
         }
         return result;
      }

      /// <summary>
      /// Распарсить строку из таблицы доступности услуг связи
      /// </summary>
      /// <param name="th">заголовок</param>
      /// <param name="td">значение</param>
      private bool ParseTableRow(string th, string td, CommunicationService commSrv) {
         if (th == "почтовая связь") {
            //commSrv.PostOn = Tools.BoolFromString(td);
            return true;
         }
         if (th == "местная ТС") {
            //commSrv.PhoneOn = Tools.BoolFromString(td);
            return true;
         }
         if (th == "количество таксофонов1") {
            //commSrv.PayphoneCount = Tools.IntFromString(td);
            return true;
         }
         if (th == "внутризоновая связь") {
            //commSrv.IntraZonePhoneOn = Tools.BoolFromString(td);
            return true;
         }
         if (th == "междугородная и международная связь") {
            //commSrv.LongDistancePhoneOn = Tools.BoolFromString(td);
            return true;
         }
         if (th == "передача данных") {
            //commSrv.DataTransferOn = Tools.BoolFromString(td);
            return true;
         }
         if (th == "телематические услуги связи") {
            //commSrv.TelematicServiceOn = Tools.BoolFromString(td);
            return true;
         }
         if (th == "GSM") {
            //commSrv.GsmOn = GsmTypeFromString(td);
            return true;
         }
         if (th == "UMTS") {
            //commSrv.UmtsOn = Tools.BoolFromString(td);
            return true;
         }
         if (th == "LTE") {
            //commSrv.LteOn = Tools.BoolFromString(td);
            return true;
         }
         if (th == "NMT-450") {
            //commSrv.NmtOn = Tools.BoolFromString(td);
            return true;
         }
         if (th == "IMT-MC-450 (CDMA)") {
            //commSrv.CdmaOn = Tools.BoolFromString(td);
            return true;
         }
         if (th == "эфирное телевидение") {
            //commSrv.TvOn = Tools.BoolFromString(td);
            return true;
         }
         if (th == "количество цифровых каналов1") {
            //commSrv.DigitalChanelCount = Tools.IntFromString(td);
            return true;
         }
         if (th == "количество аналоговых каналов1") {
            //commSrv.AnalogChanelCount = Tools.IntFromString(td);
            return true;
         }
         if (th == "радиовещание") {
            //commSrv.BroadcastingOn = Tools.BoolFromString(td);
            return true;
         }
         if (th == "количество цифровых каналов2") {
            //commSrv.DigitalChanelCount2 = Tools.IntFromString(td);
            return true;
         }
         if (th == "количество аналоговых каналов2") {
            //commSrv.AnalogChanelCount2 = Tools.IntFromString(td);
            return true;
         }
         if (th == "КТВ количество каналов") {
            //commSrv.CabelChanelCount = Tools.IntFromString(td);
            return true;
         }
         if (th == "количество почтамтов") {
            commSrv.PostCount = Tools.IntFromString(td);
            return true;
         }
         if (th == "количество отделений связи") {
            //commSrv.PostOfficeCount = Tools.IntFromString(td);
            return true;
         }
         if (th == "количество таксофонов2") {
            //commSrv.PayphoneCount2 = Tools.IntFromString(td);
            return true;
         }
         if (th == "количество ПКД") {
            //commSrv.CapsCount = Tools.IntFromString(td);
            return true;
         }
         if (th == "количество рабочих мест") {
            //commSrv.CapsJobCount = Tools.IntFromString(td);
            return true;
         }
         if (th == "точки доступа") {
            commSrv.AccessPointOn = Tools.BoolFromString(td);
            return true;
         }
         if (th == "количество точек доступа") {
            //commSrv.AccessPointCount = Tools.IntFromString(td);
            return true;
         }

         return false;
      }

      private GsmType GsmTypeFromString(string td) {
         if (td == "1800, 900/1800")
            return GsmType.Gsm_1800_900_1800;
         if (td == "1800")
            return GsmType.Gsm_1800;
         if (td == "900/1800")
            return GsmType.Gsm_900_1800;
         return GsmType.None;
      }
      #endregion

   }
}
