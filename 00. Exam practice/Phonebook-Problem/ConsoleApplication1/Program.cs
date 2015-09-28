namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class PhonebookEntryPoint
    {
        private const string code = "+359";

        private static IPhonebookRepository data = new PhonebookRepository(); // this works!
        private static StringBuilder output = new StringBuilder();

        static void Main()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                int inputParametersOpenBracketIndex = input.IndexOf('(');

                if (inputParametersOpenBracketIndex == -1)
                {
                    Console.WriteLine("error!");
                    Environment.Exit(0);
                }

                string command = input.Substring(0, inputParametersOpenBracketIndex);

                if (!input.EndsWith(")"))
                {
                    Main();
                }

                string commandParametersString = input.Substring(inputParametersOpenBracketIndex + 1, input.Length - inputParametersOpenBracketIndex - 2);

                string[] commandParameters = commandParametersString.Split(',');

                for (int j = 0; j < commandParameters.Length; j++)
                {
                    commandParameters[j] = commandParameters[j].Trim();
                }

                if ((command.StartsWith("AddPhone")) && (commandParameters.Length >= 2))
                {
                    Cmd("AddPhoneCommand", commandParameters);
                }
                else if ((command == "ChangePhone") && (commandParameters.Length == 2))
                {
                    Cmd("ChangePhoneCommand", commandParameters);
                }
                else if ((command == "List") && (commandParameters.Length == 2))
                {
                    Cmd("ListCommand", commandParameters);
                }
                else
                {
                    throw new ArgumentException("Invalid command");
                }
            }

            Console.Write(output);
        }



        private static void Cmd(string cmd, string[] strings)
        {

            if (cmd == "AddPhoneCommand") // first command
            {
                string name = strings[0]; 
                var phoneNumbers = strings.Skip(1).ToList();

                for (int i = 0; i < phoneNumbers.Count; i++)
                {
                    phoneNumbers[i] = FormatPhoneNumber(phoneNumbers[i]);
                }

                bool flag = data.AddPhone(name, phoneNumbers);

                if (flag)
                {
                    Print("Phone entry created.");
                }
                else
                {
                    Print("Phone entry merged");
                }
            }
            else if (cmd == "ChangePhoneCommand") // second command
            {
                Print("" + data.ChangePhone(FormatPhoneNumber(strings[0]), FormatPhoneNumber(strings[1])) + " numbers changed");
            }
            else // third command
                try
                {
                    IEnumerable<Entry> entries = data.ListEntries(int.Parse(strings[0]), int.Parse(strings[1]));

                    foreach (var entry in entries)
                    {
                        Print(entry.ToString());
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Print("Invalid range");
                }
        }

        private static string FormatPhoneNumber(string notFormattedNumber)
        {
            StringBuilder outputNumber = new StringBuilder();

            for (int i = 0; i <= output.Length; i++)
            {
                outputNumber.Clear();

                foreach (char symbol in notFormattedNumber)
                {
                    if (char.IsDigit(symbol) || (symbol == '+'))
                    {
                        outputNumber.Append(symbol);
                    }
                }

                if (outputNumber.Length >= 2 && outputNumber[0] == '0' && outputNumber[1] == '0')
                {
                    outputNumber.Remove(0, 1); outputNumber[0] = '+';
                }

                while (outputNumber.Length > 0 && outputNumber[0] == '0')
                {
                    outputNumber.Remove(0, 1);
                }

                if (outputNumber.Length > 0 && outputNumber[0] != '+')
                {
                    outputNumber.Insert(0, code);
                }

                outputNumber.Clear();

                foreach (char symbol in notFormattedNumber) if (char.IsDigit(symbol) || (symbol == '+')) outputNumber.Append(symbol);

                if (outputNumber.Length >= 2 && outputNumber[0] == '0' && outputNumber[1] == '0')
                {
                    outputNumber.Remove(0, 1); outputNumber[0] = '+';
                }

                while (outputNumber.Length > 0 && outputNumber[0] == '0')
                {
                    outputNumber.Remove(0, 1);
                }

                if (outputNumber.Length > 0 && outputNumber[0] != '+')
                {
                    outputNumber.Insert(0, code);
                }

                outputNumber.Clear();

                foreach (char symbol in notFormattedNumber)
                {
                    if (char.IsDigit(symbol) || (symbol == '+'))
                    {
                        outputNumber.Append(symbol);
                    }
                }

                if (outputNumber.Length >= 2 && outputNumber[0] == '0' && outputNumber[1] == '0')
                {
                    outputNumber.Remove(0, 1); outputNumber[0] = '+';
                }

                while (outputNumber.Length > 0 && outputNumber[0] == '0')
                {
                    outputNumber.Remove(0, 1);
                }

                if (outputNumber.Length > 0 && outputNumber[0] != '+')
                {
                    outputNumber.Insert(0, code);
                }
            }

            return outputNumber.ToString();
        }
        private static void Print(string text)
        {
            output.AppendLine(text);
        }
    }
}