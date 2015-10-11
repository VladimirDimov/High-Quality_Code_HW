namespace Phonebook
{
    using Phonebook.CommandFactoryData;
    using Phonebook.Commands;
    using Phonebook.Loggers;
    using System;
    using System.Text;

    public class Application
    {

        private static StringBuilder input = new StringBuilder();
        private static ILogger consoleLogger = new ConsoleLogger();
        private static IPhonebookRepository phoneRepository = new PhonebookRepository(consoleLogger);
        private static ICommandFactory commandFactory = new CommandFactory();

        static void Main()
        {
            while (true)
            {
                string inputLine = Console.ReadLine().Trim();

                if (inputLine == "End" || inputLine == null)
                {
                    break;
                }

                var commandInfo = new CommandInfo(inputLine);

                ICommand command = commandFactory.GetCommand(commandInfo.Name, commandInfo.Parameters);
                command.Execute(commandInfo.Parameters, phoneRepository, consoleLogger);
            }

            Console.Write(input);
        }
    }
}
