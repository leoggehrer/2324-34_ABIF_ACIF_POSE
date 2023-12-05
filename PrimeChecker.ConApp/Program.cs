/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 PrimeChecker
*                 This program checks whether an entered 
*                 number is prime or not. The different 
*                 loop variants should be tested. 
*----------------------------------------------------------
*/

#nullable disable
namespace PrimeChecker.ConApp
{
    /// <summary>
    /// Represents the main program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Checks if a given number is prime using two different methods: while loop and for loop.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            string input;
            int number, divider;
            bool isPrime;

            Console.WriteLine("Prime Checker");
            Console.WriteLine("=============");
            Console.WriteLine();

            // Eingabe (E)
            Console.Write("Geben Sie eine Ganzzahl ein: ");
            input = Console.ReadLine();
            number = Convert.ToInt32(input);

            // Verarbeitung (V)
            isPrime = number > 1 && (number == 2 || number % 2 != 0);
            divider = 3;

            while (isPrime && divider <= number / 2)
            {
                isPrime = number % divider != 0;
                divider += 2;
            }

            // Ausgabe (A)
            Console.WriteLine($"Variante while: Die Zahl {number} {(isPrime ? "ist" : "keine")} Primzahl!");
            Console.WriteLine();

            isPrime = number > 1 && (number == 2 || number % 2 != 0);

            for (int i = 3; isPrime && i <= number / 2; i = i + 2)
            {
                isPrime = number % i != 0;
            }

            // Ausgabe (A)
            Console.WriteLine($"Variante for: Die Zahl {number} {(isPrime ? "ist" : "keine")} Primzahl!");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
