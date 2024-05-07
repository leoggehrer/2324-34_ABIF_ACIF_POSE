/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Extract Pattern
*                 The program filters all numbers from an 
*                 input text and outputs them.
*----------------------------------------------------------
*/
#nullable disable
namespace ExtractPatterns.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void PrintHeader()
        {
            // Ausgabe der Programmheader
            Console.WriteLine("************************************************************");
            Console.WriteLine("*  Extractor - Die Software zum Extrahieren von Strukturen *");
            Console.WriteLine("*              von Klasse / Vorname Nachname               *");
            Console.WriteLine("************************************************************");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        private static void Run()
        {
            int[,] matrix = new[,]
            {
                { 1, 0, 1, 0, 1, 0, 1 },
                { 0, 1, 0, 1, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 1, 1, 1, 0 },
                { 1, 0, 0, 0, 1, 0, 0 },
                { 1, 0, 1, 0, 0, 1, 1 },
                { 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0 },
                { 0, 1, 1, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0 },
            };

            int row, col;

            do
            {
                Console.Clear();
                PrintHeader();
                PrintMatrix(matrix);
                Console.WriteLine();
                Console.WriteLine("Ende mit -1");
                Console.WriteLine();
                Console.Write($"Zeile eingeben [0..{matrix.GetLength(0)}]: ");
                row = int.Parse(Console.ReadLine()!);

                Console.Write($"Spale eingeben [0..{matrix.GetLength(1)}]: ");
                col = int.Parse(Console.ReadLine()!);

                if (row >= 0 && col >= 0)
                {
                    int[,] extractPattern = ExtractPattern(matrix, row, col);
                    int[,] neighborValues = CreateNeighborValues(extractPattern);

                    if (CountMatrix(extractPattern) > 0)
                    {
                        PrintMatrix(extractPattern);
                        PrintBinary(neighborValues);
                        Console.WriteLine();
                        Console.Write("Weiter mit Eingabe...");
                        Console.ReadLine();
                    }
                }
            } while (row >= 0 && col >= 0);
        }

        public static int CountMatrix(int[,] matrix)
        {
            int result = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] != 0)
                        result++;
                }
            }
            return result;
        }
        public static int[,] ExtractPattern(int[,] matrix, int row, int col)
        {
            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];

            if (row >= 0 && col >= 0 
                && row < matrix.GetLength(0) 
                && col < matrix.GetLength(1)
                && matrix[row, col] != 0)
            {
                ExtractPatternRec(matrix, result, row, col);
            }
            return result;
        }
        private static void ExtractPatternRec(int[,] matrix, int[,] subField, int r, int c)
        {
            if (matrix[r, c] != 0 && subField[r, c] == 0)
            {
                subField[r, c] = matrix[r, c];
                for (int rIdx = r - 1; rIdx <= r + 1; rIdx++)
                {
                    for (int cIdx = c - 1; cIdx <= c + 1; cIdx++)
                    {
                        if (rIdx >= 0
                            && rIdx < matrix.GetLength(0)
                            && cIdx >= 0
                            && cIdx < matrix.GetLength(1)
                            && (rIdx != r || cIdx != c))
                        {
                            ExtractPatternRec(matrix, subField, rIdx, cIdx);
                        }
                    }
                }
            }
        }

        public static int[,] CreateNeighborValues(int[,] matrix)
        {
            static void ClaculateNeighborValue(int[,] input, int[,] output, int inR, int inC, int outR, int outC)
            {
                if (inR >= 0
                    && inR < input.GetLength(0)
                    && inC >= 0
                    && inC < input.GetLength(1)
                    && (inR != outR || inC != outC))
                {
                    output[outR, outC] *= 2;
                    output[outR, outC] += input[inR, inC] > 0 ? 1 : 0;
                }
            }
            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] > 0)
                    {
                        ClaculateNeighborValue(matrix, result, r - 1, c, r, c);
                        ClaculateNeighborValue(matrix, result, r - 1, c + 1, r, c);
                        ClaculateNeighborValue(matrix, result, r, c + 1, r, c);
                        ClaculateNeighborValue(matrix, result, r + 1, c + 1, r, c);
                        ClaculateNeighborValue(matrix, result, r + 1, c, r, c);
                        ClaculateNeighborValue(matrix, result, r + 1, c - 1, r, c);
                        ClaculateNeighborValue(matrix, result, r, c - 1, r, c);
                        ClaculateNeighborValue(matrix, result, r - 1, c - 1, r, c);
                    }
                }
            }
            return result;
        }

        static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                Console.Write($"{r, 2}: ");
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write($" {matrix[r, c]}");
                }
                Console.WriteLine();
            }
        }
        static void PrintBinary(int[,] matrix)
        {
            Console.WriteLine();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    var binaryNumber = Convert.ToString(matrix[r, c], 2);
                    
                    while (binaryNumber.Length < 8)
                    {
                        binaryNumber = "0" + binaryNumber;
                    }
                    Console.Write($" {binaryNumber}");
                }
                Console.WriteLine();
            }
        }
    }
}