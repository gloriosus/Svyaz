using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace Svyaz {
   static class Program {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main() {
         string filename = "Parser.log";
         if (File.Exists(filename))
            File.Delete(filename);
         int listenerId = Trace.Listeners.Add(new TextWriterTraceListener(filename));
         Trace.AutoFlush = true;


         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         DevExpress.Skins.SkinManager.EnableFormSkins();
         DevExpress.UserSkins.BonusSkins.Register();
         UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

         Application.Run(new Form1());
      }


      /// <summary>
      /// Записать сообщение в лог
      /// </summary>
      internal static void WriteLog(string Msg) {
         DateTime now = DateTime.Now;
         string txt = string.Format("{0} {1}", now, Msg);
         //Trace.WriteLine(txt);
      }
   }
}