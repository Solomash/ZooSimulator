namespace ZooCommonLibrary.Animals
{
    //Абстрактный класс всех зверей, в зоопарке есть только конкретные экземпляры
    public abstract class Animal
    {
        //Свойства с Getter'ом и private Setter'ом, брать свойство можно везде, присваивать только внутри класса Animal
        public int Weight { get; private set; }
        public string Name { get; private set; }

        private int _age;

        //Constant
        public const int legs = 4;
        public AnimalSpeciesEnum AnimalSpecies {get; private set; }

        //Свойство с определенным Getter'ом. 
        public string FullInfo => $"Animal name: {Name}, weight:{Weight}, species: {AnimalSpecies}";

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Возраст не может быть меньше 1");
                _age = value;
            }
        }

        //Конструктор для животных, у кого есть кличка
        public Animal(string name, int weight, AnimalSpeciesEnum animalSpecies)
        {
            Name = name;
            Weight = weight;
            AnimalSpecies = animalSpecies;
            _age = 0;
        }

        //Конструктор для животных, у кого не может быть клички
        //TODO: Add this to call constructor
        public Animal(int weight, AnimalSpeciesEnum animalSpecies)
        {
            Name = "Unknown";
            Weight = weight;
            AnimalSpecies = animalSpecies;
        }

        public void SetAge(int age)
        {
            try
            {
                Age = age;
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
        }

        //Метод, который может быть переопределен в дочерних классах
        public virtual void Sleep()
        {
            Console.WriteLine("I'm sleeping");
        }
    }
}
