/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Dagobert
*                 This program solves Scrooge's wealth puzzle.
*----------------------------------------------------------
*/
#nullable disable

namespace Dagobert.ConApp
{
    /// <summary>
    /// Represents the entry point of the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// This method solves the "Das große Rätsel von Dagobert" by finding a triangle number (tSum) and a square number (qSum)
        /// that are equal in a given range. It starts with initial values of t = 1_000 and q = 1_000,
        /// and increases t or q depending on the comparison of tSum and qSum until they are equal or tSum exceeds the upper range.
        /// If a solution is found, it displays the solution with the values of t, q, and the common sum (qSum).
        /// If no solution is found within the specified lower and upper range, it displays a message indicating the absence of such numbers.
        /// </summary>
        /// <param name="args">An array of arguments passed to the program</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Das große Rätsel von Dagobert!");
            Console.WriteLine("==============================");
            Console.WriteLine();

            // Eingabe (E)
            const int UPPER_RANGE = 2_000_000;
            const int LOWER_RANGE = 1_000_000;
            int tSum, t = 1_000, qSum, q = 1_000;

            // Verarbeitung (V)
            do
            {
                tSum = (t + 1) * t / 2;
                qSum = q * q;

                if (tSum < qSum)
                {
                    t++;
                }
                else if (qSum < tSum)
                {
                    q++;
                }
            } while (tSum != qSum && tSum <= UPPER_RANGE);

            // Ausgabe (A)
            if (tSum == qSum)
            {  // Loesung gefunden
                Console.WriteLine();
                Console.WriteLine($"Die Lösung des Rätsels [{t},{q}]: Es sind {qSum} Dukaten!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Es gibt keine Dreieckszahl und Quadratzahl welche im Bereich {LOWER_RANGE} - {UPPER_RANGE} gleich sind!");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}