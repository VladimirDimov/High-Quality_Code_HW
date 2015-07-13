namespace CohesionAndCoupling
{
    using System;

    public static class DistanceCalculator
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            var squareDistanceX = (x2 - x1) * (x2 - x1);
            var squareDistanceY = (y2 - y1) * (y2 - y1);
            double distance = Math.Sqrt(squareDistanceX + squareDistanceY);
            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            var squareDistanceX = (x2 - x1) * (x2 - x1);
            var squareDistanceY = (y2 - y1) * (y2 - y1);
            var squareDistanceZ = (z2 - z1) * (z2 - z1);

            double distance = Math.Sqrt(squareDistanceX + squareDistanceY + squareDistanceZ);
            return distance;
        }
    }
}
