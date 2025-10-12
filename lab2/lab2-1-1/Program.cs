using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        double x, y, z;
        Console.Write("Введіть x: ");
        if (!double.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("x введено неправильно");
            return;
        }

        Console.Write("Введіть y: ");
        if (!double.TryParse(Console.ReadLine(), out y))
        {
            Console.WriteLine("y введено неправильно");
            return;
        }

        Console.Write("Введіть z: ");
        if (!double.TryParse(Console.ReadLine(), out z))
        {
            Console.WriteLine("z введено неправильно");
            return;
        }

        if (x == y)
        {
            Console.WriteLine("помилка ділення на 0 (х=у)");
            return;
        }

        if (z <= 0)
        {
            Console.WriteLine("z має бути > 0");
            return;
        }

        double s = Math.Round((y - x) * ((Math.Cos(y) - Math.Log(z) / (x - y)) / (1 + Math.Pow(x - z, 2))), 3);
        Console.WriteLine($"s = {s}");
    }
}