# Deserialize abstract classes with JSON.net

## Abstract

When deserializing a JSON structure into .NET classes that have abstract base
classes the deserializer throws an exception because it cannot determine wich
concrete type to use for instantiation. If you have just one concrete type you'll
go fine using http://www.newtonsoft.com/json/help/html/customcreationconverter.htm.

If you have multiple types a decision has to be made during the deserialization
process. This can be achieved by implementing a simple base convertes as shown in [this class](https://github.com/achimschrepfer/demos/blob/master/JsonNetDemos/DeserializeAbstractTypesDemo/TypePropertyCreationConverter.cs).

Use this class as base for your converter and you end up with only the code that
makes the decision of what type to use for the JSON input and the code that provides
the instances:
```
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
 ```
 
