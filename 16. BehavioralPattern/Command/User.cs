namespace Command
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Invoker
    /// </summary>
    public class User : IUser
    {
        private PlayField field;
        private IList<PlayFieldCommand> commands;
        private int currentCommandNumber = 0;

        public User(PlayField playField)
        {
            this.commands = new List<PlayFieldCommand>();
            this.Field = playField;
        }

        public PlayField Field
        {
            get
            {
                return this.field;
            }

            private set
            {
                this.field = value;
            }
        }

        public IList<PlayFieldCommand> Commands
        {
            get
            {
                return this.commands;
            }
        }

        public void Undo()
        {
            if (currentCommandNumber > 0)
            {
                currentCommandNumber--;
            }

            var lastCommand = this.commands[currentCommandNumber];
            lastCommand.Unexecute();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }


        public void Move(Directions direction)
        {
            var newCommand = new PlayFieldCommand(this.field, direction);
            newCommand.Execute();
            this.commands.Add(newCommand);
            currentCommandNumber = this.commands.Count;
        }
    }
}
