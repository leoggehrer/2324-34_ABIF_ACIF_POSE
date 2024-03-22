/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 LotteryChecker
*                 Reads lottery tips from a csv file and 
*                 checks if they are valid. Split the tips 
*                 into two files: valid and invalid tips.
*----------------------------------------------------------
*/

#nullable disable

namespace LotteryChecker.ConApp
{
    /// <summary>
    /// Represents the main program class.
    /// </summary>
    class Program
    {
        static string FileName = "LottoTipps.csv";
        static string CorrectFileName = "ValidLottoTipps.csv";
        static string IncorrectFileName = "InvalidLottoTipps.csv";
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("LottoChecker");
            Console.WriteLine("============");
            Console.WriteLine();

            LotteryTip[] tipps = ReadTippsFromFile(FileName);
            LotteryTip[] correctTipps = GetCorrectTipps(tipps);
            LotteryTip[] incorrectTipps = GetIncorrectTipps(tipps);

            WriteTippsToFile(correctTipps, CorrectFileName);
            WriteTippsToFile(incorrectTipps, IncorrectFileName);

            Console.WriteLine("Incorrect Tips:");
            PrintTipps(incorrectTipps);

            Console.WriteLine();
            Console.WriteLine("Exit with Enter...");
            Console.ReadLine();
        }


        /// <summary>
        /// Reads lottery tips from a file and returns an array of LotteryTip objects.
        /// </summary>
        /// <param name="filePath">The path to the file containing the lottery tips.</param>
        /// <returns>An array of LotteryTip objects.</returns>
        static LotteryTip[] ReadTippsFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            LotteryTip[] tipps = new LotteryTip[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                LotteryTip tip = new LotteryTip();
                string[] parts = lines[i].Split(';');

                tip.Id = parts[0];
                tip.Numbers[0] = int.Parse(parts[1]);
                tip.Numbers[1] = int.Parse(parts[2]);
                tip.Numbers[2] = int.Parse(parts[3]);
                tip.Numbers[3] = int.Parse(parts[4]);
                tip.Numbers[4] = int.Parse(parts[5]);
                tip.Numbers[5] = int.Parse(parts[6]);

                tipps[i] = tip;
            }
            return tipps;
        }
        /// <summary>
        /// Prints the given array of LotteryTip objects.
        /// </summary>
        /// <param name="tipps">The array of LotteryTip objects to be printed.</param>
        static void PrintTipps(LotteryTip[] tipps)
        {
            for (int i = 0; i < tipps.Length; i++)
            {
                Console.WriteLine($"{tipps[i].Id}: {tipps[i].Numbers[0],3} {tipps[i].Numbers[1],3} {tipps[i].Numbers[2],3} {tipps[i].Numbers[3],3} {tipps[i].Numbers[4],3} {tipps[i].Numbers[5],3}");
            }
        }
        /// <summary>
        /// Writes an array of LotteryTip objects to a file.
        /// </summary>
        /// <param name="tipps">The array of LotteryTip objects to write.</param>
        /// <param name="filePath">The path of the file to write to.</param>
        static void WriteTippsToFile(LotteryTip[] tipps, string filePath)
        {
            string[] lines = new string[tipps.Length];

            for (int i = 0; i < tipps.Length; i++)
            {
                lines[i] = $"{tipps[i].Id};{tipps[i].Numbers[0]};{tipps[i].Numbers[1]};{tipps[i].Numbers[2]};{tipps[i].Numbers[3]};{tipps[i].Numbers[4]};{tipps[i].Numbers[5]}";
            }
            File.WriteAllLines(filePath, lines);
        }
        /// <summary>
        /// Filters an array of lottery tips and returns only the valid ones.
        /// </summary>
        /// <param name="tipps">The array of lottery tips to filter.</param>
        /// <returns>An array of valid lottery tips.</returns>
        static LotteryTip[] GetCorrectTipps(LotteryTip[] tipps)
        {
            List<LotteryTip> result = new List<LotteryTip>();

            for (int i = 0; i < tipps.Length; i++)
            {
                if (IsTipValid(tipps[i]))
                {
                    result.Add(tipps[i]);
                }
            }
            return result.ToArray();
        }
        /// <summary>
        /// Retrieves an array of incorrect lottery tips from the given array of tips.
        /// </summary>
        /// <param name="tipps">The array of lottery tips.</param>
        /// <returns>An array of incorrect lottery tips.</returns>
        static LotteryTip[] GetIncorrectTipps(LotteryTip[] tipps)
        {
            List<LotteryTip> result = new List<LotteryTip>();

            for (int i = 0; i < tipps.Length; i++)
            {
                if (IsTipValid(tipps[i]) == false)
                {
                    result.Add(tipps[i]);
                }
            }
            return result.ToArray();
        }
        /// <summary>
        /// Checks if a given lottery tip is valid.
        /// </summary>
        /// <param name="tip">The lottery tip to be checked.</param>
        /// <returns>True if the tip is valid, otherwise false.</returns>
        static bool IsTipValid(LotteryTip tip)
        {
            bool result = true;

            for (int i = 0; i < tip.Numbers.Length && result; i++)
            {
                if (tip.Numbers[i] < 1 
                    || tip.Numbers[i] > 45
                    || CountNumberInTip(tip.Numbers[i], tip) != 1)
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// Counts the occurrences of a specific number in a given lottery tip.
        /// </summary>
        /// <param name="number">The number to count.</param>
        /// <param name="tip">The lottery tip.</param>
        /// <returns>The number of occurrences of the specified number in the lottery tip.</returns>
        private static int CountNumberInTip(int number, LotteryTip tip)
        {
            int result = 0;

            for (int i = 0; i < tip.Numbers.Length; i++)
            {
                if (number == tip.Numbers[i])
                {
                    result++;
                }
            }
            return result;
        }
    }
}
