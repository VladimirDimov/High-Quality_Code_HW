# Composite #

## Описание ##
Осигурява общ интерфейс към система от интерфейси. По този начин се осигурява интерфейс от по-високо ниво, който позволява по-удобно контролиране на подсистемата.

## UML диаграма ##

![1](images/facade.gif)

## Пример ##

Имаме подсистема от контролери на GSM устройство. Чрез шаблон Фасада ще осигурим интерфейс, който позволява управление на контролерите от един клас:

![1](images/facade_1.png)


###Код###

####Подсистема####
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

	public enum SoundLevel
    {
        SILENT, LOW, NORMAL, HIGH, VERY_HIGH
    }

    class SoundControler
    {
        public SoundLevel SoundLevel { get; private set; }

        public void SetSoundLevel(SoundLevel level)
        {
            this.SoundLevel = level;
        }

        public override string ToString()
        {
            return "The sound level is set to " + this.SoundLevel.ToString().ToLower() + ".";
        }
    }

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

####Фасада####

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

####Примерно използване####

	class Application
    {
        static void Main()
        {
            var gsmControler = new GsmModesControler();
            Console.WriteLine(gsmControler.ToString());

            gsmControler.АctivateMeetingMode();
            Console.WriteLine(gsmControler.ToString());

            gsmControler.АctivateFlightMode();
            Console.WriteLine(gsmControler.ToString());

            gsmControler.АctivateStandByMode();
            Console.WriteLine(gsmControler.ToString());
        }
    }

    