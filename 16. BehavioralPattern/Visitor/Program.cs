namespace Visitor
{
    using System;

    class Program
    {
        static void Main()
        {
            var president = new President("Gosho", 3000, 30);
            var director = new Director("Pesho", 2000, 25);
            var manager = new Manager("Toncho", 1000, 20);

            var employees = new Employees();
            employees.Add(president);
            employees.Add(director);
            employees.Add(manager);

            Console.WriteLine(employees.ToString());

            employees.Accept(new IncomeVisitor());
            employees.Accept(new VacationDaysVisitor());

            Console.WriteLine(employees.ToString());            
        }
    }
}
