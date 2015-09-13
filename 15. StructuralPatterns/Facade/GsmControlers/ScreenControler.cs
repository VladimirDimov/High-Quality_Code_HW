using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facade.GsmControlers
{
    public enum ScreenModes
    {
        OFF, DARK, NORMAL, BRIGHT
    }

    public class ScreenControler
    {        
        public ScreenModes Mode { get; private set; }

        public ScreenControler()
        {
            this.SetMode(ScreenModes.NORMAL);
        }

        public void SetMode(ScreenModes mode)
        {
            this.Mode = mode;
        }

        public override string ToString()
        {
            return "The screen is running in " + this.Mode.ToString().ToLower() + " mode.";
        }
    }
}
