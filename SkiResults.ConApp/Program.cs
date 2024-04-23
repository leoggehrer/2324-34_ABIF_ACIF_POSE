/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 SkiResults
*                 This program managed the results of ski results.
*----------------------------------------------------------
*/
#nullable disable


namespace SkiResults.ConApp
{
    /// <summary>
    /// Represents the main entry point for the program.
    /// </summary>
    internal class Program
    {
        private const string FileNameResultsOne = "results_run1.csv";
        private const string FileNameResultsTwo = "results_run2.csv";
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
            Racer[] racers = ReadRacersFromCsv(FileNameResultsOne, FileNameResultsTwo);

            // Verarbeitung (V) & Ausgabe (A)
            RunApp(racers);

            Console.WriteLine();
            Console.WriteLine("Press enter to exit: ");
            Console.ReadLine();
        }
        private static void RunApp(Racer[] racers)
        {
            bool exit;
            do
            {
                exit = false;
                Console.WriteLine();
                Console.WriteLine("1...Rangliste Ausgeben");
                Console.WriteLine("2...Disqualifizierte Läufer ausgeben");
                Console.WriteLine("3...Disqualifizierte Läufer löschen");
                Console.WriteLine("4...Ergbnisse speichern");
                Console.WriteLine("0...Beenden");
                Console.Write("Ihre Wahl: ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    SortRacersByTotalTime(racers);
                    PrintRacersByRank("Rangliste:", racers);
                }
                else if (input == "2")
                {
                    Racer[] disqualifiers = GetDisqualifiersRacers(racers);
                    PrintRacersByRank("Disqualifizierte Läufer:", disqualifiers);
                }
                else if (input == "3")
                {
                    racers = DeleteDisqualifiersRacers(racers);
                }
                else if (input == "4")
                {
                    SortRacersByTotalTime(racers);
                    WriteRacersToCsv("results.csv", racers);
                }
                else if (input == "0")
                {
                    exit = true;                    
                }

            } while (exit == false);
        }

        /// <summary>
        /// Writes the racers' data to a CSV file.
        /// </summary>
        /// <param name="fileName">The name of the CSV file.</param>
        /// <param name="racers">An array of Racer objects containing the racers' data.</param>
        private static void WriteRacersToCsv(string fileName, Racer[] racers)
        {
            List<string> lines = new List<string>();

            lines.Add("Rang;Country;Name;TimeOne;TimeTwo;TotalTime");
            for (int i = 0; i < racers.Length; i++)
            {
                int rank = racers[i].TimeOne == 0 || racers[i].TimeTwo == 0 ? -1 : i + 1;

                lines.Add($"{rank};{racers[i].Country};{racers[i].Name};{racers[i].TimeOne};{racers[i].TimeTwo};{racers[i].TotalTime}");
            }
            File.WriteAllLines(fileName, lines);
        }

