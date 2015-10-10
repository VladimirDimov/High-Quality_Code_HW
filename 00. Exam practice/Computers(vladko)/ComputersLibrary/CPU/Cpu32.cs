using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers
{
    public class Cpu32 : Cpu
    {
        public Cpu32(byte numberOfCores, IMotherboard motherboard)
            : base(numberOfCores, 32, motherboard)
        {

        }

        public override void SquareNumber()
        {
            var data = base.motherboard.LoadRamValue();

            if (data < 0)
            {
                base.motherboard.DrawOnVideoCard("Number too low.");
            }
            else if (data > 500)
            {
                base.motherboard.DrawOnVideoCard("Number too high.");
            }
            else
            {
                int value = 0;

                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                this.motherboard.DrawOnVideoCard(string.Format("Square of {0} is {1}.", data, value));
            }
        }
    }
}
