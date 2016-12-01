# Deserialize abstract classes with JSON.net

## Abstract

When deserializing a JSON structure into .NET classes that have abstract base
classes the deserializer throws an exception because it cannot determine wich
concrete type to use for instantiation. If you have just one concrete type you'll
go fine using http://www.newtonsoft.com/json/help/html/customcreationconverter.htm