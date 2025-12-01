using lab9;
using System;
using System.Text;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n=== МЕНЮ ===");
                Console.WriteLine("1. Завдання 1 (інтерфейс ITrigonometricFigure)");
                Console.WriteLine("2. Завдання 1 (абстрактний клас)");
                Console.WriteLine("3. Завдання 2 (організації)");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunInterfaceTask();
                        break;
                    case "2":
                        RunAbstractTask();
                        break;
                    case "3":
                        RunOrganizationTask();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір");
                        break;
                }
            }
        }

        static void RunInterfaceTask()
        {
            Console.WriteLine("\n--- Інтерфейси ---");
            ITrigonometricFigure[] figures = new ITrigonometricFigure[]
            {
                new Cube(5),
                new Sphere(3),
                new Cone(3, 10)
            };

            foreach (var fig in figures)
            {
                Console.WriteLine(fig.ToString());
            }
        }

        static void RunAbstractTask()
        {
            Console.WriteLine("\n--- Абстрактні класи ---");
            AbstractFigure[] figures = new AbstractFigure[]
            {
                new AbsCube(2),
                new AbsSphere(4),
                new AbsCone(2, 5)
            };

            foreach (var fig in figures)
            {
                Console.WriteLine(fig.ToString());
            }
        }

        static void RunOrganizationTask()
        {
            Console.WriteLine("\n--- Організації ---");

            OrganizationGroup group = new OrganizationGroup();
            group.Add(new Organization("google", 150000, 95.5));
            group.Add(new Organization("starlight", 50, 60.2));
            group.Add(new Organization("softServe", 12000, 88.0));
            group.Add(new Organization("epam", 40000, 85.5));
            group.Add(new Organization("startup", 5, 99.9));

            Console.WriteLine("\n1. Список без сортування:");
            foreach (var org in group)
            {
                Console.WriteLine(org);
            }

            Console.WriteLine("\n2. Сортування за кількістю працівників (IComparable - CompareTo):");
            group.SortDefault(); 
            foreach (var org in group)
            {
                Console.WriteLine(org);
            }

            Console.WriteLine("\n3. Сортування за РЕЙТИНГОМ (IComparer):");
            group.Sort(new SortByRating()); 
            foreach (var org in group)
            {
                Console.WriteLine(org);
            }

            Console.WriteLine("\n4. Сортування за кількістю працівників (через окремий IComparer):");
            group.Sort(new SortByEmployees());
            foreach (var org in group)
            {
                Console.WriteLine(org);
            }
        }
    }
}