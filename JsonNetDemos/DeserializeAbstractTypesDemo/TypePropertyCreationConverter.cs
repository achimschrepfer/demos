using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonNetDemos.DeserializeAbstractTypesDemo
{
    public abstract class TypePropertyCreationConverter<TBase> : JsonConverter where TBase : class 
    {
        protected abstract string GetTypeNameFromJsonObject(JObject jo);
        protected abstract TBase GetInstanceForType(string typeName);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            var type = GetTypeNameFromJsonObject(jo);

            TBase instance = GetInstanceForType(type);

            serializer.Populate(jo.CreateReader(), instance);
            return instance;
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(TBase);


        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("This converter type should only be used during deserialization.");
        }

        public override bool CanWrite => false;
    }
}