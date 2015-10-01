namespace ConsoleApplication1.CommandParsers
{
    using System.Collections.Generic;

    class CommandInfo : ICommandInfo
    {
        private string name;
        private IList<string> parameters;

        public CommandInfo(string name, IList<string> parametres)
        {
            this.Name = name;
            this.Parameters = parametres;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        public IList<string> Parameters
        {
            get
            {
                return this.parameters;
            }
            set
            {
                this.parameters = value;
            }
        }
    }
}
