using ZooCommonLibrary.Animals;

namespace ZooCommonLibrary.Infrastructure
{
    public class ZooBuilding
    {
        public ZooBuilding(List<Cage> cagesInZoo)
        {
            Cages = cagesInZoo;
        }
        //Класс содержит в себе несколько загонов со зверями
        public List<Cage> Cages { get; private set; }
    }
}
