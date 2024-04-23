/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Business Run
*                 You enter 3 terms via the console. Write
*                 a program that does all 6 possible
*                 Outputs combinations of these 3 terms.
*----------------------------------------------------------
*/
#nullable disable


namespace BusinessRun.ConApp
{
    /// <summary>
    /// Represents a program that displays a business card with a user's name and address.
    /// </summary>
    internal class Program
    {
        private const string InputFileName = "BusinessRun.csv";
        private const string OutputFileName = "RUN-Start.csv";
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("******************************************************");
            Console.WriteLine("* BusinessRun - Die zuverlässige Software für Läufer *");
            Console.WriteLine("******************************************************");
            Console.WriteLine();

            //Eingabe (E)
            Racer[] racers = ReadRacersFromFile(InputFileName);

            //Verarbeitung (V)
            SortRacerByTime(racers);

            //Ausgabe (A)
            DisplayTheFirstThreeRacers(racers);
            Console.WriteLine($"Durchschnittliche Laufzeit [sek]: {CalculateAverageTime(racers):f2}");

            SortRacerByStartNumber(racers);
            WriteRacersToFile(OutputFileName, racers);

            Console.WriteLine();
            Console.WriteLine("Beenden mit Eingabetaste... ");
            Console.ReadLine();
        }

        /// <summary>
        /// Reads racers from a file and returns an array of Racer objects.
        /// </summary>
        /// <param name="fileName">The name of the file to read racers from.</param>
        /// <returns>An array of Racer objects.</returns>
        private static Racer[] ReadRacersFromFile(string fileName)
        {
            List<Racer> racers = new List<Racer>();

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    Racer racer = new Racer
                    {
                        Number = parts[0],
                        Name = parts[1],
                        Vintage = int.Parse(parts[2]),
                        Nationality = parts[3],
                        Company = parts[4],
                        Team = parts[5],
                        Time = ConvertTimeToSeconds(parts[6])
                    };
                    racers.Add(racer);
                }
            }
            return racers.ToArray();
        }

        /// <summary>
        /// Writes an array of racers to a file.
        /// </summary>
        /// <param name="fileName">The name of the file to write to.</param>
        /// <param name="racers">The array of racers to write.</param>
        private static void WriteRacersToFile(string fileName, Racer[] racers)
        {
            List<string> lines = new List<string>();

            foreach (Racer racer in racers)
            {
                string line = $"{racer.Number};{racer.Name};{racer.Vintage};{racer.Nationality};{racer.Company};{racer.Team};{racer.Time}";

                lines.Add(line);
            }
            File.WriteAllLines(fileName, lines);
        }

        /// <summary>
        /// Displays the information of the first three racers in the given array of racers.
        /// </summary>
        /// <param name="racers">The array of racers.</param>
        private static void DisplayTheFirstThreeRacers(Racer[] racers)
        {
            Console.WriteLine($"{"Nr",-7}{"Name",-25}{"JG",-5}{"Nation",-7}{"Team",-30}{"Zeit[sec]",-10}");

            for (int i = 0; i < 3 && i < racers.Length; i++)
            {
                Console.WriteLine($"{racers[i].Number,-7}{racers[i].Name,-25}{racers[i].Vintage,-5}{racers[i].Nationality,-7}{racers[i].Team,-30}{racers[i].Time,-10:f2}");
            }
        }

        /// <summary>
        /// Sorts an array of racers by their time using the Bubble Sort algorithm.
        /// </summary>
        /// <param name="racers">The array of racers to be sorted.</param>
        public static void SortRacerByTime(Racer[] racers)
        {
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 0; i < racers.Length - 1; i++)
                {
                    if (racers[i].Time > racers[i + 1].Time)
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
        /// Sorts an array of racers by their start numbers in ascending order.
        /// </summary>
        /// <param name="racers">The array of racers to be sorted.</param>
        public static void SortRacerByStartNumber(Racer[] racers)
        {
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 0; i < racers.Length - 1; i++)
                {
                    if (racers[i].Number.CompareTo(racers[i + 1].Number) < 0)
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
        /// Calculates the average time for an array of racers.
        /// </summary>
        /// <param name="racers">The array of racers.</param>
        /// <returns>The average time.</returns>
        private static double CalculateAverageTime(Racer[] racers)
        {
            double result = 0;

            foreach (Racer racer in racers)
            {
                result += racer.Time;
            }
            return racers.Length > 0 ? result / racers.Length : 0.0;
        }

        /// <summary>
        /// Converts a time string in the format "mm:ss,ms" to seconds.
        /// </summary>
        /// <param name="time">The time string to convert.</param>
        /// <returns>The time in seconds.</returns>
        private static double ConvertTimeToSeconds(string time)
        {
            double result = 0;
            string[] parts = time.Split(':');

            if (IsValidTimeParts(parts))
            {
                result = int.Parse(parts[0]) * 60;

                string[] innerParts = parts[1].Split(',');

                if (IsValidTimeParts(innerParts))
                {
                    result += int.Parse(innerParts[0]);
                    result += int.Parse(innerParts[1]) / 10.0;
                }
            }
            return result;
        }

        /// <summary>
        /// Checks if the given array of time parts is valid.
        /// </summary>
        /// <param name="parts">The array of time parts to check.</param>
        /// <returns>True if the array has exactly 2 elements, otherwise false.</returns>
        private static bool IsValidTimeParts(string[] parts)
        {
            return parts.Length == 2;
        }
    }
}
