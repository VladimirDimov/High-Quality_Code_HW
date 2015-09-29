namespace ConsoleApplication1.CommandParsers
{
    using System.Collections.Generic;

    class CommandInfo : ICommandInfo
    {
        private string name;
        private IEnumerable<string> parameters;

        public CommandInfo(string name, IEnumerable<string> parametres)
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

        public IEnumerable<string> Parameters
        {
            get
            {
                return this.parameters;
            }
            private set
            {
                this.parameters = value;
            }
        }
    }
}
