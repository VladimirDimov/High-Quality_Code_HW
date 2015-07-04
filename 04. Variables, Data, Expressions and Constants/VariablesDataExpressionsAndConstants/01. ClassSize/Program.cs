using System;

public class Size
{
    private double width;
    private double height;

    public Size(double w, double h)
    {
        this.Width = w;
        this.Height = h;
    }

    public double Width
    {
        get
        {
            return this.width;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width must be greater than zero.");
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

        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height must be greater than zero.");
            }

            this.height = value;
        }
    }

    public static Size GetRotatedSize(Size s, double angleOfTheFigureThatWillBeRotaed)
    {
        double sinOfAngleOfRotation = Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed));
        double cosOfAngleOfRotation = Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed));

        double widthProjection = (cosOfAngleOfRotation * s.width) + (sinOfAngleOfRotation * s.height);
        double heightProjection = (sinOfAngleOfRotation * s.width) + (cosOfAngleOfRotation * s.height);

        return new Size(widthProjection, heightProjection);
    }
}