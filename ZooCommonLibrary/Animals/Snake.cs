using ZooCommonLibrary.Animals.Contracts;

namespace ZooCommonLibrary.Animals
{
    //Конкретный экземпляр Animal, от которого далее нельзя отнаследоваться (sealed)
    public sealed class Snake : Animal, ILiveInGroup<Snake>
    {
        //Реализованное свойство из ILiveInGroup<T> интерфейса
        public List<Snake> Neighbors { get; private set; }

        //Поскольку у змей нет клички, мы используем конструктор только с одним параметром
        public Snake(int weight) : base(weight, AnimalSpeciesEnum.Reptile)
        {
            Neighbors = new List<Snake>();
        }

        //Реализованный метод из ILiveInGroup<T> интерфейса
        public void AddNeighbor(Snake neighborAnimal)
        {
            Neighbors.Add(neighborAnimal);
        }

        //Переопределяем базовый метод, поскольку змеи не спят (условно)
        public override void Sleep()
        {
            Console.WriteLine("Snakes don't sleep! Shshshs");
        }
    }
}
