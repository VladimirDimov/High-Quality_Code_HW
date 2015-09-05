using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class AnimalFactory
    {
        public AnimalFactory()
        {
        }

        public Animal CreateCat(string name)
        {
            return new Cat(name);
        }

        public Animal CreateDog(string name)
        {
            return new Dog(name);
        }

        public Animal CreateCow(string name)
        {
            return new Cow(name);
        }
    }
}
