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
using Util;

namespace Svyaz {
   public partial class OperatorsCtrl : DevExpress.XtraEditors.XtraUserControl, IReloadData {
      #region Fields
      private Repository repo;
      BaseOperatorInfo unknownOperator;   // оператор содержащий списко не распр. юр. лиц
      private Point p1;                   // координаты захвата не распределенного юр. лица
      private Point p2;                   // координаты захвана юр. лица оператора
      private bool enableEditing;         // признак разерешения редактирования
      #endregion

      #region Ctors
      /// <summary>
      /// Элемент упрвления для отображения брендов операторов связи, ведущих лицензируемую деятельность
      /// </summary>
      public OperatorsCtrl() {
         InitializeComponent();
         repo = Repository.GetRepository();
         unknownOperator = Repository.UnknownOperator;
         p1 = Point.Empty;
         p2 = Point.Empty;
         enableEditing = false;
         this.Dock = DockStyle.Fill;
      }
      #endregion

      #region Methods
      /// <summary>
      /// Выполнить загрузку данных
      /// </summary>
      public void LoadData() {
         // получить список всех не распределенных юр. лиц
         RebindUnknown();
         // получить список всех операторов связи
         RebindOperators();
      }
     
      /// <summary>
      /// Получить текущего (выбранного) оператора связи
      /// </summary>
      private BaseOperatorInfo GetCurrentOperator() {
         BaseOperatorInfo op = null;
         if (bindingOperators.Current != null) {
            op = bindingOperators.Current as BaseOperatorInfo;
         }
         return op;
      }

      /// <summary>
      /// удалить оператора связи 
      /// при условии, что у него нет юр. лиц
      /// </summary>
      private bool DeleteOperator(BaseOperatorInfo op){
         bool ok = false;
         if (op.Corporations.Count == 0) {
            repo.Operators.Remove(op);
            RebindOperators();
            ok = true;
         }
         return ok;
      }

      /// <summary>
      /// Привязать список операторов связи к гриду
      /// </summary>
      private void RebindOperators() {
         List<BaseOperatorInfo> operators = repo.Operators.Where(o => o.OperatorName != BaseOperatorInfo.UnknownName).ToList();
         bindingOperators.DataSource = operators;
      }

      /// <summary>
      /// Привязать список юр. лиц для отображения в "юр. лицах Оператора"
      /// </summary>
      private void RebindCorp() {
         bindingCorps.DataSource = null;
         BaseOperatorInfo op = GetCurrentOperator();
         if (op != null) {
            bindingCorps.DataSource = op.Corporations.ToList();
         }
      }

      /// <summary>
      /// Привязать список юр. лиц для отображения в "не распределенные юр. лица"
      /// </summary>
      private void RebindUnknown() {
         bindingUnknown.DataSource = null;
         bindingUnknown.DataSource = unknownOperator.Corporations.ToList();
      }

      /// <summary>
      /// Создать нового оператора связи для заданного юр. лица
      /// </summary>
      /// <param corpName="corp">Наименование Юр. лица на основании данных о котором создается новый оператор связи</param>
      private BaseOperatorInfo CreateOperator(string corpName) {
         string operatorName = Tools.ClearOperatorName(corpName);
         BaseOperatorInfo op = new BaseOperatorInfo() { DefaultName = operatorName };
         repo.Operators.Add(op);
         RebindOperators();
         SelectOperator(op);
         return op;
      }

      /// <summary>
      /// Найти наиболее подходящего оператора для указанног юр. лица
      /// </summary>
      private BaseOperatorInfo FindOperatorByClearName(Corporation corp) {
         string operatorName = Tools.ClearOperatorName(corp.CorporateName);
         BaseOperatorInfo op = repo.Operators.SingleOrDefault(o => o.DefaultName == operatorName);
         return op;
      }

      /// <summary>
      /// Перейти к указанному оператору связи
      /// </summary>
      /// <param name="currentOperator"></param>
      private void SelectOperator(BaseOperatorInfo currentOperator) {
         List<BaseOperatorInfo> operators = bindingOperators.DataSource as List<BaseOperatorInfo>;
         int idx = operators.IndexOf(currentOperator);
         bindingOperators.Position = idx;
      }
      #endregion

      #region Events
      /// <summary>
      /// Элемент упрвления загружается
      /// </summary>
      private void BrandsCtrl_Load(object sender, EventArgs e) {
         LoadData();
      }

