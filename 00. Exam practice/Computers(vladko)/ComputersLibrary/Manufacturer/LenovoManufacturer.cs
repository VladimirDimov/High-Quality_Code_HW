using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers
{
    public class LenovoManufacturer : IManufacturer
    {
        public PersonalComputer GetPersonalComputer()
        {
            var videoCard = new ColorfulVideoCard();
            var ram = new Ram(4);
            var motherboard = new Motherboard(ram, videoCard);
            var cpu = new Cpu64(2, motherboard);
            var reid = new HardDrive(2000);

            return new PersonalComputer(cpu, ram, videoCard, reid);
        }

        public Laptop GetLaptop()
        {
            var videoCard = new ColorfulVideoCard();
            var ram = new Ram(16);
            var motherboard = new Motherboard(ram, videoCard);
            var cpu = new Cpu64(2, motherboard);
            var hardDrive = new HardDrive(1000);
            var batery = new Battery();

            return new Laptop(cpu, ram, videoCard, hardDrive, batery);
        }

        public Server GetServer()
        {
            var videoCard = new MonochromeVideoCard();
            var ram = new Ram(8);
            var motherboard = new Motherboard(ram, videoCard);
            var cpu = new Cpu128(2, motherboard);
            var reid = new Reid();
            reid.AddDrive(new HardDrive(500));
            reid.AddDrive(new HardDrive(500));
            var batery = new Battery();

            return new Server(cpu, ram, videoCard, reid);
        }
    }
}
