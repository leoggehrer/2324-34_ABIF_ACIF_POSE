/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 MaxOf3Values
*                 This program determines the maximum of 3 numbers.
*----------------------------------------------------------
*/

#nullable disable

namespace MaxOf3Values.ConApp
{
    /// <summary>
    /// Represents a program for calculating the minimum and maximum values among three input numbers.
    /// </summary>
    //...
    internal class Program
    {
        /// /
        // Code logic goes here
        static void Main(string[] args)
        {
            string input;
            int nOne, nTwo, nThree, nMax, nMin;
            
            Console.WriteLine("MinMax Calculator");
            Console.WriteLine("=================");
            Console.WriteLine();
            
            // Eingabe (E)
            Console.Write("Eingabe Zahl 1: ");
            input = Console.ReadLine();
            nOne = Convert.ToInt32(input);
            
            Console.Write("Eingabe Zahl 2: ");
            input = Console.ReadLine();
            nTwo = Convert.ToInt32(input);
            
            Console.Write("Eingabe Zahl 3: ");
            input = Console.ReadLine();
            nThree = Convert.ToInt32(input);
            
            // Verarbeitung (V)
            if (nOne >= nTwo && nTwo >= nThree)
            {
                nMax = nOne;
            }
            else if (nTwo >= nOne && nOne >= nThree)
            {
                nMax = nTwo;
            }
            else
            {
                nMax = nThree;
            }
            
            if (nOne <= nTwo && nTwo <= nThree)
            {
                nMin = nOne;
            }
            else if (nTwo <= nOne && nOne <= nThree)
            {
                nMin = nTwo;
            }
            else
            {
                nMin = nThree;
            }
            
            // Ausgabe (A)
            Console.WriteLine();
            Console.WriteLine($"Max = {nMax, 10}");
            Console.WriteLine($"Min = {nMin, 10}");
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
