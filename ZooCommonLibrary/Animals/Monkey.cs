using ZooCommonLibrary.Animals.Contracts;

namespace ZooCommonLibrary.Animals
{
    //Конкретный экземпляр Animal, от которого далее нельзя отнаследоваться (sealed)
    public sealed class Monkey : Animal, ILiveInGroup<Monkey>, IPlaying
    {
        //Реализованное свойство из ILiveInGroup<T> интерфейса
        public List<Monkey> Neighbors { get; private set; }

        //Поскольку базовый конструктор Animal принимает только 3 параметра, необходимо определить конструтор Monkey, 
        //который так же принимает 2 параметра и вызывает базовый конструктор
        public Monkey(string name, int weight) : base(name, weight, AnimalSpeciesEnum.Mammal)
        {
            Neighbors = new List<Monkey>();
        }

        //Реализованный метод из ILiveInGroup<T> интерфейса
        public void AddNeighbor(Monkey neighborAnimal)
        {
            Neighbors.Add(neighborAnimal);
        }

        //Реализованный метод из IPlaying интерфейса
        public void Play(Action wayOfPlay)
        {
            if (Neighbors.Count == 0)
            {
                Console.WriteLine("I don't have friends yet:(");
                return;
            }

            foreach (var friend in Neighbors)
            {
                Console.WriteLine($"I play with {friend.Name}");
                wayOfPlay.Invoke();
            }
        }
    }
}
