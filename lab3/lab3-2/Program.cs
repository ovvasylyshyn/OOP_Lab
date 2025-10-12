using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть кількість рядків n = ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введіть кількість стовпців m = ");
        int m = int.Parse(Console.ReadLine());

        double[,] arr = new double[n, m];
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                arr[i, j] = Math.Round(rnd.NextDouble() * (110.35 + 110.34) - 110.34, 2);
            }
        }

        Console.WriteLine("\nПочатковий масив:");
        PrintArray(arr);

        double[] maxInColumns = new double[m];
        for (int j = 0; j < m; j++)
        {
            double max = arr[0, j];
            for (int i = 1; i < n; i++)
            {
                if (arr[i, j] > max)
                    max = arr[i, j];
            }
            maxInColumns[j] = max;
        }

        Console.WriteLine("\nНайбільші елементи у кожному стовпці:");
        foreach (double val in maxInColumns)
            Console.Write($"{val,8}");

        double minAmongMax = maxInColumns[0];
        for (int j = 1; j < m; j++)
        {
            if (maxInColumns[j] < minAmongMax)
                minAmongMax = maxInColumns[j];
        }

        Console.WriteLine($"\n\nНайменший серед найбільших елементів стовпців = {minAmongMax}");

        for (int i = 0; i < n; i++)
        {
            int left = 0, right = m - 1;
            while (left < right)
            {
                double temp = arr[i, left];
                arr[i, left] = arr[i, right];
                arr[i, right] = temp;
                left++;
                right--;
            }
        }

        Console.WriteLine("\nМасив після реверсу рядків:");
        PrintArray(arr);
    }

    static void PrintArray(double[,] arr)
    {
        int n = arr.GetLength(0);
        int m = arr.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write($"{arr[i, j],8}");
            Console.WriteLine();
        }
    }
}
