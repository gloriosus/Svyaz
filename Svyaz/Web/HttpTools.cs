using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Net;
using Microsoft.Win32;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Globalization;

namespace Util {
   /// <summary>
   /// Набор методов для работы с контентом Internet
   /// </summary>
   public static class HttpTools {
      /// <summary>
      /// Записать результат HttpResponse в файл по заданному пути с указанным именем
      /// </summary>
      public static void SaveToFile(string txt, string fname, Encoding enc) {
         if (File.Exists(fname))
            File.Delete(fname);
         File.WriteAllText(fname, txt, enc);
      }

      /// <summary>
      /// Прочитать текстовый файл
      /// </summary>
      public static string LoadFile(string filename, Encoding enc) {
         string text = "";
         FileStream fs = new FileStream(filename, FileMode.Open);
         using (StreamReader reader = new StreamReader(fs, enc)) {
            text = reader.ReadToEnd();
         }
         return text;
      }

      /// <summary>
      /// Вернуть место положение файла hosts
      /// </summary>
      /// <returns></returns>
      public static string getHostsPath() {
         string hostsPath = "";
         RegistryKey hklm = Registry.LocalMachine;
         RegistryKey tcpipParameters = hklm.OpenSubKey(@"System\CurrentControlSet\Services\Tcpip\Parameters");
         hostsPath = tcpipParameters.GetValue("DataBasePath").ToString();
         ;
         return hostsPath;
      }

      /// <summary>
      /// Выполнить очистку кэша DNS 
      /// </summary>
      public static void flushDns() {
         string path = Environment.SystemDirectory + "\\ipconfig.exe";
         Process p = new Process();
         p.StartInfo.FileName = path;
         p.StartInfo.Arguments = "/flushdns";
         p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
         p.Start();
      }

      /// <summary>
      /// Преобразовать строку в массив байтов
      /// </summary>
      public static byte[] StrToByteArray(string str) {
         System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
         return encoding.GetBytes(str);
      }

      /// <summary>
      /// Перобразовать строку Unicode в строку utf8
      /// </summary>
      /// <param name="strUnicode">текст вида "\\u043E\\u043A\\u043D\\u043E"</param>
      public static string StrUnicodeToString(string strUnicode) {
         string inputStr = strUnicode.Replace("\\r", "\r");
         inputStr = inputStr.Replace("\\n", "\n");
         inputStr = inputStr.Replace("\\t", "\t");
         string[] letters = inputStr.Split(new string[] { "\\u" }, StringSplitOptions.RemoveEmptyEntries);
         StringBuilder sb = new StringBuilder();
         for (int i = 0; i < letters.Length; i++) {
            // разбор ситуации "\\u043E (BMP) "
            try {
               string letter = letters[i].Substring(0, 4);
               string another = letters[i].Substring(4);
               int utf32 = Int32.Parse(letter, NumberStyles.HexNumber);
               sb.Append(char.ConvertFromUtf32(utf32));
               sb.Append(another);
            } catch (FormatException c) {
               sb.Append(letters[i]);
            }
         }
         string result = sb.ToString();
         return result;
      }

      /// <summary>
      /// Очистить кэш IExlplore
      /// </summary>
      public static void clearIECache() {
         string ieCasheDir = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
         DirectoryInfo ieCasheDirInfo = new DirectoryInfo(ieCasheDir);
         ClearFolder(ieCasheDirInfo);
      }

      /// <summary>
      /// Очистить папку
      /// </summary>
      private static void ClearFolder(DirectoryInfo folder) {
         foreach (FileInfo file in folder.GetFiles()) {
            try {
               file.Delete();
            } catch (IOException ex) {
               Debug.WriteLine(ex.ToString());    // Не можем удалить используемый файл
            } catch (UnauthorizedAccessException ex) {
               Debug.WriteLine(ex.ToString());    // Не хватает прав для удаления файла
            }
         }
         foreach (DirectoryInfo subfolder in folder.GetDirectories()) {
            ClearFolder(subfolder);
         }
      }

      /// <summary>
      ///  Создать http запрос GET
      /// </summary>
      public static HttpWebRequest CreateHttpWebRequestGET(string host, CookieContainer cookies) {
         HttpWebRequest httpRequest = null;
         try {
            httpRequest = (HttpWebRequest)HttpWebRequest.Create(host);
            httpRequest.Method = "GET";
            httpRequest.AllowAutoRedirect = true;
            httpRequest.KeepAlive = true;
            httpRequest.Accept = @"text/html, application/xhtml+xml, */*";
            httpRequest.UserAgent = @" Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
            httpRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            httpRequest.Headers.Add("Accept-Language", "ru-RU");
            httpRequest.CookieContainer = cookies;
         } catch (UriFormatException ex) {
            Tools.WriteLog("Ошибка выполнения HttpTools.CreateHttpWebRequestGET");
            Tools.WriteLog(ex.Message);
         }
         return httpRequest;
      }

