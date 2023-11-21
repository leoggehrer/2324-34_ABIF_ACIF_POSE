namespace Dagobert.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Das Rätsel von Dagobert!");

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
        }
    }
}