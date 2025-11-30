using lab6;
using System;
using System.Text;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Entrant[] students = null; 

            while (true)
            {
                Console.WriteLine("\n=== МЕНЮ ===");
                Console.WriteLine("1. Створити список абітурієнтів");
                Console.WriteLine("2. Показати всіх");
                Console.WriteLine("3. Показати одного (за кодом)");
                Console.WriteLine("4. Найкращий предмет кожного");
                Console.WriteLine("5. Хто в топі рейтингу");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        students = CreateArray();
                        break;
                    case "2":
                        ShowAll(students);
                        break;
                    case "3":
                        ShowOne(students);
                        break;
                    case "4":
                        ShowBestSubjects(students);
                        break;
                    case "5":
                        ShowTopRating(students);
                        break;
                    case "0":
                        return; 
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        public static Entrant[] CreateArray()
        {
            Console.Write("Введіть кількість студентів: ");
            int n = int.Parse(Console.ReadLine());

            Entrant[] array = new Entrant[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nСтудент №" + (i + 1));

                Console.Write("Прізвище та ініціали: ");
                string name = Console.ReadLine();

                Console.Write("Ідентифікаційний код: ");
                string code = Console.ReadLine();

                Console.Write("Середній бал атестату (через кому, напр. 4,5): ");
                double avg = double.Parse(Console.ReadLine());

                Console.Write("Чи є медаль (1-так, 0-ні): ");
                bool medal = (Console.ReadLine() == "1");

                Console.Write("Кількість предметів ЗНО: ");
                int znoCount = int.Parse(Console.ReadLine());

                ZNO[] znoList = new ZNO[znoCount];
                for (int j = 0; j < znoCount; j++)
                {
                    Console.Write("  Предмет: ");
                    string subjName = Console.ReadLine();
                    Console.Write("  Бал: ");
                    double subjPoints = double.Parse(Console.ReadLine());

                    znoList[j] = new ZNO(subjName, subjPoints);
                }

                array[i] = new Entrant(name, code, avg, medal, znoList);
            }
            return array;
        }

        public static void ShowAll(Entrant[] array)
        {
            if (array == null)
            {
                Console.WriteLine("Список порожній. Спочатку створіть його (пункт 1).");
                return;
            }

            foreach (var st in array)
            {
                Console.WriteLine("----------------");
                Console.WriteLine(st.ToString());
            }
        }

        public static void ShowOne(Entrant[] array)
        {
            if (array == null)
            {
                Console.WriteLine("Список порожній.");
                return;
            }
            Console.Write("Введіть номер (від 1 до " + array.Length + "): ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < array.Length)
            {
                Console.WriteLine(array[index].ToString());
            }
            else
            {
                Console.WriteLine("Невірний номер.");
            }
        }

        public static void ShowBestSubjects(Entrant[] array)
        {
            if (array == null) return;
            foreach (var st in array)
            {
                Console.WriteLine(st.FullName + ": найкращий предмет - " + st.GetBestSubject());
            }
        }

        public static void ShowTopRating(Entrant[] array)
        {
            if (array == null) return;
            Console.WriteLine("Студенти з медаллю та балом >= 4.9:");

            bool found = false;
            foreach (var st in array)
            {
                if (st.IsOnTopOfTheRating())
                {
                    Console.WriteLine("- " + st.FullName);
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Таких немає.");
        }
    }
}