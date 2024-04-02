/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 FileWizard
*                 This program is an exercise in file handling. 
*                 The operations of copying a file, writing a 
*                 file and reading a file should be practiced.
*----------------------------------------------------------
*/
#nullable disable
using System.Text;

namespace FileWizard.ConApp
{
    /// <summary>
    /// Represents the entry point of the program.
    /// </summary>
    internal class Program
    {
        static readonly ConsoleColor DefaultColor = Console.ForegroundColor;
        const string LOGO_FILE = "logo.txt";

        /// <summary>
        /// The main method of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            string fileName;
            string logo = File.ReadAllText(LOGO_FILE, Encoding.Default);

            Console.WriteLine(logo);
            fileName = GetFileName();
            CreateBackup(fileName);

            bool finished;

            do
            {
                finished = PerformOperation(ref fileName);
            } while (finished == false);

            Console.WriteLine("Vielen Dank, dass ich Dir helfen durfte!");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Prompts the user to enter a file name and validates if the file exists.
        /// </summary>
        /// <returns>The name of the existing file entered by the user.</returns>
        private static string GetFileName()
        {
            string result = string.Empty;
            string input;
            do
            {
                Console.Write("Welche Datei soll ich öffnen?: ");
                input = Console.ReadLine();
                if (File.Exists(input))
                {
                    result = input;
                }
                else
                {
                    Console.WriteLine("Diese Datei existiert nicht!");
                }
            } while (string.IsNullOrEmpty(result));

            return result;
        }

        /// <summary>
        /// Performs the selected operation based on user input.
        /// </summary>
        /// <param name="fileName">The name of the file to perform the operation on.</param>
        /// <returns>True if the user selected to end the program, otherwise false.</returns>
        private static bool PerformOperation(ref string fileName)
        {
            string input;

//            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Was kann ich für dich tun?");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"FileName: {fileName}");
            Console.ForegroundColor = DefaultColor;

            Console.WriteLine();
            Console.WriteLine("(1) Datei am Bildschirm ausgeben");
            Console.WriteLine("(2) Zeilennummern hinzufügen");
            Console.WriteLine("(3) Zeilen reversieren");
            Console.WriteLine("(4) Zeichenketten ersetzen");
            Console.WriteLine("(5) Neue Datei einlesen");
            Console.WriteLine("(0) Ende");
            Console.WriteLine();
            Console.Write("Deine Wahl: ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    PrintFile(fileName);
                    break;
                case "2":
                    AddLineNumbers(fileName);
                    break;
                case "3":
                    ReverseLines(fileName);
                    break;
                case "4":
                    ReplaceCharacters(fileName);
                    break;
                case "5":
                    fileName = GetFileName();
                    CreateBackup(fileName);
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe!");
                    break;
            }
            return input == "0";
        }

        /// <summary>
        /// Creates a backup of the specified file.
        /// </summary>
        /// <param name="fileName">The name of the file to create a backup for.</param>
        private static void CreateBackup(string fileName)
        {
            int counter = 1;
            string backupExtension = ".bak";
            string backupFileName = $"{fileName}{backupExtension}";

            while (File.Exists(backupFileName))
            {
                backupFileName = $"{fileName}{backupExtension}{counter}";
                counter++;
            }

            if (File.Exists(fileName))
            {
                File.Copy(fileName, backupFileName);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Die Sicherungskopie '{backupFileName}' wurde erstellt.");
                Console.ForegroundColor = DefaultColor;
            }
            else
            {
                Console.WriteLine($"Die Datei '{fileName}' existiert nicht!");
            }
        }

        /// <summary>
        /// Reverses the lines in a file.
        /// </summary>
        /// <param name="fileName">The name of the file to reverse the lines in.</param>
        private static void ReverseLines(string fileName)
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                Array.Reverse(lines);
                File.WriteAllLines(fileName, lines);
            }
            else
            {
                Console.WriteLine($"Die Datei '{fileName}' existiert nicht!");
            }
        }

        /// <summary>
        /// Adds line numbers to a file.
        /// </summary>
        /// <param name="fileName">The name of the file to add line numbers to.</param>
        private static void AddLineNumbers(string fileName)
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                List<string> numberedLines = new List<string>();

                for (int i = 0; i < lines.Length; i++)
                {
                    numberedLines.Add($"{i + 1}: {lines[i]}");
                }
                File.WriteAllLines(fileName, numberedLines);
            }
            else
            {
                Console.WriteLine($"Die Datei '{fileName}' existiert nicht!");
            }
        }

        /// <summary>
        /// Replaces a specified string with a new string in the content of a file.
        /// </summary>
        /// <param name="fileName">The path of the file to modify.</param>
        private static void ReplaceCharacters(string fileName)
        {
            if (File.Exists(fileName))
            {
                string content = File.ReadAllText(fileName);
                Console.Write("Welche Zeichenkette soll ersetzt werden?:       ");
                string oldString = Console.ReadLine();
                Console.Write("Durch welche Zeichenkette soll ersetzt werden?: ");
                string newString = Console.ReadLine();
                content = content.Replace(oldString, newString);
                File.WriteAllText(fileName, content);
            }
            else
            {
                Console.WriteLine($"Die Datei '{fileName}' existiert nicht!");
            }
        }

        /// <summary>
        /// Prints the contents of a file to the console.
        /// </summary>
        /// <param name="fileName">The name of the file to print.</param>
        private static void PrintFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine($"Die Datei '{fileName}' existiert nicht!");
            }
        }
    }
}
