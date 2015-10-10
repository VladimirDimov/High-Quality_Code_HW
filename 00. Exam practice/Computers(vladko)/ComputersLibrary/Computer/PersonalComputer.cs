using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers
{
    public class PersonalComputer : Computer
    {
        public PersonalComputer(Cpu cpu, Ram ram, VideoCard videoCard, HardDrive hardDrive)
            : base(cpu, ram, videoCard, hardDrive)
        {
        }

        public void Play(int guessNumber)
        {
            Cpu.rand(1, 10);
            var number = Ram.LoadValue();
            if (number + 1 != guessNumber + 1)
            {
                VideoCard.Draw(string.Format("You didn't guess the number {0}.", number));
            }

            else VideoCard.Draw("You win!");
        }
    }
}
