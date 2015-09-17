namespace Facade
{
    using Facade.GsmControlers;
    using System.Text;

    public enum GsmModes
    {
        DEFAULT, FLIGHT, MEETING, STAND_BY
    }

    class GsmModesControler
    {
        private GpsControler gpsControler;
        private KeyboardControler keyboardControler;
        private ScreenControler screenControler;
        private WiFiControler wifiControler;
        private SoundControler soundControler;

        public GsmModes ActiveMode { get; private set; }

        public GsmModesControler()
        {
            gpsControler = new GpsControler();
            keyboardControler = new KeyboardControler();
            screenControler = new ScreenControler();
            wifiControler = new WiFiControler();
            soundControler = new SoundControler();

            АctivateDefaultMode();
        }

        public void АctivateDefaultMode()
        {
            this.ActiveMode = GsmModes.DEFAULT;

            gpsControler.TurnOn();
            keyboardControler.Unlock();
            screenControler.SetMode(ScreenModes.NORMAL);
            wifiControler.TurnOn();
            soundControler.SetSoundLevel(SoundLevel.NORMAL);
        }

        public void АctivateFlightMode()
        {
            this.ActiveMode = GsmModes.FLIGHT;

            gpsControler.TurnOff();
            wifiControler.TurnOff();
            soundControler.SetSoundLevel(SoundLevel.LOW);
        }

        public void АctivateMeetingMode()
        {
            this.ActiveMode = GsmModes.MEETING;

            soundControler.SetSoundLevel(SoundLevel.SILENT);
        }

        public void АctivateStandByMode()
        {
            this.ActiveMode = GsmModes.STAND_BY;

            screenControler.SetMode(ScreenModes.OFF);
            keyboardControler.Lock();
        }

        public override string ToString()
        {
            var report = new StringBuilder();

            report.AppendLine("Gsm is running in " + this.ActiveMode + " mode.");
            report.AppendLine(this.gpsControler.ToString());
            report.AppendLine(this.keyboardControler.ToString());
            report.AppendLine(this.screenControler.ToString());
            report.AppendLine(this.soundControler.ToString());
            report.AppendLine(this.wifiControler.ToString());
            return report.ToString();
        }
    }
}
