using System;
using System.Text;
using lab7; 

namespace EntrantApp
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
                Console.WriteLine("2. Показати всіх (з вартістю навчання)");
                Console.WriteLine("3. Вивести вартість навчання окремо (таблицею)");
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
                        ShowTuitionTable(students);
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
                Console.WriteLine($"\n--- Студент №{i + 1} ---");

                Console.Write("Прізвище та ініціали: ");
                string name = Console.ReadLine();

                Console.Write("Ідентифікаційний код: ");
                string code = Console.ReadLine();

                Console.Write("Середній бал атестату: ");
                double avg = double.Parse(Console.ReadLine());

                Console.Write("Чи є медаль (1-так, 0-ні): ");
                bool medal = (Console.ReadLine() == "1");

                double monthlyPrice = InputTuition();

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

                array[i] = new Entrant(name, code, avg, medal, znoList, monthlyPrice);
            }
            return array;
        }

        public static double InputTuition()
        {
            Console.WriteLine("Введіть вартість навчання. Оберіть одиницю виміру:");
            Console.WriteLine(" 1 - грн/місяць");
            Console.WriteLine(" 2 - грн/рік (10 місяців)");
            Console.WriteLine(" 3 - грн/весь період (40 місяців)");
            Console.Write("Ваш вибір: ");

            int type = int.Parse(Console.ReadLine());
            Console.Write("Введіть суму: ");
            double inputAmount = double.Parse(Console.ReadLine());

            double finalMonthlyPrice = 0;

            switch (type)
            {
                case 1:
                    finalMonthlyPrice = inputAmount;
                    break;
                case 2:
                    finalMonthlyPrice = inputAmount / 10.0;
                    break;
                case 3:
                    finalMonthlyPrice = inputAmount / 40.0;
                    break;
                default:
                    Console.WriteLine("Невірний тип, вважаємо як за місяць.");
                    finalMonthlyPrice = inputAmount;
                    break;
            }
            return finalMonthlyPrice;
        }

        public static void ShowAll(Entrant[] array)
        {
            if (array == null)
            {
                Console.WriteLine("Список порожній.");
                return;
            }
            foreach (var st in array)
            {
                Console.WriteLine("----------------");
                Console.WriteLine(st.ToString());
            }
        }

        public static void ShowTuitionTable(Entrant[] array)
        {
            if (array == null) return;

            Console.WriteLine("\n{0,-20} | {1,-10} | {2,-10} | {3,-10}", "Прізвище", "Місяць", "Рік", "Всього");
            Console.WriteLine(new string('-', 60));

            foreach (var st in array)
            {
                Console.WriteLine("{0,-20} | {1,-10:F0} | {2,-10:F0} | {3,-10:F0}",
                    st.FullName, st.TuitionPerMonth, st.TuitionPerYear, st.TuitionTotal);
            }
        }
    }
}