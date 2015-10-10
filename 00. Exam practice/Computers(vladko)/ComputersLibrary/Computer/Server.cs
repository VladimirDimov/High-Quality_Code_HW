using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers
{
    public class Server : Computer
    {
        public Server(Cpu cpu, Ram ram, VideoCard videoCard, Reid hardDrive)
            : base(cpu, ram, videoCard, hardDrive)
        {
        }
    }
}
