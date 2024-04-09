/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*---------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Class Management
*                 This program manages a list of pupils with 
*                 their catalog numbers, first names, last names, 
*                 and postal codes. About a menu, the user can 
*                 read pupils, sort them by catalog number or 
*                 last name, print the list of pupils, search for 
*                 pupils by last name or postal code, and save 
*                 the list of pupils to a CSV file. 
*----------------------------------------------------------
*/
#nullable disable

namespace ClassManagement.ConApp
{
    /// <summary>
    /// Represents the entry point of the program.
    /// </summary>
    internal class Program
    {
        private const string FILE_NAME = "pupils.csv";
        /// <summary>
        /// The main method of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            RunApp();
        }

        private static void RunApp()
        {
            bool exit = false;
            Pupil[] pupils = ReadPupilsFromCsvFile(FILE_NAME);
            int choice = PrintAndExecuteMenu();

            do
            {
                switch (choice)
                {
                    case 1:
                        ReadPupil(pupils);
                        break;
                    case 2:
                        SortPupilsByCatalogNumber(pupils);
                        break;
                    case 3:
                        SortPupilsByLastName(pupils);
                        break;
                    case 4:
                        PrintPupils(pupils);
                        break;
                    case 5:
                        SearchPupilsByLastName(pupils);
                        break;
                    case 6:
                        SearchPupilsByPostalCode(pupils);
                        break;
                    case 7:
                        WritePupilsToCsvFile(FILE_NAME, pupils);
                        break;
                    case 8:
                        exit = true;
                        break;
                }
                if (!exit)
                {
                    choice = PrintAndExecuteMenu();
                }

            } while (exit == false);
        }

        /// <summary>
        /// Prints the menu options for class management and prompts the user for their choice.
        /// Validates the user's input and returns the chosen option.
        /// </summary>
        /// <returns>The user's chosen menu option.</returns>
        private static int PrintAndExecuteMenu()
        {
            int choice;
            bool validChoice = false;

            do
            {
                Console.WriteLine("Klassen-Management");
                Console.WriteLine("==================");
                Console.WriteLine();

                Console.WriteLine("1 - Neuen Schüler einlesen");
                Console.WriteLine("2 - Schüler nach Katalognummer sortieren");
                Console.WriteLine("3 - Schüler nach Familiennamen sortieren");
                Console.WriteLine("4 - Schülerliste ausgeben");
                Console.WriteLine("5 - Schüler nach Familiennamen suchen und ausgeben");
                Console.WriteLine("6 - Schüler nach Postleitzahl suchen und ausgeben");
                Console.WriteLine("7 - Schülerliste speichern");
                Console.WriteLine("8 - Beenden");
                Console.WriteLine();
                Console.Write("Ihre Wahl: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    validChoice = choice >= 1 && choice <= 8;
                }
            } while (validChoice == false);

            return choice;
        }

