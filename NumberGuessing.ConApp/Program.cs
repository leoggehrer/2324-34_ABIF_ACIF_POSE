/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 NumberGuessing
*                 A program that generates a random number 
*                 between 1 and 100. Te player then has to 
*                 guess this number. The program counts the 
*                 guess attempts, and depending on the number 
*                 of attempts, the player's guessing strategy 
*                 is judged. After every If the attempt fails, 
*                 the player receives a hint as to whether the 
*                 number they are looking for is larger or 
*                 smaller than that entered number is.
*----------------------------------------------------------
*/
#nullable disable

namespace NumberGuessing.ConApp
{
    /// <summary>
    /// Represents the main program class for a number guessing game.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            string input;
            int counter = 0;
            int guessNumber;
            int randomNumber = Random.Shared.Next(1, 101);

            Console.WriteLine("Zahlenraten");
            Console.WriteLine("===========");
            Console.WriteLine();
            Console.WriteLine("Ich habe mir eine Zahl zwischen 1 und 100 ausgedacht. Kannst du sie erraten?");

            do
            {
                // Eingabe (E)
                Console.Write($"{++counter}. Versuch: ");
                input = Console.ReadLine();
                guessNumber = Convert.ToInt32(input);
                // Verarbeitung (V)
                if (guessNumber < randomNumber)
                {
                    Console.Write("Die gesuchte Zahl ist größer, ");
                }
                else if (guessNumber > randomNumber)
                {
                    Console.Write("Die gesuchte Zahl ist kleiner, ");
                }
            } while (guessNumber != randomNumber);

            // Ausgabe (A)
            if (counter > 1 && counter <= 5)
            {
                Console.WriteLine("Tolle Leistung!");
            }
            else if (counter > 5 && counter <= 10)
            {
                Console.WriteLine("Schon ganz gut!");
            }
            else
            {
                Console.WriteLine("Endlich geschafft!");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
