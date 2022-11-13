using ZooCommonLibrary.Animals.Contracts;
using ZooCommonLibrary.Common.Exceptions;

namespace ZooCommonLibrary.Personel
{
    public class ZooKeeper
    {
        //Переменная, указывающая, находится ли работник на месте
        private bool _onWork;

        public string Name { get; private set; }
        public decimal Salary { get; private set; }
        public int YearsExperience { get; private set; }

        //Свойство, помогающее выставить переменную _onWork
        public bool IsWorkingNow
        {
            get
            {
                return _onWork;
            }
            set
            {
                Console.WriteLine("Я выхожу на работу!");
                _onWork = value;
            }
        }

        public ZooKeeper(string name, decimal salary, int yearsExperience)
        {
            Name = name;
            Salary = salary;
            YearsExperience = yearsExperience;
        }

        //В этом методе смотритель начинает следить за потенциальным беглецом
        public void KeepEyesOnPossibleEscapeAnimal(ICanEscape canEscapeAnimal)
        {
            canEscapeAnimal.EscapeHandlerEvent += EscapeHandlerEvent;
        }

        //Если побег происходит, то он получает уведомление об этом и предпринимает попытку его поимки, если он находится на рабочем месте!
        private void EscapeHandlerEvent(object? sender, string e)
        {
            if (!IsWorkingNow)
                throw new WorkerNotAvailableException("Работник не на месте! Зверь сейчас сбежит!");
            Console.WriteLine($"{e}  пытается сбежать! Пойду его ловить");
        }
    }
}
