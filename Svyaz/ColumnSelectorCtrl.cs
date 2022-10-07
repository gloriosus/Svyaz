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
using DevExpress.XtraTreeList;
using Svyaz.Model;
using Svyaz.Data;
using DevExpress.XtraTreeList.Nodes;

namespace Svyaz {
   public partial class ColumnSelectorCtrl : XtraUserControl, IReloadData {
      private string prop = "";

      #region Ctors
      public ColumnSelectorCtrl() {
         InitializeComponent();
         LoadData();
      }
      #endregion

      #region Methods
      /// <summary>
      /// Выполнить загрузку данных
      /// </summary>
      public void LoadData() {
         Repository repo = Repository.GetRepository();
         treeList1.DataSource = repo.GetTreeColumns();
         treeList1.ExpandAll();
      }

      /// <summary>
      /// Сформтировать csv строку содежращую свойства всех отмеченных колонок
      /// </summary>
      /// <returns>csv строка</returns>
      private string GetCheckedColumns(TreeListNode node) {
         string data = "";
         if (!node.Checked) {
            data = node.GetValue("Property").ToString();
            node.TreeList.GetAllCheckedNodes().ForEach(n => n.Checked = false);
         }

         if (node.Checked) {
            var nodes = node.TreeList.GetAllCheckedNodes();
            foreach (var checkedNode in nodes) {
               if (checkedNode.Level == 1) {
                  string prop = checkedNode.GetValue("Property").ToString();
                  data = string.Format("{0};{1}", data, prop);
               }
            }
            data = data.Substring(1);
         }
         return data;
      }
      #endregion

      #region Events
      private void treeList1_MouseDown(object sender, MouseEventArgs e) {
         TreeList tl = sender as TreeList;
         if (e.Button == MouseButtons.Left) {
            TreeListHitInfo hitInfo = tl.CalcHitInfo(new Point(e.X, e.Y));
            if (hitInfo.Node != null && hitInfo.Column != null) {
               TreeListNode node = hitInfo.Node;
               prop = GetCheckedColumns(node);
            }
         }
      }

      private void treeList1_MouseMove(object sender, MouseEventArgs e) {
         if (e.Button == MouseButtons.Left && Control.ModifierKeys == Keys.None && prop.Length > 0) {
            TreeList tl = sender as TreeList;
            string data = prop;
            tl.DoDragDrop(data, DragDropEffects.Move);
         }
         prop = "";
      }

      private void treeList1_DragOver(object sender, DragEventArgs e) {
         if (e.Data.GetDataPresent(typeof(string)) && prop.Length > 0)
            e.Effect = DragDropEffects.Move;
         else
            e.Effect = DragDropEffects.None;
      }

      /// <summary>
      /// Крыжим только нужные колонки
      /// </summary>
      private void treeList1_AfterCheckNode(object sender, NodeEventArgs e) {
         TreeListNode node = e.Node;
         if (node != null && node.Level == 0) {    // Выставить или снять отметку для всех дочерних элементов корневого узла
            foreach (TreeListNode childNode in node.Nodes) {
               childNode.Checked = node.Checked;
            }
         }
         if (node != null && node.Checked && node.Level > 1) {
            node.Checked = false;
         }
      }

      private void treeList1_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e) {
         if (treeList1.FocusedNode != null && treeList1.FocusedNode == e.Node) {
            e.Appearance.Font = new Font(e.Column.AppearanceCell.Font, FontStyle.Bold);
         } else {
            e.Appearance.Font = new Font(e.Column.AppearanceCell.Font, FontStyle.Regular);
         }
      }
      #endregion

   }
}
