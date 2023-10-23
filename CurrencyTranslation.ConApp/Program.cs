/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Currency Translation
*                 This program converts a value in
*                 euros into the currencies francs
*                 and dollars (daily exchange rate when created).
*----------------------------------------------------------
*/
#nullable disable
namespace CurrencyTranslation.ConApp
{
    /// <summary>
    /// This class represents a currency converter program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entry point for the currency converter program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            bool validInput = true;
            string input, sourceCurrency;
            double value, euroValue = 0, dollarValue = 0, francValue = 0;
            
            Console.WriteLine("***************************************************");
            Console.WriteLine("* Währungsrechner - Der faire Austausch von Geld  *");
            Console.WriteLine("*                   EURO    -> DOLLAR             *");
            Console.WriteLine("*                   EURO    -> FRANKEN            *");
            Console.WriteLine("* oder              DOLLAR  -> EURO               *");
            Console.WriteLine("*                   DOLLAR  -> FRANKEN            *");
            Console.WriteLine("* oder              FRANKEN -> EURO               *");
            Console.WriteLine("*                   FRANKEN -> DOLLAR             *");
            Console.WriteLine("***************************************************");
            Console.WriteLine();
            
            // Eingabe (E)
            Console.Write("Eingabe der Ausgangswaehrung (D=Dollar, E=Euro, F=Franken): ");
            sourceCurrency = Console.ReadLine().ToUpper();
            
            Console.WriteLine();
            Console.Write("Betrag: ");
            input = Console.ReadLine();
            value = Convert.ToDouble(input);
            
            // Verarbeitung (V)
            switch (sourceCurrency)
            {
                case "E":
                euroValue = value;
                dollarValue = value * 1.06;
                francValue = value * 0.95;
                break;
                case "F":
                francValue = value;
                dollarValue = value * 1.12;
                euroValue = value * 1.06;
                break;
                case "D":
                dollarValue = value;
                francValue = value * 0.89;
                euroValue = value * 0.94;
                break;
                default:
                validInput = false;
                Console.WriteLine("Ungültige Eingabe!");
                break;
            }
            
            // Ausgabe (A)
            if (validInput)
            {
                Console.WriteLine($"Euro:    {euroValue:f2}");
                Console.WriteLine($"Dollar:  {dollarValue:f2}");
                Console.WriteLine($"Franken: {francValue:f2}");
            }
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
