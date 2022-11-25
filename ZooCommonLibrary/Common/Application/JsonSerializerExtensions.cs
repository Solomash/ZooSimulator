using System.Text.Json;
using System.Text.Json.Serialization;
using ZooCommonLibrary.Animals;

namespace ZooCommonLibrary.Common.Application
{
    public static class JsonSerializerExtensions
    {
        //метод, создающий настройки для сериализации/десериализации
        public static JsonSerializerOptions GetZooJsonSerializerOptions()
        {
            var options = new JsonSerializerOptions
            {
                IgnoreReadOnlyProperties = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                
            };
            //включает в себя конвертер, для работы с классом Monkey
            options.Converters.Add(new MonkeyJsonConverter());

            return options;
        }
    }
    //Класс конкретного конвертера наследуется от JsonConverter<T>, необходимо реализовать 2 метода для работы
    public class MonkeyJsonConverter : JsonConverter<Monkey>
    {
        public override Monkey? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.Read();//"name" - field
            reader.Read();//"strValue" - value
            var name = reader.GetString();
            reader.Read();//"weight" - field
            reader.Read();//"intValue" - value
            var weight = reader.GetInt32();
            reader.Read();//"age" - field
            reader.Read();//"intValue" - value
            var age = reader.GetInt32();
            var monkey = new Monkey(name, weight, age);
            return monkey;
        }

        public override void Write(Utf8JsonWriter writer, Monkey value, JsonSerializerOptions options)
        {
            //В этом методе построчно заполняется json файл
            options.PropertyNamingPolicy ??= JsonNamingPolicy.CamelCase;
            writer.WriteStartObject(); //{
            writer.WriteString("name", value.Name);// "name" : "Strvalue"
            writer.WriteNumber("weight", value.Weight);// "name" : numberVal
            writer.WriteNumber("age", value.Age);
            writer.WriteString("AnimalSpecies", value.AnimalSpecies.ToString());
            writer.WriteStartArray();// [
            foreach (var neighbor in value.Neighbors)
            {
                writer.WriteStartObject();//{
                writer.WriteString("NeighborName", neighbor.Name);
                writer.WriteEndObject();//}
            }
            writer.WriteEndArray();//]
            writer.WriteEndObject();//}
        }
    }
}
