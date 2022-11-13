//Что бы работать с классами из других проектов, необходимо добавить ссылку на них и подключить пространство имен
using ZooCommonLibrary.Animals;
using ZooCommonLibrary.Common.Exceptions;
using ZooCommonLibrary.Common.Exceptions.Cage;
using ZooCommonLibrary.Infrastructure;

namespace ZooProject.Application
{
    //Статический класс, экземпляр которого создавать не требуется
    public static class ZooBuilder
    {
        //Статический метод создания зоопарка. Вызываем просто от имени метода класса ZooBuilder
        public static ZooBuilding Create()
        {
            var chackyMonkey = new Monkey("Chacky", 12);
            var mickeyMonkey = new Monkey("Mickey", 14);
            mickeyMonkey.AddNeighbor(chackyMonkey);
            chackyMonkey.AddNeighbor(mickeyMonkey);
            var monkeyCage = new Cage(1);
            var monkeyCageReserved = new Cage(3);
            //Опасный код помещаем в Try/ Catch
            try
            {
                monkeyCage.AddAnimal(chackyMonkey);
                monkeyCage.AddAnimal(mickeyMonkey);
            }
            //Обработка конкретного Exception, с последующей проброской ошибки выше
            catch (CageOverFlowException ex)
            {
                monkeyCageReserved.AddAnimal(ex.HomelessAnimal);
                throw;
            }
            //Обработка более общего Exception
            catch (CageException ex)
            {
                Console.WriteLine("Нужно решить проблему с клеткой " + ex.Message);
            }

            return new ZooBuilding(new List<Cage>() { monkeyCage, monkeyCageReserved });
        }
    }
}
