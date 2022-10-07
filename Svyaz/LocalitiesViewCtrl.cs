using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Svyaz.Data;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;
using System.IO;
using DevExpress.XtraGrid.Columns;
using Svyaz.Model;
using Svyaz.Web;
using Util;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Diagnostics;
using System.Reflection;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid;
using System.Collections;
using DevExpress.Compression;
using DevExpress.XtraPrinting;

namespace Svyaz {
   public partial class LocalitiesViewCtrl : XtraUserControl, IReloadData {
      #region Fields
      private const int BIROBIDJAN = 6078;
      private Repository repo;
      private string _columns = "";       // список колонок для грида 
      private Point? lastClickPoint;      // точка последнего клика мышкой
      private decimal customSum;
      private int customCount;
      private Dictionary<string, TypeCode> dicSummary;

      private int masterDetailCount;      // количество детализирующих таблиц
      private List<string> relationNames; // список содержащий наименование детализирующих отношений
      private List<string> relationCaptions; // список заголовков детализирующхи отношений

      private int rowHandle;              // номер строки в которой откр. детализирующие данные
      private int relationIndex;          // индекс закладки детализирующих данных
      private Dictionary<string, ColumnFilterInfo> _dicFilters; // фильтры для колонок заголовка
      #endregion

      #region Properties
      /// <summary>
      /// Признак показать/скрыть левую панель
      /// </summary>
      public bool CollapsedLeftPanel {
         get { return !barBtnLeft.Down; }
         set { barBtnLeft.Down = !value; }
      }

      /// <summary>
      /// Строка состояния (потокобезопасная)
      /// </summary>
      public string StatusItem {
         get { return statusItem.Caption; }
         set { Tools.ChangeBarStaticItemCaption(this, statusItem, value); }
      }

      /// <summary>
      /// Выбранный для отображения источник данных (спас. DevExpres за доступ через жопу)
      /// </summary>
      public DataSrc DataSrc {
         get {
            int idx = riComboSrc.Items.IndexOf(barComboSrc.EditValue.ToString());
            return (DataSrc)idx;
         }
         set { barComboSrc.EditValue = riComboSrc.Items[(int)value]; }
      }

      public DataView DataViewBy {
         get {
            string val = barComboView.EditValue.ToString();
            return (val == "По юридическим лицам") ? DataView.ByCorporatiions : DataView.ByOperators;
         }
         set { barComboView.EditValue = riComboView.Items[(int)value]; }
      }
      #endregion

      #region Ctors
      public LocalitiesViewCtrl() {
         InitializeComponent();
         InitFiltersInfo();
         this.Dock = DockStyle.Fill;
         dicSummary = new Dictionary<string, TypeCode>();
         DataViewBy = DataView.ByOperators;
         DataSrc = DataSrc.OpenData;

         repo = Repository.GetRepository();
         if (repo.Operators.Count <= 1) {
            DataViewBy = DataView.ByCorporatiions;
            riComboView.Items.RemoveAt(0);
         }
         LoadData();
      }
      #endregion

      #region Methods
      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {

         if (disposing && (components != null)) {
            components.Dispose();
         }
         if (popupContainerControl1.IsDisposed)
            return;
         if (popupContainerControl1.Parent != null)
            popupContainerControl1.Parent.Dispose();
         popupContainerControl1.Dispose();

         base.Dispose(disposing);
      }

      /// <summary>
      /// Выполнить загрузку данных
      /// </summary>
      public void LoadData() {
         columnSelectorCtrl.LoadData();
         ShowData("");
      }

      /// <summary>
      /// Отобразить данныде, т.е.
      /// привязать их и пересоздать колонки для грида свода
      /// </summary>
      private void ShowData(string columnData) {
         _columns = columnData;
         SaveFiltersInfo();
         List<ColumnInfo> columns = Bind();
         UpdateMasterDetail(columns);
         UpdateGridView(columns);
         RestoreFiltersInfo();
      }

      /// <summary>
      /// Сохранить фильтры колонок заголовков
      /// </summary>
      private void SaveFiltersInfo() {
         List<string> columns = GetHeaderColNames();
         _dicFilters = new Dictionary<string,ColumnFilterInfo>();
         columns.ForEach(key => _dicFilters.Add(key, gridView1.Columns.ColumnByFieldName(key).FilterInfo));
      }

      /// <summary>
      /// Восстановить фильтры колонок заголовков
      /// </summary>
      private void RestoreFiltersInfo() {
         foreach (var kvp in _dicFilters) {
            gridView1.Columns.ColumnByFieldName(kvp.Key).FilterInfo = kvp.Value;
         }
      }

      /// <summary>
      /// инициализировать фильтры колонок заголовков
      /// </summary>
      private void InitFiltersInfo() {
         List<string> columns = GetHeaderColNames();
         _dicFilters = new Dictionary<string, ColumnFilterInfo>();
         columns.ForEach( key => _dicFilters.Add(key, null));
      }

      /// <summary>
      /// Обновить в GridView связки для отображения master-detail
      /// </summary>
      /// <param name="columns"></param>
      private void UpdateMasterDetail(List<ColumnInfo> columns) {
         masterDetailCount = 0;
         relationNames = new List<string>();
         relationCaptions = new List<string>();
         List<string> collPropNames = CommunicationService.GetCollectionPropNames();
         foreach (ColumnInfo ci in columns) {
            bool exist = collPropNames.Contains(ci.Property);
            if (exist) {
               masterDetailCount++;
               relationNames.Add(ci.Property);
               relationCaptions.Add(ci.Name);
            }
         }
      }

