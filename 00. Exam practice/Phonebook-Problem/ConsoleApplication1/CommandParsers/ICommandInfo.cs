using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CommandParsers
{
    interface ICommandInfo
    {
        string Name { get; }
        IList<string> Parameters { get; set; }
    }
}
