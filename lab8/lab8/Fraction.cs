using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public class Fraction
    {
        private int numerator;   
        private int denominator; 

        public Fraction()
        {
            numerator = 0;
            denominator = 1;
        }

        public Fraction(int num, int den)
        {
            if (den == 0)
                throw new ArgumentException("Знаменник не може бути нулем!");

            numerator = num;
            denominator = den;
            Reduce(); 
        }

        public Fraction(Fraction other)
        {
            this.numerator = other.numerator;
            this.denominator = other.denominator;
        }

        public void Reduce()
        {
            int gcd = GetGCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }

        private int GetGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.numerator, a.denominator);

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.denominator - b.numerator * a.denominator, a.denominator * b.denominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.numerator == 0) throw new DivideByZeroException("Ділення на нуль.");
            return new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return (double)a > (double)b;
        }
        public static bool operator <(Fraction a, Fraction b)
        {
            return (double)a < (double)b;
        }
        public static bool operator >=(Fraction a, Fraction b)
        {
            return (double)a >= (double)b;
        }
        public static bool operator <=(Fraction a, Fraction b)
        {
            return (double)a <= (double)b;
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return (a.numerator * b.denominator) == (b.numerator * a.denominator);
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction f)
                return this == f;
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(numerator, denominator);
        }

        public static explicit operator double(Fraction f)
        {
            return (double)f.numerator / f.denominator;
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }
    }
}
