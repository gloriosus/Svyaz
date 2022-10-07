using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svyaz {
   /// <summary>
   /// категория поселения
   /// </summary>
   public enum SettlmentCategory {
      городское,
      сельское
   }

   /// <summary>
   /// Категория населенного пункта
   /// </summary>
   public enum SettlementCategory {
      /// <summary>
      /// Город
      /// </summary>
      г,
      /// <summary>
      /// Село
      /// </summary>
      с,
      /// <summary>
      /// Поселок
      /// </summary>
      пос,
      /// <summary>
      /// Станция
      /// </summary>
      ст,
      /// <summary>
      /// Разъезд
      /// </summary>
      рзд,
      /// <summary>
      /// Поселок городского типа
      /// </summary>
      пгт,
      /// <summary>
      /// Деревня
      /// </summary>
      д
   }

   /// <summary>
   /// Тип GSM стандарта
   /// </summary>
   public enum GsmType {
      /// <summary>
      /// GSM связь отсутствует
      /// </summary>
      [Description("Нет")]
      None,
     
      /// <summary>
      /// GSM 900/1800
      /// </summary>
      [Description("900/1800")]
      Gsm_900_1800,
      
      /// <summary>
      /// GSM 1800
      /// </summary>
      [Description("1800")]
      Gsm_1800,
      
      /// <summary>
      /// GSM 1800,900/1800
      /// </summary>
      [Description("1800,900/1800")]
      Gsm_1800_900_1800
   }

   /// <summary>
   /// Скорость передачи данных (современные на базе 1000)
   /// </summary>
   public enum ModernDataRateUnit { 
      /// <summary>
      /// отсутствует
      /// </summary>
      none,
      /// <summary>
      ///  бит в секунду 
      /// </summary>
      bps,
      /// <summary>
      /// килобит в секунду
      /// </summary>
      kbps,
      /// <summary>
      /// мегабит в секунду
      /// </summary>
      Mbps,
      /// <summary>
      /// гигабит в секунду
      /// </summary>
      Gbps,
      /// <summary>
      /// терабит в секунду
      /// </summary>
      Tbps
   }

   /// <summary>
   /// Источник данных
   /// </summary>
   public enum DataSrc {
      /// <summary>
      /// Открытые данные Роскомнадзора
      /// </summary>
      [Description("Открытые данные Роскомнадзора")]
      OpenData,
      /// <summary>
      /// Данные поставшиков услуг
      /// </summary>
      [Description("Данные поставшиков услуг")]
      OperatorData
   }

   /// <summary>
   /// Вид отображения сводных данных в своди (по операторам связи или юр. лицам)
   /// </summary>
   public enum DataView {
      /// <summary>
      /// отображать операторов связи
      /// </summary>
      ByOperators,
      /// <summary>
      /// отображать юр. лциа
      /// </summary>
      ByCorporatiions
   }
}
