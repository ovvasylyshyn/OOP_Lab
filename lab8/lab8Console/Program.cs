using lab8; 
using System;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n=== ГОЛОВНЕ МЕНЮ ===");
                Console.WriteLine("1. Робота з тваринами");
                Console.WriteLine("2. Робота з дробами");
                Console.WriteLine("0. Вихід");
                Console.Write("Оберіть завдання: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunAnimalsDemo();
                        break;
                    case "2":
                        RunFractionsDemo();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        static void RunAnimalsDemo()
        {
            Console.WriteLine("\n--- Демонстрація тварин ---");

            Animal[] zoo = new Animal[4];

            zoo[0] = new Fish(2, 0.5, "Female", false); 
            zoo[1] = new Fish(5, 12.0, true);           
            zoo[2] = new Bird(3, 1.2, "Male", true);   
            zoo[3] = new Bird(1, 4.5, false);           

            Console.WriteLine("Інформація про всіх тварин:");
            foreach (var animal in zoo)
            {
                animal.ShowInfo(); 
            }

            Console.WriteLine("\nЗмінюємо параметри...");
            ((Fish)zoo[0]).ChangeWaterType();
            ((Bird)zoo[2]).ChangeFlightAbility(false); 

            zoo[0].SetAge(3); 
            zoo[0].ShowInfo();
            zoo[2].ShowInfo();

            Console.WriteLine("\nПорівняння об'єктів:");
            Fish f1 = new Fish(1, 1, "Male", true);
            Fish f2 = new Fish(1, 1, "Male", true);
            Console.WriteLine($"Риба 1 дорівнює Рибі 2? Відповідь: {f1.Equals(f2)}");
        }

        static void RunFractionsDemo()
        {
            Console.WriteLine("\n--- Демонстрація дробів ---");

            try
            {
                Fraction a = new Fraction(1, 2); 
                Fraction b = new Fraction(3, 4); 
                Fraction c = new Fraction(20, 6);

                Console.WriteLine($"Дріб A: {a}");
                Console.WriteLine($"Дріб B: {b}");
                Console.WriteLine($"Дріб C (автоскорочення 20/6): {c}");

                Console.WriteLine($"\nСума (A + B): {a + b}");
                Console.WriteLine($"Різниця (B - A): {b - a}");
                Console.WriteLine($"Множення (A * C): {a * c}");
                Console.WriteLine($"Ділення (A / B): {a / b}");
                Console.WriteLine($"Унарний мінус (-A): {-a}");

                Console.WriteLine("\nПорівняння:");
                Console.WriteLine($"A > B? {a > b}");
                Console.WriteLine($"A < B? {a < b}");
                Console.WriteLine($"A == 0.5 (приблизно)? {(double)a == 0.5}");

                Console.WriteLine($"\nПриведення до double (3/4): {(double)b}");

                Fraction d = new Fraction(100, 200);
                Console.WriteLine($"\nДріб 100/200 до скорочення: {d}");
                d.Reduce();
                Console.WriteLine($"Після Reduce(): {d}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}