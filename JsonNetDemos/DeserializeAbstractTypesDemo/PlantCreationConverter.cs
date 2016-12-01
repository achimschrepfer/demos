using System;
using JsonNetDemos.DeserializeAbstractTypesDemo.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonNetDemos.DeserializeAbstractTypesDemo
{
    public class PlantCreationConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            var type = jo["Type"].ToString();

            Plant instance = null;

            switch (type)
            {
                case "Oak":
                    instance = new Tree();
                    break;
                case "Rose":
                    instance = new Flower();
                    break;
            }

            serializer.Populate(jo.CreateReader(), instance);
            return instance;
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(Plant);

        public override bool CanWrite => false;
    }
}