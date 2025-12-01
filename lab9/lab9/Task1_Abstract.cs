using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public abstract class AbstractFigure
    {
        public abstract double GetVolume();
    }

    public class AbsCube : AbstractFigure
    {
        private double side;
        public AbsCube(double side) => this.side = side;

        public override double GetVolume() => Math.Pow(side, 3);

        public override string ToString() => $"[Abs] Куб (сторона {side}), V = {GetVolume():F2}";
    }

    public class AbsSphere : AbstractFigure
    {
        private double radius;
        public AbsSphere(double radius) => this.radius = radius;

        public override double GetVolume() => (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);

        public override string ToString() => $"[Abs] Сфера (радіус {radius}), V = {GetVolume():F2}";
    }

    public class AbsCone : AbstractFigure
    {
        private double radius;
        private double height;
        public AbsCone(double radius, double height)
        {
            this.radius = radius;
            this.height = height;
        }

        public override double GetVolume() => (1.0 / 3.0) * Math.PI * Math.Pow(radius, 2) * height;

        public override string ToString() => $"[Abs] Конус (R={radius}, H={height}), V = {GetVolume():F2}";
    }
}
