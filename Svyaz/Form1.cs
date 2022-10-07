using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using Svyaz.Data;
using Svyaz.Model;
using Svyaz.Web;
using System.IO;


namespace Svyaz {
   public partial class Form1 : DevExpress.XtraBars.TabForm {
      #region Ctors
      public Form1() {
         InitializeComponent();

         // Отобразить в заголовке окна инф. о версии программы
         string title = string.Format("Связь ЕАО ver. {0}", Application.ProductVersion);
         this.Text = title;

         InitBarMenu();
      }
      #endregion

      #region Methods
      /// <summary>
      /// Иницилизировать меню со списком откытых закладок
      /// </summary>
      private void InitBarMenu() {
         int count = tabFormControl1.Pages.Count;
         for (int i = 0; i < count; i++) {
            RemoveBarButton(tabFormControl1.Pages[i]);
         }

         foreach (TabFormPage page in tabFormControl1.Pages) {
            AddBarButton(page);
         }
      }

      /// <summary>
      /// Добавить элемент в меню открытых закладок
      /// </summary>
      private void AddBarButton(TabFormPage page) {
         BarButtonItem barButton = tabFormDefaultManager1.Items.CreateButton(page.Text);
         if (string.IsNullOrEmpty(page.Name))
            page.Name = Guid.NewGuid().ToString();
         barButton.Name = page.Name;
         barButton.Caption = page.Text;
         barButton.Tag = page;
         barButton.ItemClick += barButton_ItemClick;
         barPagesMenu.AddItem(barButton);
         page.Disposed += Page_Disposed;
      }

      /// <summary>
      /// Удалить элемент из меню открытых закладок
      /// </summary>
      private void RemoveBarButton(TabFormPage page) {
         if (page.Name != null) {
            BarItem baritem = tabFormDefaultManager1.Items[page.Name];
            if (baritem != null && barPagesMenu.ItemLinks.Count > 0) {
               barPagesMenu.ItemLinks.Remove(baritem.Links[0]);
               baritem.ItemClick -= barButton_ItemClick;
               tabFormDefaultManager1.Items.Remove(baritem);
            }
         }
      }

      /// <summary>
      /// Добавить закладку
      /// </summary>
      /// <param name="ctrl">контент</param>
      /// <param name="title">заголовок</param>
      private TabFormPage AddTabFormPage(Control ctrl, string title) {
         TabFormPage page = FindTabFormPage(title);
         if (page == null) {
            page = new TabFormPage();
            page.Name = title;
            page.Text = title;
            page.ContentContainer = ctrl;
            tabFormControl1.Pages.Add(page);
         }
         tabFormControl1.SelectedPage = page;
         return page;
      }

      /// <summary>
      /// Найти закладку по ее заголовку
      /// </summary>
      private TabFormPage FindTabFormPage(string title) {
         TabFormPage page = (from p in tabFormControl1.Pages
                             where p.Text == title
                             select p).SingleOrDefault();
         return page;
      }
      #endregion

      #region Events
      /// <summary>
      /// Загрузка формы
      /// </summary>
      private void Form1_Load(object sender, EventArgs e) {
         // Восстановить положение, размеры и состояние окна
         this.Location = Properties.Settings.Default.Location;
         this.Size = Properties.Settings.Default.Size;
         this.WindowState = Properties.Settings.Default.WindowState;
         
         // Загрузить выбранную обложку
         string skinName = Properties.Settings.Default.DefaultSkinName;
         if (!string.IsNullOrEmpty(skinName)) {
            UserLookAndFeel.Default.SkinName = skinName;
         }

         // Загрузка данных в репозиторий
         splashScreenManager1.ShowWaitForm();
         splashScreenManager1.SetWaitFormCaption("Загрузка данных");
         splashScreenManager1.SetWaitFormDescription("Подождите...");
         Application.DoEvents();
         Repository repo = Repository.GetRepository();
         LocalitiesViewCtrl ctrl1 = new LocalitiesViewCtrl();
         Application.DoEvents();
         BorroughtsCtrl ctrl2 = new BorroughtsCtrl();
         SettlermentsCtrl ctrl3 = new SettlermentsCtrl();
         LocalitiesCtrl ctrl4 = new LocalitiesCtrl();
         ColumnSelectorCtrl ctrl5 = new ColumnSelectorCtrl();
         ctrl1.Dispose();
         ctrl2.Dispose();
         ctrl3.Dispose();
         ctrl4.Dispose();
         ctrl5.Dispose();
         splashScreenManager1.CloseWaitForm(); 
      }

      /// <summary>
      /// Форма закрывается
      /// </summary>
      private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
         splashScreenManager1.ShowWaitForm();
         splashScreenManager1.SetWaitFormCaption("Сохранение данных");
         splashScreenManager1.SetWaitFormDescription("Подождите...");
         Application.DoEvents();

         //Сохранить состояние окна, положение, размеры
         Properties.Settings.Default.WindowState = this.WindowState;
         if (this.WindowState == FormWindowState.Normal) {
            Properties.Settings.Default.Location = this.Location;
            Properties.Settings.Default.Size = this.Size;
         }
         // сохранить выбранную обложку
         Properties.Settings.Default.DefaultSkinName = UserLookAndFeel.Default.SkinName;
         Properties.Settings.Default.Save();
         // Сохранить данные
         Repository repo = Repository.GetRepository();
         repo.SaveAll();
         splashScreenManager1.CloseWaitForm();
      }

