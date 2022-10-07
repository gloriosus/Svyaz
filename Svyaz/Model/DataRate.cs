using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Svyaz.Model {
   /// <summary>
   /// Скорость передачи данных
   /// </summary>
   public class DataRate:IComparable<DataRate>, IComparable {
      #region Fields
      private static Dictionary<ModernDataRateUnit, decimal> bpsDic;    // словарь для пересчета скорости из bps (бит в секунду)
      private static Dictionary<ModernDataRateUnit, decimal> kbpsDic;   // словарь для пересчета скорости из kbps (килобит в секунду)
      private static Dictionary<ModernDataRateUnit, decimal> MbpsDic;   // словарь для пересчета скорости из Mbps (мегабит в секунду
      private static Dictionary<ModernDataRateUnit, decimal> GbpsDic;
      private static Dictionary<ModernDataRateUnit, decimal> TbpsDic;
      private decimal rateValue;       // скорость передачи данных в bps
      private ModernDataRateUnit unit; // ед. изм. скорости передачи данных 
      #endregion

      static DataRate() {
         bpsDic = new Dictionary<ModernDataRateUnit, decimal>();
         kbpsDic = new Dictionary<ModernDataRateUnit, decimal>();
         MbpsDic = new Dictionary<ModernDataRateUnit, decimal>();
         GbpsDic = new Dictionary<ModernDataRateUnit, decimal>();
         TbpsDic = new Dictionary<ModernDataRateUnit, decimal>();
         InitDic();
      }

      #region Properties
      /// <summary>
      /// Значение скорости передачи данных
      /// </summary>
      public decimal Rate { 
         get {
            decimal val = ConvertValue(rateValue, ModernDataRateUnit.bps, Unit);
            return val;
         }
         set { rateValue = ConvertValue(value, Unit, ModernDataRateUnit.bps); }
      }

      /// <summary>
      /// Единица измерения скорости передачи данных
      /// </summary>
      public ModernDataRateUnit Unit {
         get { return unit; }
         set {
            if (value != unit) {
               if (unit == ModernDataRateUnit.none) {
                  rateValue = ConvertValue(rateValue, value, ModernDataRateUnit.bps);
               }
            }
            unit = value;
         } 
      }
      #endregion

      public DataRate() {
         rateValue = 0m;
         unit = ModernDataRateUnit.none;
      }

      #region Methods
      private static void InitDic() {
         bpsDic.Add(ModernDataRateUnit.bps, 1m);
         bpsDic.Add(ModernDataRateUnit.kbps, 0.001m);
         bpsDic.Add(ModernDataRateUnit.Mbps, 0.000001m);
         bpsDic.Add(ModernDataRateUnit.Gbps, 0.000000001m);
         bpsDic.Add(ModernDataRateUnit.Tbps, 0.000000000001m);

         kbpsDic.Add(ModernDataRateUnit.bps, 1000m);
         kbpsDic.Add(ModernDataRateUnit.kbps, 1m);
         kbpsDic.Add(ModernDataRateUnit.Mbps, 0.001m);
         kbpsDic.Add(ModernDataRateUnit.Gbps, 0.000001m);
         kbpsDic.Add(ModernDataRateUnit.Tbps, 0.000000001m);

         MbpsDic.Add(ModernDataRateUnit.bps, 1000000m);
         MbpsDic.Add(ModernDataRateUnit.kbps, 1000m);
         MbpsDic.Add(ModernDataRateUnit.Mbps, 1m);
         MbpsDic.Add(ModernDataRateUnit.Gbps, 0.001m);
         MbpsDic.Add(ModernDataRateUnit.Tbps, 0.000001m);

         GbpsDic.Add(ModernDataRateUnit.bps, 1000000000m);
         GbpsDic.Add(ModernDataRateUnit.kbps, 1000000m);
         GbpsDic.Add(ModernDataRateUnit.Mbps, 1000m);
         GbpsDic.Add(ModernDataRateUnit.Gbps, 1m);
         GbpsDic.Add(ModernDataRateUnit.Tbps, 0.001m);

         TbpsDic.Add(ModernDataRateUnit.bps, 1000000000000m);
         TbpsDic.Add(ModernDataRateUnit.kbps, 1000000000m);
         TbpsDic.Add(ModernDataRateUnit.Mbps, 1000000m);
         TbpsDic.Add(ModernDataRateUnit.Gbps, 1000m);
         TbpsDic.Add(ModernDataRateUnit.Tbps, 1m);
      }

      /// <summary>
      /// Предстваить в виде строки
      /// </summary>
      public override string ToString() {
         string unitStr = UnitToString(Unit);
         string str = string.Format("{0:F} {1}", Rate, unitStr);
         return str;
      }

      public override bool Equals(object obj) {
         if (obj == null)
            return false;
         DataRate other = obj as DataRate;
         if (other == null)
            return false;
         return this.rateValue.Equals(other.rateValue);
      }

      /// <summary>
      /// Пересчитать значение скорости
      /// </summary>
      /// <param name="existValue">текущее значение скорости передачи данных</param>
      /// <param name="existUnit">текущее значение единицы измерения</param>
      /// <param name="newUnit">новое значение диницы измерения</param>
      /// <returns></returns>
      public static decimal ConvertValue(decimal existValue, ModernDataRateUnit existUnit, ModernDataRateUnit newUnit) {
         decimal newValue = existValue;

         if (existUnit != ModernDataRateUnit.none && newUnit != ModernDataRateUnit.none) {
            if (existUnit == ModernDataRateUnit.bps) {
               newValue *= bpsDic[newUnit];
            }
            if (existUnit == ModernDataRateUnit.kbps) {
               newValue *= kbpsDic[newUnit];
            }
            if (existUnit == ModernDataRateUnit.Mbps) {
               newValue *= MbpsDic[newUnit];
            }
            if (existUnit == ModernDataRateUnit.Gbps) {
               newValue *= GbpsDic[newUnit];
            }
            if (existUnit == ModernDataRateUnit.Tbps) {
               newValue *= TbpsDic[newUnit];
            }
         }

         return newValue;
      }

      /// <summary>
      /// Привести ед. измерения скорости передачи данных в строковый вид.
      /// </summary>
      private static string UnitToString(ModernDataRateUnit unit) {
         switch (unit) {
            case ModernDataRateUnit.bps:
               return "б/с";
            case ModernDataRateUnit.kbps:
               return "Кб/с";
            case ModernDataRateUnit.Mbps:
               return "Мб/с";
            case ModernDataRateUnit.Gbps:
               return "Гб/с";
            case ModernDataRateUnit.Tbps:
               return "Тб/с";
            default:
               return "";
         }
      }

      /// <summary>
      /// Перевести строковое значение ед. изм. к перечислению
      /// </summary>
      private static ModernDataRateUnit StringToUnit(string str) {
         if (str == "б/с")
            return ModernDataRateUnit.bps;
         if (str == "Кб/с")
            return ModernDataRateUnit.kbps;
         if (str == "Мб/с")
            return ModernDataRateUnit.Mbps;
         if (str == "Гб/с")
            return ModernDataRateUnit.Gbps;
         if (str == "Тб/с")
            return ModernDataRateUnit.Tbps;

         return ModernDataRateUnit.kbps;
      }

      /// <summary>
      /// Преобразовать строку в объект "Скорость передачи данных"
      /// </summary>
      /// <param name="str">значение из html</param>
      public static DataRate ConvertFromString(string str) {
         DataRate dr = null;
         string[] items = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
         if (items.Length == 2) {
            int val = Tools.IntFromString(items[0]);
            ModernDataRateUnit unit = StringToUnit(items[1]);
            DataRate rate = new DataRate() { Unit = unit, Rate = val };
            return rate;
         }
         return dr;
      }
      #endregion

      #region реализация IComparable<T>, IComparable
      public int CompareTo(DataRate other) {
         if (other == null)
            return 1;
         if (this.Equals(other))
            return 0;

         if (this.rateValue > other.rateValue)
            return 1;
         return -1;
      }

      public int CompareTo(object obj) {
         if (obj == null)
            return 1;
         DataRate other = obj as DataRate;
         return this.CompareTo(other);
      }
      #endregion
   }
}
