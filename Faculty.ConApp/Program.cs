/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Faculty
*                 This program calculates the factorial of 
*                 an entered number.
*----------------------------------------------------------
*/
#nullable disable
namespace Faculty.ConApp
{
    /// <summary>
    /// Represents the Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Calculates the faculty of a given number.
        /// </summary>
        /// <param name="args">Arguments passed to the method.</param>
        static void Main(string[] args)
        {
            string input;
            long number;
            long result = 1;

            Console.WriteLine("Calculate Faculty");
            Console.WriteLine("=================");
            Console.WriteLine();

            // Eingabe (E)
            Console.Write("Please enter a number: ");
            input = Console.ReadLine();
            number = Convert.ToInt32(input);

            // Verarbeitung (V)
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            Console.WriteLine();
            Console.WriteLine($"{number}! results in {result}.");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
