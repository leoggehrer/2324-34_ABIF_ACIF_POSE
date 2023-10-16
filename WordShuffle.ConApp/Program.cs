/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 The user's name and addresses are read
*                 in and output in the form of a business card.
*----------------------------------------------------------
*/
#nullable disable

namespace WordShuffle.ConApp
{
    ///<summary>
    /// Represents the Program class.
    ///</summary>
    internal class Program
    {
        /// <summary>
        /// The main method for the Word Shuffle program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Word Shuffle");
            Console.WriteLine("============");
            
            //Eingabe (E)
            Console.Write("Please enter 1st word: ");
            string word1 = Console.ReadLine();
            
            Console.Write("Please enter 2nd word: ");
            string word2 = Console.ReadLine();
            
            Console.Write("Please enter 1rd word: ");
            string word3 = Console.ReadLine();
            
            //Verarbeitung (V)
            
            //Ausgabe (A)
            Console.WriteLine("Shuffling words ... six possible combinations:");
            Console.WriteLine();
            Console.WriteLine(word1 + " " + word2 + " " + word3);
            Console.WriteLine(word1 + " " + word3 + " " + word2);
            Console.WriteLine(word2 + " " + word1 + " " + word3);
            Console.WriteLine(word2 + " " + word3 + " " + word1);
            Console.WriteLine(word3 + " " + word1 + " " + word2);
            Console.WriteLine(word3 + " " + word2 + " " + word1);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