      private List<string> GetHeaderColNames() {
         List<string> colNames = new List<string>() { "Borrough", "Settlement", "FullName", "IsAdmCenter", "CurrentPopulationCount" };
         return colNames;
      }

      /// <summary>
      /// Создать список, содержащий инф. об общих для всех запросов колонках
      /// </summary>
      private List<ColumnInfo> CreateHeaderColInfo() {
         List<ColumnInfo> lst = new List<ColumnInfo>();
         List<string> headerColNames = GetHeaderColNames();
         foreach (string columnName in headerColNames) {
            lst.Add(repo.FindColumnInfo(columnName));
         }
         return lst;
      }

      /// <summary>
      /// Привязать данные
      /// </summary>
      private List<ColumnInfo> Bind() {
         List<ColumnInfo> selectedColumns = new List<ColumnInfo>();
         if (_columns == "PhoneOnDetail")
            selectedColumns = BindPhoneOnDetail();
         else if (_columns == "IntraZonePhoneDetail")
            selectedColumns = BindIntraZonePhoneDetail();
         else if (_columns == "LongDistancePhoneDetail")
            selectedColumns = BindLongDistancePhoneDetail();
         else if (_columns == "TransferDataDetails") {
            selectedColumns = BindTransferDetails();
         } else if (_columns == "TelematicServiceDetail") {
            selectedColumns = BindTelematicServiceDetails();
         } else if (_columns == "GsmDetail") {
            selectedColumns = BindGsmDetail();
         } else if (_columns == "UmtsDetail") {
            selectedColumns = BindUmtsDetail();
         } else if (_columns == "LteDetail") {
            selectedColumns = BindLteDetail();
         } else if (_columns == "EtvChanelDetail") {
            selectedColumns = BindEtvChanelDetail();
         } else if (_columns == "EtvDigitalChanelDetail") {
            selectedColumns = BindEtvDigitalChanelDetail();
         } else if (_columns == "EtvAnalogChanelDetail") {
            selectedColumns = BindEtvAnalogChanelDetail();
         } else if (_columns == "RvChanelDetail") {
            selectedColumns = BindRvChanelDetail();
         } else if (_columns == "RvDigitalChanelDetail") {
            selectedColumns = BindRvDigitalChanelDetail();
         } else if (_columns == "RvAnalogChanelDetail") {
            selectedColumns = BindRvAnalogChanelDetail();
         } else if (_columns == "CableChanelDetail") {
            selectedColumns = BindCableChanelDetail();
         } else {
            selectedColumns = BindData(_columns);
         }
         return selectedColumns;
      }

