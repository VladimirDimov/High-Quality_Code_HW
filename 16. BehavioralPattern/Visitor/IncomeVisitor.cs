namespace Visitor
{
    public class IncomeVisitor : IVisitor
    {
        public void Visit(IElement element)
        {
            var employee = element as Employee;
            employee.Income *= 1.2m;
        }
    }
}
