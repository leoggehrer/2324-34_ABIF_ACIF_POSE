/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Matrix
*                 This program generates a matrix with random 
*                 numbers and compares the values in each row
*                 and the values of each column.
*----------------------------------------------------------
*/

#nullable disable

namespace Matrix.ConApp
{
    /// <summary>
    /// Represents the entry point of the lottery simulation program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The minimum number allowed.
        /// </summary>
        private const int MIN_NUMBER = 1;
        /// <summary>
        /// The maximum number allowed.
        /// </summary>
        private const int MAX_NUMBER = 9;

        /// <summary>
        /// The entry point of the program.
        /// </summary>
        static void Main()
        {
            string input;
            int rows, cols;

            do
            {
                ReadMatrixDimensions(out rows, out cols);

                int[,] matrix = CreateMatrix(rows, cols);

                CompareAndPrintMatrix(matrix);

                Console.Write("Weitere Matrix anzeigen (j/n)? ");
                input = Console.ReadLine();
            } while (input.ToLower() == "j");
        }

        /// <summary>
        /// Reads the dimensions of the matrix from the user.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="cols">The number of columns in the matrix.</param>
        private static void ReadMatrixDimensions(out int rows, out int cols)
        {
            string input;
            bool validInput;

            do
            {
                Console.Write("Zeilen:  ");
                input = Console.ReadLine();
                validInput = int.TryParse(input, out rows);
                if (!validInput)
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine positive ganze Zahl ein.");
                }
            } while (!validInput);

            do
            {
                Console.Write("Spalten: ");
                input = Console.ReadLine();
                validInput = int.TryParse(input, out cols);
                if (!validInput)
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine positive ganze Zahl ein.");
                }
            } while (!validInput);
        }

        /// <summary>
        /// Creates a matrix with the specified number of rows and columns.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="cols">The number of columns in the matrix.</param>
        /// <returns>A 2D array representing the matrix.</returns>
        public static int[,] CreateMatrix(int rows, int cols)
        {
            int[,] result = new int[Math.Max(0, rows), Math.Max(0, cols)];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = Random.Shared.Next(MIN_NUMBER, MAX_NUMBER + 1);
                }
            }
            return result;
        }

        /// <summary>
        /// Compares and prints the values of a given matrix.
        /// </summary>
        /// <param name="matrix">The matrix to compare and print.</param>
        private static void CompareAndPrintMatrix(int[,] matrix)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                CompareAndPrintMatrixValues(matrix, r);
                Console.WriteLine();
                if (r < matrix.GetLength(0) - 1)
                {
                    CompareAndPrintMatrixRows(matrix, r, r + 1);
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = originalColor;
        }
        /// <summary>
        /// Compares and prints the values of a specified row in a matrix.
        /// </summary>
        /// <param name="matrix">The matrix to compare and print values from.</param>
        /// <param name="row">The row index of the matrix to compare and print values from.</param>
        private static void CompareAndPrintMatrixValues(int[,] matrix, int row)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            ConsoleColor valueColor = ConsoleColor.Yellow;
            ConsoleColor relationColor = ConsoleColor.Red;
            ConsoleColor equalsColor = ConsoleColor.Green;

            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                Console.ForegroundColor = valueColor;
                Console.Write($"{matrix[row, c]}");
                if (c < matrix.GetLength(1) - 1)
                {
                    if (matrix[row, c] > matrix[row, c + 1])
                    {
                        Console.ForegroundColor = relationColor;
                        Console.Write(" > ");
                    }
                    else if (matrix[row, c] < matrix[row, c + 1])
                    {
                        Console.ForegroundColor = relationColor;
                        Console.Write(" < ");
                    }
                    else
                    {
                        Console.ForegroundColor = equalsColor;
                        Console.Write(" = ");
                    }
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.ForegroundColor = originalColor;
        }
        /// <summary>
        /// Compares and prints the rows of a matrix based on the values in each column.
        /// </summary>
        /// <param name="matrix">The matrix to compare.</param>
        /// <param name="firstRow">The index of the first row to compare.</param>
        /// <param name="secondRow">The index of the second row to compare.</param>
        private static void CompareAndPrintMatrixRows(int[,] matrix, int firstRow, int secondRow)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            ConsoleColor relationColor = ConsoleColor.Red;
            ConsoleColor equalsColor = ConsoleColor.Green;

            if (firstRow >= 0 && firstRow < matrix.GetLength(0) && secondRow >= 0 && secondRow < matrix.GetLength(0))
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[firstRow, c] > matrix[secondRow, c])
                    {
                        Console.ForegroundColor = relationColor;
                        Console.Write("V   ");
                    }
                    else if (matrix[firstRow, c] < matrix[secondRow, c])
                    {
                        Console.ForegroundColor = relationColor;
                        Console.Write("A   ");
                    }
                    else
                    {
                        Console.ForegroundColor = equalsColor;
                        Console.Write("=   ");
                    }
                }
            }
            Console.ForegroundColor = originalColor;
        }
    }
}
