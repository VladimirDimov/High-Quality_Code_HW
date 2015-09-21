using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge
{
    public abstract class ConsoleSettings
    {
        public abstract void Apply();

        public abstract void Cancel();
    }
}
