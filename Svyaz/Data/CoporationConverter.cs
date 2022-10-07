using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Svyaz.Model;

namespace Svyaz.Data {
   /// <summary>
   /// Json конвертер для десериализации объектов типа Corporation
   /// </summary>
   public class CoporationConverter : JsonConverter {

      public override bool CanRead {
         get { return true; }
      }

      public override bool CanWrite {
         get { return false; }
      }


      public override bool CanConvert(Type objectType) {
         return (objectType == typeof(Corporation));
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
         JObject jo = JObject.Load(reader);

         // Read the properties which will be used as constructor parameters
         string corpName  = (string)jo["CorporateName"];
         BaseOperatorInfo op = JsonConvert.DeserializeObject<BaseOperatorInfo>( jo["Operator"].ToString());

         // Construct the Corporation object using the non-default constructor
         Corporation corp = new Corporation(corpName, op);
         return corp;
      }

      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
         throw new NotImplementedException();
      }
   }
}