      /// <summary>
      /// Привязать данные свод к gridView
      /// </summary>
      private List<ColumnInfo> BindData(string columns) {
         List<CommSrvData> q = null;
         q = (from l in repo.Localities
              join s in repo.Settlements on l.SettlementId equals s.Id into gj
              from subSettlement in gj.DefaultIfEmpty()
              select new CommSrvData {
                 Borrough = (subSettlement == null ? null : subSettlement.Borrough),
                 Settlement = l.Settlement,
                 FullName = l,
                 IsAdmCenter = (subSettlement != null && subSettlement.Borrough.CenterId == l.Id) ||
                             (l.Settlement != null && l.Settlement.CenterId == l.Id) ||
                             subSettlement == null || l.Settlement == null ? true : false,
                 CurrentPopulationCount = l.CurrentPopulationCount,
                 CurrentCommSrv = l.CommSrv,
                 PostOn = l.CommSrv.PostOn,
                 PhoneOn = l.CommSrv.PhoneOn,
                 PayphoneCount = l.CommSrv.PayphoneCount,
                 IntraZonePhoneOn = l.CommSrv.IntraZonePhoneOn,
                 LongDistancePhoneOn = l.CommSrv.LongDistancePhoneOn,
                 DataTransferOn = l.CommSrv.DataTransferOn,
                 TelematicServiceOn = l.CommSrv.TelematicServiceOn,
                 GsmOn = l.CommSrv.GsmOn,
                 UmtsOn = l.CommSrv.UmtsOn,
                 LteOn = l.CommSrv.LteOn,
                 NmtOn = l.CommSrv.NmtOn,
                 CdmaOn = l.CommSrv.CdmaOn,
                 TvOn = l.CommSrv.TvOn,
                 DigitalChanelCount = l.CommSrv.DigitalChanelCount,
                 AnalogChanelCount = l.CommSrv.AnalogChanelCount,
                 BroadcastingOn = l.CommSrv.BroadcastingOn,
                 DigitalChanelCount2 = l.CommSrv.DigitalChanelCount2,
                 AnalogChanelCount2 = l.CommSrv.AnalogChanelCount2,
                 CabelChanelCount = l.CommSrv.CabelChanelCount,
                 PostCount = l.CommSrv.PostCount,
                 PostOfficeCount = l.CommSrv.PostOfficeCount,
                 PayphoneCount2 = l.CommSrv.PayphoneCount2,
                 CapsCount = l.CommSrv.CapsCount,
                 CapsJobCount = l.CommSrv.CapsJobCount,
                 AccessPointOn = l.CommSrv.AccessPointOn,
                 AccessPointCount = l.CommSrv.AccessPointCount
              }).OrderBy(i => i.Borrough).ThenBy(i => i.Settlement).ToList();

         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         if (columns.Length > 0) {
            string[] items = _columns.Split(new char[] { ',', ';' });
            foreach (string item in items) {
               selectColumns.Add(repo.FindColumnInfo(item));
            }
         }

         if (this.InvokeRequired) {
            this.Invoke((MethodIntInvoker)delegate {
               bindingSrc.DataSource = q;
            });
         } else {
            bindingSrc.DataSource = q;
         }
         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи осуществляющих местную телефонную связь
      /// </summary>
      private List<ColumnInfo> BindPhoneOnDetail() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetPhoneOnDetailColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(bool));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<AvailabilityDataOperator> temp = null;
         temp = from c in repo.CommSrvs
                from td in c.PhoneOnDetail
                select new AvailabilityDataOperator() {
                   LocalityId = c.LocalityId,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName,
                   Availability = td.Availability
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            foreach (ColumnInfo col in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == col.Name
                               select t.Availability).FirstOrDefault();
               row[col.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;

         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи осуществляющих внутризоновую телефонную связь
      /// </summary>
      private List<ColumnInfo> BindIntraZonePhoneDetail() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetIntraZonePhoneDetailColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(bool));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<AvailabilityDataOperator> temp = null;
         temp = from c in repo.CommSrvs
                from td in c.IntraZonePhoneDetail
                select new AvailabilityDataOperator() {
                   LocalityId = c.LocalityId,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName,
                   Availability = td.Availability
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            foreach (ColumnInfo col in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == col.Name
                               select t.Availability).FirstOrDefault();
               row[col.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;

         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи осуществляющих междугороднюю и международную связь
      /// </summary>
      private List<ColumnInfo> BindLongDistancePhoneDetail() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetLongDistanceDetailColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(bool));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<AvailabilityDataOperator> temp = null;
         temp = from c in repo.CommSrvs
                from td in c.LongDistancePhoneDetail
                select new AvailabilityDataOperator() {
                   LocalityId = c.LocalityId,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName,
                   Availability = td.Availability
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            foreach (ColumnInfo col in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == col.Name
                               select t.Availability).FirstOrDefault();
               row[col.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;
         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи осуществляющих услуги передачи данных
      /// </summary>
      private List<ColumnInfo> BindTransferDetails() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetTransferDetailsColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(DataRate));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<TransferDataOperator> temp;
         temp = from c in repo.CommSrvs
                from td in c.TransferDataDetails
                select new TransferDataOperator() {
                   LocalityId = c.LocalityId
                                  ,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName
                                  ,
                   Rate = td.MaxRate
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            // добавить данные по колонкам оператово связи
            foreach (ColumnInfo colInfo in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == colInfo.Name
                               select t.Rate).FirstOrDefault();
               row[colInfo.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;
         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи оказывающих телематические услуги связи
      /// </summary>
      private List<ColumnInfo> BindTelematicServiceDetails() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetTelematicDetailsColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(DataRate));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<TransferDataOperator> temp;
         temp = from c in repo.CommSrvs
                from td in c.TelematicDataDetails
                select new TransferDataOperator() {
                   LocalityId = c.LocalityId
                                  ,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName
                                  ,
                   Rate = td.MaxRate
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            // добавить данные по колонкам оператово связи
            foreach (ColumnInfo colInfo in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == colInfo.Name
                               select t.Rate).FirstOrDefault();
               row[colInfo.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;
         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи осуществляющих услуги вещания в стандарте GSM (2G)
      /// </summary>
      private List<ColumnInfo> BindGsmDetail() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetGsmDetailColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(GsmType));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<GsmDataOperator> temp;
         temp = from c in repo.CommSrvs
                from td in c.GsmDetail
                select new GsmDataOperator() {
                   LocalityId = c.LocalityId
                   ,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName
                   ,
                   Gsm = td.GSMType
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            foreach (ColumnInfo col in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == col.Name
                               select t.Gsm).FirstOrDefault();
               row[col.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;
         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи осуществляющих услуги вещания в стандарте LTE (4G)
      /// </summary>
      private List<ColumnInfo> BindUmtsDetail() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetUmtsDetailColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(bool));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<AvailabilityDataOperator> temp = null;
         temp = from c in repo.CommSrvs
                from td in c.UmtsDetail
                select new AvailabilityDataOperator() {
                   LocalityId = c.LocalityId
                    ,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName
                    ,
                   Availability = td.Availability
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            foreach (ColumnInfo col in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == col.Name
                               select t.Availability).FirstOrDefault();
               row[col.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;
         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи осуществляющих услуги вещания в стандарте UMTS (3G)
      /// </summary>
      private List<ColumnInfo> BindLteDetail() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetLteDetailColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(bool));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<AvailabilityDataOperator> temp = null;
         temp = from c in repo.CommSrvs
                from td in c.LteDetail
                select new AvailabilityDataOperator() {
                   LocalityId = c.LocalityId,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName,
                   Availability = td.Availability
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            foreach (ColumnInfo col in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == col.Name
                               select t.Availability).FirstOrDefault();
               row[col.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;
         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи осуществляющих услуги эфирного телевещания
      /// </summary>
      private List<ColumnInfo> BindEtvChanelDetail() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetEtvChanelDetailColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(bool));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<AvailabilityDataOperator> temp = null;
         temp = from c in repo.CommSrvs
                from td in c.EtvChanelDetail
                select new AvailabilityDataOperator() {
                   LocalityId = c.LocalityId,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName,
                   Availability = true
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            foreach (ColumnInfo col in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == col.Name
                               select t.Availability).FirstOrDefault();
               row[col.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;
         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи осуществляющих цифровое эфирное телевещание
      /// </summary>
      private List<ColumnInfo> BindEtvDigitalChanelDetail() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetEtvDigitalChanelDetailColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(int));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<CountDataOperator> temp = null;
         temp = from c in repo.CommSrvs
                from td in c.EtvDigitalChanelDetail
                select new CountDataOperator() {
                   LocalityId = c.LocalityId,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName,
                   Count = td.Count
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            foreach (ColumnInfo col in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == col.Name
                               select t.Count).FirstOrDefault();
               row[col.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;
         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи осуществляющих аналоговое эфирное телевещание
      /// </summary>
      private List<ColumnInfo> BindEtvAnalogChanelDetail() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetEtvAnalogChanelDetailColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(int));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<CountDataOperator> temp = null;
         temp = from c in repo.CommSrvs
                from td in c.EtvAnalogChanelDetail
                select new CountDataOperator() {
                   LocalityId = c.LocalityId,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName,
                   Count = td.Count
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            foreach (ColumnInfo col in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == col.Name
                               select t.Count).FirstOrDefault();
               row[col.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;
         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи осуществляющих услуги эфирного радиовещания
      /// </summary>
      private List<ColumnInfo> BindRvChanelDetail() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetRvChanelDetailColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(bool));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<AvailabilityDataOperator> temp = null;
         temp = from c in repo.CommSrvs
                from td in c.RvChanelDetail
                select new AvailabilityDataOperator() {
                   LocalityId = c.LocalityId,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName,
                   Availability = true
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            foreach (ColumnInfo col in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == col.Name
                               select t.Availability).FirstOrDefault();
               row[col.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;
         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи осуществляющих цифровое эфирное радиовещание
      /// </summary>
      private List<ColumnInfo> BindRvDigitalChanelDetail() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetRvDigitalChanelDetailColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(int));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<CountDataOperator> temp = null;
         temp = from c in repo.CommSrvs
                from td in c.RvDigitalChanelDetail
                select new CountDataOperator() {
                   LocalityId = c.LocalityId,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName,
                   Count = td.Count
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            foreach (ColumnInfo col in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == col.Name
                               select t.Count).FirstOrDefault();
               row[col.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;
         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи осуществляющих аналоговое эфирное радиовещание
      /// </summary>
      private List<ColumnInfo> BindRvAnalogChanelDetail() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetRvAnalogChanelDetailColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(int));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<CountDataOperator> temp = null;
         temp = from c in repo.CommSrvs
                from td in c.RvAnalogChanelDetail
                select new CountDataOperator() {
                   LocalityId = c.LocalityId,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName,
                   Count = td.Count
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            foreach (ColumnInfo col in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == col.Name
                               select t.Count).FirstOrDefault();
               row[col.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;
         return selectColumns;
      }

      /// <summary>
      /// Првязать к гриду pivot данные по операторам связи осуществляющих кабельное телевещание
      /// </summary>
      private List<ColumnInfo> BindCableChanelDetail() {
         List<ColumnInfo> selectColumns = CreateHeaderColInfo();
         List<ColumnInfo> pivotCols = repo.GetCableChanelDetailColumns(DataViewBy);
         DataTable tbl = CreateDataTable(selectColumns, pivotCols, typeof(int));
         IEnumerable<PivotHeader> header = PivotHeader.GetPivotHeader();

         IEnumerable<CountDataOperator> temp = null;
         temp = from c in repo.CommSrvs
                from td in c.CableChanelDetail
                select new CountDataOperator() {
                   LocalityId = c.LocalityId,
                   Name = (DataViewBy == DataView.ByCorporatiions) ? td.Corp.CorporateName : td.Corp.Operator.OperatorName,
                   Count = td.Count
                };

         foreach (var item in header) {
            DataRow row = CreatePivotDataRow(tbl, item);
            foreach (ColumnInfo col in pivotCols) {
               object value = (from t in temp
                               where item.Id == t.LocalityId && t.Name == col.Name
                               select t.Count).FirstOrDefault();
               row[col.Property] = value;
            }
         }

         bindingSrc.DataSource = tbl;
         return selectColumns;
      }

      /// <summary>
      /// Занести данные заголовка в строку данных
      /// </summary>
      /// <param name="item">данные заголовка</param>
      /// <param name="row">строка данныз</param>
      private static DataRow CreatePivotDataRow(DataTable tbl, PivotHeader item) {
         DataRow row = tbl.NewRow();
         row["Borrough"] = item.Borrough;
         row["Settlement"] = item.Settlement;
         row["FullName"] = item.FullName;
         row["IsAdmCenter"] = item.IsAdmCenter;
         row["CurrentPopulationCount"] = item.CurrentPopulationCount;
         tbl.Rows.Add(row);
         return row;
      }

      /// <summary>
      /// Создать табл. данных для дальнейшего формирования Pivot табл.
      /// </summary>
      private DataTable CreateDataTable(List<ColumnInfo> selectColumns, List<ColumnInfo> pivotCols, Type type) {
         DataTable tbl = new DataTable();
         tbl.Columns.Add("Borrough");
         tbl.Columns.Add("Settlement");
         tbl.Columns.Add("FullName", typeof(Locality));
         tbl.Columns.Add("IsAdmCenter", typeof(bool));
         tbl.Columns.Add("CurrentPopulationCount", typeof(int));
         foreach (ColumnInfo col in pivotCols) {
            selectColumns.Add(col);
            tbl.Columns.Add(col.Property, type);
         }

         return tbl;
      }

      /// <summary>
      /// Пересоздать колонки для грида свода
      /// </summary>
      private void UpdateGridView(List<ColumnInfo> columns) {
         if (columns.Count > 0) {
            gridView1.Columns.Clear();
            GridColumn[] gridViewColumns = new GridColumn[columns.Count];
            for (int i = 0; i < columns.Count; i++) {
               ColumnInfo ci = repo.FindColumnInfo(columns[i].Property);
               if (ci == null) {
                  ci = repo.AddColumnInfo(columns[i].Name, columns[i].Property);
               }

               GridColumn col = new GridColumn();
               col.Name = ci.Name;
               col.FieldName = ci.Property;
               col.Visible = true;
               col.VisibleIndex = i;
               col.Width = ci.GridColumnWidth;
               col.Caption = GetGridColumnCaption(ci.Name);
               gridViewColumns[i] = col;
            }
            gridView1.Columns.AddRange(gridViewColumns);
         }
      }

      private string GetGridColumnCaption(string colName) {
         string caption = colName;
         int idx = caption.IndexOf('_');
         if (idx > 0)
            caption = caption.Substring(idx + 1);
         return caption;
      }

      /// <summary>
      /// Загрузить данные с сайта Роскомнадзора
      /// </summary>
      private void DownloadCommSrv() {
         Parser parser = new Parser();
         for (int i = 0; i < bindingSrc.Count; i++) {
            Locality locality = gridView1.GetRowCellValue(i, "FullName") as Locality;
            string msg = string.Format("Идет обновление данных по {0} ({1} из {2})", locality.FullName, i, bindingSrc.Count);
            StatusItem = msg;
            locality.DownloadCommSrv();
            backgroundWorker.ReportProgress(i + 1);   // отмечаем прогресс в выполнении обработки
         }
      }

      /// <summary>
      /// Открыть окно детальной инфорации о поселении
      /// </summary>
      private void ShowDetail(Locality locality) {
         LocalityEditForm f = new LocalityEditForm(locality);
         DialogResult dr = f.ShowDialog(this);
      }

      /// <summary>
      /// Открыть страницу на портале "Открытый реестр связи"
      /// </summary>
      /// <param name="localityId">уникальный код населенного пункта в реестре связи</param>
      private void OpenInternetReestr(int localityId) {
         string url = Tools.GetReestrSvyazUrl(localityId);
         Process.Start(url);
      }

      /// <summary>
      /// Определить есть ли открытые gridView отображающие дочерние данные
      /// </summary>
      /// <returns></returns>
      private bool IsVisibleDetailView() {
         for (int i = 0; i < gridView1.RowCount; i++) {
            BaseView childView = gridView1.GetVisibleDetailView(i);
            if (childView != null)
               return true;
         }
         return false;
      }

      /// <summary>
      /// Вернуть экземпляр CommunicationService для текущей строки грида
      /// </summary>
      private CommunicationService GetCurrentCommSrv() {
         object data = bindingSrc.Current;
         CommunicationService commSrv = data.GetType().GetProperty("CurrentCommSrv").GetValue(data, null) as CommunicationService;
         return commSrv;
      }

      /// <summary>
      /// Сформировать массив инф. о данных в формате json
      /// </summary>
      private FileInfo[] GetJsonFiles() {
         string dataDir = dataDir = Path.Combine(Application.StartupPath, "Data");
         DirectoryInfo dirInfo = new DirectoryInfo(dataDir);
         FileInfo[] files = dirInfo.GetFiles("*.json");
         return files;
      }

      /// <summary>
      /// Выполнить резервное копирование данных
      /// </summary>
      private void Backup() {
         using (ZipArchive zip = new ZipArchive()) {
            FileInfo[] backupFiles = GetJsonFiles();
            foreach (FileInfo fi in backupFiles) {
               zip.AddFile(fi.FullName, "/");
            }
            string backupDescr = string.Format("Полное резервное копирование выполненное {0}", DateTime.Now);
            zip.AddText("description", backupDescr, Encoding.UTF8);
            string nowStr = DateTime.Now.ToString();
            nowStr = nowStr.Replace(".", "");
            nowStr = nowStr.Replace(" ", "_");
            nowStr = nowStr.Replace(":", "");
            string backupPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.None);
            string zipName = string.Format("{0}\\SvyazBackup_{1}.zip", backupPath, nowStr);
            zip.Save(zipName);
         }
      }
      #endregion

      #region Events
      /// <summary>
      /// Элемент управления загружается
      /// </summary>
      private void LocalitiesViewCtrl_Load(object sender, EventArgs e) {
         //InitDataView("");
      }

      /// <summary>
      /// Нажали кнопку "Показать/скрыть панель
      /// </summary>
      private void barBtnLeft_ItemClick(object sender, ItemClickEventArgs e) {
         splitContainerControl1.Collapsed = CollapsedLeftPanel;
      }

      /// <summary>
      /// Нажали кнопку "Экспорт в Excel"
      /// </summary>
      private void barBtnToExcel_ItemClick(object sender, ItemClickEventArgs e) {
         SaveFileDialog sfd = new SaveFileDialog();
         sfd.Title = "Сохранить в формате Excel";
         sfd.Filter = "Книга Excel 97-2003 (*.xls)|*.xls| Кника Excel (*.xlsx)|*.xlsx";
         DialogResult dr = sfd.ShowDialog();
         if (dr == DialogResult.OK) {
            string ext = Path.GetExtension(sfd.FileName);
            if (ext == ".xls") {
               gridControl1.ExportToXls(sfd.FileName);
               //gridControl1.MainView.Export(DevExpress.XtraPrinting.ExportTarget.Xls, sfd.FileName);
            } else if (ext == ".xlsx") {
               gridControl1.MainView.Export(DevExpress.XtraPrinting.ExportTarget.Xlsx, sfd.FileName);
            }
         }
      }

      /// <summary>
      /// Загрузить данные Роскомнадзора по всем населенным пунктам 
      /// </summary>
      private void barBtnInternet_ItemClick(object sender, ItemClickEventArgs e) {
         backgroundWorker.RunWorkerAsync();
      }

      /// <summary>
      /// Нажали кнопку "Перечитать данные об услугах связи"
      /// </summary>
      private void barBtnRefresh_ItemClick(object sender, ItemClickEventArgs e) {
         Bind();
      }

      /// <summary>
      /// Нажали кнопку "Открыть страницу на сайте Роскомнадзора"
      /// </summary>
      private void barBtnWww_ItemClick(object sender, ItemClickEventArgs e) {
         GridView gv = gridView1;
         int rowHandle = gv.FocusedRowHandle;
         if (rowHandle >= 0) {
            Locality locality = gridView1.GetRowCellValue(rowHandle, "FullName") as Locality;
            OpenInternetReestr(locality.Id);
         }
      }

      /// <summary>
      /// Изменили источник данных для отображения детализирующей информации
      /// </summary>
      private void barComboSrc_EditValueChanged(object sender, EventArgs e) {
         if (repo != null) {
            repo.CommSrvs.ForEach(i => i.DataSrc = this.DataSrc);
            ShowData(_columns);
         }
      }

      /// <summary>
      /// Изменили вид представления сводных данных (по юр.лицам или по операторам связи)
      /// </summary>
      private void barComboView_EditValueChanged(object sender, EventArgs e) {
         if (repo != null) {
            ShowData(_columns);
         }
      }

      private void gridControl1_DragDrop(object sender, DragEventArgs e) {
         if (e.Data.GetDataPresent(typeof(string))) {
            object data = e.Data.GetData(typeof(string));
            if (data != null) {
               string coldata = data.ToString();
               ShowData(coldata);
               barComboSrc.Enabled = true;

            }
         }
      }

      private void gridControl1_DragOver(object sender, DragEventArgs e) {
         if (e.Data.GetDataPresent(typeof(string)))
            e.Effect = DragDropEffects.Move;
         else
            e.Effect = DragDropEffects.None;
      }

      private void gridControl1_DragEnter(object sender, DragEventArgs e) {
         if (e.Data.GetDataPresent(typeof(string)))
            e.Effect = DragDropEffects.Move;
         else
            e.Effect = DragDropEffects.None;
      }

      /// <summary>
      /// Регистрируем дочернее GridView
      /// </summary>
      private void gridControl1_ViewRegistered(object sender, ViewOperationEventArgs e) {
         GridView detail = gridView1.GetDetailView(rowHandle, relationIndex) as GridView;
         detail.BestFitColumns(true);
         if (this.DataSrc == Svyaz.DataSrc.OperatorData) {
            detail.OptionsBehavior.ReadOnly = false;
            detail.OptionsBehavior.Editable = true;
            detail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            detail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            detail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            foreach (GridColumn col in detail.Columns) {
               if (col.FieldName == "Corp") {
                  col.OptionsColumn.ReadOnly = true;
                  col.OptionsColumn.AllowEdit = false;
               }
               if (col.FieldName == "MinRate" || col.FieldName == "MaxRate") {
                  col.ColumnEdit = this.riPopupContainerEdit1;
               }
            }
         }
         if (this.DataSrc == Svyaz.DataSrc.OpenData) {
            detail.OptionsBehavior.ReadOnly = true;
            detail.OptionsBehavior.Editable = false;
            detail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.Default;
            detail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.Default;
            detail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
         }
      }

      private void gridView1_DoubleClick(object sender, EventArgs e) {
         GridView gv = sender as GridView;

         if (lastClickPoint != null) {
            GridHitInfo hitInfo = gv.CalcHitInfo((Point)lastClickPoint);
            lastClickPoint = null;
            if (hitInfo.RowHandle >= 0) {
               object obj = gridView1.GetRowCellValue(hitInfo.RowHandle, "FullName");
               Locality locality = obj as Locality;
               ShowDetail(locality);
            }
         }
      }

      private void gridView1_MouseUp(object sender, MouseEventArgs e) {
         lastClickPoint = e.Location;
      }

      private void gridView1_KeyUp(object sender, KeyEventArgs e) {
         if (e.KeyCode == Keys.Enter) {
            GridView gv = sender as GridView;
            int rowHandle = gv.FocusedRowHandle;
            if (rowHandle >= 0) {
               Locality locality = gridView1.GetRowCellValue(rowHandle, "FullName") as Locality;
               ShowDetail(locality);
            }
         }
      }

      /// <summary>
      /// Изменили ширину колонки gridView
      /// </summary>
      private void gridView1_ColumnWidthChanged(object sender, ColumnEventArgs e) {
         ColumnInfo ci = repo.FindColumnInfo(e.Column.FieldName);
         if (ci != null) {
            ci.GridColumnWidth = e.Column.Width;
         }
      }

      /// <summary>
      /// Расчет Summaries
      /// </summary>
      private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e) {
         GridSummaryItem item = e.Item as GridSummaryItem;
         //Initialization
         if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start) {
            if (e.IsGroupSummary) {
               customSum = 0m;
            }
            if (e.IsTotalSummary) {
               customCount = 0;
            }
         }

         //Calculation
         if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate) {
            if (e.IsGroupSummary) {
               customSum += Convert.ToDecimal(e.FieldValue);
            }
            if (e.IsTotalSummary) {
               GridColumnSummaryItem summaryItem = e.Item as GridColumnSummaryItem;
               if (dicSummary.ContainsKey(summaryItem.FieldName)) {
                  TypeCode tc = dicSummary[summaryItem.FieldName];
                  switch (tc) {
                     case TypeCode.Boolean:
                        bool boolValue = Convert.ToBoolean(e.FieldValue);
                        if (boolValue == true)
                           customCount++;
                        break;
                     case TypeCode.Int32:
                        if (tc == TypeCode.Int32) {
                           int intValue = Convert.ToInt32(e.FieldValue);
                           if (intValue > 0)
                              customCount++;
                        }
                        break;
                     case TypeCode.Object:
                        if (tc == TypeCode.Object) {
                           DataRate rate = e.FieldValue as DataRate;
                           if (rate != null && rate.Rate > 0)
                              customCount++;
                        }
                        break;
                     default:
                        break;
                  }
               }
            }
         }

         //Finalization
         if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize) {
            if (e.IsGroupSummary) {
               decimal total = repo.GetTotalPopulation();
               e.TotalValue = customSum / total * 100m;
            }
            if (e.IsTotalSummary) {
               e.TotalValue = customCount;
            }
         }

      }

      /// <summary>
      /// Открываем контекстное меню
      /// </summary>
      private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e) {
         if (e.MenuType == GridMenuType.Summary) {
            string fieldName = e.HitInfo.Column.FieldName;
            object val = gridView1.GetRowCellValue(0, e.HitInfo.Column);
            TypeCode tc = Type.GetTypeCode(val.GetType());
            if (!dicSummary.ContainsKey(fieldName)) {
               dicSummary.Add(fieldName, tc);
            }
            //e.Menu.Items[3].Enabled = true;     // сделать доступным пункт меню "Количество"
            e.Menu.Items[5].Enabled = true;     // сделать доступным пункт меню "Нет"
         }
      }

      /// <summary>
      /// Выбираем элемент контекстного меню
      /// </summary>
      private void gridView1_GridMenuItemClick(object sender, GridMenuItemClickEventArgs e) {
         if (e.MenuType == GridMenuType.Summary) {
            if (dicSummary.ContainsKey(e.Column.FieldName)) {
               if (e.SummaryType == DevExpress.Data.SummaryItemType.Count) {
                  e.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                  e.SummaryFormat = "Кол.={0}";
               }
            }
         }
      }

      /// <summary>
      /// MasterRow закрылась
      /// </summary>
      private void gridView1_MasterRowCollapsed(object sender, CustomMasterRowEventArgs e) {
         bool isChildVisible = IsVisibleDetailView();
         barComboSrc.Enabled = !isChildVisible;
      }

      /// <summary>
      /// MasterRow закрывается
      /// </summary>
      private void gridView1_MasterRowCollapsing(object sender, MasterRowCanExpandEventArgs e) {
         if (DataSrc == Svyaz.DataSrc.OpenData)
            return;
         CommunicationService commSrv = GetCurrentCommSrv();
         if (commSrv != null) {
            CommSrvData d = bindingSrc.Current as CommSrvData;
            d.LoadData(commSrv);
            bindingSrc.ResetCurrentItem();
         }
      }

      /// <summary>
      /// MasterRow отрывается
      /// открываются закладки, содержащие дочерние данные
      /// </summary>
      private void gridView1_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e) {
         rowHandle = e.RowHandle;
         relationIndex = e.RelationIndex;
         e.Allow = true;
      }

      /// <summary>
      /// MasterRow открылась
      /// </summary>
      private void gridView1_MasterRowExpanded(object sender, CustomMasterRowEventArgs e) {
         barComboSrc.Enabled = false;
      }

      /// <summary>
      /// Формируем коллекции для отображения дочерних данных
      /// </summary>
      private void gridView1_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e) {
         CommunicationService commSrv = GetCurrentCommSrv();
         BindingSource bs = new BindingSource();
         string relationName = relationNames[e.RelationIndex];
         IList list = commSrv.GetMasterDetailInfo(DataSrc, relationName);
         bs.DataSource = list;
         e.ChildList = bs;
      }

      /// <summary>
      /// Определить заголовки дочерних GridView
      /// </summary>
      private void gridView1_MasterRowGetRelationDisplayCaption(object sender, MasterRowGetRelationNameEventArgs e) {
         int idx = e.RelationIndex;
         e.RelationName = relationCaptions[idx];
      }

      /// <summary>
      /// Определить наименование дочерних GridView
      /// </summary>
      private void gridView1_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e) {
         int idx = e.RelationIndex;
         e.RelationName = relationNames[idx];
      }

      /// <summary>
      /// Определить кол. дочерних gridView
      /// </summary>
      private void gridView1_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e) {
         e.RelationCount = masterDetailCount;
      }

      /// <summary>
      /// Открывается редактор скорости передачи данных
      /// </summary>
      private void riPopupContainerEdit1_BeforePopup(object sender, EventArgs e) {
         GridView detail = gridView1.GetDetailView(rowHandle, relationIndex) as GridView;
         DataRate rate = (detail.GetFocusedValue() as DataRate);
         dataRateEditor1.ReadOnly = false;
         dataRateEditor1.Rate = rate;
      }

      /// <summary>
      /// Редактор скорости передачи данных закрылся
      /// </summary>
      private void riPopupContainerEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e) {
         if (e.CloseMode != PopupCloseMode.Cancel) {
            GridView detail = gridView1.GetDetailView(rowHandle, relationIndex) as GridView;
            DataRate rate = dataRateEditor1.Rate;
            detail.SetFocusedValue(rate);
            detail.CloseEditor();
         }
      }
      #endregion

      #region BackgroundWorker
      /// <summary>
      /// Выполняем асинхронную обработку
      /// </summary>
      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
         StatusItem = "Выполняется архивирование существующих данных";
         Backup();
         StatusItem = "Выполняется операция загрузки данных с сайта Роскомнадзора";
         DownloadCommSrv();
      }

      /// <summary>
      /// Отображаем изменение состояния асинхронной обработки
      /// </summary>
      private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
         progressBarItem.EditValue = e.ProgressPercentage;
         //bindingSrc.ResetItem(e.ProgressPercentage);
         //bindingSrc.ResumeBinding();
      }

      /// <summary>
      /// Асинхронная обработка завершена
      /// </summary>
      private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
         string status = "Загрузка данных с сайта Роскомнадзора завершена успешно";
         if (e.Error != null) {
            MessageBox.Show(e.Error.Message, "Ошибка загрузки данных с сайта Роскомнадзора", MessageBoxButtons.OK, MessageBoxIcon.Error);
            status = "Обработка загрузки данных с сайта Роскомнадзора завершилась с ошибками";
         }
         if (e.Error == null) {
            Bind();
            repo.SaveAll();
         }

         this.StatusItem = status;
         progressBarItem.EditValue = 0;
      }
      #endregion

