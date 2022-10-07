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
   public partial class SettlermentsCtrl : DevExpress.XtraEditors.XtraUserControl, IReloadData {
      private Repository repo;

      public SettlermentsCtrl() {
         InitializeComponent();
         this.Dock = DockStyle.Fill;
      }

      /// <summary>
      /// Перезагрузить данные
      /// </summary>
      public void LoadData() {
         repo = Repository.GetRepository();
         int position = bindingSrc.Position;
         bindingSrc.DataSource = repo.Settlements;
         bindingSrc.Position = position;
      }

      /// <summary>
      /// Элемент управления - загружается
      /// </summary>
      private void SettlermentsCtrl_Load(object sender, EventArgs e) {
         LoadData();
      }

      #region MasterDetail Events

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
