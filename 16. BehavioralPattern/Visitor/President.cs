using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitor
{
    public class President : Employee
    {
        public President(string name, decimal income, int vacationDays)
            :base(name, income, vacationDays)
        {
        }
    }
}
