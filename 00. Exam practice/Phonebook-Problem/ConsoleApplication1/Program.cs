namespace ConsoleApplication1
{
    using ConsoleApplication1.Command;
    using ConsoleApplication1.Command.CommandFactory;
    using ConsoleApplication1.CommandParsers;
    using ConsoleApplication1.Printer;
    using System;
    using System.Text;

    public class PhonebookEntryPoint
    {
        static void Main()
        {
            IPhonebookRepository data = new PhonebookRepository();
            StringBuilder output = new StringBuilder();
            IPrinter consolePrinter = new ConsolePrinter();
            string input;
            var commandParser = new CommandParser(consolePrinter);
            var commandFactory = new CommandFactory(output, data, consolePrinter);

            while ((input = Console.ReadLine()) != "End")
            {
                var commandInfo = commandParser.Parse(input);
                var commandName = commandInfo.Name;
                var commandParameters = commandInfo.Parameters;

                var command = commandFactory.CreateCommand(commandInfo.Name);
                command.Execute(commandInfo.Parameters);
            }

            Console.Write(output);
        }
    }
}