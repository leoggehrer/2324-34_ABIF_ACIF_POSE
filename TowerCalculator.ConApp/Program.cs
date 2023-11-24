/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 VocabularyTrainer
*                 This program practices learning vocabulary.
*----------------------------------------------------------
*/
#nullable disable

namespace TowerCalculator.ConApp
{
    /// <summary>
    /// Represents the main entry point for the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Generates a pyramid of numbers based on user input.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            string input;
            int number, operand, result;

            Console.WriteLine("Pyramid of Numbres");
            Console.WriteLine("==================");
            Console.WriteLine();

            // Eingabe (E)
            Console.Write("Please enter a number: ");
            input = Console.ReadLine();
            number = Convert.ToInt32(input);
            operand = number;
            Console.WriteLine();

            // Verarbeitung (V)
            for (int i = 2; i < 10; i++)
            {
                result = operand * i;
                // Ausgabe (A)
                Console.WriteLine($"{operand} * {i} = {result}");
                operand = result;
            }

            for (int i = 2; i < 10; i++)
            {
                // Ausgabe (A)
                result = operand / i;
                Console.WriteLine($"{operand} / {i} = {result}");
                operand = result;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
