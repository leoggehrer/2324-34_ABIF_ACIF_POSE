/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 VocabularyTrainer
*                 This program practices learning vocabulary.
*----------------------------------------------------------
*/
#nullable disable

namespace VocabularyTrainer.ConApp
{
    /// <summary>
    /// Represents the main entry point for the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// This method handles the main logic of the vocabulary learning program.
        /// It prompts the user to enter an English word and its German translation,
        /// and then asks the user to provide the German translation for the entered word.
        /// It continues to prompt the user until the correct translation is provided or
        /// the maximum number of attempts is reached.
        /// Finally, it displays a message based on the number of attempts made by the user.
        /// </summary>
        /// <param name="args">Array of string arguments passed to the program</param>
        static void Main(string[] args)
        {
            int counter = 0;
            string englishWord, germanWord;
            string translation;

            Console.WriteLine("Lerne die Vokabeln!");
            Console.WriteLine("===================");
            Console.WriteLine();

            // Eingabe (E)
            Console.WriteLine("* --------------------------- *");
            Console.WriteLine("*      Expertenabschnitt      *");
            Console.WriteLine("* --------------------------- *");
            Console.WriteLine();
            Console.Write("Englisches Wort:      ");
            englishWord = Console.ReadLine()!;
            Console.Write("Deutsche Übersetzung: ");
            germanWord = Console.ReadLine()!;

            Console.Clear();
            Console.WriteLine("* --------------------------- *");
            Console.WriteLine("*      Schülerabschnitt       *");
            Console.WriteLine("* --------------------------- *");
            Console.WriteLine();
            Console.WriteLine($"Gib die deutsche Übersetzung für '{englishWord}' an:");
            Console.WriteLine();

            // Verarbeitung (V)
            do
            {
                Console.Write($"{++counter}. Versuch: ");
                translation = Console.ReadLine()!;
            } while (translation != germanWord && counter < 10);

            // Ausgabe (A)
            if (counter == 1)
            {
                Console.WriteLine("Ausgezeichnet, sofort gewußt!");
            }
            else if ((counter == 2) || (counter == 3))
            {
                Console.WriteLine("Gut gemacht, nur {0} Versuche!", counter);
            }
            else if ((counter == 4) || (counter == 5))
            {
                Console.WriteLine("Ein bisschen üben, das wird schon.");
            }
            else if ((counter > 5) && (counter < 10))
            {
                Console.WriteLine("Üben, üben, üben!");
            }
            else if (counter == 10)
            {
                Console.WriteLine("Das war wohl nichts!!");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
