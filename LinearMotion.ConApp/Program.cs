/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 LienarMotion
*                 This program calculates the distance 
*                 between two vehicles approaching each 
*                 other every minute. The calculation 
*                 continues until the vehicles reach 
*                 the distance of 0. 
*----------------------------------------------------------
*/

#nullable disable

namespace LinearMotion.ConApp
{
    /// <summary>
    /// Represents the main program for calculating the meeting point of two vehicles in linear motion.
    /// </summary>
    // ...
    internal class Program
    {
        /// <summary>
        /// This method simulates the linear motion of two vehicles meeting each other.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        static void Main(string[] args)
        {
            string input;
            int counterInSec = 0;
            double distanceInKm, distanceInM, way = 0;
            double speedInKmh_A, speedInKmh_B, speedInSec_A, speedInSec_B;
            double distanceInM_A, distanceInM_B;

            Console.WriteLine("Lienar Motion");
            Console.WriteLine("=============");
            Console.WriteLine();
            Console.WriteLine("Begegnung zweier entgegenfahrender Fahrzeuge");
            Console.WriteLine();

            // Eingabe (E)
            Console.Write("Entfernung [positive Ganzzahl in km]:                         ");
            input = Console.ReadLine();
            distanceInKm = Convert.ToDouble(input);
            distanceInM = distanceInKm * 1_000;

            Console.Write("Geschwindigkeit des Fahrzeuges A [positive Ganzzahl in km/h]: ");
            input = Console.ReadLine();
            speedInKmh_A = Convert.ToDouble(input);
            speedInSec_A = speedInKmh_A / 3.6;

            Console.Write("Geschwindigkeit des Fahrzeuges B [positive Ganzzahl in km/h]: ");
            input = Console.ReadLine();
            speedInKmh_B = Convert.ToDouble(input);
            speedInSec_B = speedInKmh_B / 3.6;
            Console.WriteLine();

            // Verarbeitung (V)
            while (way < distanceInM)
            {
                way = (speedInSec_A + speedInSec_B) * counterInSec;
                distanceInM_A = way * speedInSec_A / (speedInSec_A + speedInSec_B);
                distanceInM_B = way * speedInSec_B / (speedInSec_A + speedInSec_B);
                // Ausgabe (A)
                if (counterInSec % 60 == 0)
                {
                    Console.WriteLine($"Minute: {counterInSec / 60,4} | Position A: {distanceInM_A / 1_000,6:f} km | Position B: {distanceInM_B / 1_000,6:f} km | Distanz: {Math.Abs(distanceInM - distanceInM_A - distanceInM_B) / 1_000,6:f}");
                }
                counterInSec++;
            }
            counterInSec = counterInSec > 0 ? counterInSec - 1 : counterInSec;
            distanceInM_A = distanceInM * speedInSec_A / (speedInSec_A + speedInSec_B);
            distanceInM_B = distanceInM * speedInSec_B / (speedInSec_A + speedInSec_B);

            // Ausgabe (A)
            Console.WriteLine();
            Console.WriteLine($"Treffpunkt von A nach {distanceInM_A / 1_000:f} km und von B nach {distanceInM_B / 1_000:f} km nach {counterInSec / 3_600} Stunden, {(counterInSec % 3_600) / 60} Minuten und {counterInSec % 60} Sekunden");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
