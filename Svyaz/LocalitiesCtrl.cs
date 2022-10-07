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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Svyaz.Model;

namespace Svyaz {
   public partial class LocalitiesCtrl : DevExpress.XtraEditors.XtraUserControl, IReloadData {
      #region Fields
      private Repository repo;
      private Point lastClickPoint;    // точка последнего клика мышкой
      #endregion

      #region Ctors
      public LocalitiesCtrl() {
         InitializeComponent();
         this.Dock = DockStyle.Fill;
      }
      #endregion

      #region Methods
      /// <summary>
      /// Перезагрузить данные
      /// </summary>
      public void LoadData() {
         repo = Repository.GetRepository();
         int position = bindingSrc.Position;
         bindingSrc.DataSource = repo.Localities;
         bindingSrc.Position = position;
      }

      /// <summary>
      /// Открыть окно детальной инфорации о поселении
      /// </summary>
      private void ShowDetail(Locality locality) {
         LocalityEditForm f = new LocalityEditForm(locality);
         DialogResult dr = f.ShowDialog(this);
      }
      #endregion

      #region Events
      /// <summary>
      /// Элемент управления загружается 
      /// </summary>
      private void LocalitiesCtrl_Load(object sender, EventArgs e) {
         LoadData();
      }

      private void gvLocalities_DoubleClick(object sender, EventArgs e) {
         GridView gv = sender as GridView;

         if (lastClickPoint != null){
            GridHitInfo hitInfo = gv.CalcHitInfo(lastClickPoint);
            if (hitInfo.RowHandle >= 0) {
               Locality locality = gv.GetFocusedRow() as Locality;
               ShowDetail(locality);
            }
         }
      }

      /// <summary>
      /// Отпустили клавишу мышки
      /// </summary>
      private void gvLocalities_MouseUp(object sender, MouseEventArgs e) {
         lastClickPoint = e.Location;
      }

      /// <summary>
      /// отпустили клавишу (Ловим Enter)
      /// </summary>
      private void gvLocalities_KeyUp(object sender, KeyEventArgs e) {
         if (e.KeyCode == Keys.Enter) {
            GridView gv = sender as GridView;
            Locality locality = gv.GetFocusedRow() as Locality;
            ShowDetail(locality);
         }
      }
      #endregion

      #region MasterDetail Events

      private void gvPopulations_MasterRowGetLevelDefaultView(object sender, MasterRowGetLevelDefaultViewEventArgs e) {
         if (e.RelationIndex == 0)
            e.DefaultView = gvPopulations;
      }

      private void gvPopulations_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e) {
         e.RelationCount = 1;
      }

      private void gvPopulations_MasterRowGetRelationDisplayCaption(object sender, MasterRowGetRelationNameEventArgs e) {
         if (e.RelationIndex == 0)
            e.RelationName = "Население";
      }
      #endregion
   }
}
