using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Application
    {
        static void Main()
        {
            var person = new ProxyPerson("Pesho", "Petrov", 30);
            Console.WriteLine(person.FullName); // => Pesho Petrov

            person.FullName = "Gosho Goshev";
            Console.WriteLine(person.FirstName + " " + person.LastName); // => Gosho Goshev
        }
    }
}
