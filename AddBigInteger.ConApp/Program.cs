/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Add Big Integer
*                 This C# program reads in two natural numbers
*                 of any size, adds these numbers together 
*                 and displays them in the console.
*----------------------------------------------------------
*/
#nullable disable

namespace AddBigInteger.ConApp
{
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            string number1, number2, result;

            Console.WriteLine("Addieren von sehr großen Zahlen (Integer)");
            Console.WriteLine("=========================================");

            // Input (I)
            number1 = ReadBigInteger("Geben Sie die erste Zahl ein: ");
            number2 = ReadBigInteger("Geben Sie die zweite Zahl ein:");
            // Processing (P)
            result = AddBigInteger(number1, number2);
            // Output (O)
            Console.WriteLine("Summer der beiden Zahlen:");
            Console.WriteLine($"{result}");

            Console.WriteLine();
            Console.WriteLine("Beenden mit Eingabetaste... ");
            Console.ReadLine();
        }

        /// <summary>
        /// Adds two big integers represented as strings.
        /// </summary>
        /// <param name="number1">The first big integer.</param>
        /// <param name="number2">The second big integer.</param>
        /// <returns>The sum of the two big integers.</returns>
        private static string AddBigInteger(string number1, string number2)
        {
            string result = string.Empty;
            int maxNumber = Math.Max(number1.Length, number2.Length) + 1;
            bool carry = false;

            number1 = AddLeadingCharacters(number1, '0', maxNumber - number1.Length);
            number2 = AddLeadingCharacters(number2, '0', maxNumber - number2.Length);

            for (int i = number1.Length - 1; i >= 0; i--)
            {
                int sum = number1[i] - '0' + number2[i] - '0' + (carry ? 1 : 0);

                if (sum < 10)
                {
                    result = sum.ToString() + result;
                    carry = false;
                }
                else
                {
                    result = (sum % 10).ToString() + result;
                    carry = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Adds leading characters to a given string.
        /// </summary>
        /// <param name="number">The original string.</param>
        /// <param name="chr">The character to add as a leading character.</param>
        /// <param name="count">The number of leading characters to add.</param>
        /// <returns>The string with the specified number of leading characters added.</returns>
        private static string AddLeadingCharacters(string number, char chr, int count)
        {
            string result = number;
            int length = number.Length + count;

            while (result.Length < length)
            {
                result = chr + result;
            }
            return result;
        }

        /// <summary>
        /// Reads a string input from the console and validates if it represents a big integer.
        /// </summary>
        /// <param name="prompt">The prompt message to display before reading the input.</param>
        /// <returns>A string representing the valid big integer input.</returns>
        private static string ReadBigInteger(string prompt)
        {
            string result;
            bool validInput;

            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
                validInput = IsBigNumber(result);
                if (validInput == false)
                {
                    Console.WriteLine("Ungültige Eingabe!");
                }
            } while (validInput == false);

            return result;
        }

        /// <summary>
        /// Determines whether the given string represents a big number.
        /// A big number is considered valid if it contains only digits.
        /// </summary>
        /// <param name="number">The string to check.</param>
        /// <returns><c>true</c> if the string represents a big number; otherwise, <c>false</c>.</returns>
        private static bool IsBigNumber(string number)
        {
            bool result = number.Length > 0;
            int idx = 0;

            while (idx < number.Length && result)
            {
                result = char.IsDigit(number[idx++]);
            }
            return result;
        }
    }
}
