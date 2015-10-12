namespace CalendarSystem.CommandParserData
{
    using System;

    public class CommandInfo
    {
        private string name;

        public CommandInfo(string name, string[] parametres)
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

            set
            {
                this.name = value;
            }
        }

        public string[] Parameters { get; set; }
    }
}
