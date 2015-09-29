using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CommandParsers
{
    interface ICommandInfo
    {
        public string Name { get; }
        public IEnumerable<string> Parameters { get; set; }
    }
}
