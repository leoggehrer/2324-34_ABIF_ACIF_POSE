/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Currency Converter
*                 This program converts the currency from euros
*                 to francs and dollars.
*----------------------------------------------------------
*/
#nullable disable

namespace CurrencyConverter.ConApp
{
    /// <summary>
    /// Represents the Program class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// This method converts a given amount in Euro to Dollar and Franc.
        /// </summary>
        /// <param name="args">An array of strings representing the command line arguments.</param>
        /// <returns>void</returns>
        static void Main(string[] args)
        {
            string input;
            double euroToFranc = 0.95, euroToDollar = 1.05;  // Exchange rate on 17.10.2023
            double euroValue, francValue, dollarValue;
            
            Console.WriteLine("***************************************************");
            Console.WriteLine("* Währungsrechner - Der faire Austausch von Geld  *");
            Console.WriteLine("*                   EURO -> DOLLAR                *");
            Console.WriteLine("*                   EURO -> FRANKEN               *");
            Console.WriteLine("***************************************************");
            Console.WriteLine();
            
            // Eingabe (E)
            Console.Write("Eingabe des Betrages in Euro: ");
            input = Console.ReadLine();
            euroValue = Convert.ToDouble(input);
            
            // Verarbeitung (V)
            dollarValue = euroValue * euroToDollar;
            francValue = euroValue * euroToFranc;
            
            // Ausgabe (A)
            Console.WriteLine($"Dollar:  {dollarValue,10:f4}");
            Console.WriteLine($"Franken: {francValue,10:f4}");
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}


