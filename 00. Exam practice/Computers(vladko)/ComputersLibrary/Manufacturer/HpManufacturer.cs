namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HpManufacturer : IManufacturer
    {

        public PersonalComputer GetPersonalComputer()
        {
            var videoCard = new ColorfulVideoCard();
            var ram = new Ram(2);
            var motherboard = new Motherboard(ram, videoCard);
            var cpu = new Cpu32(2, motherboard);
            var hardDrive = new HardDrive(500);

            return new PersonalComputer(cpu, ram, videoCard, hardDrive);
        }

        public Laptop GetLaptop()
        {
            var videoCard = new ColorfulVideoCard();
            var ram = new Ram(4);
            var motherboard = new Motherboard(ram, videoCard);
            var cpu = new Cpu64(2, motherboard);
            var hardDrive = new HardDrive(500);
            var batery = new Battery();

            return new Laptop(cpu, ram, videoCard, hardDrive, batery);
        }

        public Server GetServer()
        {
            var videoCard = new MonochromeVideoCard();
            var ram = new Ram(32);
            var motherboard = new Motherboard(ram, videoCard);
            var cpu = new Cpu32(4, motherboard);
            var batery = new Battery();
            var reid = new Reid();
            reid.AddDrive(new HardDrive(1000));
            reid.AddDrive(new HardDrive(1000));

            return new Server(cpu, ram, videoCard, reid);
        }
    }
}
