/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 LotterySimulation
*                 This program simulates a lottery drawing. 
*                 First, 1,000,000 lottery tips are generated 
*                 and then compared with a simulated drawing.
*----------------------------------------------------------
*/

#nullable disable

using System.Diagnostics;

namespace LotterySimulation.ConApp
{
    /// <summary>
    /// Represents the entry point of the lottery simulation program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The size of the tip in the lottery simulation.
        /// </summary>
        const int TIP_SIZE = 6;
        /// <summary>
        /// The minimum number allowed in the lottery simulation.
        /// </summary>
        const int MIN_NUMBER = 1;
        /// <summary>
        /// The maximum number allowed in the lottery simulation.
        /// </summary>
        const int MAX_NUMBER = 45;
        /// <summary>
        /// The number of lottery tips.
        /// </summary>
        const int TIPPS_COUNT = 1_000_000;  // 1.000.000 Lottotipps
        /// <summary>
        /// Represents a random number generator.
        /// </summary>
        static Random random = new Random(1);  // 1 damit immer gleiches Ergebnis kommt

        /// <summary>
        /// The entry point of the program.
        /// </summary>
        static void Main()
        {
            // 1.000.000 Lottotipps erzeugen
            int[] results; // wieviele 0er, 1er, 2er, ..., 6er gibt es in den Tipps
            int[] correctResult = { 400874, 423358, 151635, 22687, 1416, 30, 0 };
            int[] thrownNumbers; // Lottoziehung
            int[,] lottoTipps = CreateTipps(TIPPS_COUNT);  // 1.000.000 Lottotipps
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine("Lottosimulator");
            Console.WriteLine("==============");
            Console.WriteLine();
            Console.WriteLine("{0} Tippkolonnen", lottoTipps.GetLength(0));
            Console.WriteLine();

            // Ziehung simulieren
            thrownNumbers = CreateTip();
            // Treffer Zählen
            stopWatch.Start();
            results = AnalyzeLottery(lottoTipps, thrownNumbers);
            stopWatch.Stop();

            PrintResult(results);
            Console.WriteLine();

            if (EqualsTo(results, correctResult))
            {
                Console.WriteLine("Das Ergebnis ist richtig!");
            }
            else
            {
                Console.WriteLine("Für 1 Mio Versuche ist das Ergebnis falsch!");
            }

            Console.WriteLine("Rechenzeit: {0} Millisekunden!", stopWatch.ElapsedMilliseconds);
            Console.WriteLine("Exit with Enter...");
            Console.ReadLine();
        }

        /// <summary>
        /// Prints the results of a lottery simulation.
        /// </summary>
        /// <param name="results">An array containing the number of occurrences for each result.</param>
        public static void PrintResult(int[] results)
        {
            int resultSum = 0;

            for (int i = TIP_SIZE; i >= 0; i--)
            {
                Console.WriteLine($"{i}er: {results[i], 10}");
                resultSum += results[i];
            }
            Console.WriteLine(new string('-' , 20));
            Console.WriteLine($"Summe: {resultSum, 8}");
        }

        /// <summary>
        /// Compares two integer arrays and determines if they are equal.
        /// </summary>
        /// <param name="arrayOne">The first integer array to compare.</param>
        /// <param name="arrayTwo">The second integer array to compare.</param>
        /// <returns>True if the arrays are equal, otherwise false.</returns>
        public static bool EqualsTo(int[] arrayOne, int[] arrayTwo)
        {
            int idx = 0;
            bool result = arrayOne.Length == arrayTwo.Length;

            while (result && idx < arrayOne.Length)
            {
                result = arrayOne[idx] == arrayTwo[idx];
                idx++;
            }
            return result;
        }

        /// <summary>
        /// Analyzes the lottery by counting the number of hits for each lotto tipp.
        /// </summary>
        /// <param name="lottoTipps">The array of lotto tipps.</param>
        /// <param name="thrownNumbers">The array of thrown numbers.</param>
        /// <returns>An array containing the count of hits for each lotto tipp.</returns>
        static int[] AnalyzeLottery(int[,] lottoTipps, int[] thrownNumbers)
        {
            int[] result = new int[TIP_SIZE + 1];

            for (int i = 0; i < lottoTipps.GetLength(0); i++)
            {
                int hits = CountNumberOfHits(i, lottoTipps, thrownNumbers);

                result[hits]++;
            }
            return result;
        }

        /// <summary>
        /// Counts the number of hits between the given index of tipps and the thrown numbers.
        /// </summary>
        /// <param name="index">The index of tipps to compare with the thrown numbers.</param>
        /// <param name="tipps">The 2D array of tipps.</param>
        /// <param name="thrownNumbers">The array of thrown numbers.</param>
        /// <returns>The number of hits between the tipps and the thrown numbers.</returns>
        public static int CountNumberOfHits(int index, int[,] tipps, int[] thrownNumbers)
        {
            int result = 0;

            for (int i = 0; i < tipps.GetLength(1); i++)
            {
                for (int j = 0; j < thrownNumbers.Length; j++)
                {
                    if (tipps[index, i] == thrownNumbers[j])
                    {
                        result++;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Creates an array of lottery tips.
        /// </summary>
        /// <param name="countTipps">The number of tips to create.</param>
        /// <returns>An array of lottery tips.</returns>
        public static int[,] CreateTipps(int countTipps)
        {
            int[,] result = new int[countTipps, TIP_SIZE];
            for (int tippNummer = 0; tippNummer < countTipps; tippNummer++)
            {
                int[] tip = CreateTip();
                for (int zahlNummer = 0; zahlNummer < 6; zahlNummer++)
                {
                    result[tippNummer, zahlNummer] = tip[zahlNummer];
                }
            }
            return result;
        }
        /// <summary>
        /// Creates an array of random numbers representing a lottery tip.
        /// </summary>
        /// <returns>An array of integers representing the lottery tip.</returns>
        public static int[] CreateTip()
        {
            int[] result = new int[TIP_SIZE];
            int number;
            bool found;

            for (int i = 0; i < result.Length; i++)
            {
                do
                {
                    found = false; // gibt es die Zahl bereits
                    // lottoZahl = random.Next(1, 7);  // dann gibt es nur 6er
                    number = random.Next(MIN_NUMBER, MAX_NUMBER + 1);
                    for (int j = 0; j < i; j++)
                    {
                        if (number == result[j])
                        {
                            found = true;
                        }
                    }
                } while (found);
                result[i] = number;
            }
            return result;
        }
    }
}
