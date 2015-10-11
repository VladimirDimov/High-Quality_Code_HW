using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Loggers
{
    public interface ILogger
    {
        void Print(string message);
    }
}
