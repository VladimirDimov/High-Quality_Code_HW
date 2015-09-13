using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facade.GsmControlers
{
    public class KeyboardControler
    {
        public bool IsLocked { get; private set; }

        public KeyboardControler()
        {
            this.Unlock();
        }

        public void Lock()
        {
            IsLocked = true;
        }

        public void Unlock()
        {
            IsLocked = false;
        }

        public override string ToString()
        {
            string state = IsLocked ? "locked" : "unlocked";
            return "The keyboard is " + state + ".";
        }

    }
}
