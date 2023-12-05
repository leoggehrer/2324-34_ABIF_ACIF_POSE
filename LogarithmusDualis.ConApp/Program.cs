/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 LogarithmusDualis
*                 This program calculates the logarithm of 
*                 two from a natural number.
*----------------------------------------------------------
*/

#nullable disable

namespace LogarithmusDualis.ConApp
{
    /// <summary>
    /// Represents the main program class for calculating the logarithm of a number in base 2.
    /// </summary>
    // Rest of the code here...
    internal class Program
    {
        /// <summary>
        /// This method calculates the logarithmus dualis of a given number.
        /// </summary>
        /// <param name="args">The command-line arguments passed to the program.</param>
        /// <returns>Void.</returns>
        /// <remarks>
        /// The method first prompts the user for a number.
        /// It then calculates the logarithmus dualis of the given number by continuously dividing it by 2 until it reaches a value less than or equal to 1.
        /// The number of divisions required is stored in the logarithmus variable.
        /// Finally, the method displays the calculated logarithmus dualis to the console.
        /// </remarks>
        static void Main(string[] args)
        {
            string input;
            int number, logarithmus = 0;

            Console.WriteLine("Logarithmus Dualis");
            Console.WriteLine("==================");
            Console.WriteLine();

            // Eingabe (E)
            Console.Write("Zahl: ");
            input = Console.ReadLine();
            number = Convert.ToInt32(input);

            // Verarbeitung (V)
            while (number > 1)
            {
                number /= 2;
                logarithmus++;
            }

            // Ausgabe (A)
            Console.WriteLine();
            Console.WriteLine($"Der Logarithmus Dualis von {number} ist {logarithmus}.");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
