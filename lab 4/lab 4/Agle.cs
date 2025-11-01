using System;

public struct Agle
{
    public int Degrees;
    public int Minutes;

    public Agle(int degrees, int minutes)
    {
        Degrees = 0;
        Minutes = 0;
        try
        {
            if (degrees < 0 || minutes < 0)
                throw new ArgumentOutOfRangeException("Градуси та хвилини не можуть бути від’ємними");
            Degrees = degrees;
            Minutes = minutes;
        }
        catch (ArgumentOutOfRangeException)
        {
            throw;
        }
        finally
        {
            NormalizeSelf(ref Degrees, ref Minutes);
        }
    }

    public Agle(double decimalDegrees)
    {
        Degrees = 0;
        Minutes = 0;
        try
        {
            double totalMinutes = decimalDegrees * 60.0;
            int wholeMinutes = (int)Math.Round(totalMinutes, MidpointRounding.AwayFromZero);
            Degrees = wholeMinutes / 60;
            Minutes = wholeMinutes % 60;
        }
        catch
        {
            Degrees = 0;
            Minutes = 0;
        }
        finally
        {
            NormalizeSelf(ref Degrees, ref Minutes);
        }
    }

    public static Agle FromRadians(double radians)
    {
        double deg = radians * 180.0 / Math.PI;
        return new Agle(deg);
    }

    public double ToRadians()
    {
        double d = Degrees + Minutes / 60.0;
        return d * Math.PI / 180.0;
    }

    public double Sin()
    {
        return Math.Sin(ToRadians());
    }

    public void Normalize()
    {
        NormalizeSelf(ref Degrees, ref Minutes);
    }

    public void Add(int d, int m)
    {
        int total = TotalMinutes(Degrees, Minutes) + TotalMinutes(d, m);
        FromTotalMinutes(total, out Degrees, out Minutes);
        NormalizeSelf(ref Degrees, ref Minutes);
    }

    public void Subtract(int d, int m)
    {
        int total = TotalMinutes(Degrees, Minutes) - TotalMinutes(d, m);
        FromTotalMinutes(total, out Degrees, out Minutes);
        NormalizeSelf(ref Degrees, ref Minutes);
    }

    public void Divide(double divisor)
    {
        try
        {
            if (divisor == 0.0)
                throw new DivideByZeroException("Не можна ділити на 0");

            double dec = Degrees + Minutes / 60.0;
            double res = dec / divisor;
            int totalMin = (int)Math.Round(res * 60.0, MidpointRounding.AwayFromZero);
            FromTotalMinutes(totalMin, out Degrees, out Minutes);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
        finally
        {
            NormalizeSelf(ref Degrees, ref Minutes);
        }
    }

    public static bool operator >(Agle a, Agle b)
    {
        return TotalMinutes(a.Degrees, a.Minutes) > TotalMinutes(b.Degrees, b.Minutes);
    }

    public static bool operator <(Agle a, Agle b)
    {
        return TotalMinutes(a.Degrees, a.Minutes) < TotalMinutes(b.Degrees, b.Minutes);
    }

    public static bool operator >=(Agle a, Agle b)
    {
        return TotalMinutes(a.Degrees, a.Minutes) >= TotalMinutes(b.Degrees, b.Minutes);
    }

    public static bool operator <=(Agle a, Agle b)
    {
        return TotalMinutes(a.Degrees, a.Minutes) <= TotalMinutes(b.Degrees, b.Minutes);
    }

    public static bool operator ==(Agle a, Agle b)
    {
        return TotalMinutes(a.Degrees, a.Minutes) == TotalMinutes(b.Degrees, b.Minutes);
    }

    public static bool operator !=(Agle a, Agle b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Agle)) return false;
        Agle other = (Agle)obj;
        return this == other;
    }

    public override int GetHashCode()
    {
        return TotalMinutes(Degrees, Minutes);
    }

    public override string ToString()
    {
        return $"{Degrees}° {Minutes:00}′";
    }

    private static int TotalMinutes(int d, int m)
    {
        return d * 60 + m;
    }

    private static void FromTotalMinutes(int totalMinutes, out int d, out int m)
    {
        d = totalMinutes / 60;
        m = totalMinutes % 60;
    }

    private static void NormalizeSelf(ref int d, ref int m)
    {
        if (m >= 60 || m < 0)
        {
            d += m / 60;
            m = m % 60;
            if (m < 0) { m += 60; d -= 1; }
        }

        int mod = 360;
        d = d % mod;
        if (d < 0) d += mod;
    }
}
