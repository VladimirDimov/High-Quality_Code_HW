using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facade.GsmControlers
{
    public class GpsControler
    {
        public bool IsRunning { get; private set; }

        public GpsControler()
        {
            this.TurnOn();
        }

        public void TurnOn()
        {
            IsRunning = true;
        }

        public void TurnOff()
        {
            IsRunning = false;
        }

        public override string ToString()
        {
            string state = IsRunning ? "turned on" : "turned off";
            return "The GPS is " + state + ".";
        }

    }
}
