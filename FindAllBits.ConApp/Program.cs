/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 FindAllBits
*                 This program calculates all bits of an 
*                 entered number.
*----------------------------------------------------------
*/
#nullable disable
namespace FindAllBits.ConApp
{
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            string input;
            uint number = 0;
            double numPow = 0;
            int idx = 0, bit = 0, sumBit = 0;

            Console.WriteLine("Find all Bits");
            Console.WriteLine("=============");
            Console.WriteLine();

            //Eingabe (E)
            Console.Write($"Geben Sie eine Zahl zwischen 1 und {uint.MaxValue} ein (0 für Ende): ");
            input = Console.ReadLine();

            //Verarbeitung (V)
            if (uint.TryParse(input, out number) && number > 0)
            {
                while (number > 0)
                {
                    bit = (int)number % 2;  // 0 or 1
                    number = number / 2;
                    numPow = bit * Math.Pow(2, idx);
                    sumBit += (int)numPow;  // Summe aller Bits berechnen

                    // Ausgabe (A)
                    Console.WriteLine($"{bit} * 2^{idx++} = {numPow}");                   
                }
                Console.WriteLine("=========================");
                Console.WriteLine($"Dezimalzahl:          {input:n0}");
                Console.WriteLine($"Summe aller Bitwerte: {sumBit:n0}");
                Console.WriteLine("=========================");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit... ");
            Console.ReadKey();
        }
    }
}
