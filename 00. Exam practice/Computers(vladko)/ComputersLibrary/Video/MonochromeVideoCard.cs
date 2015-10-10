using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers
{
    public class MonochromeVideoCard : VideoCard
    {
        public override void Draw(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
