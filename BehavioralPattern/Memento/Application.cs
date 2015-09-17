namespace Memento
{
    using System;

    class Application
    {
        static void Main()
        {
            var pesho = new Person("Petar", "Petrov", 30);
            Console.WriteLine(pesho.GetInfo());

            var saveOfPesho = pesho.Save();

            pesho.Age = 35;
            Console.WriteLine(pesho.GetInfo());

            pesho.Load(saveOfPesho);
            Console.WriteLine(pesho.GetInfo());
        }
    }
}
