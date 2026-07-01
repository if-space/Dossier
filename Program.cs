using System;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[0];
            string[] positions = new string[0];
            bool isOpen = true;

            const string AddDossierCommand = "1";
            const string OutputAllDossiersCommand = "2";
            const string DeleteDossiersCommand = "3";
            const string FindDossiersCommand = "4";
            const string ExitCommand = "5";

            Console.WriteLine("Меню кадрового учета");

            while (isOpen)
            {
                Console.WriteLine("Список команд: \n" +
                    $"{AddDossierCommand} - добавить досье\n" +
                    $"{OutputAllDossiersCommand} - вывести все досье\n" +
                    $"{DeleteDossiersCommand} - удалить досье\n" +
                    $"{FindDossiersCommand} - найти досье по фамилии\n" +
                    $"{ExitCommand} - выход");

                Console.WriteLine("\nВведите номер команды: ");

                switch (Console.ReadLine())
                {
                    case AddDossierCommand:
                        AddDossier(ref names, ref positions);
                        break;

                    case OutputAllDossiersCommand:
                        OutputAllDossiers(names, positions);
                        break;

                    case DeleteDossiersCommand:
                        DeleteDossiers(ref names, ref positions);
                        break;

                    case FindDossiersCommand:
                        FindDossier(names, positions);
                        break;

                    case ExitCommand:
                        isOpen = false;
                        break;

                    default:
                        Console.WriteLine("Такой команды нет");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
                Console.ReadLine();
                Console.Clear();
            }

            static void AddDossier(ref string[] names, ref string[] positions)
            {
                Console.Write("\nВведите ФИО: ");
                string userName = Console.ReadLine();

                Console.Write("Введите должность: ");
                string userPosition = Console.ReadLine();

                names = IncreaseDossier(names);
                names[names.Length - 1] = userName;

                positions = IncreaseDossier(positions);
                positions[positions.Length - 1] = userPosition;
            }

            static string[] IncreaseDossier(string[] dossier)
            {
                string[] tempDossier = new string[dossier.Length + 1];

                for (int i = 0; i < dossier.Length; i++)
                    tempDossier[i] = dossier[i];

                dossier = tempDossier;

                return dossier;
            }

            static void OutputAllDossiers(string[] names, string[] positions)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    int index = i + 1;

                    Console.WriteLine($"{index}. {names[i]} - {positions[i]}.");
                }
            }

            static void DeleteDossiers(ref string[] names, ref string[] positions)
            {
                OutputAllDossiers(names, positions);

                Console.WriteLine("Введите номер досье, которое вы хотите удалить");

                if (int.TryParse(Console.ReadLine(), out int dossierNumber))
                {
                    dossierNumber--;

                    if (dossierNumber < names.Length && dossierNumber >= 0)
                    {
                        names = DecreaseDossier(names, dossierNumber);
                        positions = DecreaseDossier(positions, dossierNumber);

                        Console.Write("Досье успешно удалено");
                    }
                    else
                        Console.Write("Некорректный номер досье");
                }
                else
                    Console.Write("Ошибка, введено неверное число");
            }

            static string[] DecreaseDossier(string[] dossier, int userNumbers)
            {
                string[] tempDossiers = new string[dossier.Length - 1];

                for (int i = 0; i < userNumbers; i++)
                    tempDossiers[i] = dossier[i];

                for (int i = userNumbers + 1; i < dossier.Length; i++)
                    tempDossiers[i - 1] = dossier[i];

                dossier = tempDossiers;

                return dossier;
            }

            static void FindDossier(string[] names, string[] positions)
            {
                Console.Write("Введите фамилию: ");
                string userInput = Console.ReadLine();

                bool isPersonFind = false;

                for (int i = 0; i < names.Length; i++)
                {
                    char space = ' ';
                    string[] surnames = names[i].Split(space);

                    if (userInput.ToLower() == surnames[0].ToLower())
                    {
                        Console.WriteLine($"Досье найдено {names[i]} - {positions[i]}");

                        isPersonFind = true;
                    }
                }

                if (isPersonFind == false)
                    Console.WriteLine($"Досье с фамилией {userInput} не найдено");
            }
        }
    }
}