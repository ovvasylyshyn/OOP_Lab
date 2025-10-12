using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть кількість елементів масиву n = ");
        int n = int.Parse(Console.ReadLine());

        double[] arr = new double[n];
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            arr[i] = Math.Round(rnd.NextDouble() * (18.3 + 14.2) - 14.2, 1);
        }

        Console.WriteLine("\nПочатковий масив:");
        PrintArray(arr);

        int minIndex = 0, maxIndex = 0;
        for (int i = 1; i < n; i++)
        {
            if (arr[i] < arr[minIndex]) minIndex = i;
            if (arr[i] > arr[maxIndex]) maxIndex = i;
        }

        Console.WriteLine($"\nМінімальний елемент = {arr[minIndex]} (індекс {minIndex})");
        Console.WriteLine($"Максимальний елемент = {arr[maxIndex]} (індекс {maxIndex})");

        int start = Math.Min(minIndex, maxIndex);
        int end = Math.Max(minIndex, maxIndex);

        int sumOfIndexes = 0;
        for (int i = start + 1; i < end; i++)
        {
            sumOfIndexes += i;
        }
        Console.WriteLine($"\nСума індексів елементів між мінімальним і максимальним = {sumOfIndexes}");

        for (int left = start + 1, right = end - 1; left < right; left++, right--)
        {
            double temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }

        Console.WriteLine("\nМасив після реверсу елементів між мінімальним і максимальним:");
        PrintArray(arr);
    }

    static void PrintArray(double[] arr)
    {
        foreach (double x in arr)
            Console.Write($"{x,6}");
        Console.WriteLine();
    }
}
