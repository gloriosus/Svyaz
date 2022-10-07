using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Svyaz.Model;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.LookAndFeel;
using Svyaz.Web;

namespace Svyaz {
   public partial class LocalityEditForm : DevExpress.XtraBars.Ribbon.RibbonForm {
      private Locality locality;       // населенный пункт
      List<Population> populations;    // демография 

      /// <summary>
      /// Населенный пункт
      /// </summary>
      public Locality Locality {
         get { return locality; }
      }

      /// <summary>
      /// Источник данных доступности услуг связи
      /// </summary>
      public DataSrc DataSrc {
         get { return (DataSrc)barEditDataSrc.EditValue; }
         set { barEditDataSrc.EditValue = (int)value; }
      }

      #region ctors
      public LocalityEditForm() {
         InitializeComponent();
         populations = new List<Population>();
      }

      public LocalityEditForm(Locality locality):this() {
         this.locality = locality;
         this.Text = locality.FullName;
      }
      #endregion

      #region Methods
      /// <summary>
      /// Загрузить элементы интерфейса данными из объекта "населенный пункт"
      /// </summary>
      private void LoadFromLocality(){
         if (locality.Settlement != null) {
            Borrough borrough = locality.Settlement.Borrough;
            textEditBorrough.Text = borrough.ToString();
            textEditSettlement.Text = locality.Settlement.ToString();
         }
         textEditId.Text = locality.Id.ToString();
         textEditName.Text = locality.Name;
         comboCategory.SelectedIndex = (int)locality.Category;
         textEditFullName.Text = locality.FullName;

         //textEditCurrentCount.DataBindings.Add("Text", locality, "CurrentPopulationCount");
         textEditCurrentCount.Text = locality.CurrentPopulationCount.ToString();

         bindingSrc.DataSource = null;
         populations.Clear();
         populations.AddRange(locality.Populations);
         bindingSrc.DataSource = populations;
      }

      /// <summary>
      /// Загрузить объект "населенный пункт" данными из элементов интерфейса
      /// </summary>
      private void LoadToLocality() {
         locality.Name = textEditName.Text;
         locality.Category = (SettlementCategory)comboCategory.SelectedIndex;

         locality.Populations.Clear();
         locality.Populations.AddRange(populations);
      }

      /// <summary>
      /// Вернуть актуальное значение кол. жителей
      /// </summary>
      private int GetPopulationCount() {
         Population population = (from p in populations
                                  where p.Date == populations.Max(p1 => p1.Date)
                                  select p).SingleOrDefault();
         return (population != null) ? population.Count : 0;
      }
      #endregion

      #region Events
      /// <summary>
      /// Загрузка формы
      /// </summary>
      private void LocalityDetailForm_Load(object sender, EventArgs e) {
         LoadFromLocality();
         comSrvCtrl1.CommSrv = locality.CommSrv;
      }

      /// <summary>
      /// Нажали кнопку "Сохранить и закрыть"
      /// </summary>
      private void barBtnSaveAndClose_ItemClick(object sender, ItemClickEventArgs e) {
         LoadToLocality();
         comSrvCtrl1.Save();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      /// <summary>
      /// нажали кнопку "Отменить изменения"
      /// </summary>
      private void barBtnReset_ItemClick(object sender, ItemClickEventArgs e) {
         LoadFromLocality();
      }

      /// <summary>
      /// Нажали кнопку "Загрузить из реестра роскомнадзора"
      /// </summary>
      private void barBtnDownload_ItemClick(object sender, ItemClickEventArgs e) {
         locality.DownloadCommSrv();
         comSrvCtrl1.CommSrv = locality.CommSrv;
      }

      /// <summary>
      /// Нажали кнопку "Закрыть"
      /// </summary>
      private void barBtnClose_ItemClick(object sender, ItemClickEventArgs e) {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      /// <summary>
      /// Изменили выбор источника данных для отображения инф. о доступности услуг связи
      /// </summary>
      private void barEditDataSrc_EditValueChanged(object sender, EventArgs e) {
         comSrvCtrl1.EnableEditData(DataSrc);
      }

      /// <summary>
      /// Изменилось значение Population
      /// </summary>
      private void bindingSrc_CurrentChanged(object sender, EventArgs e) {
         textEditCurrentCount.Text = GetPopulationCount().ToString();
      }

      /// <summary>
      /// Законичили ввод новой строки
      /// </summary>
      private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
         if (e.PrevFocusedRowHandle == -2147483647)
            textEditCurrentCount.Text = GetPopulationCount().ToString();
      }
      #endregion

   }
}