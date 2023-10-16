/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 This program determines the net price
*                 based on the current VAT rate of 10%
*                 and calculates a gross price for 5% VAT.
*----------------------------------------------------------
*/
namespace TaxCalculator.ConApp
{
    /// <summary>
    /// Represents the program for calculating taxes on affordable basic foods.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// This method calculates the net price, taxes, and gross price for a given gross price with a VAT percentage of 10%.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            string input;
            double netPrice, grossPrice10, tax10, grossPrice5, tax5;
            
            Console.WriteLine("***************************************************");
            Console.WriteLine("* Steuerrechner für leistbare Grundnahrungsmittel *");
            Console.WriteLine("***************************************************");
            
            // Eingabe (E)
            Console.Write("Aktueller Verkaufspreis:            ");
            input = Console.ReadLine();
            grossPrice10 = Convert.ToDouble(input);
            
            // Verarbeitung (V)
            netPrice = grossPrice10 / 1.1;    // Calculate net price (10% VAT)
            tax10 = grossPrice10 - netPrice;  // Calculate VAT for 10%
            grossPrice5 = netPrice * 1.05;    // Calculate gross price (5% VAT)
            tax5 = grossPrice5 - netPrice;    // Calculate VAT for 5%
            
            // Ausgabe (A)
            Console.WriteLine();
            Console.WriteLine($"Nettopreis:                    {netPrice,10:f} EUR");
            Console.WriteLine($"Derzeitige Merwehrtsteuer:     {tax10,10:f} EUR");
            Console.WriteLine();
            
            Console.WriteLine($"Werte bei 5% Steuer");
            Console.WriteLine($"-------------------");
            Console.WriteLine($"Mehrwertsteuer:                {tax5,10:f} EUR");
            Console.WriteLine($"Zukünftiger Verkaufspreis:     {grossPrice5,10:f} EUR");
            
            Console.WriteLine();
            Console.Write("Zum Beenden Eingabetaste drücken...");
            Console.ReadLine();
        }
    }
}
