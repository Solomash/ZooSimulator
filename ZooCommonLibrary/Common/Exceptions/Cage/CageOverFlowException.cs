using ZooCommonLibrary.Animals;

namespace ZooCommonLibrary.Common.Exceptions.Cage
{
    //Собственный класс исключения, который мы можем использовать для проверки клетки на переполнение
    // Наследуем от более общего исключения CageException
    public class CageOverFlowException : CageException
    {
        public Animal HomelessAnimal { get; set; }
        public CageOverFlowException(string message, Animal homelessAnimal) 
            : base($"Dude {homelessAnimal} cannot find home" + message)
        {
            HomelessAnimal = homelessAnimal;
        }
    }
}
