using System.Collections.Generic;

namespace Computers
{   
    public class Computer : IComputer
    {       
        public Computer(Cpu cpu, Ram ram, VideoCard videoCard, IDrive reid)
        {
            Cpu = cpu;
            Ram = ram;
            HardDrive = reid;
            VideoCard = videoCard;
        }

        public IDrive HardDrive { get; set; }

        public VideoCard VideoCard { get; set; }

        public Cpu Cpu { get; set; }

        public Ram Ram { get; set; }

        public void Process(int data)
        {
            Ram.SaveValue(data);
            // TODO: Fix it
            Cpu.SquareNumber();
        }
    }
}
