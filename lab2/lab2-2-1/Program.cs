using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        double a, b, c;

        Console.WriteLine("Обчислення коренів квадратного рівняння ax² + bx + c = 0");

        a = ReadDouble("Введіть a: ");
        b = ReadDouble("Введіть b: ");
        c = ReadDouble("Введіть c: ");

        if (a == 0)
        {
            Console.WriteLine("Це не квадратне рівняння (a = 0).");
            return;
        }

        double d = b * b - 4 * a * c;
        Console.WriteLine($"Дискримінант D = {d}");

        if (d > 0)
        {
            double x1 = (-b + Math.Sqrt(d)) / (2 * a);
            double x2 = (-b - Math.Sqrt(d)) / (2 * a);
            Console.WriteLine($"Рівняння має два розв'язки: x₁ = {x1}, x₂ = {x2}");
        }
        else if (d == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Рівняння має один розв'язок: x = {x}");
        }
        else
        {
            Console.WriteLine("Рівняння не має дійсних розв'язків.");
        }
    }

    static double ReadDouble(string message)
    {
        double result;
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (double.TryParse(input, out result))
                return result;
            else
                Console.WriteLine("Помилка! Введіть коректне число.");
        }
    }
}