      private void gridView1_BeforePrintRow(object sender, DevExpress.XtraGrid.Views.Printing.CancelPrintRowEventArgs e) {
         var str = e.ToString();
         Console.WriteLine(str);
      }
   }

   #region Private Classes
   class TransferDataOperator {
      public int LocalityId { get; set; }
      public string Name { get; set; }
      public DataRate Rate { get; set; }
   }

   class CountDataOperator {
      public int LocalityId { get; set; }
      public string Name { get; set; }
      public int Count { get; set; }
   }

   class GsmDataOperator {
      public int LocalityId { get; set; }
      public string Name { get; set; }
      public GsmType Gsm { get; set; }
   }

   class AvailabilityDataOperator {
      public int LocalityId { get; set; }
      public string Name { get; set; }
      public bool Availability { get; set; }
   }

   class CommSrvData {
      public Borrough Borrough { get; set; }
      public Settlement Settlement { get; set; }
      public Locality FullName { get; set; }
      public bool IsAdmCenter { get; set; }
      public int CurrentPopulationCount { get; set; }
      public CommunicationService CurrentCommSrv { get; set; }
      public bool PostOn { get; set; }
      public bool PhoneOn { get; set; }
      public int PayphoneCount { get; set; }
      public bool IntraZonePhoneOn { get; set; }
      public bool LongDistancePhoneOn { get; set; }
      public bool DataTransferOn { get; set; }
      public bool TelematicServiceOn { get; set; }
      public GsmType GsmOn { get; set; }
      public bool UmtsOn { get; set; }
      public bool LteOn { get; set; }
      public bool NmtOn { get; set; }
      public bool CdmaOn { get; set; }
      public bool TvOn { get; set; }
      public int DigitalChanelCount { get; set; }
      public int AnalogChanelCount { get; set; }
      public bool BroadcastingOn { get; set; }
      public int DigitalChanelCount2 { get; set; }
      public int AnalogChanelCount2 { get; set; }
      public int CabelChanelCount { get; set; }
      public int PostCount { get; set; }
      public int PostOfficeCount { get; set; }
      public int PayphoneCount2 { get; set; }
      public int CapsCount { get; set; }
      public int CapsJobCount { get; set; }
      public bool AccessPointOn { get; set; }
      public int AccessPointCount { get; set; }

