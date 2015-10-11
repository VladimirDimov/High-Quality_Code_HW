using Phonebook.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Commands
{
    public interface ICommand
    {
        void Execute(string[] input, IPhonebookRepository phoneRepository, ILogger logger);
    }
}
