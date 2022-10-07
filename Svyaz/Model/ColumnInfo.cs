using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Svyaz.Model {
   /// <summary>
   /// Информация о колонке в gridView свода
   /// </summary>
   public class ColumnInfo {
      #region Properties
      /// <summary>
      /// Код родительской колонки
      /// </summary>
      public int ParentID { get; set; }

      /// <summary>
      /// Код колонки
      /// </summary>
      public int ID { get; set; }

      /// <summary>
      /// Наименование (заголовок)
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// имя свойства из CommunicationService
      /// </summary>
      public string Property { get; set; }

      /// <summary>
      /// индекс для отображения в дереве
      /// </summary>
      public int ImageIndex { get; set; }

      /// <summary>
      /// Колонка будет отображена в дереве
      /// </summary>
      public bool IsTreeColumn { get; set; }

      public int VisibleIndex { get; set; }

      /// <summary>
      /// Ширина колонки в GridView
      /// </summary>
      public int GridColumnWidth { get; set; }
      #endregion

      #region Ctors
      public ColumnInfo() {
         IsTreeColumn = true;
         GridColumnWidth = 100;
      }

      public ColumnInfo(string colName, string propName):this() {
         Name = colName;
         Property = propName;
      }

      public ColumnInfo(int imageIdx, int id, int parentId, string name, string property): this() {
         ImageIndex = imageIdx;
         ID = id;
         ParentID = parentId;
         Name = name;
         Property = property;
      }
      #endregion

      #region Methods
      public override string ToString() {
         return Name;
      }

      /// <summary>
      /// Перепаковать список операторов  в формат ColumnInfo
      /// </summary>
      public static List<ColumnInfo> CreateList(List<string> src, string preffix = "") {
         List<ColumnInfo> dst = new List<ColumnInfo>();
         foreach (string prop in src) {
            dst.Add(new ColumnInfo(prop, preffix+prop));
         }
         return dst;
      }

      /// <summary>
      /// Получить объект вида деятельности
      /// </summary>
      /// <returns></returns>
      public LicensedActivity GetActivity() {
         LicensedActivity activity = new LicensedActivity(ID, ParentID, Name, Property);
         return activity;
      }
      #endregion
   }
}
