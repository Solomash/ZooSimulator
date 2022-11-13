namespace ZooCommonLibrary.Common.Exceptions
{
    //Собственный класс исключения, который мы можем использовать если работник отсутсвует на рабочем месте
    public class WorkerNotAvailableException : Exception
    {
        public WorkerNotAvailableException(string message) : base(message)
        {

        }
    }
}
