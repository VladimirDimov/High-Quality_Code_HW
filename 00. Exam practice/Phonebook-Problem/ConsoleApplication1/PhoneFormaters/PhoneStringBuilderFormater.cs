namespace ConsoleApplication1.PhoneFormaters
{
    using System.Text;

    class PhoneStringBuilderFormater : IPhoneFormater
    {
        private const string Code = "+359";

        public string Format(string input, StringBuilder output)
        {
            StringBuilder outputNumber = new StringBuilder();

            for (int i = 0; i <= output.Length; i++)
            {
                outputNumber.Clear();

                foreach (char symbol in input)
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
                    outputNumber.Insert(0, Code);
                }

                outputNumber.Clear();

                foreach (char symbol in input) if (char.IsDigit(symbol) || (symbol == '+')) outputNumber.Append(symbol);

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
                    outputNumber.Insert(0, Code);
                }

                outputNumber.Clear();

                foreach (char symbol in input)
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
                    outputNumber.Insert(0, Code);
                }
            }

            return outputNumber.ToString();
        }
    }
}
