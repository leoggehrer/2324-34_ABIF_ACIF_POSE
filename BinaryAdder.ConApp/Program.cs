/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Binary Adder
*                 The program reads two binary numbers 
*                 from the user in the form of a character 
*                 string, adds them together and outputs the 
*                 result in binary format.
*----------------------------------------------------------
*/
#nullable disable


using System.Runtime.Intrinsics.Arm;

namespace BinaryAdder.ConApp
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

            Console.WriteLine("Binäraddierer");
            Console.WriteLine("=============");

            // Input (I)
            number1 = ReadBinaryNumber(1);
            number2 = ReadBinaryNumber(2);
            // Processing (P)
            result = AddBinaryNumbers(number1, number2);
            // Output (O)
            Console.WriteLine($"{number1} + {number2} =  {result}");

            Console.WriteLine();
            Console.WriteLine("Beenden mit Eingabetaste... ");
            Console.ReadLine();
        }

        /// <summary>
        /// Adds two binary numbers and returns the result as a binary string.
        /// </summary>
        /// <param name="number1">The first binary number.</param>
        /// <param name="number2">The second binary number.</param>
        /// <returns>The sum of the two binary numbers as a binary string.</returns>
        private static string AddBinaryNumbers(string number1, string number2)
        {
            bool carry = false;
            string result = string.Empty;
            int numberLength = Math.Max(number1.Length, number2.Length) + 1;

            number1 = ExpandNumber(number1, numberLength);
            number2 = ExpandNumber(number2, numberLength);

            for (int i = numberLength - 1; i >= 0; i--)
            {
                if (carry == false && number1[i] == '0' && number2[i] == '0')
                {
                    result = '0' + result;
                }
                else if (carry == false && number1[i] == '1' && number2[i] == '0')
                {
                    result = '1' + result;
                }
                else if (carry == false && number1[i] == '0' && number2[i] == '1')
                {
                    result = '1' + result;
                }
                else if (carry == false && number1[i] == '1' && number2[i] == '1')
                {
                    carry = true;
                    result = '0' + result;
                }
                else if (carry && number1[i] == '0' && number2[i] == '0')
                {
                    carry = false;
                    result = '1' + result;
                }
                else if (carry && number1[i] == '1' && number2[i] == '0')
                {
                    result = '0' + result;
                }
                else if (carry && number1[i] == '0' && number2[i] == '1')
                {
                    result = '0' + result;
                }
                else if (carry && number1[i] == '1' && number2[i] == '1')
                {
                    result = '1' + result;
                }
            }
            return ShrinkNumber(result);
        }

        /// <summary>
        /// Removes leading zeros from a given number.
        /// </summary>
        /// <param name="number">The number to shrink.</param>
        /// <returns>The number without leading zeros.</returns>
        private static string ShrinkNumber(string number)
        {
            return number.TrimStart('0');
        }

        /// <summary>
        /// Expands a given number by adding leading zeros until it reaches the specified length.
        /// </summary>
        /// <param name="number">The number to be expanded.</param>
        /// <param name="numberLength">The desired length of the expanded number.</param>
        /// <returns>The expanded number.</returns>
        private static string ExpandNumber(string number, int numberLength)
        {
            while (number.Length < numberLength)
            {
                number = '0' + number;
            }
            return number;
        }

        /// <summary>
        /// Reads a binary number from the console.
        /// </summary>
        /// <param name="number">The number of the binary number being read.</param>
        /// <returns>The binary number entered by the user.</returns>
        private static string ReadBinaryNumber(int number)
        {
            string result;
            bool validInput;

            do
            {
                Console.Write($"Geben Sie die {number}. Binärzahl ein: ");
                result = Console.ReadLine();
                validInput = CheckBinaryNumber(result);
                if (!validInput)
                {
                    Console.WriteLine("Fehler: In einer Binärzahl sind nur 1 und 0 erlaubt!");
                }
            } while (validInput == false);
            return result;
        }

        /// <summary>
        /// Checks if a given string represents a binary number.
        /// </summary>
        /// <param name="number">The string to be checked.</param>
        /// <returns>True if the string represents a binary number, otherwise false.</returns>
        private static bool CheckBinaryNumber(string number)
        {
            bool result = true;
            int idx = 0;

            while (idx < number.Length && result)
            {
                result = IsBinaryDigit(number[idx++]);
            }
            return result;
        }

        /// <summary>
        /// Determines whether the specified character is a binary digit (0 or 1).
        /// </summary>
        /// <param name="chr">The character to check.</param>
        /// <returns>True if the character is a binary digit; otherwise, false.</returns>
        private static bool IsBinaryDigit(char chr)
        {
            return chr == '0' || chr == '1';
        }
    }
}
