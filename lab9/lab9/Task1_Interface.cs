using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public interface ITrigonometricFigure
    {
        double GetVolume();
    }

    public class Cube : ITrigonometricFigure
    {
        private double side;

        public Cube(double side)
        {
            this.side = side;
        }

        public double GetVolume()
        {
            return Math.Pow(side, 3);
        }

        public override string ToString() => $"Куб (сторона {side}), V = {GetVolume():F2}";
    }

    public class Sphere : ITrigonometricFigure
    {
        private double radius;

        public Sphere(double radius)
        {
            this.radius = radius;
        }

        public double GetVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
        }

        public override string ToString() => $"Сфера (радіус {radius}), V = {GetVolume():F2}";
    }

    public class Cone : ITrigonometricFigure
    {
        private double radius;
        private double height;

        public Cone(double radius, double height)
        {
            this.radius = radius;
            this.height = height;
        }

        public double GetVolume()
        {
            return (1.0 / 3.0) * Math.PI * Math.Pow(radius, 2) * height;
        }

        public override string ToString() => $"Конус (R={radius}, H={height}), V = {GetVolume():F2}";
    }
}
