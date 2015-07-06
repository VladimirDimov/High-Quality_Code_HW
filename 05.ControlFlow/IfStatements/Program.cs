namespace IfStatements
{
    public class Program
    {
        public static bool ShouldVisitCell { get; set; }

        private static void Main()
        {
            // First statement ...
            Potato potato = new Potato();

            if (potato != null && potato.IsPeeled && !potato.IsRotten)
            {
                Cook(potato);
            }

            // Second statement
            const double MIN_X = 0;
            const double MAX_X = 10;
            const double MIN_Y = 0;
            const double MAX_Y = 10;

            double x = 3;
            double y = 5;

            if (IsInRange(x, MIN_X, MAX_X) && IsInRange(y, MIN_Y, MAX_Y) && ShouldVisitCell)
            {
                VisitCell();
            }
        }

        private static bool IsInRange(double checkedValue, double minValue, double maxValue)
        {
            if (minValue <= checkedValue && checkedValue <= maxValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void VisitCell()
        {
            throw new System.NotImplementedException();
        }

        private static void Cook(Potato potato)
        {
            throw new System.NotImplementedException();
        }
    }
}
