using System;
using System.Text;
using ClassLibraryStudent;
using ClassLibraryAcademyGroup;

namespace MainApp
{
    class Main_Class
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Academy_Group group = new Academy_Group();
            string path = "students.txt";

            while (true)
            {
                try
                {
                    Console.WriteLine("\n=== МЕНЮ ===");
                    Console.WriteLine("1. Додати студента");
                    Console.WriteLine("2. Видалити студента");
                    Console.WriteLine("3. Редагувати студента");
                    Console.WriteLine("4. Показати всіх студентів");
                    Console.WriteLine("5. Пошук студента");
                    Console.WriteLine("6. Зберегти у файл");
                    Console.WriteLine("7. Завантажити з файлу");
                    Console.WriteLine("8. Сортування групи");
                    Console.WriteLine("9. Створити клон групи");
                    Console.WriteLine("10. Перебір через IEnumerator (foreach)");
                    Console.WriteLine("0. Вихід");
                    Console.Write("Ваш вибір: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddStudent(group);
                            break;

                        case "2":
                            Console.Write("Введіть прізвище для видалення: ");
                            group.Remove(Console.ReadLine());
                            break;

                        case "3":
                            EditStudent(group);
                            break;

                        case "4":
                            group.Print();
                            break;

                        case "5":
                            Console.Write("Введіть прізвище для пошуку: ");
                            var st = group.Search(Console.ReadLine());
                            if (st != null) st.Print();
                            else Console.WriteLine("Не знайдено.");
                            break;

                        case "6":
                            group.Save(path);
                            Console.WriteLine("Збережено.");
                            break;

                        case "7":
                            group.Load(path);
                            Console.WriteLine("Завантажено.");
                            break;

                        case "8":
                            Console.WriteLine("\nОберіть критерій сортування:");
                            Console.WriteLine("1. За прізвищем");
                            Console.WriteLine("2. За віком");
                            Console.WriteLine("3. За GPA");
                            Console.WriteLine("4. За номером групи");
                            Console.Write("Ваш вибір: ");

                            string sortChoice = Console.ReadLine();

                            switch (sortChoice)
                            {
                                case "1":
                                    group.Sort(new Student.SortBySurname());
                                    Console.WriteLine("Відсортовано за прізвищем.");
                                    break;

                                case "2":
                                    group.Sort(new Student.SortByAge());
                                    Console.WriteLine("Відсортовано за віком.");
                                    break;

                                case "3":
                                    group.Sort(new Student.SortByGPA());
                                    Console.WriteLine("Відсортовано за GPA.");
                                    break;

                                case "4":
                                    group.Sort(new Student.SortByGroupNumber());
                                    Console.WriteLine("Відсортовано за номером групи.");
                                    break;

                                default:
                                    Console.WriteLine("Невірний вибір сортування!");
                                    break;
                            }

                            group.Print();

                            Console.Write("\nЗберегти зміни у файл? (y/n): ");
                            string saveChoice = Console.ReadLine();

                            if (saveChoice != null && saveChoice.ToLower() == "y")
                            {
                                group.Save(path);
                                Console.WriteLine("Файл перезаписано.");
                            }
                            else
                            {
                                Console.WriteLine("Зміни не збережено у файл.");
                            }

                            break;

                        case "9":
                            Academy_Group clonedGroup = (Academy_Group)group.Clone();

                            Console.WriteLine("Клон групи створено.");
                            Console.WriteLine("\n--- Клон групи ---");
                            clonedGroup.Print();

                            Console.Write("\nЗберегти клон у файл? (y/n): ");
                            string cloneSaveChoice = Console.ReadLine();

                            if (cloneSaveChoice?.ToLower() == "y")
                            {
                                Console.Write("Введіть ім'я файлу для клону: ");
                                string newPath = Console.ReadLine();

                                if (!string.IsNullOrWhiteSpace(newPath))
                                {
                                    clonedGroup.Save(newPath);
                                    Console.WriteLine("Клон збережено у файл.");
                                }
                                else
                                {
                                    Console.WriteLine("Невірне ім'я файлу.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Клон не збережено.");
                            }

                            break;

                        case "10":
                            Console.WriteLine("\nПеребір групи через foreach:");

                            foreach (Student s in group)
                            {
                                s.Print();
                            }

                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Невірний вибір!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Помилка: " + ex.Message);
                }
            }
        }

        static string ReadString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Поле не може бути порожнім!");
            }
        }

        static int ReadInt(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;

                Console.WriteLine("Введіть коректне число!");
            }
        }

        static double ReadDouble(string message)
        {
            double value;
            while (true)
            {
                Console.Write(message);

                if (double.TryParse(Console.ReadLine(), out value) && value >= 0 && value <= 100)
                    return value;

                Console.WriteLine("Введіть число від 0 до 100!");
            }
        }

        static void AddStudent(Academy_Group group)
        {
            try
            {
                string name = ReadString("Ім'я: ");
                string surname = ReadString("Прізвище: ");
                int age = ReadInt("Вік: ");
                string phone = ReadString("Телефон: ");
                double gpa = ReadDouble("GPA: ");
                string groupNum = ReadString("Група: ");

                group.Add(new Student(name, surname, age, phone, gpa, groupNum));

                Console.WriteLine("Студента додано!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при додаванні: " + ex.Message);
            }
        }

        static void EditStudent(Academy_Group group)
        {
            try
            {
                string surname = ReadString("Введіть прізвище студента для редагування: ");

                Console.WriteLine("\nВведіть нові дані:");

                string name = ReadString("Ім'я: ");
                string newSurname = ReadString("Прізвище: ");
                int age = ReadInt("Вік: ");
                string phone = ReadString("Телефон: ");
                double gpa = ReadDouble("GPA: ");
                string groupNum = ReadString("Група: ");

                group.Edit(surname, new Student(name, newSurname, age, phone, gpa, groupNum));

                Console.WriteLine("Дані оновлено!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при редагуванні: " + ex.Message);
            }
        }


    }
}