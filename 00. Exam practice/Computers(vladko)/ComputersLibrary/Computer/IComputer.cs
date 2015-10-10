namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IComputer
    {
        Cpu Cpu { get; }

        Ram Ram { get; }

        VideoCard VideoCard { get; }

        IDrive HardDrive { get; }
    }
}
