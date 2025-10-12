using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введіть k: ");
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine("\nОберіть суму для обчислення:");
        Console.WriteLine("1. 1^n/2^2 + ... + k^k");
        Console.WriteLine("2. 1^k + 2^k + ... + n^k");
        Console.WriteLine("3. 1/n + 2/n² + 3/n³ + ... + k/n^k");
        Console.Write("\nВаш вибір: ");
        int choice = int.Parse(Console.ReadLine());

        double sum = 0;

        switch (choice)
        {
            case 1:
                for (int i = 1; i <= k; i++)
                {
                    sum += Math.Pow(i, n) / Math.Pow(i, 2);
                }
                Console.WriteLine($"\nСума 1 = {sum}");
                break;

            case 2:
                for (int i = 1; i <= n; i++)
                {
                    sum += Math.Pow(i, k);
                }
                Console.WriteLine($"\nСума 2 = {sum}");
                break;

            case 3:
                for (int i = 1; i <= k; i++)
                {
                    sum += i / Math.Pow(n, i);
                }
                Console.WriteLine($"\nСума 3 = {sum}");
                break;

            default:
                Console.WriteLine("\nНевірний вибір! Оберіть 1, 2 або 3.");
                break;
        }
    }
}