      public void LoadData(CommunicationService commSrv) {
         CurrentCommSrv = commSrv;
         PostOn = commSrv.PostOn;
         PhoneOn = commSrv.PhoneOn;
         PayphoneCount = commSrv.PayphoneCount;
         IntraZonePhoneOn = commSrv.IntraZonePhoneOn;
         LongDistancePhoneOn = commSrv.LongDistancePhoneOn;
         DataTransferOn = commSrv.DataTransferOn;
         TelematicServiceOn = commSrv.TelematicServiceOn;
         GsmOn = commSrv.GsmOn;
         UmtsOn = commSrv.UmtsOn;
         LteOn = commSrv.LteOn;
         NmtOn = commSrv.NmtOn;
         CdmaOn = commSrv.CdmaOn;
         TvOn = commSrv.TvOn;
         DigitalChanelCount = commSrv.DigitalChanelCount;
         AnalogChanelCount = commSrv.AnalogChanelCount;
         BroadcastingOn = commSrv.BroadcastingOn;
         DigitalChanelCount2 = commSrv.DigitalChanelCount2;
         AnalogChanelCount2 = commSrv.AnalogChanelCount2;
         CabelChanelCount = commSrv.CabelChanelCount;
         PostCount = commSrv.PostCount;
         PostOfficeCount = commSrv.PostOfficeCount;
         PayphoneCount2 = commSrv.PayphoneCount2;
         CapsCount = commSrv.CapsCount;
         CapsJobCount = commSrv.CapsJobCount;
         AccessPointOn = commSrv.AccessPointOn;
         AccessPointCount = commSrv.AccessPointCount;
      }
   }
   #endregion
}
