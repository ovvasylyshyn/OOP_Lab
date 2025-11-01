using System;
using System.Collections.Generic;
using System.Linq;

namespace lab5
{
    internal class Program
    {
        private const string FilePath = "disciplines.txt";

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("1. Додати запис");
                Console.WriteLine("2. Показати всі записи");
                Console.WriteLine("3. Пошук за прізвищем викладача");
                Console.WriteLine("4. Пошук за назвою дисципліни");
                Console.WriteLine("5. Пошук за наявністю курсової");
                Console.WriteLine("6. Пошук за номером семестру");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddRecord();
                        break;
                    case "2": ShowAll(); 
                        break;
                    case "3": SearchByTeacher(); 
                        break;
                    case "4": SearchByDiscipline();
                        break;
                    case "5": SearchByCourseWork();
                        break;
                    case "6": SearchBySemester();
                        break;
                    case "0": return;
                    default: Console.WriteLine("Невірний вибір");
                        break;
                }
            }
        }

        static void AddRecord()
        {
            DisciplineInfo d = new DisciplineInfo();

            Console.Write("Назва дисципліни: ");
            d.DisciplineName = Console.ReadLine();

            Console.Write("ПІБ викладача: ");
            d.TeacherFullName = Console.ReadLine();

            Console.Write("Назва групи: ");
            d.GroupName = Console.ReadLine();

            Console.Write("Кількість студентів: ");
            d.StudentsCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Вид контролю: 1 - Екзамен, 2 - Залік, 3 - Диференційований залік");
            d.FinalControl = (FinalControlType)int.Parse(Console.ReadLine());

            Console.Write("Є курсова робота (так/ні, yes/no): ");
            string input = Console.ReadLine().Trim().ToLower();
            d.HasCourseWork = input == "так" || input == "yes" || input == "y";

            Console.Write("Назва спеціальності: ");
            d.SpecialtyName = Console.ReadLine();

            Console.Write("Номер семестру: ");
            d.SemesterNumber = int.Parse(Console.ReadLine());

            FileStore.Append(FilePath, d);
            Console.WriteLine("Запис додано");
        }

        static void ShowAll()
        {
            var list = FileStore.ReadAll(FilePath);
            if (list.Count == 0)
            {
                Console.WriteLine("Файл порожній або відсутній");
                return;
            }

            foreach (var d in list)
            {
                Console.WriteLine("   ");
                Console.WriteLine(d);
            }
        }

        static void SearchByTeacher()
        {
            Console.Write("Введіть прізвище викладача: ");
            string surname = Console.ReadLine();
            var list = FileStore.ReadAll(FilePath)
                .Where(x => x.TeacherSurname.Equals(surname, StringComparison.OrdinalIgnoreCase))
                .ToList();
            PrintResults(list);
        }

        static void SearchByDiscipline()
        {
            Console.Write("Введіть назву дисципліни: ");
            string name = Console.ReadLine();
            var list = FileStore.ReadAll(FilePath)
                .Where(x => x.DisciplineName.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
            PrintResults(list);
        }

        static void SearchByCourseWork()
        {
            Console.Write("Є курсова робота (так/ні, yes/no): ");
            string input = Console.ReadLine().Trim().ToLower();

            bool has = input == "так" || input == "yes" || input == "y";

            var list = FileStore.ReadAll(FilePath)
                .Where(x => x.HasCourseWork == has)
                .ToList();

            PrintResults(list);
        }

        static void SearchBySemester()
        {
            Console.Write("Введіть номер семестру: ");
            int sem = int.Parse(Console.ReadLine());
            var list = FileStore.ReadAll(FilePath)
                .Where(x => x.SemesterNumber == sem)
                .ToList();
            PrintResults(list);
        }

        static void PrintResults(List<DisciplineInfo> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("   ");
                Console.WriteLine("Нічого не знайдено");
                return;
            }
            Console.WriteLine($"\nЗнайдено {list.Count} записів:");
            foreach (var d in list)
            {
                Console.WriteLine("   ");
                Console.WriteLine(d);
            }
        }
    }
}
