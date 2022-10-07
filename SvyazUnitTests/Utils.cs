using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SvyazUnitTests {
   /// <summary>
   /// Полезные вспомогательные утилиты
   /// </summary>
   public static class Utils {

      public static string DataCatalog {
         get { return Path.Combine(Environment.CurrentDirectory, "Data\\"); }
      }

      /// <summary>
      /// Сохранить коллекцию на диск
      /// </summary>
      public static void SerializeCollection<T>(List<T> collection, string path) {
         string json = JsonConvert.SerializeObject(collection, Formatting.Indented);
         File.WriteAllText(path, json);
      }

      /// <summary>
      /// Сохранить hashset на диск
      /// </summary>
      public static void SerializeHashSet<T>(HashSet<T> collection, string path) {
         string json = JsonConvert.SerializeObject(collection, Formatting.Indented);
         File.WriteAllText(path, json);
      }

      /// <summary>
      /// Загрузить коллекцию с диска
      /// </summary>
      public static List<T> DeserializeCollection<T>(string path) {
         List<T> collection = new List<T>();
         if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            collection = JsonConvert.DeserializeObject<List<T>>(json);
         }
         return collection;
      }

      /// <summary>
      /// Загрузить коллекцию с диска
      /// </summary>
      public static HashSet<T> DeserializeHashSet<T>(string path) {
         HashSet<T> collection = new HashSet<T>();
         if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            collection = JsonConvert.DeserializeObject<HashSet<T>>(json);
         }
         return collection;
      }

      /// <summary>
      /// Список юр. лиц без дублей
      /// </summary>
      public static List<Corporation> CreateCorporations() {
         List<Corporation> corps = new List<Corporation>();
         corps.Add(new Corporation("ПАО Мегафон"));
         corps.Add(new Corporation("ЗАО Мегафон"));
         corps.Add(new Corporation("АО Мегафон"));
         corps.Add(new Corporation("ПАО Ростелеком"));
         corps.Add(new Corporation("ОАО Ростелеком"));
         corps.Add(new Corporation("АО Ростелеком"));

         return corps;
      }

      /// <summary>
      /// Создать список юр. лиц с дублями
      /// </summary>
      public static List<Corporation> CreateCorporationsWithDoubles() {
         List<Corporation> corps = new List<Corporation>();
         corps.Add(new Corporation("ПАО Мегафон"));
         corps.Add(new Corporation("ЗАО Мегафон"));
         corps.Add(new Corporation("АО Мегафон"));

         corps.Add(new Corporation("ПАО Мегафон"));
         corps.Add(new Corporation("ПАО Мегафон"));
         corps.Add(new Corporation("АО Мегафон"));

         return corps;
      }
   }
}
