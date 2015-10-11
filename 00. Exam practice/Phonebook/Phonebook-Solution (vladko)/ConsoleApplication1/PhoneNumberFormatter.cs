using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public static class PhoneNumberFormatter
    {
        private const string code = "+359";

        public static string Format(string unformattedNumber)
        {
            StringBuilder output = new StringBuilder();

            foreach (char symbol in unformattedNumber)
            {
                if (char.IsDigit(symbol) || (symbol == '+'))
                {
                    output.Append(symbol);
                }
            }

            if (output.Length >= 2 && output[0] == '0' && output[1] == '0')
            {
                output.Remove(0, 1);
                output[0] = '+';
            }

            while (output.Length > 0 && output[0] == '0')
            {
                output.Remove(0, 1);
            }

            if (output.Length > 0 && output[0] != '+')
            {
                output.Insert(0, code);
            }

            return output.ToString();
        }
    }
}
