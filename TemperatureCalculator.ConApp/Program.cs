/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Temperatur Rechner
*                 This program converts the entered
*                 temperature from degrees to Fahrenheit.
*----------------------------------------------------------
*/
#nullable disable
namespace TemperatureCalculator.ConApp
{
    /// <summary>
    /// Represents a program for converting Celsius to Fahrenheit.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// This method converts a temperature in Celsius to Fahrenheit and displays the result.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        static void Main(string[] args)
        {
            string input;
            double celsius, fahrenheit;
            
            Console.WriteLine("Umrechnung Celsius  ->  Fahrenheit");
            Console.WriteLine("==================================");
            Console.WriteLine();
            
            //  Eingabe (E)
            Console.Write("Eingabe Grad Celsius: ");
            input = Console.ReadLine();
            celsius = Convert.ToDouble(input);
            
            // Verarbeitung (V)
            fahrenheit = (celsius * 9.0 / 5.0) + 32;
            
            // Ausgabe (A)
            Console.Write("Das Ergebnis: ");
            
            if (fahrenheit >= 0)
            {
                Console.Write("Ist größer oder gleich 0", 10);
            }
            else
            {
                Console.Write("Ist kleiner 0", 10);
            }
            
            Console.WriteLine();
            Console.WriteLine($"Celsius:    {celsius:f1}");
            Console.WriteLine($"Fahrenheit: {fahrenheit:f1}");
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
