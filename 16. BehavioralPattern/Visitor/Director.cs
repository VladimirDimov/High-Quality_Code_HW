using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitor
{
    public class Director : Employee
    {
        public Director(string name, decimal income, int vacationDays)
            : base(name, income, vacationDays)
        {

        }
    }
}
