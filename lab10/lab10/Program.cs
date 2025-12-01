using lab10;
using System;
using System.Collections.Generic; 
using System.Text;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n=== ЛАБОРАТОРНА РОБОТА 10 ===");
                Console.WriteLine("1. Завдання 1: Клас List");
                Console.WriteLine("2. Завдання 2: Клас Dictionary");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DemoList();
                        break;
                    case "2":
                        DemoDictionary();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        static void DemoList()
        {
            Console.WriteLine("\n--- Демонстрація класу List<T> ---");

            List<string> cities = new List<string>();

            Console.WriteLine("[1] Додавання елементів");
            cities.Add("ternopil");
            cities.Add("Львів");
            cities.Add("Одеса");
            cities.Add("Харків");
            cities.Add("Дніпро");

            Console.WriteLine("Список міст:");
            foreach (var city in cities)
            {
                Console.WriteLine(" - " + city);
            }

            Console.Write("\n[2] Пошук. Введіть назву міста: ");
            string search = Console.ReadLine();

            if (cities.Contains(search))
            {
                Console.WriteLine($" - Місто '{search}' є у списку.");
            }
            else
            {
                Console.WriteLine($" - Місто '{search}' не знайдено.");
            }

            Console.WriteLine($"\n[3] Кількість міст: {cities.Count}");

            Console.WriteLine("\n[4] Видаляємо 'Київ'");
            cities.Remove("Київ");

            Console.WriteLine("Список після видалення:");
            foreach (var c in cities) Console.Write(c + " ");
            Console.WriteLine();

            Console.WriteLine("\n[5] Очищення списку...");
            cities.Clear();
            Console.WriteLine($"Кількість після Clear: {cities.Count}");
        }

        static void DemoDictionary()
        {
            Console.WriteLine("\n--- Демонстрація класу Dictionary<TKey, TValue> ---");

            Dictionary<string, Entrant> students = new Dictionary<string, Entrant>();

            Entrant s1 = new Entrant("Василишин В.О.", "1", 4.5);
            Entrant s2 = new Entrant("Брянка В.А.", "2", 4.9);
            Entrant s3 = new Entrant("Бриндьо О.В.", "3", 5.0);

            Console.WriteLine("[1] Додавання у словник");
            try
            {
                students.Add(s1.IdNum, s1);
                students.Add(s2.IdNum, s2);
                students.Add(s3.IdNum, s3);
                Console.WriteLine(" - Додано 3 студентів");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Помилка: Такий ключ вже існує!");
            }

            Console.WriteLine("\nВміст словника:");
            foreach (var item in students)
            {
                Console.WriteLine($"Ключ: {item.Key} - {item.Value.FullName}");
            }

            Console.Write("\n[2] Введіть ID код для пошуку: ");
            string id = Console.ReadLine();

            if (students.ContainsKey(id))
            {
                Console.WriteLine(" - Знайдено: " + students[id].ToString());
            }
            else
            {
                Console.WriteLine(" - Студента з таким ID немає");
            }

            Console.WriteLine($"\n[3] Всього записів: {students.Count}");

            Console.WriteLine("\n[4] Видаляємо студента з ID '2'");
            students.Remove("2");

            if (!students.ContainsKey("2"))
            {
                Console.WriteLine(" - Видалено успішно");
            }

            Console.WriteLine("\n[5] Очищення бази...");
            students.Clear();
            Console.WriteLine($"Кількість записів: {students.Count}");
        }
    }
}