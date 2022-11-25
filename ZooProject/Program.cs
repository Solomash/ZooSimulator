using ZooCommonLibrary.Animals;
using ZooCommonLibrary.Common.Application;
using ZooCommonLibrary.Common.Exceptions.Cage;
using ZooProject.Application;

//Создаем экземпляр обезьяны, которую мы хотим сохранить (сериализовать)
var monkey = new Monkey("Chak", 14, 2);
//Используем статический метод для сериализации в бинарный файл
SerializationExtentions.WriteToBinaryFile(@"D:/test.bin", monkey);
//Используем статический метод для десериализации из бинарного файла
var restoredMonkey = SerializationExtentions.ReadFromBinaryFile<Monkey>(@"D:/test.bin");


//Используем статический метод для сериализации в json файл
SerializationExtentions.WriteToJsonFile<Monkey>(@"D:/test.json", monkey);
//Используем статический метод для десериализации из json файла
var restoredMonkey2 = SerializationExtentions.ReadFromJsonFile<Monkey>(@"D:/test.json");

try
{
    var zoo = ZooBuilder.Create();
}
catch (CageOverFlowException ex)
{
    Console.WriteLine("Решить проблему с расслением зверей! " + ex.Message);
}