        /// <summary>
        /// Reads pupil data from a file and returns an array of Pupil objects.
        /// </summary>
        /// <param name="fileName">The name of the file to read from.</param>
        /// <returns>An array of Pupil objects.</returns>
        private static Pupil[] ReadPupilsFromCsvFile(string fileName)
        {
            Pupil[] result = new Pupil[40];

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                for (int i = 1; i < lines.Length && i < result.Length; i++)
                {
                    string[] data = lines[i].Split(';');

                    Pupil pupil = new Pupil
                    {
                        CatalogNumber = int.Parse(data[0]),
                        FirstName = data[1],
                        LastName = data[2],
                        PostalCode = data[3],
                    };
                    result[i - 1] = pupil;
                }
            }
            return result;
        }

        /// <summary>
        /// Writes an array of Pupil objects to a CSV file.
        /// </summary>
        /// <param name="fileName">The name of the CSV file to write.</param>
        /// <param name="pupils">An array of Pupil objects to write to the CSV file.</param>
        private static void WritePupilsToCsvFile(string fileName, Pupil[] pupils)
        {
            List<string> lines = new List<string>();

            lines.Add("Katalognummer;Vorname;Familienname;PLZ");

            for (int i = 0; i < pupils.Length; i++)
            {
                Pupil pupil = pupils[i];

                if (pupil != null)
                {
                    lines.Add($"{pupil.CatalogNumber};{pupil.FirstName};{pupil.LastName};{pupil.PostalCode}");
                }
            }
            File.WriteAllLines(fileName, lines);
        }

        /// <summary>
        /// Reads pupil information from the user and stores it in the provided array of Pupil objects.
        /// </summary>
        /// <param name="pupils">The array of Pupil objects to store the pupil information.</param>
        private static void ReadPupil(Pupil[] pupils)
        {
            int idx;

            do
            {
                idx = -1;
                for (int i = 0; i < pupils.Length && idx == -1; i++)
                {
                    if (pupils[i] == null)
                    {
                        idx = i;
                    }
                }

                if (idx == -1)
                {
                    Console.WriteLine("Kein Speicherplatz mehr verfügbar!");
                }
                else
                {
                    Pupil pupil = new Pupil();

                    Console.Write("Katalognummer: ");
                    pupil.CatalogNumber = int.Parse(Console.ReadLine());
                    Console.Write("Vorname: ");
                    pupil.FirstName = Console.ReadLine();
                    Console.Write("Familienname: ");
                    pupil.LastName = Console.ReadLine();
                    Console.Write("PLZ: ");
                    pupil.PostalCode = Console.ReadLine();

                    pupils[idx] = pupil;

                    Console.Write("Weiteren Schüler einlesen (j/n)? ");
                }

            } while (Console.ReadLine().ToLower().Equals("j") && idx != -1);
        }
        /// <summary>
        /// Prints the details of the given array of pupils.
        /// </summary>
        /// <param name="pupils">The array of pupils to be printed.</param>
        private static void PrintPupils(Pupil[] pupils)
        {
            string format = "{0,-4} {1,-20} {2,-20} {3,-5}";
            string output = string.Format(format, "Nr.", "Vorname", "Familienname", "PLZ");

            Console.WriteLine(output);
            Console.Write(new string('=', output.Length));
            Console.WriteLine();

            for (int i = 0; i < pupils.Length; i++)
            {
                Pupil pupil = pupils[i];

                if (pupil != null)
                {
                    output = string.Format(format, pupil.CatalogNumber, pupil.FirstName, pupil.LastName, pupil.PostalCode);

                    Console.WriteLine(output);
                }
            }
        }
        /// <summary>
        /// Sorts an array of Pupil objects by their catalog number in ascending order.
        /// </summary>
        /// <param name="pupils">The array of Pupil objects to be sorted.</param>
        private static void SortPupilsByCatalogNumber(Pupil[] pupils)
        {
            bool exchange;

            do
            {
                exchange = false;
                for (int i = 0; i < pupils.Length - 1; i++)
                {
                    if (pupils[i] != null && pupils[i + 1] != null && pupils[i].CatalogNumber > pupils[i + 1].CatalogNumber)
                    {
                        Pupil temp = pupils[i];

                        pupils[i] = pupils[i + 1];
                        pupils[i + 1] = temp;
                        exchange = true;
                    }
                }

            } while (exchange == true);
        }
        /// <summary>
        /// Sorts an array of Pupil objects by their last names in ascending order.
        /// </summary>
        /// <param name="pupils">The array of Pupil objects to be sorted.</param>
        private static void SortPupilsByLastName(Pupil[] pupils)
        {
            bool exchange;

            do
            {
                exchange = false;
                for (int i = 0; i < pupils.Length - 1; i++)
                {
                    if (pupils[i] != null && pupils[i + 1] != null && pupils[i].LastName.CompareTo(pupils[i + 1].LastName) > 0)
                    {
                        Pupil temp = pupils[i];

                        pupils[i] = pupils[i + 1];
                        pupils[i + 1] = temp;
                        exchange = true;
                    }
                }

            } while (exchange == true);
        }

        /// <summary>
        /// Searches for pupils with a given last name and prints the results.
        /// </summary>
        /// <param name="pupils">An array of Pupil objects.</param>
        private static void SearchPupilsByLastName(Pupil[] pupils)
        {
            int printIdx = 0;
            Pupil[] printList = new Pupil[40];

            Console.Write("Familiennamen eingeben: ");
            string input = Console.ReadLine();

            for (int i = 0; i < pupils.Length; i++)
            {
                Pupil pupil = pupils[i];

                if (pupil != null && pupil.LastName.Equals(input))
                {
                    printList[printIdx++] = pupil;
                }
            }
            if (printIdx > 0)
            {
                PrintPupils(printList);
            }
            else
            {
                Console.WriteLine("Keine Schüler mit diesem Familiennamen gefunden!");
            }
        }
        /// <summary>
        /// Searches for pupils by postal code and prints the matching pupils.
        /// </summary>
        /// <param name="pupils">An array of Pupil objects.</param>
        private static void SearchPupilsByPostalCode(Pupil[] pupils)
        {
            int printIdx = 0;
            Pupil[] printList = new Pupil[40];

            Console.Write("Postleitzahl eingeben: ");
            string input = Console.ReadLine();

            for (int i = 0; i < pupils.Length; i++)
            {
                Pupil pupil = pupils[i];

                if (pupil != null && pupil.PostalCode.Equals(input))
                {
                    printList[printIdx++] = pupil;
                }
            }
            if (printIdx > 0)
            {
                PrintPupils(printList);
            }
            else
            {
                Console.WriteLine("Keine Schüler mit diesem Familiennamen gefunden!");
            }
        }
    }
}
