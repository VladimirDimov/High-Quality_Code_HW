
namespace Composite
{
    using System;
    using Composite.Units;
    class Application
    {
        static void Main()
        {
            Commander commander = new Commander("Mr Pesho");
            commander.AddUnit(new Marine("Gosho"));
            commander.AddUnit(new Marine("Ivan"));
            commander.AddUnit(new Trooper("Toncho"));
            commander.AddUnit(new Trooper("Penko"));

            Console.WriteLine("======================");
            Console.WriteLine(commander.GetInfo());
            Console.WriteLine("======================");
        }
    }
}
