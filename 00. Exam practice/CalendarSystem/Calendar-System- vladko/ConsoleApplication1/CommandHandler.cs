namespace CalendarSystem
{
    using CalendarSystem.CommandParserData;
using CalendarSystem.CommandsFactory;

    public class CommandHandler
    {
        private readonly IEventsManager eventsManager;

        public CommandHandler(IEventsManager evnetsManager)
        {
            this.eventsManager = evnetsManager;
        }

        public IEventsManager EventsProcessor
        {
            get
            {
                return this.eventsManager;
            }
        }

        public string ProcessCommand(CommandInfo commandInfo, ICommandFactory commandFactory)
        {
            var command = commandFactory.GetCommand(commandInfo.Name);
            return command.Execute(this.eventsManager, commandInfo.Parameters);
        }
    }
}
