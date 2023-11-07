/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 FuelCalculator
*                 This program calculates the average
*                 consumption and provides a comment.
*----------------------------------------------------------
*/

#nullable disable

namespace FuelCalculator.ConApp
{
    /// <summary>
    /// The Program class is responsible for calculating the fuel consumption of a vehicle.
    /// </summary>
    // Rest of the code...
    internal class Program
    {
        /// <summary>
        /// Calculates the average fuel consumption per 100 km based on user input.
        /// </summary>
        /// <param name="args">Array of command-line arguments.</param>
        /// <returns>void</returns>
        static void Main(string[] args)
        {
            string input, fuel;
            double distance, consumption, consumptionPer100;
            
            Console.WriteLine("Fuel Calculator");
            Console.WriteLine("===============");
            Console.WriteLine();
            
            // Eingabe (E)
            Console.Write("Welchen Kraftstoff tanken Sie (Diesel/Benzin)? ");
            fuel = Console.ReadLine();
            Console.Write("Wieviel Kilometer sind Sie gefahren?           ");
            input = Console.ReadLine();
            distance = Convert.ToDouble(input);
            Console.Write("Wieviel Kraftstoff haben Sie getankt?          ");
            input = Console.ReadLine();
            consumption = Convert.ToDouble(input);
            
            // Verarbeitung (V)
            consumptionPer100 = consumption / distance * 100;
            
            // Ausgabe (A)
            Console.WriteLine();
            if (fuel.ToLower() != "benzin" && fuel.ToLower() != "diesel")
            {
                Console.WriteLine("Ungültige Kraftstoff!");
            }
            else
            {
                Console.WriteLine($"Der errechnete Durchschnittsverbrauch ist {consumptionPer100:F2} Liter pro 100 km");
                
                if (fuel.ToLower() == "Diesel")
                {
                    if (consumptionPer100 < 5.0)
                    {
                        Console.WriteLine("Ihr Auto ist sparsam!");
                    }
                    else if (consumptionPer100 <= 6.0)
                    {
                        Console.WriteLine("Ihr Auto ist im Normbereich!");
                    }
                    else
                    {
                        Console.WriteLine("Ihr Auto verbraucht zu viel!");
                    }
                }
                else
                {
                    // Benzin
                    if (consumptionPer100 < 6.0)
                    {
                        Console.WriteLine("Ihr Auto ist sparsam!");
                    }
                    else if (consumptionPer100 <= 7.0)
                    {
                        Console.WriteLine("Ihr Auto ist im Normbereich!");
                    }
                    else
                    {
                        Console.WriteLine("Ihr Auto verbraucht zu viel!");
                    }
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
