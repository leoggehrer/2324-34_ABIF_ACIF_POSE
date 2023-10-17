/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 VisitYourAunt
*                 This program calculates the travel time
*                 to your favorite aunt by bike.
*----------------------------------------------------------
*/
#nullable disable

namespace VisitYourAunt
{
    /// <summary>
    /// Represents a program for calculating arrival time based on distance and speed.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method for calculating the arrival time
        /// </summary>
        /// <param name="args">The command-line arguments</param>
        static void Main(string[] args)
        {
            string input;
            double distance, speed, time;
            int hour, min, sec, timeInSec;
            
            Console.WriteLine("***************************************************");
            Console.WriteLine("* Lieblingstante - Die Fahrt zu meiner Tante      *");
            Console.WriteLine("*                  Berechnung der Ankunftszeit    *");
            Console.WriteLine("***************************************************");
            Console.WriteLine();
            
            // Eingabe (E)
            Console.Write("Enfernung in km:         ");
            input = Console.ReadLine();
            distance = Convert.ToDouble(input);
            
            Console.Write("Geschwindigkeit in km/h: ");
            input = Console.ReadLine();
            speed = Convert.ToDouble(input);
            
            // Verarbeitung (V)
            time = distance / speed;
            timeInSec = (int)(time * 3600);
            hour = 10 + ((timeInSec / 3600) % 24); // 10 Uhr + Anzahl der Stunden und falls die Fahrt ueber 24 Stunden benoetigt.
            min = (timeInSec % 3600) / 60;
            sec = timeInSec % 60;
            
            // Ausgabe (A)
            Console.WriteLine();
            Console.WriteLine($"Für die Strecke von {distance:f2} benötigen Sie {time:f2} Stunden.");
            Console.WriteLine($"Sie kommen um {hour:D2}:{min:D2}:{sec:D2} an.");
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}


