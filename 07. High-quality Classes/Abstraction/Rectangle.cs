namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Rectangle.Width", "Width must be greater than 0.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Rectangle.Height", "Height must be greater than 0.");
                }

                this.height = value;
            }
        }

        public override double CalcPerimeter()
        {
            var perimeter = 2 * (this.Height + this.Width);
            return perimeter;
        }

        public override double CalcSurface()
        {
            var surface = this.Height * this.Width;
            return surface;
        }
    }
}