        /// <summary>
        /// Reads racer data from two CSV files and returns an array of Racer objects.
        /// </summary>
        /// <param name="fileNameResultsOne">The file path of the first CSV file.</param>
        /// <param name="fileNameResultsTwo">The file path of the second CSV file.</param>
        /// <returns>An array of Racer objects containing the racer data.</returns>
        private static Racer[] ReadRacersFromCsv(string fileNameResultsOne, string fileNameResultsTwo)
        {
            Racer[] result = new Racer[0];

            // passage one
            if (File.Exists(fileNameResultsOne))
            {
                var lines = File.ReadAllLines(fileNameResultsOne);

                result = new Racer[lines.Length - 1];
                for (int i = 1; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(';');

                    if (parts.Length > 1)
                    {
                        var racer = new Racer
                        {
                            Country = parts[0],
                            Name = parts[1],
                            TimeOne = ConvertTimeToSeconds(parts[2]),
                        };
                        result[i - 1] = racer;
                    }
                }
            }
            // passage two
            if (File.Exists(fileNameResultsTwo))
            {
                var lines = File.ReadAllLines(fileNameResultsTwo);

                for (int i = 1; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(';');

                    if (parts.Length > 1)
                    {
                        var racer = GetRacerByName(result, parts[1]);

                        if (racer != null)
                        {
                            racer.TimeTwo = ConvertTimeToSeconds(parts[2]);
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Represents a racer.
        /// </summary>
        private static Racer GetRacerByName(Racer[] racers, string name)
        {
            Racer result = null;

            for (int i = 0; i < racers.Length && result == null; i++)
            {
                if (racers[i].Name == name)
                {
                    result = racers[i];
                }
            }
            return result;
        }

        /// <summary>
        /// Sorts an array of racers by their total time in ascending order.
        /// </summary>
        /// <param name="racers">The array of racers to be sorted.</param>
        private static void SortRacersByTotalTime(Racer[] racers)
        {
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 0; i < racers.Length - 1; i++)
                {
                    if (racers[i].TotalTime > racers[i + 1].TotalTime)
                    {
                        Racer temp = racers[i];

                        racers[i] = racers[i + 1];
                        racers[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
        /// <summary>
        /// Retrieves an array of racers who have been disqualified.
        /// A racer is considered disqualified if either their TimeOne or TimeTwo is equal to 0.
        /// </summary>
        /// <param name="racers">The array of racers to check for disqualifications.</param>
        /// <returns>An array of racers who have been disqualified.</returns>
        private static Racer[] GetDisqualifiersRacers(Racer[] racers)
        {
            List<Racer> result = new List<Racer>();

            foreach (Racer racer in racers)
            {
                if (racer.TimeOne == 0 || racer.TimeTwo == 0)
                {
                    result.Add(racer);
                }
            }
            return result.ToArray();
        }
        /// <summary>
        /// Deletes disqualifiers from the array of racers.
        /// A racer is considered a disqualifier if their TimeOne and TimeTwo properties are both equal to 0.
        /// </summary>
        /// <param name="racers">The array of racers to filter.</param>
        /// <returns>An array of racers without the disqualifiers.</returns>
        private static Racer[] DeleteDisqualifiersRacers(Racer[] racers)
        {
            List<Racer> result = new List<Racer>();

            foreach (Racer racer in racers)
            {
                if (racer.TimeOne != 0 && racer.TimeTwo != 0)
                {
                    result.Add(racer);
                }
            }
            return result.ToArray();
        }
        /// <summary>
        /// Prints the racers by rank.
        /// </summary>
        /// <param name="title">The title to display.</param>
        /// <param name="racers">The array of racers.</param>
        private static void PrintRacersByRank(string title, Racer[] racers)
        {
            Console.WriteLine(title);
            Console.WriteLine();
            Console.WriteLine($"{"",-5}{"Name",-35}{"Country",-10}{"Time",-8}{ "Time",-8}{"Total Time"}");

            for (int i = 0; i < racers.Length; i++)
            {
                Console.WriteLine($"{i + 1, -5}{racers[i].Name,-35}{racers[i].Country, -10}{racers[i].TimeOne,-8:f2}{racers[i].TimeTwo, -8:f2}{racers[i].TotalTime:f2}");
            }
        }
        /// <summary>
        /// Converts a time string to seconds.
        /// </summary>
        /// <param name="time">The time string to convert.</param>
        /// <returns>The time in seconds.</returns>
        private static double ConvertTimeToSeconds(string time)
        {
            double result = 0;
            string[] parts = time.Replace(":", ".").Split('.');

            if (parts.Length == 3)
            {
                result = int.Parse(parts[0]) * 60; // minutes
                result += int.Parse(parts[1]); // seconds
                result += double.Parse(parts[2]) / 10.0;
            }
            else if (parts.Length == 2)
            {
                result = int.Parse(parts[0]); // seconds
                result += double.Parse(parts[1]) / 10.0;
            }

            return result;
        }
    }
}
