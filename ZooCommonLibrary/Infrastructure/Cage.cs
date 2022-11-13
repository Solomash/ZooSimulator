using ZooCommonLibrary.Animals;
using ZooCommonLibrary.Common.Exceptions;
using ZooCommonLibrary.Common.Exceptions.Cage;

namespace ZooCommonLibrary.Infrastructure
{
    //Класс представляет собой место, где живут звери
    public class Cage
    {
        private List<Animal> Animals { get; }
        private int _cageSize;
        public Cage(int size)
        {
            if (size < 1)
            {
                //Поскольку размер меньше нужного, констуктор генерирует ошибку
                throw new CageException("Размер клетки не может быть меньше 1");
            }
            _cageSize = size;
            Animals = new List<Animal>(size);
        }

        public void AddAnimal(Animal animalToAdd)
        {
            if (Animals.Count() == _cageSize)
                throw new CageOverFlowException("Клетка уже полная!", animalToAdd);
            Animals.Add(animalToAdd);
        }

        //Этот Generic метод позволяет нам получить конкретный экземпляр зверя в клетке
        public T? GetAnimalById<T>(int id) where T : Animal
        {
            return Animals[id] as T;
        }
    }
}
