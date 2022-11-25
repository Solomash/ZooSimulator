using System.Text.Json;

namespace ZooCommonLibrary.Common.Application
{
    public static class SerializationExtentions
    {
        //данный метод записывает в бинарный файл экземпляр предоставленного класса с помощью BinaryFormatter
         public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

         //данный метод вычитывает из бинарного файла и создает экземпляр предоставленного класса с помощью BinaryFormatter
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        //Метод записывает в json файл предоставленный объект, согласно предоставленным сериализационным настройкам
        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            string jsonString = JsonSerializer.Serialize(objectToWrite, JsonSerializerExtensions.GetZooJsonSerializerOptions());
            File.WriteAllText(filePath, jsonString);
        }

        //Метод вычитывает json файл и создает объект, предоставленного типа, согласно предоставленным сериализационным настройкам
        public static T? ReadFromJsonFile<T>(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jsonString, JsonSerializerExtensions.GetZooJsonSerializerOptions());
        }
    }
}
