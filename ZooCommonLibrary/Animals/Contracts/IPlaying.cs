namespace ZooCommonLibrary.Animals.Contracts
{
    //В этом интерфейсе мы определяем методы, которые реализуются, если экземпляр класса должен уметь играть
    public interface IPlaying
    {
        public void Play(Action wayOfPlay);
    }
}
