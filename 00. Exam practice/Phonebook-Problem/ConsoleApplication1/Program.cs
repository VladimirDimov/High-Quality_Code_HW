namespace ConsoleApplication1
{
    using ConsoleApplication1.Command;
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

            while ((input = Console.ReadLine()) != "End")
            {
                var commandInfo = commandParser.Parse(input);
                var commandName = commandInfo.Name;
                var commandParameters = commandInfo.Parameters;

                ICommand command;
                if ((commandName.StartsWith("AddPhone")) && (commandParameters.Length >= 2))
                {
                    command = new AddPhoneCommand(output, data, consolePrinter);
                }
                else if ((commandName == "ChangePhone") && (commandParameters.Length == 2))
                {
                    command = new ChangePhoneCommand(output, data, consolePrinter);
                }
                else if ((commandName == "List") && (commandParameters.Length == 2))
                {
                    command = new ListCommand(output, data, consolePrinter);
                }
                else
                {
                    throw new ArgumentException("Invalid command");
                }

                command.Execute(commandParameters);
            }

            Console.Write(output);
        }
    }
}