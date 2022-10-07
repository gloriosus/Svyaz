using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraEditors.Controls;
using Svyaz.Data;
using DevExpress.Compression;

namespace Svyaz {
   public partial class CreateBackupForm : DevExpress.XtraEditors.XtraForm {
      #region Fields
      private string dataDir;    // каталог размещения файлов данных в формате json
      #endregion

      #region Properties
      /// <summary>
      /// 
      /// </summary>
      public string BackupFileName { get; set; }

      /// <summary>
      /// Описание архива
      /// </summary>
      public string BackupDescr {
         get { return textEdit1.Text; }
         set { textEdit1.Text = value; }
      }

      /// <summary>
      /// Путь к каталогу хранения резервных копий
      /// </summary>
      public string BackupPath {
         get { return btnEdit1.Text; }
         set { btnEdit1.Text = value; }
      }
      #endregion

      #region Ctors
      public CreateBackupForm() {
         InitializeComponent();
         dataDir = Path.Combine(Application.StartupPath, "Data");
      }
      #endregion

      #region Methods
      /// <summary>
      /// Загрузить для выбора список данных в формате json
      /// </summary>
      private void LoadListData() {
         DirectoryInfo dirInfo = new DirectoryInfo(dataDir);
         FileInfo[] files = dirInfo.GetFiles("*.json");
         foreach (FileInfo fi in files) {
            int idx = listBoxDataFiles.Items.Add(fi);
         }
         listBoxDataFiles.CheckAll();
      }

      /// <summary>
      /// Отобразить описание файла данных
      /// </summary>
      /// <param name="fi">информация о файле данных</param>
      private void ShowDataDescription(FileInfo fi) {
         string fileName = fi.FullName;
         fileName = Path.GetFileNameWithoutExtension(fileName);
         Repository repo = Repository.GetRepository();
         string descr = repo.GetDataFileDescription(fileName);
         labelDescr.Text = descr;
      }

      /// <summary>
      /// Выполнить резервное копирование
      /// </summary>
      /// <param name="backupFiles">Список файлов включенных в резервную копию</param>
      /// <param name="path">Каталог для размещения резервной копии</param>
      private void Backup(List<FileInfo> backupFiles) {
         using (ZipArchive zip = new ZipArchive()) {
            foreach (FileInfo fi in backupFiles) {
               zip.AddFile(fi.FullName, "/");
            }
            zip.AddText("description", BackupDescr, Encoding.UTF8);
            string nowStr = DateTime.Now.ToString();
            nowStr = nowStr.Replace(".", "");
            nowStr = nowStr.Replace(" ", "_");
            nowStr = nowStr.Replace(":", "");
            string zipName = string.Format("{0}\\SvyazBackup_{1}.zip", BackupPath, nowStr);
            zip.Save(zipName);
         }
      }
      #endregion

      #region Events
      /// <summary>
      /// Загрузка формы
      /// </summary>
      private void CreateBackupForm_Load(object sender, EventArgs e) {
         BackupPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.None);
         BackupDescr = string.Format("Полное резервное копирование выполненное {0}", DateTime.Now);
         LoadListData();
      }

      /// <summary>
      /// перешли на новую строчку в списке файлов данных
      /// </summary>
      private void listBoxDataFiles_SelectedIndexChanged(object sender, EventArgs e) {
         var item = listBoxDataFiles.SelectedItem as CheckedListBoxItem;
         var fi = item.Value as FileInfo;
         if (fi != null)
            ShowDataDescription(fi);
      }

      /// <summary>
      /// Нажали кнопку для выбора каталога хранения резервной копии
      /// </summary>
      private void btnEditBackupDir_ButtonPressed(object sender, ButtonPressedEventArgs e) {
         FolderBrowserDialog fbd = new FolderBrowserDialog();
         fbd.ShowNewFolderButton = true;
         fbd.SelectedPath = BackupPath;
         fbd.Description = "Каталог размещения резервной копии данных";

         DialogResult dr = fbd.ShowDialog(this);
         if (dr == DialogResult.OK) {
            BackupPath = fbd.SelectedPath;
         }
      }

      /// <summary>
      /// Нажали кнопку "Сохранить"
      /// </summary>
      private void btnOK_Click(object sender, EventArgs e) {
         List<FileInfo> backupFiles = new List<FileInfo>();
         foreach (int idx in listBoxDataFiles.CheckedIndices) {
            var item = listBoxDataFiles.Items[idx] as CheckedListBoxItem;
            var fi = item.Value as FileInfo;
            backupFiles.Add(fi);
         }
         Backup(backupFiles);

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      /// <summary>
      /// Нажали кнопку "Отмена"
      /// </summary>
      private void btnCancel_Click(object sender, EventArgs e) {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }
      #endregion

   }
}