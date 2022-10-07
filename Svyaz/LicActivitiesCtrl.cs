using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Svyaz.Model;
using Svyaz.Data;
using System.Collections;
using DevExpress.XtraTreeList.Nodes;

namespace Svyaz {
   /// <summary>
   /// Визуальное предстваление для коллекции объектов LicensedActivity
   /// </summary>
   public partial class LicActivitiesCtrl : DevExpress.XtraEditors.XtraUserControl {
      #region Fields
      Repository repo;
      private List<LicensedActivity> activities;
      private BaseOperatorInfo _operator;
      private Corporation _corp;
      private DataView _dataViewBy;
      #endregion

      #region Properties
      /// <summary>
      /// Юр. лицо
      /// </summary>
      public Corporation Corp {
         get { return _corp; }
         set { 
            _corp = value;
            if (_corp != null) {
               _operator = _corp.Operator;
               InitActivities();
            }
         }
      }

      /// <summary>
      /// Вид отображения данных (для оператора или для юр.лица)
      /// </summary>
      public DataView DataViewBy {
         get { return _dataViewBy; }
         set { 
            _dataViewBy = value;
            if (_corp != null) {
               InitActivities();
            }
         }
      }
      #endregion

      #region Ctors
      public LicActivitiesCtrl() {
         InitializeComponent();
         _operator = null;
         _dataViewBy = DataView.ByCorporatiions;
         repo = Repository.GetRepository();
         activities = repo.LicActivities;
         this.Dock = DockStyle.Fill;
      }
      #endregion

      #region Methods
      /// <summary>
      /// Инициализировать деятельности (расставить галочки
      /// </summary>
      private void InitActivities() {
         treeList1.UncheckAll();
         if (_dataViewBy == DataView.ByCorporatiions)
            InitActivitiesByCorp(_corp);
         if (_dataViewBy == DataView.ByOperators)
            InitActivitiesByOperator(_operator);
         InitLocalities();
      }

      /// <summary>
      /// Инициализировать деятельности для юр. лица
      /// </summary>
      private void InitActivitiesByCorp(Corporation corp) {
         foreach (LicensedActivity activity in corp.Activities) {
            int idx = activities.IndexOf(activity);
            var node = treeList1.FindNodeByFieldValue("Property", activity.Property);
            if (node != null) {
               node.Checked = true;
            }
         }
      }

      /// <summary>
      /// Инициализировать деятельности для оператора связи
      /// </summary>
      private void InitActivitiesByOperator(BaseOperatorInfo op) {
         foreach (Corporation corp in op.Corporations) {
            InitActivitiesByCorp(corp);
         }
      }

      /// <summary>
      /// Отфильтровать населенные пункты в которых оказывается лицензируемая услуга
      /// </summary>
      private void InitLocalities() {
         List<int> localitiesRange = new List<int>();
         TreeListNode node = treeList1.FocusedNode;
         if (node != null && node.Checked) {
            string propName = node.GetValue("Property").ToString();
            localitiesRange = repo.CommSrvs.Where(c => (DataViewBy == DataView.ByCorporatiions) ?
                                                        c.ExistCorp(propName, _corp) :
                                                        c.ExistCorp(propName, _corp.Operator))
                                           .Select(c => c.LocalityId)
                                           .ToList();
         }
         localitiesBaseViewCtrl1.InitLocalities(localitiesRange);
      }
      #endregion

      #region Events
      /// <summary>
      /// Элемент управл. загружается
      /// </summary>
      private void LicActivitiesCtrl_Load(object sender, EventArgs e) {
         bindingSrc.DataSource = activities;
         treeList1.ExpandAll();
      }

      private void radioGroup1_EditValueChanged(object sender, EventArgs e) {
         DataView viewBy = (DataView)radioGroup1.EditValue;
         DataViewBy = viewBy;
      }

      private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
         InitLocalities();
      }
      #endregion
   }
}
