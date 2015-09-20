using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public abstract class Employee : IElement
    {
        public Employee(string name, decimal income, int vacationDays)
        {
            this.Name = name;
            this.Income = income;
            this.VacationDays = vacationDays;
        }

        public string Name
        {
            get;
            set;
        }

        public decimal Income
        {
            get;
            set;
        }

        public int VacationDays
        {
            get;
            set;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return this.Name + ", Income: " + this.Income + ", Vacation days: " + this.VacationDays;
        }
    }
}
