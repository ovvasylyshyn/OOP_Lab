using System;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Agle[] arr = AgleUtils.ReadArray();

        Console.WriteLine("\nПочатковий масив:");
        foreach (var a in arr) AgleUtils.PrintAgle(a);

        AgleUtils.SortArray(arr);
        Console.WriteLine("\nВідсортований масив:");
        foreach (var a in arr) AgleUtils.PrintAgle(a);

        if (arr.Length > 0)
        {
            Console.WriteLine("\nМодифікуємо перший елемент (+1° 15′):");
            AgleUtils.Modify(ref arr[0]);
            AgleUtils.PrintAgle(arr[0]);
        }

        AgleUtils.GetMinMax(arr, out Agle min, out Agle max);
        Console.WriteLine($"\nМінімальний: {min}");
        Console.WriteLine($"Максимальний: {max}");

        if (arr.Length > 0)
        {
            Console.WriteLine("\nСпроба поділити перший елемент на 0:");
            arr[0].Divide(0);
        }
    }
}
