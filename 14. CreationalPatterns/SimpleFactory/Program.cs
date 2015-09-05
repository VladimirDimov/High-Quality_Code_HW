namespace UserInterface
{
    using Animals;
    using System;

    class Program
    {
        static void Main()
        {
            var animalFactory = new AnimalFactory();

            var dog = animalFactory.CreateDog("Sharo");
            var cat = animalFactory.CreateCat("MissPiss");
            var cow = animalFactory.CreateCow("MissMu");

            Console.WriteLine(dog.Say());
            Console.WriteLine(cat.Say());
            Console.WriteLine(cow.Say());
        }
    }
}
