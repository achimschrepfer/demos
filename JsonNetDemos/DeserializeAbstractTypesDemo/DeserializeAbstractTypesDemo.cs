using System.Collections.Generic;
using System.Linq;
using JsonNetDemos.DeserializeAbstractTypesDemo.Types;
using Newtonsoft.Json;
using Xunit;

namespace JsonNetDemos.DeserializeAbstractTypesDemo
{
    public class DeserializeAbstractTypesDemo
    {
        private static string GetJson()
        {
            var list = new List<Plant>
            {
                new Tree {Height = 5, Type = "Oak"},
                new Flower {Color = "Red", Type = "Rose"}
            };

            var json = JsonConvert.SerializeObject(list, Formatting.Indented);
            return json;
        }

        [Fact]
        public void DeserializationOfAbstractTypesDoesNotWorkOutOfTheBox()
        {
            var json = GetJson();

            Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<List<Plant>>(json));
        }

        [Fact]
        public void DeserializationWorksWithSpecificJsonConverterForAbstractTypes()
        {
            var json = GetJson();

            var deserializedObject =  JsonConvert.DeserializeObject<List<Plant>>(json, new PlantCreationConverter());

            // Of course these asserts only work with two items in the list :-)
            Assert.IsType<Tree>(deserializedObject.First());
            Assert.IsType<Flower>(deserializedObject.Last());
        }

        [Fact]
        public void DeserializationWorksWithConverterBasedOnTypePropertyCreationConverter()
        {
            var json = GetJson();

            var deserializedObject = JsonConvert.DeserializeObject<List<Plant>>(json, new PlantCreationConverterWithBaseClass());

            // Of course these asserts only work with two items in the list :-)
            Assert.IsType<Tree>(deserializedObject.First());
            Assert.IsType<Flower>(deserializedObject.Last());
        }
    }
}