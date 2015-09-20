namespace Visitor
{
    public class VacationDaysVisitor : IVisitor
    {
        public void Visit(IElement element)
        {
            var employee = element as Employee;
            employee.VacationDays += 3;
        }
    }
}
