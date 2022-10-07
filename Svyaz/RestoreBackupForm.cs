using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.Compression;
using System.IO;
using Svyaz.Data;

namespace Svyaz {
   public partial class RestoreBackupForm : DevExpress.XtraEditors.XtraForm {
      #region Fields
      private string dataDir;    // каталог размещения файлов данных в формате json
      #endregion

      #region Properties
      /// <summary>
      /// Резервная копия
      /// </summary>
      public string BackupPath {
         get { return btnEdit1.Text; }
         set { btnEdit1.Text = value; }
      }

      /// <summary>
      /// Описание архива
      /// </summary>
      public string BackupDescr {
         get { return textEdit1.Text; }
         set { textEdit1.Text = value; }
      }

      /// <summary>
      /// Признак полной замены всех файлов в каталоге данных
      /// </summary>
      public bool IsFullRestore {
         get { return (bool)toggleSwitch1.EditValue; }
      }
      #endregion

      #region ctors
      public RestoreBackupForm() {
         InitializeComponent();
         dataDir = Path.Combine(Application.StartupPath, "Data");
      }
      #endregion

      #region Methods
      /// <summary>
      /// Удалить все сществующие файлы данных
      /// </summary>
      private void ClearExistDataFiles() {
         DirectoryInfo dir = new DirectoryInfo(dataDir);
         FileInfo[] files = dir.GetFiles("*.json");
         for (int i = 0; i < files.Length; i++) {
            string file = files[i].FullName;
            File.Delete(file);
         }
      }

      /// <summary>
      /// Восстановить данные
      /// </summary>
      /// <param name="backupFiles">список файлов для восстановления</param>
      private void Restore(List<string> backupFiles) {
         if (IsFullRestore) {    // если вкл. режим полной замены 
            ClearExistDataFiles();
         }
         using (ZipArchive zip = ZipArchive.Read(BackupPath)) {
            foreach (ZipItem item in zip) {
               if (backupFiles.SingleOrDefault(i => i == item.Name) != null) {
                  item.Extract(dataDir, AllowFileOverwriteMode.Allow);
               }
            }
         }
      }

      /// <summary>
      /// Прочитать содержимое резервной копии
      /// </summary>
      /// <param name="backupFileName">имя архива для восстановления</param>
      private void RestoreBackupInfo() {
         using (ZipArchive zip = ZipArchive.Read(BackupPath)) {
            listBoxZipData.Items.Clear();
            foreach (ZipItem item in zip) {
               if (item.Name == "description") {
                  MemoryStream stream = new MemoryStream();
                  item.Extract(stream);
                  stream.Position = 0;
                  StreamReader reader = new StreamReader(stream);
                  string descr = reader.ReadToEnd();
                  BackupDescr = descr;
                  reader.Close();
                  stream.Close();
                  continue;
               }
               listBoxZipData.Items.Add(item.Name);
            }
         }
         listBoxZipData.CheckAll();
      }

      /// <summary>
      /// Отобразить описание файла данных
      /// </summary>
      /// <param name="fi">информация о файле данных</param>
      private void ShowDataDescription(string fi) {
         string fileName = Path.GetFileNameWithoutExtension(fi);
         Repository repo = Repository.GetRepository();
         string descr = repo.GetDataFileDescription(fileName);
         labelDescr.Text = descr;
      }
      #endregion

      #region Events
      /// <summary>
      /// Форма загружается
      /// </summary>
      private void RestoreBackupForm_Load(object sender, EventArgs e) {
         string lastRestoredBackup = Svyaz.Properties.Settings.Default.LastRestoredBackup;
         if (lastRestoredBackup.Length > 0) {
            if (File.Exists(lastRestoredBackup)) {
               BackupPath = lastRestoredBackup;
               RestoreBackupInfo();
            }
         }
      }

      /// <summary>
      /// перешли на новую строчку в списке файлов данных
      /// </summary>
      private void checkedListBoxControl1_SelectedIndexChanged(object sender, EventArgs e) {
         var item = listBoxZipData.SelectedItem as CheckedListBoxItem;
         if (item != null) {
            var fi = item.Value as string;
            if (fi != null)
               ShowDataDescription(fi);
         }
      }

      /// <summary>
      /// Выбрать резервную копиюю
      /// </summary>
      private void btnEdit1_ButtonPressed(object sender, ButtonPressedEventArgs e) {
         OpenFileDialog ofd = new OpenFileDialog();
         ofd.Title = "Выбрать резервную копию";
         ofd.Filter = "Архивы резеврных копий (*.zip)|*.zip|Все файлы (*.*)|*.*";
         ofd.Multiselect = false;

         DialogResult dr = ofd.ShowDialog(this);
         if (dr == DialogResult.OK) {
            BackupPath = ofd.FileName;
            RestoreBackupInfo();
         }
      }

      /// <summary>
      /// Нажали кнопку "Восстановить"
      /// </summary>
      private void btnOK_Click(object sender, EventArgs e) {
         List<string> backupFiles = new List<string>();
         foreach (int idx in listBoxZipData.CheckedIndices) {
            var item = listBoxZipData.Items[idx] as CheckedListBoxItem;
            var fi = item.Value as string;
            backupFiles.Add(fi);
         }
         Restore(backupFiles);
         Properties.Settings.Default.LastRestoredBackup = BackupPath;
         Properties.Settings.Default.Save();

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      /// <summary>
      /// Нажали кнопку "Отмена"
      /// </summary>
      private void btnCancel_Click(object sender, EventArgs e) {
         Properties.Settings.Default.LastRestoredBackup = BackupPath;
         Properties.Settings.Default.Save();

         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }
      #endregion
   }
}