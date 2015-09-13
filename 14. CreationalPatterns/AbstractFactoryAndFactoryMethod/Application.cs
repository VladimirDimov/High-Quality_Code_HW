namespace FactoryMethod
{
    using FactoryMethod.AbstractFactory;
    using FactoryMethod.Units;
    using System;

    class Application
    {
        static void Main()
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("Testing Abstract factory");
            Console.WriteLine("=======================================================");
            var simpleFactory = new SimpleUnitFactory();
            var simpleMarine = simpleFactory.CreateMarine();
            var simpleTank = simpleFactory.CreateTank();

            simpleMarine.SpecialAbility();
            simpleTank.SpecialAbility();

            var superUnitsFactory = new SuperUnitFactory();
            var superMarine = superUnitsFactory.CreateMarine();
            var superTank = superUnitsFactory.CreateTank();

            superMarine.SpecialAbility();
            superTank.SpecialAbility();

            Console.WriteLine("");
            Console.WriteLine("=======================================================");
            Console.WriteLine("Testing Factory Method");
            Console.WriteLine("=======================================================");
            UnitFactoryMethod simpleMarineFactory = new SimpleMarineCreator();
            var simpleMarineOne = new SimpleMarine(1, 2, 3, 4);


        }
    }
}
