using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers
{
    public class Cpu128 : Cpu
    {
        public Cpu128(byte numberOfCores, IMotherboard motherboard)
            : base(numberOfCores, 128, motherboard)
        {

        }

        public override void SquareNumber()
        {
            var data = this.motherboard.LoadRamValue();

            if (data < 0)
            {
                this.motherboard.DrawOnVideoCard("Number too low.");
            }
            else if (data > 2000)
            {
                this.motherboard.DrawOnVideoCard("Number too high.");
            }
            else
            {
                int square = data * data;
                this.motherboard.DrawOnVideoCard(string.Format("Square of {0} is {1}.", data, square));
            }
        }
    }
}