      /// <summary>
      /// Страница создана
      /// </summary>
      private void tabFormControl1_PageCreated(object sender, PageCreatedEventArgs e) {
         //AddBarButton(e.Page);
      }

      /// <summary>
      /// Изменилась коллекция закладок
      /// </summary>
      private void tabFormControl1_PageCollectionChanged(object sender, EventArgs e) {
         InitBarMenu();
      }

      /// <summary>
      /// Страница уничтожена
      /// </summary>
      private void Page_Disposed(object sender, EventArgs e) {
         TabFormPage page = sender as TabFormPage;
         RemoveBarButton(page);
      }

      /// <summary>
      /// Нажали на элемент из меню открытых закладок
      /// </summary>
      private void barButton_ItemClick(object sender, ItemClickEventArgs e) {
         BarButtonItem barButton = e.Item as BarButtonItem;
         TabFormPage page = barButton.Tag as TabFormPage;
         tabFormControl1.SelectedPage = page;
      }

      /// <summary>
      /// Справочники|Районы
      /// </summary>
      private void barBtnRefBorroughts_ItemClick(object sender, ItemClickEventArgs e) {
         BorroughtsCtrl ctrl = new BorroughtsCtrl();
         TabFormPage page = AddTabFormPage(ctrl, "Районы");
      }

      /// <summary>
      /// Справочники|Поселения
      /// </summary>
      private void barBtnSettlements_ItemClick(object sender, ItemClickEventArgs e) {
         SettlermentsCtrl ctrl = new SettlermentsCtrl();
         TabFormPage page = AddTabFormPage(ctrl, "Поселения");
      }

      /// <summary>
      /// Справочники|Населенные пункты
      /// </summary>
      private void barBtnLocalities_ItemClick(object sender, ItemClickEventArgs e) {
         LocalitiesCtrl ctrl = new LocalitiesCtrl();
         TabFormPage page = AddTabFormPage(ctrl, "Нас. пункты");
      }

      /// <summary>
      /// Справочники|Лицензируемая деятельность
      /// </summary>
      private void barBtnLicActivities_ItemClick(object sender, ItemClickEventArgs e) {
         LicActivitiesCtrl ctrl = new LicActivitiesCtrl();
         TabFormPage page = AddTabFormPage(ctrl, "Лицензируемая деятельность");
      }

      /// <summary>
      /// Справочники|Операторы
      /// </summary>
      private void barBtnBrand_ItemClick(object sender, ItemClickEventArgs e) {
         OperatorsCtrl ctrl = new OperatorsCtrl();
         TabFormPage page = AddTabFormPage(ctrl, "Операторы");
      }

      /// <summary>
      /// Карта покрытия
      /// </summary>
      private void barBtnMap_ItemClick(object sender, ItemClickEventArgs e) {
         MapCtrl ctrl = new MapCtrl();
         TabFormPage page = AddTabFormPage(ctrl, "Карта покрытия");
      }

      /// <summary>
      /// Справочники|Свод
      /// </summary>
      private void barBtnLocalitiesView_ItemClick(object sender, ItemClickEventArgs e) {
         LocalitiesViewCtrl ctrl = new LocalitiesViewCtrl();
         TabFormPage page = AddTabFormPage(ctrl, "Свод");

      }

      /// <summary>
      /// Нажали кнопку "Настройки"
      /// </summary>
      private void barBtnSettings_ItemClick(object sender, ItemClickEventArgs e) {
         SettingsCtrl ctrl = new SettingsCtrl();
         TabFormPage page = AddTabFormPage(ctrl, "Настройки");
      }

      /// <summary>
      /// нажали кнопку "Сделать резервную копию данных"
      /// </summary>
      private void barBtnBackup_ItemClick(object sender, ItemClickEventArgs e) {
         CreateBackupForm backupDialog = new CreateBackupForm();
         DialogResult dr = backupDialog.ShowDialog(this);
         if (dr == DialogResult.OK) {
            MessageBox.Show("Резервное копирование данных завершено.");
         }
      }

      /// <summary>
      /// Нажали кнопку "Перезагрузить данные"
      /// </summary>
      private void barBtnReload_ItemClick(object sender, ItemClickEventArgs e) {
         Repository repo = Repository.GetRepository();
         repo.LoadData();

         foreach (TabFormPage page in tabFormControl1.Pages) {
            IReloadData reloadData = page.ContentContainer as IReloadData;
            if (reloadData != null) {
               reloadData.LoadData();
            }
         }
      }

      /// <summary>
      ///  нажали кнопку "Восстановить данные из резервной копии"
      /// </summary>
      private void barBtnRestore_ItemClick(object sender, ItemClickEventArgs e) {
         RestoreBackupForm backupDialog = new RestoreBackupForm();
         DialogResult dr = backupDialog.ShowDialog(this);
         if (dr == DialogResult.OK) {
            MessageBox.Show("Восстановлены данные из резервной копии.");
         }
      }
      #endregion
   }
}