using System;

public static class AgleUtils
{
    public static Agle[] ReadArray()
    {
        Console.Write("Введіть кількість елементів n: ");
        int n = int.Parse(Console.ReadLine() ?? "0");
        Agle[] arr = new Agle[n];

        Console.WriteLine("Введіть кути: градуси хвилини (через пробіл). Наприклад: 12 30");
        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                Console.Write($"[{i}] = ");
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Порожній ввід. Повторіть спробу");
                    continue;
                }

                string[] p = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (p.Length < 2)
                {
                    Console.WriteLine("Потрібно два числа: градуси і хвилини");
                    continue;
                }

                if (int.TryParse(p[0], out int d) && int.TryParse(p[1], out int m))
                {
                    try
                    {
                        arr[i] = new Agle(d, m);
                        break;
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine("Помилка: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Некоректні числа. Повторіть спробу");
                }
            }
        }
        return arr;
    }

    public static void PrintAgle(Agle a)
    {
        Console.WriteLine($"{a} | рад: {a.ToRadians():F6} | sin: {a.Sin():F6}");
    }

    public static void SortArray(Agle[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    Agle t = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = t;
                }
            }
        }
    }

    public static void Modify(ref Agle a)
    {
        a.Degrees += 1;
        a.Minutes += 15;
        a.Normalize();
    }

    public static void GetMinMax(Agle[] arr, out Agle min, out Agle max)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Масив порожній");

        min = arr[0];
        max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min) min = arr[i];
            if (arr[i] > max) max = arr[i];
        }
    }
}
