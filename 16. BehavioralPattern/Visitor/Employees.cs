using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitor
{
    public class Employees : IElementsGroup
    {
        private IList<Employee> employees;

        public Employees()
        {
            this.employees = new List<Employee>();
        }

        public void Add(IElement element)
        {
            this.employees.Add(element as Employee);
        }

        public void Remove(IElement element)
        {
            this.employees.Remove(element as Employee);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var employee in this.employees)
            {
                employee.Accept(visitor);
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            foreach (var item in this.employees)
            {
                output.AppendLine(item.ToString());
            }

            return output.ToString();
        }
    }
}