      /// <summary>
      /// Нажали клавишу (начало и завершение редактирования)
      /// </summary>
      private void gridView1_KeyDown(object sender, KeyEventArgs e) {
         if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape) {
            // Начать редактирование
            if (!enableEditing && e.KeyCode == Keys.F2) {
               enableEditing = true;
               gridView1.ShowEditor();
               e.Handled = true;
            }
            if (enableEditing) {
               // Закончить редактирование (с сохранением)
               if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter) {
                  gridView1.CloseEditor();
               }
               // выйти из редактирования без сохранения
               if (e.KeyCode == Keys.Escape) {
                  gridView1.HideEditor();
               }
               enableEditing = false;
            }

         }
      }

      /// <summary>
      /// Начинаем редактирование (проверить условия, разрешающие начать редактирование)
      /// </summary>
      private void gridView1_ShowingEditor(object sender, CancelEventArgs e) {
         e.Cancel = !enableEditing;
      }

      /// <summary>
      /// Редактро ячейки открылся (сбросить признак разрешения редактирования
      /// </summary>
      private void gridView1_ShownEditor(object sender, EventArgs e) {
         enableEditing = false;
      }

      /// <summary>
      /// Выбрали оператора связи
      /// </summary>
      private void bindingOperators_PositionChanged(object sender, EventArgs e) {
         RebindCorp();
      }

      /// <summary>
      /// Вызвать контекстное меню
      /// </summary>
      private void listBoxControl_MouseUp(object sender, MouseEventArgs e) {
         if (e.Button == System.Windows.Forms.MouseButtons.Right) {
            ListBoxControl lb = sender as ListBoxControl;
            int idx = lb.IndexFromPoint(e.Location);
            if (idx >= 0) {
               lb.SelectedIndex = idx;
               Point p = lb.PointToScreen(e.Location);
               if (lb.Equals(listBoxUnknown))
                  p1 = e.Location;
               if (lb.Equals(listBoxCorp))
                  p2 = e.Location;
               popupMenu1.ShowPopup(p);
            }
         }
      }

      /// <summary>
      /// Нажали мышкой на не распределенном юр. лице
      /// </summary>
      private void listBoxUnknown_MouseDown(object sender, MouseEventArgs e) {
         if (e.Button == MouseButtons.Left) {
            ListBoxControl lb = sender as ListBoxControl;
            p1 = new Point(e.X, e.Y);
            int idx = lb.IndexFromPoint(p1);
            if (idx < 0) 
               p1 = Point.Empty;
         }
      }

      /// <summary>
      /// Перемещаем мышку с нажатой левой клавишей (тащим не распределенное юр. лицо)
      /// </summary>
      private void listBoxUnknown_MouseMove(object sender, MouseEventArgs e) {
         if (e.Button == MouseButtons.Left) {
            if (p1 != Point.Empty && bindingUnknown.Count > 0) {
               if ((Math.Abs(e.X - p1.X) > 5) || (Math.Abs(e.Y - p1.Y) > 5)){
                  ListBoxControl lb = sender as ListBoxControl;
                  lb.DoDragDrop(sender, DragDropEffects.Move);
               }
            }
         }
      }

      /// <summary>
      /// Тащим  элемент из списка не распр. юр. лиц
      /// </summary>
      private void listBoxCorp_DragEnter(object sender, DragEventArgs e) {
         e.Effect = DragDropEffects.Move;
      }

      /// <summary>
      /// Перетащили не распределенное юр. лицо
      /// </summary>
      private void listBoxCorp_DragDrop(object sender, DragEventArgs e) {
         if (p1 != Point.Empty && bindingUnknown.Current != null) {
            int index = listBoxUnknown.IndexFromPoint(p1);
            Corporation corp = bindingUnknown[index] as Corporation;
            if (corp != null) {
               BaseOperatorInfo currentOperator = GetCurrentOperator();
               if (currentOperator == null) {
                  currentOperator = CreateOperator(corp.CorporateName);
               } else {
                  string operatorName = Tools.ClearOperatorName(corp.CorporateName);
                  if (operatorName != currentOperator.OperatorName) {   // Юр. лицо формально не может принадлежать текущему оператору связи
                     BaseOperatorInfo findOperator = FindOperatorByClearName(corp);   // ищем оператора связи, которому может принадлежать юр. лицо
                     StringBuilder sb = new StringBuilder();
                     // *********************************
                     // подходящего оператора нет
                     // *********************************
                     if (findOperator == null) {
                        sb.AppendFormat("'{0}' - скорее всего не является оператором связи '{1}'\r\n\r\n", corp.CorporateName, currentOperator);
                        sb.AppendLine("Нажмите ДА, для создания новго оператора связи");
                        sb.AppendFormat("Нажмине НЕТ для добавления к {0}", currentOperator);
                        string msg = sb.ToString();

                        DialogResult dr = MessageBox.Show(msg, "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (dr == DialogResult.Yes) {
                           currentOperator = CreateOperator(corp.CorporateName);
                        }
                     }
                     // **********************************
                     // подходящий оператор есть
                     // **********************************
                     if (findOperator != null) {
                        sb.AppendFormat("'{0}' - скорее всего является оператором связи '{1}'\r\n\r\n", corp.CorporateName, findOperator);
                        sb.AppendFormat("Нажмите Да, для добавления к {0}\r\n", findOperator);
                        sb.AppendFormat("Нажмине Нет для добавления к {0}\r\n", currentOperator);
                        string msg = sb.ToString();

                        DialogResult dr = MessageBox.Show(msg, "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (dr == DialogResult.Yes) {
                           currentOperator = findOperator;
                           SelectOperator(currentOperator);
                        }
                     }
                  }
               }
               bool ok = currentOperator.AddCorp(corp);
               if (ok) {
                  RebindCorp();
                  RebindUnknown();
               }
            }
         }
         p1 = Point.Empty;
      }

      /// <summary>
      /// Перемещаем элемент содержащий юр. лицо
      /// </summary>
      private void licActivitiesCtrl1_DragEnter(object sender, DragEventArgs e) {
         e.Effect = DragDropEffects.Move;
      }

      /// <summary>
      /// Нажали мышкой на юр. лице операторе
      /// </summary>
      private void listBoxCorp_MouseDown(object sender, MouseEventArgs e) {
         if (e.Button == MouseButtons.Left) {
            ListBoxControl lb = sender as ListBoxControl;
            p2 = new Point(e.X, e.Y);
            int idx = lb.IndexFromPoint(p2);
            if (idx < 0)
               p2 = Point.Empty;
         }
      }

      /// <summary>
      /// Перемещаем мышку с нажатой левой клавишей (тащим юр. лицо оператора)
      /// </summary>
      private void listBoxCorp_MouseMove(object sender, MouseEventArgs e) {
         if (e.Button == MouseButtons.Left) {
            if (p2 != Point.Empty && bindingCorps.Count > 0) {
               if ((Math.Abs(e.X - p2.X) > 5) || (Math.Abs(e.Y - p2.Y) > 5)) {
                  ListBoxControl lb = sender as ListBoxControl;
                  lb.DoDragDrop(sender, DragDropEffects.Move);
               }
            }
         }
      }

      /// <summary>
      /// Тащим  элемент из списка юр. лиц оператора
      /// </summary>
      private void listBoxUnknown_DragEnter(object sender, DragEventArgs e) {
         e.Effect = DragDropEffects.Move;
      }

      /// <summary>
      /// Перемещаем элемент содержащий юр. лицо
      /// </summary>
      private void listBoxUnknown_DragDrop(object sender, DragEventArgs e) {
         if (p2 != Point.Empty && bindingCorps.Current != null) {
            int index = listBoxCorp.IndexFromPoint(p2);
            Corporation corp = bindingCorps[index] as Corporation;
            if (corp != null && unknownOperator != null) {
               BaseOperatorInfo currentOperator = repo.FindOperator(corp);
               if (currentOperator != null) {
                  bool ok = currentOperator.DeleteCorp(corp);
                  if (ok && currentOperator.Corporations.Count == 0) {
                     DeleteOperator(currentOperator);
                  }

                  unknownOperator.AddCorp(corp);
                  RebindCorp();
                  RebindUnknown();
               }
            }
         }
      }

      /// <summary>
      /// Закрылось всплывающее меню
      /// </summary>
      private void popupMenu1_CloseUp(object sender, EventArgs e) {
         p1 = Point.Empty;
         p2 = Point.Empty;
      }

      /// <summary>
      /// Всплывающее меню | Копировать
      /// </summary>
      private void popupCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
         Corporation corp = null;
         if (p1 != Point.Empty) {
            int index = listBoxUnknown.IndexFromPoint(p1);
            corp = bindingUnknown[index] as Corporation;
         }
         if (p2 != Point.Empty) {
            int index = listBoxCorp.IndexFromPoint(p2);
            corp = bindingCorps[index] as Corporation;
         }
         Clipboard.SetText(corp.CorporateName);
      }

      private void listBoxCorp_SelectedIndexChanged(object sender, EventArgs e) {
         Corporation corp = listBoxCorp.SelectedValue as Corporation;
         if (corp != null) {
            licActivitiesCtrl1.Corp = corp;
         }
      }
      #endregion
   }
}
