namespace ZooCommonLibrary.Animals.Contracts
{
    //В этом интерфейсе мы определяем метод, которые реализуются, если зверь может попытаться сбежать
    public interface ICanEscape
    {
        public EventHandler<string> EscapeHandlerEvent { get; set; }
        public void Escape();
    }
}
