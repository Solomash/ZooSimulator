namespace ZooCommonLibrary.Animals.Contracts
{
    //В этом интерфейсе мы определяем методы, которые реализуются, если экземпляр класса живет в группе сородичей
    //Интерфейс объявлен как Generic, поскольку он может применятся к разным видам зверей
    internal interface ILiveInGroup<T> where T : Animal
    {
        public List<T> Neighbors { get; }
        public void AddNeighbor(T neighborAnimal);
    }
}
