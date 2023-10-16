/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 This program reads two integers from
*                 on the console and add the two numbers.
*                 The entire invoice is output flush to
*                 the right.
*----------------------------------------------------------
*/
#nullable disable

namespace Calculator.ConApp
{
    /// <summary>
    /// Represents the entry point for the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point for the application.
        /// </summary>
        /// <param name="args">An array of command-line args passed to the application.</param>
        static void Main(string[] args)
        {
            string input;
            int number1, number2, sum;
            
            Console.WriteLine("****************************************");
            Console.WriteLine("* Calculator - Ihr Zahlenbegleiter     *");
            Console.WriteLine("****************************************");
            
            // Eingabe (E)
            Console.Write("Erste Zahl:  ");
            input = Console.ReadLine();
            number1 = Convert.ToInt32(input);
            
            Console.Write("Zweite Zahl: ");
            input = Console.ReadLine();
            number2 = Convert.ToInt32(input);
            
            // Verarbeitung (V)
            sum = number1 + number2;
            
            // Ausgabe (A)
            Console.WriteLine("Ergebnis:");
            Console.WriteLine("====================");
            Console.WriteLine($"{number1,20}");
            Console.WriteLine($"+{number2,19}");
            Console.WriteLine("--------------------");
            Console.WriteLine($"{sum,20}");
            Console.WriteLine("====================");
            
        }
    }
}
