/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 GrownUpCalculator
*                 The implementation of age evaluation #
*                 from lessons.
*----------------------------------------------------------
*/

#nullable disable

namespace GrownUpCalculator.ConApp
{
    /// <summary>
    /// Represents the main program of the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main method of the program. Asks the user for their age, calculates the difference
        /// between their age and the grown-up age (18), and displays a message based on the age
        /// category they fall into.
        /// </summary>
        /// <param name="args">Command line arguments, if any.</param>
        /// <returns>None</returns>
        static void Main(string[] args)
        {
            const int GROWN_UP_AGE = 18;
            string input;
            int age, ageDiff;
            
            Console.WriteLine("GrownUp Calculator");
            Console.WriteLine("==================");
            Console.WriteLine();
            
            // Eingabe (E)
            Console.Write("How old are you? ");
            input = Console.ReadLine();
            age = Convert.ToInt32(input);
            
            // Verarbeitung (V)
            ageDiff = age - GROWN_UP_AGE;
            
            // Ausgabe (A)
            if (ageDiff >= 0)
            {
                Console.WriteLine($"In approx. {ageDiff} you will be grwon-up");
            }
            else
            {
                Console.WriteLine("You are to old");
                
            }
            
            if (age < 18)
            {
                Console.WriteLine("You are under 18. ");
            }
            else if (age == 18)
            {
                Console.WriteLine("You are right now 18");
            }
            else if (age > 18 || age <= 20)
            {
                Console.WriteLine($"You are {age}");
            }
            else if (age > 20 || age <= 25)
            {
                Console.WriteLine($"You are between 21 and 25. Right now You are {age}");
            }
            else
            {
                Console.WriteLine("You are living your life. Keep growing!!!");
            }
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
