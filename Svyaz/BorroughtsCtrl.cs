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

namespace Svyaz {
   public partial class BorroughtsCtrl : DevExpress.XtraEditors.XtraUserControl, IReloadData {
      private Repository repo;

      public BorroughtsCtrl() {
         InitializeComponent();
         this.Dock = DockStyle.Fill;
      }

      /// <summary>
      /// Перезагрузить данные
      /// </summary>
      public void LoadData() {
         repo = Repository.GetRepository();
         bindingSrc.DataSource = repo.Borrougts;
      }

      /// <summary>
      /// Элемент упрвления загружается
      /// </summary>
      private void BorroughtsCtrl_Load(object sender, EventArgs e) {
         LoadData();
      }

      #region MasterDetail Events

      private void gridView1_MasterRowGetLevelDefaultView(object sender, MasterRowGetLevelDefaultViewEventArgs e) {
         if (e.RelationIndex == 0)
            e.DefaultView = gvSettlemets;
      }

      private void gridView1_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e) {
         e.RelationCount = 1;
      }

      private void gridView1_MasterRowGetRelationDisplayCaption(object sender, MasterRowGetRelationNameEventArgs e) {
         if (e.RelationIndex == 0)
            e.RelationName = "Поселения";
      }


      private void gvSettlemets_MasterRowGetLevelDefaultView(object sender, MasterRowGetLevelDefaultViewEventArgs e) {
         if (e.RelationIndex == 0)
            e.DefaultView = gvLocalities;
      }

      private void gvSettlemets_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e) {
         e.RelationCount = 1;
      }

      private void gvSettlemets_MasterRowGetRelationDisplayCaption(object sender, MasterRowGetRelationNameEventArgs e) {
         if (e.RelationIndex == 0)
            e.RelationName = "Населенные пункты";
      }
      #endregion
   }
}
