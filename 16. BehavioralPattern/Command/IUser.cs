using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Command
{
    public interface IUser
    {
        PlayField Field { get; }
        IList<PlayFieldCommand> Commands { get; }
        void Move(Directions direction);
        void Undo();
        void Redo();
    }
}
