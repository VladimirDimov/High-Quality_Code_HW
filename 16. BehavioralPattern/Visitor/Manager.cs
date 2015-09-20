using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitor
{
    public class Manager : Employee
    {
        public Manager(string name, decimal income, int vacationDays)
            : base(name, income, vacationDays)
        {

        }
    }
}
