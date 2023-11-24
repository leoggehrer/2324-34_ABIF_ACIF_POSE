/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 NumberStatistics
*                 This program reads a series of integers 
*                 and calculates the mean, max, min and 
*                 average values.
*----------------------------------------------------------
*/

#nullable disable

namespace NumberStatistics.ConApp
{
    /// <summary>
    /// Represents an internal class that contains the main entry point for the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// This method calculates statistics for a list of positive integers entered by the user.
        /// </summary>
        /// <param name="args">An array of command-line arguments.</param>
        /// <returns>Void</returns>
        // method code
        static void Main(string[] args)
        {
            string input;
            int sum = 0, prvMax = Int32.MinValue, max = Int32.MinValue, min = Int32.MaxValue, num = 0, idx = 0;
            double average = 0;

            Console.WriteLine(" Zahlen Statistik ");
            Console.WriteLine("==================");
            Console.WriteLine();

            // Eingabe (E)
            Console.WriteLine("Geben Sie positive ganze Zahlen ein [0..Ende]");

            do
            {
                idx = idx + 1;
                Console.Write($"Zahl {idx}: ");
                input = Console.ReadLine();
                num = Convert.ToInt32(input);
                if (num != 0)
                {
                    // Verarbeitung (V)
                    sum = sum + num;
                    if (num > max)
                    {
                        prvMax = max;
                        max = num;
                    }
                    else if (num > prvMax && num < max)
                    {
                        prvMax = num;
                    }

                    if (num < min)
                    {
                        min = num;
                    }
                    average = sum / (double)idx;
                }
            } while (num != 0);

            // Ausgabe (A)
            Console.WriteLine();
            if (idx > 1)
            {
                Console.WriteLine($"Sie haben {idx - 1} Zahlen eingegeben.");
                Console.WriteLine($"Die Summe der eingegebenen Zahlen ist {sum}.");
                Console.WriteLine($"Der maximale Wert ist {max}.");
                if (idx > 2)
                {
                    Console.WriteLine($"Die zweitgrößte Zahl ist {prvMax}.");
                }
                Console.WriteLine($"Der minimale Wert ist {min}.");
                Console.WriteLine($"Der Durchschnittswert ist {average:f}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}