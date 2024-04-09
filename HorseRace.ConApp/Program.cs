/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*---------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Horse Races
*                 This program simulates a horse race.
*----------------------------------------------------------
*/
#nullable disable

namespace HorseRace.ConApp
{
    /// <summary>
    /// Represents the entry point of the program.
    /// </summary>
    internal class Program
    {
        private const string FILE_NAME = "horses.csv";
        /// <summary>
        /// The main method of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            RunApp();
        }

        /// <summary>
        /// Runs the horse race application.
        /// </summary>
        private static void RunApp()
        {
            Horse[] horses = ReadFromCsvFile(FILE_NAME);
            int tipp = GetTipp(horses);

            if (IsCorrectTipp(horses, tipp))
            {
                Horse horse = GetHorseByNumber(horses, tipp);

                Console.WriteLine("Ihr Tipp mit der Startnummer {tipp} heisst {horse.Name} und ist {horse.Age} Jahre alt.");
                Console.WriteLine("Das Rennen beginnt ...");
                SimulateRace(horses);
                SortHorsesByPosition(horses);
                int index = GetHorseIndexByNumber(horses, tipp);

                Console.WriteLine($"Ihr Startnummer {tipp} Name {horse.Name} {horse.Age} Jahre alt erzielte Rang {index + 1}!");
            }
            else
            {
                Console.WriteLine("Ihr Tipp ist falsch!");
            }
        }


        /// <summary>
        /// Simulates a horse race by moving each horse randomly until one of them reaches the finish line.
        /// </summary>
        /// <param name="horses">An array of Horse objects representing the horses participating in the race.</param>
        private static void SimulateRace(Horse[] horses)
        {
            bool raceFinished = false;

            for (int i = 0; i < horses.Length; i++)
            {
                horses[i].Position = 0;
            }

            while (raceFinished == false)
            {
                for (int i = 0; i < horses.Length; i++)
                {
                    bool canMove = Random.Shared.Next(0, 2) == 1;

                    if (canMove)
                    {
                        horses[i].Position++;
                        raceFinished = horses[i].Position >= 60;
                    }
                }
                PrintSimulation(horses);
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Prints the simulation of a horse race.
        /// </summary>
        /// <param name="horses">An array of Horse objects representing the horses in the race.</param>
        private static void PrintSimulation(Horse[] horses)
        {
            Console.Clear();
            Console.WriteLine("Pferderennen - Simulation");

            for (int i = 0; i < horses.Length; i++)
            {
                Console.WriteLine($"Pferd {horses[i].Number, 2}: {new string(' ', horses[i].Position)}*");
            }
        }

        /// <summary>
        /// Reads data from a CSV file and returns an array of Horse objects.
        /// </summary>
        /// <param name="fileName">The path to the CSV file.</param>
        /// <returns>An array of Horse objects.</returns>
        private static Horse[] ReadFromCsvFile(string fileName)
        {
            Horse[] result = new Horse[0];

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                result = new Horse[lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(';');

                    Horse horse = new Horse
                    {
                        Number = i + 1,
                        Name = data[0],
                        Age = int.Parse(data[1]),
                    };
                    result[i] = horse;
                }
            }
            return result;
        }

        /// <summary>
        /// Prints the details of the horses.
        /// </summary>
        /// <param name="horses">An array of Horse objects.</param>
        private static void PrintHorses(Horse[] horses)
        {
            string format = "{0,-4} {1,-20} {2,-5}";
            string output = string.Format(format, "Nr.", "Name", "Alter");

            Console.WriteLine(output);
            Console.Write(new string('=', output.Length));
            Console.WriteLine();

            for (int i = 0; i < horses.Length; i++)
            {
                Horse horse = horses[i];

                if (horse != null)
                {
                    output = string.Format(format, horse.Number, horse.Name, horse.Age);

                    Console.WriteLine(output);
                }
            }
        }

        /// <summary>
        /// Gets the user's choice for the horse in the horse race.
        /// </summary>
        /// <param name="horses">The array of Horse objects representing the horses in the race.</param>
        /// <returns>The user's choice for the horse.</returns>
        private static int GetTipp(Horse[] horses)
        {
            int tipp;
            bool validChoice = false;

            do
            {
                Console.WriteLine("Pferderennen - Starterliste");
                Console.WriteLine("===========================");
                PrintHorses(horses);
                Console.WriteLine();
                Console.Write("Auf welches Pferd wollen Sie setzen? (0 für Ende): ");
                if (int.TryParse(Console.ReadLine(), out tipp))
                {
                    validChoice = tipp == 0 || IsCorrectTipp(horses, tipp);
                }
            } while (validChoice == false);

            return tipp;
        }

        /// <summary>
        /// Checks if the given tipp is correct by comparing it with the numbers of the horses.
        /// </summary>
        /// <param name="horses">An array of Horse objects representing the horses in the race.</param>
        /// <param name="tipp">The tipp to be checked.</param>
        /// <returns>True if the tipp is correct, otherwise false.</returns>
        private static bool IsCorrectTipp(Horse[] horses, int tipp)
        {
            bool result = false;

            for (int i = 0; i < horses.Length && result == false; i++)
            {
                if (horses[i].Number == tipp)
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the Horse in the array based on its number.
        /// </summary>
        /// <param name="horses">The array of horses.</param>
        /// <param name="number">The number of the horse to search for.</param>
        /// <returns>The index of the horse in the array, or -1 if not found.</returns>
        private static Horse GetHorseByNumber(Horse[] horses, int number)
        {
            Horse result = null;
            int index = GetHorseIndexByNumber(horses, number);

            if (index != -1)
            {
                result = horses[index];
            }
            return result;
        }
        /// <summary>
        /// Gets the index of a horse in the array based on its number.
        /// </summary>
        /// <param name="horses">The array of horses.</param>
        /// <param name="number">The number of the horse to search for.</param>
        /// <returns>The index of the horse in the array, or -1 if not found.</returns>
        private static int GetHorseIndexByNumber(Horse[] horses, int number)
        {
            int result = -1;

            for (int i = 0; i < horses.Length && result == -1; i++)
            {
                if (horses[i].Number == number)
                {
                    result = i;
                }
            }
            return result;
        }

        /// <summary>
        /// Sorts an array of Horse objects by their position in descending order.
        /// </summary>
        /// <param name="horses">The array of Horse objects to be sorted.</param>
        private static void SortHorsesByPosition(Horse[] horses)
        {
            for (int i = 0; i < horses.Length -1; i++)
            {
                for (int j = i + 1; j < horses.Length; j++)
                {
                    if (horses[i].Position < horses[j].Position)
                    {
                        Horse temp = horses[i];

                        horses[i] = horses[j];
                        horses[j] = temp;
                    }
                }
            }
        }
    }
}
