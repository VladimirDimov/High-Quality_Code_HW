namespace Phonebook.Commands
{
    using System;
    using System.Collections.Generic;

    class ListPhonesCommand : ICommand
    {
        public void Execute(string[] input, IPhonebookRepository phoneRepository, Loggers.ILogger logger)
        {
            ValidateInputParameters(input);

            try
            {
                IEnumerable<Entry> entries = phoneRepository.ListEntries(int.Parse(input[0]), int.Parse(input[1]));

                foreach (var entry in entries)
                {
                    logger.Print(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                logger.Print("Invalid range");
            }
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
