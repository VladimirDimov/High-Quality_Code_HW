using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Command
{
    /// <summary>
    /// The Command interface
    /// </summary>
    public interface ICommand
    {
        void Execute();
        void Unexecute();
    }
}
