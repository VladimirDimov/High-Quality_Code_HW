using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Command.CommandFactory
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string name);
    }
}