      /// <summary>
      ///  Создать http запрос GET
      /// </summary>
      public static HttpWebRequest CreateHttpWebRequestGET(string host, string referer, CookieContainer cookies) {
         HttpWebRequest httpRequest = null;
         try {
            httpRequest = (HttpWebRequest)HttpWebRequest.Create(host);
            httpRequest.Method = "GET";
            httpRequest.AllowAutoRedirect = true;
            httpRequest.Referer = referer;
            httpRequest.KeepAlive = true;
            httpRequest.Accept = @"text/html, application/xhtml+xml, */*";
            httpRequest.UserAgent = @" Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
            httpRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            httpRequest.Headers.Add("Accept-Language", "ru-RU");
            httpRequest.CookieContainer = cookies;
         } catch (UriFormatException ex) {
            Tools.WriteLog("Ошибка выполнения HttpTools.CreateHttpWebRequestGET");
            Tools.WriteLog(ex.Message);
         }
         return httpRequest;
      }

      /// <summary>
      ///  Создать http запрос PUT
      /// </summary>
      public static HttpWebRequest CreateHttpWebRequestPOST(string host, CookieContainer cookies) {
         HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(host);
         httpRequest.Method = "POST";
         httpRequest.ServicePoint.Expect100Continue = false;
         httpRequest.Accept = "*/*";
         httpRequest.AllowAutoRedirect = true;
         httpRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; InfoPath.2)";
         httpRequest.ContentType = "application/x-www-form-urlencoded";
         httpRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
         httpRequest.Headers.Add("Pragma", "no-cache");
         httpRequest.Headers.Add("Accept-Language", "ru-RU");
         httpRequest.KeepAlive = true;
         httpRequest.CookieContainer = cookies;
         return httpRequest;
      }

      /// <summary>
      /// Добавить к Post'у запрос
      /// </summary>
      public static void CreateHttpWebRequestPOST2(HttpWebRequest httpRequest, string query) {
         byte[] byteContent = Encoding.UTF8.GetBytes(query);
         httpRequest.ContentLength = byteContent.Length;
         Stream writer = httpRequest.GetRequestStream();
         writer.Write(byteContent, 0, byteContent.Length);
      }

      /// <summary>
      /// Вернуть результат ответа в виде текста
      /// </summary>
      public static string getResponseTxt(HttpWebResponse httpResponse, Encoding enc) {
         if (httpResponse == null)
            return "";
         if (enc == null)
            return "";
         StreamReader reader = null;
         string acceptEncoding = httpResponse.ContentEncoding;
         //acceptEncoding = httpResponse.ContentType;
         if (IsGzip(acceptEncoding)) {
            Stream responseStream = httpResponse.GetResponseStream();
            responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
            reader = new StreamReader(responseStream, enc);
         } else
            reader = new StreamReader(httpResponse.GetResponseStream(), enc);
         string txt = "";
         try {
            txt = reader.ReadToEnd();
         } catch (IOException ex) {
            Tools.WriteLog("Ошибка выполнения HttpTools.getResponseTxt");
            Tools.WriteLog(ex.Message);
         } finally {
            reader.Close();
         }
         return txt;
      }

      /// <summary>
      /// Определить кодировку html (по умолчанию Win1251);
      /// </summary>
      public static Encoding GetEncoding(HttpWebResponse httpResponse) {
         Encoding enc = Encoding.Default;
         try {
            enc = Encoding.GetEncoding(httpResponse.CharacterSet);
         } catch (ArgumentException ex) {
            Tools.WriteLog("Ошибка выполнения HttpTools.GetEncoding");
            Tools.WriteLog(ex.Message);
            enc = null;
         }
         return enc;
      }

      /// <summary>
      /// Выполнить синхронный запрос к веб серверу
      /// </summary>
      /// <param name="host">URL</param>
      /// <param name="proxy">Прокси</param>
      /// <param name="cookies">куки</param>
      /// <returns>html</returns>
      public static string RequestGetHtml(ref string host, WebProxy proxy, CookieContainer cookies) {
         HttpWebRequest httpRequest = HttpTools.CreateHttpWebRequestGET(host, cookies);  // создали запрос
         string html = "";
         if (httpRequest == null)
            return html;
         if (proxy != null)
            httpRequest.Proxy = proxy;
         HttpWebResponse httpResponse = null;
         try {
            httpResponse = (HttpWebResponse)httpRequest.GetResponse();
         } catch (WebException ex) {
            HttpWebResponse response = ex.Response as HttpWebResponse;
            string r = HttpTools.getResponseTxt(response, Encoding.UTF8);
            Tools.WriteLog(ex.Message);
            return html;
         }
         if (httpResponse != null) {
            using (httpResponse) {
               // Определить кодировку
               Encoding enc = HttpTools.GetEncoding(httpResponse);
               if (enc == null)
                  enc = Encoding.UTF8;
               // Вернуть результат в виде текста
               html = HttpTools.getResponseTxt(httpResponse, enc);
            }
         }
         return html;
      }

