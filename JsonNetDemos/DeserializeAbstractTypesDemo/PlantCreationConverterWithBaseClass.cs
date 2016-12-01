using JsonNetDemos.DeserializeAbstractTypesDemo.Types;
using Newtonsoft.Json.Linq;

namespace JsonNetDemos.DeserializeAbstractTypesDemo
{
    public class PlantCreationConverterWithBaseClass : TypePropertyCreationConverter<Plant>
    {
        protected override string GetTypeNameFromJsonObject(JObject jo) => jo["Type"].ToString();

        protected override Plant GetInstanceForType(string typeName)
        {
            switch (typeName)
            {
                case "Oak":
                    return new Tree();
                case "Rose":
                    return new Flower();
                default:
                    return null;
            }
        }
    }
}