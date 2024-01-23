/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Simple methods
*                 A collection of simple methods, to practice 
*                 utilizing them in programing.
*----------------------------------------------------------
*/

#nullable disable

namespace SimpleMethods.ConApp
{
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            char characterDisplayed;
            int menueNumber = 0, numChars = 0, numStars = 0, sumOfAllDigits = 0, indexSubString = 0, lengthSubString = 0;
            string inputSumOfDigits, searchedSubString, inputString;

            do
            {
                Console.Clear();
                Console.WriteLine("Simple Methods");
                Console.WriteLine("==============");
                Console.WriteLine();

                Console.WriteLine("Welche Methode möchten Sie verwenden?");
                Console.WriteLine("1 ... WriteStars");
                Console.WriteLine("2 ... WriteCharacters");
                Console.WriteLine("3 ... SumOfDigits");
                Console.WriteLine("4 ... SubString");
                Console.WriteLine("0 ... Exit");
                Console.Write("Geben Sie eine Zahl ein [1-4]: ");
                menueNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (menueNumber)
                {
                    case 1:
                        Console.Write("Geben Sie die Anzahl der Sterne ein, die Sie anzeigen möchten: ");
                        numStars = Convert.ToInt32(Console.ReadLine());
                        WriteStars(numStars);
                        Console.WriteLine();
                        Console.Write("Weiter mit Eingabe...");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Geben Sie das Zeichen ein, das Sie anzeigen möchten: ");
                        characterDisplayed = Convert.ToChar(Console.ReadLine());
                        Console.Write($"Geben Sie an, wie oft {characterDisplayed} angezeigt werden soll: ");
                        numChars = Convert.ToInt32(Console.ReadLine());
                        WriteCharacters(numChars, characterDisplayed);
                        Console.WriteLine();
                        Console.Write("Weiter mit Eingabe...");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Geben Sie Ihren Text ein, sie erhalten eine Zusammenfassung: ");
                        inputSumOfDigits = Console.ReadLine();
                        sumOfAllDigits = SumOfDigits(inputSumOfDigits);
                        Console.WriteLine();
                        Console.WriteLine($"Die Summe aller Zahlen ist gleich {sumOfAllDigits}");
                        Console.Write("Weiter mit Eingabe...");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Geben Sie Ihren Text ein: ");
                        inputString = Console.ReadLine();
                        Console.Write("Geben Sie den Index ein, an dem der SubString beginnt: ");
                        indexSubString = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Geben Sie die Länge des SubStrings ein: ");
                        lengthSubString = Convert.ToInt32(Console.ReadLine());
                        searchedSubString = SubString(inputString, indexSubString, lengthSubString);
                        Console.WriteLine($"Der Teiltext ist: {searchedSubString}");
                        Console.WriteLine();
                        Console.Write("Weiter mit Eingabe...");
                        Console.ReadLine();
                        break;
                }
            } while (menueNumber != 0);
        }

        /// <summary>
        /// Writes a specified number of stars to the console.
        /// </summary>
        /// <param name="count">The number of stars to write.</param>
        public static void WriteStars(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Writes a specified number of characters to the console.
        /// </summary>
        /// <param name="count">The number of characters to write.</param>
        /// <param name="character">The character to write.</param>
        public static void WriteCharacters(int count, char character)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(character);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Calculates the sum of all the digits in a given string.
        /// </summary>
        /// <param name="text">The string to calculate the sum of digits from.</param>
        /// <returns>The sum of all the digits in the string.</returns>
        public static int SumOfDigits(string text)
        {
            int result = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    result += text[i] - '0';
                }
            }
            return result;
        }

        /// <summary>
        /// Retrieves a substring from the specified text, starting at the specified index and with the specified length.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <param name="startIndex">The starting index of the substring.</param>
        /// <param name="length">The length of the substring.</param>
        /// <returns>The substring.</returns>
        public static string SubString(string text, int startIndex, int length)
        {
            string result = string.Empty;

            for (int i = startIndex; i >= 0 && i < text.Length && i < startIndex + length; i++)
            {
                result += text[i];
            }
            return result;
        }
    }
}