      /// <summary>
      /// Выполнить синхронный запрос к веб серверу
      /// </summary>
      /// <param name="host">URL</param>
      /// <param name="cookies">куки</param>
      /// <returns>html</returns>
      public static string RequestGetHtml(ref string host, CookieContainer cookies) {
         HttpWebRequest httpRequest = HttpTools.CreateHttpWebRequestGET(host, cookies);  // создали запрос
         string html = "";
         if (httpRequest == null)
            return html;
         HttpWebResponse httpResponse = null;
         try {
            httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            host = httpResponse.ResponseUri.AbsoluteUri;
         } catch (WebException ex) {
            string msg = string.Format("Ошибка выполнения HttpTools.RequestGetHtml host = \"{0}\"", host);
            Tools.WriteLog(msg);
            Tools.WriteLog(ex.Message);
            return html;
         }

         if (httpResponse != null) {
            using (httpResponse) {
               // Определить кодировку
               Encoding enc = HttpTools.GetEncoding(httpResponse);
               enc = null;
               if (enc == null) {
                  enc = Encoding.UTF8;
               }
               // Вернуть результат в виде текста
               html = HttpTools.getResponseTxt(httpResponse, enc);
            }
         }
         return html;
      }

      /// <summary>
      /// Выполнить Ajax запрос
      /// </summary>
      public static string RequestGetAjax(string host, string referer, CookieContainer cookies) {
         HttpWebRequest httpRequest = HttpTools.CreateHttpWebRequestGET(host, referer, cookies);  // создали запрос
         string html = "";
         if (httpRequest == null)
            return html;
         httpRequest.Headers.Add("X-Requested-With", "XMLHttpRequest");
         HttpWebResponse httpResponse = null;
         try {
            httpResponse = (HttpWebResponse)httpRequest.GetResponse();
         } catch (WebException ex) {
            string msg = string.Format("Ошибка выполнения HttpTools.RequestGetHtml host = \"{0}\"", host);
            Tools.WriteLog(msg);
            Tools.WriteLog(ex.Message);
            return html;
         }

         if (httpResponse != null) {
            using (httpResponse) {
               // Определить кодировку
               Encoding enc = HttpTools.GetEncoding(httpResponse);
               enc = null;
               if (enc == null) {
                  enc = Encoding.UTF8;
               }
               // Вернуть результат в виде текста
               html = HttpTools.getResponseTxt(httpResponse, enc);
            }
         }
         return html;
      }

      /// <summary>
      /// Выполнить синхронный запрос к веб серверу
      /// </summary>
      /// <param name="host">URL</param>
      /// <param name="cookies">куки</param>
      /// <returns>html</returns>
      public static string RequestGetHtml(string host, string referer, CookieContainer cookies) {
         HttpWebRequest httpRequest = HttpTools.CreateHttpWebRequestGET(host, referer, cookies);  // создали запрос
         string html = "";
         if (httpRequest == null)
            return html;
         HttpWebResponse httpResponse = null;
         try {
            httpResponse = (HttpWebResponse)httpRequest.GetResponse();
         } catch (WebException ex) {
            string msg = string.Format("Ошибка выполнения HttpTools.RequestGetHtml host = \"{0}\"", host);
            Tools.WriteLog(msg);
            Tools.WriteLog(ex.Message);
            return html;
         }

         if (httpResponse != null) {
            using (httpResponse) {
               // Определить кодировку
               Encoding enc = HttpTools.GetEncoding(httpResponse);
               enc = null;
               if (enc == null) {
                  enc = Encoding.UTF8;
               }
               // Вернуть результат в виде текста
               html = HttpTools.getResponseTxt(httpResponse, enc);
            }
         }
         return html;
      }

      /// <summary>
      /// Проверить, наличие признака сжатия контента
      /// </summary>
      private static bool IsGzip(string acceptEncoding) {
         if (acceptEncoding.ToLower().IndexOf("gzip") >= 0)
            return true;
         return false;
      }

   }
}
