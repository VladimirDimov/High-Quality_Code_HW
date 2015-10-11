namespace Phonebook.CommandFactoryData
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class CommandInfo
    {
        private string commandName;
        private string[] inputParameters;

        public CommandInfo(string input)
        {
            int openingBracketIndex = input.IndexOf('(');
            if (openingBracketIndex == -1 || !input.EndsWith(")"))
            {
                Console.WriteLine("error!");
                Environment.Exit(0);
            }

            this.commandName = input.Substring(0, openingBracketIndex);

            string inputParametersText = input.Substring(openingBracketIndex + 1, input.Length - openingBracketIndex - 2);

            this.inputParameters = inputParametersText.Split(',');

            for (int j = 0; j < this.inputParameters.Length; j++)
            {
                this.inputParameters[j] = this.inputParameters[j].Trim();
            }
        }

        public string Name
        {
            get
            {
                return this.commandName;
            }
        }

        public string[] Parameters
        {
            get
            {
                return this.inputParameters;
            }
        }
    }
}
