/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 VocabularyTrainer with CSV-File
*                 This program practices learning vocabulary.
*----------------------------------------------------------
*/
#nullable disable


namespace VocabularyTrainerWithCsv.ConApp
{
    /// <summary>
    /// Represents the main entry point for the program.
    /// </summary>
    internal class Program
    {
        private const string FileName = "vocabulary.csv";
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
            // Eingabe (E)
            Word[] words = ReadWordsFromCsv(FileName);
            // Verarbeitung (V)
            LerningRound(words);
            SortWordsByFails(words);

            // Ausgabe (A)
            PrintWordsStatistics(words);
            WriteWordsToCsv(words, FileName);
            
            Console.WriteLine();
            Console.WriteLine("Press enter to exit: ");
            Console.ReadLine();
        }

        /// <summary>
        /// Writes an array of Word objects to a CSV file.
        /// </summary>
        /// <param name="words">The array of Word objects to write.</param>
        /// <param name="fileName">The name of the CSV file to write to.</param>
        private static void WriteWordsToCsv(Word[] words, string fileName)
        {
            string[] lines = new string[words.Length + 1];

            lines[0] = "German;English;Fails;Hits";

            for (int i = 0; i < words.Length; i++)
            {
                Word word = words[i];

                lines[i + 1] = $"{word.GermanWord};{word.EnglishWord};{word.Fails};{word.Hits}";
            }

            File.WriteAllLines(fileName, lines);
        }

        /// <summary>
        /// Prints the statistics of the given array of Word objects.
        /// </summary>
        /// <param name="words">The array of Word objects.</param>
        private static void PrintWordsStatistics(Word[] words)
        {
            Console.WriteLine("Ergebnis des Vokabeltests");
            Console.WriteLine("=========================");
            
            Console.WriteLine($"{"deutsch", -25}{"englisch", -25}{"falsch", -10}{"richtig", -10}");
            for (int i = 0; i < words.Length; i++)
            {
                Word word = words[i];

                Console.WriteLine($"{word.GermanWord, -25}{word.EnglishWord,-25}{word.Fails, -10}{word.Hits,-10}");
            }
        }

        /// <summary>
        /// Reads words from a CSV file and returns an array of Word objects.
        /// </summary>
        /// <param name="inputFileName">The path of the input CSV file.</param>
        /// <returns>An array of Word objects.</returns>
        private static Word[] ReadWordsFromCsv(string inputFileName)
        {
            List<Word> result = new List<Word>();

            if (File.Exists(inputFileName))
            {
                var lines = File.ReadAllLines(inputFileName);

                for (int i = 1; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(';');

                    if (parts.Length > 1)
                    {
                        var word = new Word
                        {
                            GermanWord = parts[0],
                            EnglishWord = parts[1],
                            Fails = parts.Length > 2 ? int.Parse(parts[2]) : 0,
                            Hits = parts.Length > 3 ? int.Parse(parts[3]) : 0,
                        };
                        result.Add(word);
                    }
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Executes a learning round for a given array of words.
        /// </summary>
        /// <param name="words">The array of words to be used for the learning round.</param>
        private static void LerningRound(Word[] words)
        {
            string input;

            Console.Clear();
            Console.WriteLine("============= Vokabeltrainer =============");
            Console.WriteLine();
            Console.WriteLine("Beenden mit Eingabetaste");

            do
            {
                int index = Random.Shared.Next(0, words.Length);
                
                Word word = words[index];

                Console.Write($"{word.GermanWord}': ");
                input = Console.ReadLine();
                if (input != string.Empty)
                {
                    if (input == word.EnglishWord)
                    {
                        Console.WriteLine("Richtig!");
                        Console.WriteLine();
                        word.Hits++;
                    }
                    else
                    {
                        Console.WriteLine("Leider falsch!");
                        Console.WriteLine();
                        word.Fails++;
                    }
                }
            } while (input != string.Empty);
        }

        /// <summary>
        /// Sorts an array of Word objects by the number of fails in ascending order.
        /// </summary>
        /// <param name="words">The array of Word objects to be sorted.</param>
        private static void SortWordsByFails(Word[] words)
        {
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 0; i < words.Length - 1; i++)
                {
                    if (words[i].Fails < words[i + 1].Fails)
                    {
                        Word temp = words[i];

                        words[i] = words[i + 1];
                        words[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
}
