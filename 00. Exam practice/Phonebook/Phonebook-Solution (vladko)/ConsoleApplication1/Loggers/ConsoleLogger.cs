namespace Phonebook.Loggers
{
    using System;

    public class ConsoleLogger : ILogger
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
