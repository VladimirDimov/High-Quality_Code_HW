using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facade.GsmControlers
{
    public class WiFiControler
    {
        public bool IsRunning { get; private set; }

        public WiFiControler()
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
            return "The WiFi is " + state + ".";
        }
    }
}
