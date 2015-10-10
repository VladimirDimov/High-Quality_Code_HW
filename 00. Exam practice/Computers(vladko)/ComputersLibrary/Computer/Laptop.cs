using System.Collections.Generic;
namespace Computers
{
    public class Laptop : Computer
    {
        readonly Battery battery;

        public Laptop(Cpu cpu, Ram ram, VideoCard videoCard, IDrive hardDrive, Battery batery)
            : base(cpu, ram, videoCard, hardDrive)
        {
            this.battery = batery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);
            base.VideoCard.Draw(string.Format("Battery status: {0}%", battery.Percentage));
        }
    }
}
