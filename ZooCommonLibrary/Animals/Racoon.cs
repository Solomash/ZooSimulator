using ZooCommonLibrary.Animals.Contracts;

namespace ZooCommonLibrary.Animals
{
    //Конкретный экземпляр Animal, от которого далее нельзя отнаследоваться (sealed)
    public sealed class Racoon : Animal, ICanEscape
    {
        
        //Поскольку базовый конструктор Animal принимает только 3 параметра, необходимо определить конструтор Monkey, 
        //который так же принимает 2 параметра и вызывает базовый конструктор
        public Racoon(string name, int weight) : base(name, weight, AnimalSpeciesEnum.Mammal)
        {
        }

        //Поскольку еноты могут копать, они умееют сбегать
        //Что бы предупредить служащего зоопарка, идет сообщение от системы безопасности (в нашем случае EscapeHandlerEvent)
        public EventHandler<string> EscapeHandlerEvent { get; set; }
        public void Escape()
        {
            Console.WriteLine($"Racoon {Name} trying to escape!");
            EscapeHandlerEvent(this, FullInfo);
        }
    }
}
