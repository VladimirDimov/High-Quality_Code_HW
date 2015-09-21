using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Command
{
    class Application
    {
        static void Main()
        {
            var user = new User(new PlayField(10));

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        user.Move(Directions.UP);
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        user.Move(Directions.DOWN);
                    }
                    else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        user.Move(Directions.LEFT);
                    }
                    else if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        user.Move(Directions.RIGHT);
                    }
                    else if (keyInfo.Key == ConsoleKey.U)
                    {
                        user.Undo();
                    }
                }
            }
        }
    }
}
