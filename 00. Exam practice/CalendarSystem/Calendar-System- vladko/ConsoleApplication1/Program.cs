namespace CalendarSystem
{
    using System;
    using CalendarSystem.CommandParserData;
    using CalendarSystem.CommandsFactory;

    public class Application
    {
        private static CommandFactory commandFactory = new CommandFactory();

        internal static void Main()
        {
            var eventsManager = new EventsManagerFast();
            var commandHandler = new CommandHandler(eventsManager);
            var commandParser = new CommandParser();

            while (true)
            {
                string commandText = Console.ReadLine();

                if (commandText == "End" || commandText == null)
                {
                    break;
                }

                try
                {
                    var commandInfo = commandParser.Parse(commandText);
                    var message = commandHandler.ProcessCommand(commandInfo, commandFactory);
                    Console.WriteLine(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}