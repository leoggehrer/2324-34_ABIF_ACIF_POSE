/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 NumberPalindrom
*                 This program takes an integer from the 
*                 user and checks whether that number is 
*                 a palindrome. A palindrome is a number 
*                 that has the same value from right to 
*                 left as well as from left to right. 
*----------------------------------------------------------
*/
#nullable disable

namespace NumberGuessing.ConApp
{
    /// <summary>
    /// Represents the entry point of the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            string input;
            int number, divider = 1, reverseNumber = 0;

            Console.Clear();
            Console.WriteLine("Palindrom number");
            Console.WriteLine("================");
            Console.WriteLine();

            // Input (I)
            Console.Write("Number [>...0]: ");
            input = Console.ReadLine();

            if (int.TryParse(input, out number) && number > 0)
            {
                // Processing (P)
                while (divider <= number)
                {
                    reverseNumber *= 10;
                    reverseNumber += number / divider % 10;
                    divider *= 10;
                }
            }
            else
            {
                // Output (O)
                Console.WriteLine("Invalid number!");
            }

            // Ouput (O)
            Console.WriteLine();
            Console.WriteLine($"{number} {(number == reverseNumber ? "ist" : "kein")} Palindrom!");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
