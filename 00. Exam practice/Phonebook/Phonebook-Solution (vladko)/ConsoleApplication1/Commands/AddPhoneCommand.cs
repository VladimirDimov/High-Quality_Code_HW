namespace Phonebook.Commands
{
    using System;
    using System.Linq;
    using Phonebook.Loggers;

    public class AddPhoneCommand : ICommand
    {
        public void Execute(string[] input, IPhonebookRepository phoneRepository, ILogger logger)
        {
            this.ValidateInputParameters(input);

            string name = input[0];
            var phoneNumbers = input.Skip(1).ToList();

            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                phoneNumbers[i] = PhoneNumberFormatter.Format(phoneNumbers[i]);
            }

            bool isExistingEntry = phoneRepository.AddPhone(name, phoneNumbers);

            if (!isExistingEntry)
            {
                logger.Print("Phone entry created");
            }
            else
            {
                logger.Print("Phone entry merged");
            }
        }

        private void ValidateInputParameters(string[] input)
        {
            if (input.Length < 2)
            {
                throw new ArgumentException(this.GetType() + " must have two input parameters!");
            }
        }
    }
}
