/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Game Of Life
*                 This is a simple implementation of the
*                 Game of Life. It is a cellular automaton
*                 devised by the British mathematician
*                 John Horton Conway in 1970.
*----------------------------------------------------------
*/
#nullable disable

namespace GameOfLife.ConApp
{
    /// <summary>
    /// Represents the entry point of the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The maximum number of rows in the game grid.
        /// </summary>
        const int MAX_ROWS = 20;
        /// <summary>
        /// The maximum number of columns in the game grid.
        /// </summary>
        const int MAX_COLS = 79;

        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            string input;
            int[,] field = new int[0, 0];
            int occupancy;

            Console.Clear();
            Console.WriteLine("GameOfLife");
            Console.WriteLine("==========");
            Console.WriteLine();
            Console.WriteLine("1...Erstellen eines zufälligen Feldes (79 * 20 Zellen)");
            Console.WriteLine("2...Erstellen eines Blinkers (Blinker.csv)");
            Console.WriteLine("3...Erstellen eines Blinkers II (Blinker2.csv)");
            Console.WriteLine("4...Erstellen eines Bipols (Bipol.csv)");

            Console.WriteLine();
            Console.Write("Wählen Sie eine Option: ");
            input = Console.ReadLine();

            if (input == "1")
            {
                do
                {
                    Console.Write($"Wieviele Zellen sollen lebendig sein <Max: {MAX_ROWS * MAX_COLS}> ? ");
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out occupancy) || occupancy < 0 || occupancy > MAX_ROWS * MAX_COLS);

                field = CreateRandomField(MAX_ROWS, MAX_COLS, occupancy);
            }
            else if (input == "2")
            {
                field = ReadFieldFromCsvFile("Blinker.csv");
            }
            else if (input == "3")
            {
                field = ReadFieldFromCsvFile("Blinker2.csv");
            }
            else if (input == "4")
            {
                field = ReadFieldFromCsvFile("Bipol.csv");
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe!");
            }

            Simulate(field, 1000, 250);
        }

        /// <summary>
        /// Simulates the Game of Life by iterating through the given field for a specified number of iterations.
        /// </summary>
        /// <param name="field">The initial field configuration.</param>
        /// <param name="iterations">The number of iterations to simulate.</param>
        /// <param name="delay">The delay (in milliseconds) between each iteration.</param>
        public static void Simulate(int[,] field, int iterations, int delay)
        {
            PrintField(field);
            Thread.Sleep(delay);
            for (int i = 0; i < iterations && SumCellValues(field) > 0; i++)
            {
                field = CreateNextGeneration(field);
                PrintField(field);
                Thread.Sleep(delay);
            }
        }

        /// <summary>
        /// Calculates the sum of all cell values in a given field.
        /// </summary>
        /// <param name="field">The 2D array representing the field.</param>
        /// <returns>The sum of all cell values.</returns>
        public static int SumCellValues(int[,] field)
        {
            int sum = 0;
            for (int r = 0; r < field.GetLength(0); r++)
            {
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    sum += field[r, c];
                }
            }
            return sum;
        }

        /// <summary>
        /// Calculates the number of living neighbors around a given cell in a 2D field.
        /// </summary>
        /// <param name="field">The 2D field representing the game board.</param>
        /// <param name="row">The row index of the cell.</param>
        /// <param name="col">The column index of the cell.</param>
        /// <returns>The number of living neighbors around the specified cell.</returns>
        public static int GetLivingNeighbors(int[,] field, int row, int col)
        {
            int result = 0;
            int rowCount = field.GetLength(0);
            int colCount = field.GetLength(1);

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    int rIdx = r < 0 ? rowCount - 1 : r >= rowCount ? 0 : r;
                    int cIdx = c < 0 ? colCount - 1 : c >= colCount ? 0 : c;

                    if (rIdx == row && cIdx == col)
                        result += 0;
                    else
                        result += field[rIdx, cIdx];
                }
            }
            return result;
        }
        
        /// <summary>
        /// Creates the next generation of the game field based on the current field.
        /// </summary>
        /// <param name="currentField">The current game field represented as a 2D array.</param>
        /// <returns>The next generation of the game field as a 2D array.</returns>
        private static int[,] CreateNextGeneration(int[,] currentField)
        {
            int[,] nextField = new int[currentField.GetLength(0), currentField.GetLength(1)];

            for (int r = 0; r < currentField.GetLength(0); r++)
            {
                for (int c = 0; c < currentField.GetLength(1); c++)
                {
                    int neighbors = GetLivingNeighbors(currentField, r, c);
                    // Eine tote Zelle mit genau drei lebenden Nachbarn wird in der Folgegeneration neu geboren.
                    if (currentField[r, c] == 0 && neighbors == 3)
                        nextField[r, c] = 1;
                    // Lebende Zellen mit weniger als zwei lebenden Nachbarn sterben in der Folgegeneration an Einsamkeit.
                    else if (currentField[r, c] == 1 && neighbors < 2)
                        nextField[r, c] = 0;
                    // Eine lebende Zelle mit zwei oder drei lebenden Nachbarn bleibt in der Folgegeneration am Leben.
                    else if (currentField[r, c] == 1 && (neighbors == 2 || neighbors == 3))
                        nextField[r, c] = 1;
                    // Lebende Zellen mit mehr als drei lebenden Nachbarn sterben in der Folgegeneration an Überbevölkerung.
                    else if (currentField[r, c] == 1 && neighbors > 3)
                        nextField[r, c] = 0;
                    else
                        nextField[r, c] = currentField[r, c];
                }
            }
            return nextField;
        }

        /// <summary>
        /// Prints the given field to the console.
        /// </summary>
        /// <param name="field">The field to be printed.</param>
        public static void PrintField(int[,] field)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int r = 0; r < field.GetLength(0); r++)
            {
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    char sign = field[r, c] == 0 ? ' ' : '*';

                    Console.Write($" {sign} ");
                }
                Console.WriteLine();
            }
        }

        #region Fields
        /// <summary>
        /// Creates a random field with the specified number of rows, columns, and occupancy.
        /// </summary>
        /// <param name="rows">The number of rows in the field.</param>
        /// <param name="cols">The number of columns in the field.</param>
        /// <param name="occupancy">The desired occupancy of the field (number of cells with value 1).</param>
        /// <returns>A 2D array representing the random field.</returns>
        public static int[,] CreateRandomField(int rows, int cols, int occupancy)
        {
            int count = 0;
            int[,] field = new int[Math.Max(rows, 0), Math.Max(cols, 0)];

            occupancy = Math.Min(occupancy, rows * cols);

            while (count < occupancy)
            {
                int r = Random.Shared.Next(0, rows);
                int c = Random.Shared.Next(0, cols);

                if (field[r, c] == 0)
                {
                    field[r, c] = 1;
                    count++;
                }
            }
            return field;
        }

        /// <summary>
        /// Reads a field from a CSV file and returns it as a 2D integer array.
        /// </summary>
        /// <param name="filePath">The path to the CSV file.</param>
        /// <returns>A 2D integer array representing the field read from the CSV file.</returns>
        public static int[,] ReadFieldFromCsvFile(string filePath)
        {
            bool isDefined = false;
            int[,] result = new int[0, 0];

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                for (int r = 0; r < lines.Length; r++)
                {
                    string[] values = lines[r].Split(';');

                    if (isDefined == false)
                    {
                        result = new int[lines.Length, values.Length];
                        isDefined = true;
                    }
                    for (int c = 0; c < values.Length; c++)
                    {
                        result[r, c] = int.Parse(values[c]);
                    }
                }
            }
            return result;
        }
        #endregion Fields
    }
}