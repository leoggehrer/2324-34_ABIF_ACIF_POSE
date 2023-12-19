/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 DigitFilter
*                 The program filters all numbers from an 
*                 input text and outputs them.
*----------------------------------------------------------
*/
#nullable disable
namespace DigitFilter.ConApp
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
            string input, output = string.Empty;

            Console.WriteLine("***************************************************");
            Console.WriteLine("* Digit Filter                                    *");
            Console.WriteLine("***************************************************");
            Console.WriteLine();

            // Eingabe (E)
            Console.Write("Eingabetext: ");
            input = Console.ReadLine();

            // Verarbeitung (V)
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    output += input[i];
                }
            }

            // Ausgabe (A)
            Console.WriteLine($"Ausgabetext: {output}");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
