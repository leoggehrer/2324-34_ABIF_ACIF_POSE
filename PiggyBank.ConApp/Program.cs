/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 PiggyBank
*                 This program calculating the total 
*                 amount of money in a piggy bank.
*----------------------------------------------------------
*/
#nullable disable

namespace PiggyBank.ConApp
{
    /// <summary>
    /// Represents a program for calculating the total amount of money in a piggy bank.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method for the "Sparschwein - Meine Bank, meine Zukunft" program.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns>Void</returns>
        static void Main(string[] args)
        {
            string input;
            double sum;
            int fiftyCentCount, oneEuroCount, twoEuroCount;
            
            Console.WriteLine("***************************************************");
            Console.WriteLine("* Sparschwein - Meine Bank, meine Zukunft         *");
            Console.WriteLine("***************************************************");
            Console.WriteLine();
            
            // Eingabe (E)
            Console.Write("Wie viele Fünfzigerl?     ");
            input = Console.ReadLine();
            fiftyCentCount = Convert.ToInt32(input);
            
            Console.Write("Wie viele Euro Stücke?    ");
            input = Console.ReadLine();
            oneEuroCount = Convert.ToInt32(input);
            
            Console.Write("Wie viele Zweieurostücke? ");
            input = Console.ReadLine();
            twoEuroCount = Convert.ToInt32(input);
            
            // Verarbeitung (V)
            sum = fiftyCentCount * 0.5 + oneEuroCount * 1 + twoEuroCount * 2;
            
            // Ausgabe (A)
            Console.WriteLine("===================================================");
            Console.WriteLine($"Dein Sparschwein enthält {sum:f2} EUR");
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}

