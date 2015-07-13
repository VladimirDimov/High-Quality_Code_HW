namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Circle radius must be grater than 0.");
                }

                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            var perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            var surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
