/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 FizzBuzz
*                 A C# program “FizzBuzz” that counts from 
*                 1 to 100 using a loop of your choice and 
*                 outputs according to the “Fizz-Buzz” rules. 
*----------------------------------------------------------
*/
#nullable disable
namespace FizzBuzz.ConApp
{
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            // Eingabe (E)
            int idx = 1;
            int number = 100;

            Console.WriteLine("***************************************");
            Console.WriteLine("* Ausgabe für Fizz-Buzz von 1 bis 100 *");
            Console.WriteLine("* Fizz, wenn durch 3 teilbar ist      *");
            Console.WriteLine("* Buzz, wenn durch 5 teilbar ist      *");
            Console.WriteLine("***************************************");

            // Verarbeitung (V)
            while (idx <= number)
            {
                if (idx % 3 != 0 && idx % 5 != 0)
                {
                    Console.Write($"{idx} ");
                }
                if (idx % 3 == 0)
                {
                    Console.Write("Fizz ");
                }
                if (idx % 5 == 0)
                {
                    Console.Write("Buzz ");
                }
                if (idx % 5 == 0 && idx % 3 == 0)
                {
                    Console.Write("Fizz Buzz ");
                }
                idx++;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
