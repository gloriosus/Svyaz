using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Svyaz.Data;
using Svyaz.Model;

namespace Svyaz {
   public partial class LocalitiesBaseViewCtrl : DevExpress.XtraEditors.XtraUserControl {
      private Repository repo;

      public LocalitiesBaseViewCtrl() {
         InitializeComponent();
         repo = Repository.GetRepository();
      }

      /// <summary>
      /// Отфильтровать список населенных пунктов
      /// </summary>
      public void InitLocalities(List<int> filter) {
         var query = PivotHeader.GetPivotHeader();
         var data = query.Where(l => filter.IndexOf(l.Id) >= 0)
                         .ToList();
         bindingSrc.DataSource = data;
      }

      private void gridControl1_Click(object sender, EventArgs e) {

      }
   }
}
