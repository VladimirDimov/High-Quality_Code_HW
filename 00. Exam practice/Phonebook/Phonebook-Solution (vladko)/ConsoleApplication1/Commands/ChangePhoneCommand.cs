using Phonebook.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Commands
{
    class ChangePhoneCommand : ICommand
    {
        public void Execute(string[] input, IPhonebookRepository data, ILogger logger)
        {
            ValidateInputParameters(input);

            string name = input[0];
            var phoneNumbers = input.Skip(1).ToList();

            logger.Print(data.ChangePhone(PhoneNumberFormatter.Format(name), PhoneNumberFormatter.Format(input[1])) + " numbers changed");
        }

        private void ValidateInputParameters(string[] input)
        {
            if (input.Length != 2)
            {
                throw new ArgumentException(this.GetType() + " must have two input parameters!");
            }
        }

    }
}
