/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 StarSquare
*                 This program outputs a star square to the
*                 console depending on an input.
*----------------------------------------------------------
*/

#nullable disable
namespace StarSquare.ConApp
{
    /// <summary>
    /// Represents the entry point for the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Prints a square of stars based on the user inputted number.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            string input;
            int number;

            Console.WriteLine("StarSquare");
            Console.WriteLine("==========");
            Console.WriteLine();

            // Eingabe (E)
            Console.Write("Geben Sie eine Ganzzahl ein: ");
            input = Console.ReadLine();
            number = Convert.ToInt32(input);

            // Verarbeitung (V)
            Console.WriteLine();
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    // Ausgabe (A)
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
