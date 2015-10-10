namespace Computers
{
    using System.Collections.Generic;

    public class DellManufacturer : IManufacturer
    {

        public PersonalComputer GetPersonalComputer()
        {
            var videoCard = new ColorfulVideoCard();
            var ram = new Ram(8);
            var motherboard = new Motherboard(ram, videoCard);
            var cpu = new Cpu64(4, motherboard);
            var reid = new HardDrive(1000);

            return new PersonalComputer(cpu, ram, videoCard, reid);
        }

        public Laptop GetLaptop()
        {
            var videoCard = new ColorfulVideoCard();
            var ram = new Ram(8);
            var motherboard = new Motherboard(ram, videoCard);
            var cpu = new Cpu32(4, motherboard);
            var hardDrive = new HardDrive(1000);
            var batery = new Battery();

            return new Laptop(cpu, ram, videoCard, hardDrive, batery);
        }

        public Server GetServer()
        {
            var videoCard = new MonochromeVideoCard();
            var ram = new Ram(64);
            var motherboard = new Motherboard(ram, videoCard);
            var cpu = new Cpu64(8, motherboard);
            var reid = new Reid();
            reid.AddDrive(new HardDrive(2000));
            reid.AddDrive(new HardDrive(2000));

            var batery = new Battery();

            return new Server(cpu, ram, videoCard, reid);
        }
    }
}
