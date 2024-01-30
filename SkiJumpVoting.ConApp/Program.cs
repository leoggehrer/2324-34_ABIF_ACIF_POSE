/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 SkiJumpVoting
*                 The program is used to determine points 
*                 for a jumper in a ski jumping competition
*----------------------------------------------------------
*/
#nullable disable

namespace SkiJumpVoting.ConApp
{
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            double far, points;
            double[] posturePoints;

            Console.WriteLine("Notenermittlung für Skispringer");
            Console.WriteLine("===============================");

            // Input (I)
            far = ReadJumpFar();
            Console.WriteLine();
            posturePoints = ReadPosturePoints(5);
            // Processing (P)
            points = CalculateJump(far) + CalculatePosturePoints(posturePoints);
            // Output (O)
            Console.WriteLine();
            Console.WriteLine($"Weitenpunkte: {CalculateJump(far):f} Haltungsnote: {CalculatePosturePoints(posturePoints):f} Gesamt: {points:f}");

            Console.WriteLine();
            Console.WriteLine("Beenden mit Eingabetaste... ");
            Console.ReadLine();
        }

        /// <summary>
        /// Calculates the score for a ski jump based on the distance jumped.
        /// </summary>
        /// <param name="far">The distance jumped in meters.</param>
        /// <returns>The score for the ski jump.</returns>
        private static double CalculateJump(double far)
        {
            far = (int)far;

            return far >= 120 ? 60 + (far - 120) * 1.8 : far * 1.8;
        }
        /// <summary>
        /// Calculates the posture points by subtracting the maximum and minimum values from the sum of all points.
        /// </summary>
        /// <param name="posturePoints">An array of posture points.</param>
        /// <returns>The calculated posture points.</returns>
        private static double CalculatePosturePoints(double[] posturePoints) 
        {
            double result = 0;
            double max = Double.MinValue;
            double min = Double.MaxValue;

            for (int i = 0; i < posturePoints.Length; i++)
            {
                if (posturePoints[i] > max)
                {
                    max = posturePoints[i];
                }
                if (posturePoints[i] < min)
                {
                    min = posturePoints[i];
                }
                result += posturePoints[i];
            }

            return result - max - min;
        }
        /// <summary>
        /// Reads the posture points from the user input.
        /// </summary>
        /// <param name="count">The number of posture points to read.</param>
        /// <returns>An array of posture points.</returns>
        private static double[] ReadPosturePoints(int count)
        {
            int idx = 0;
            string input;
            double[] result = new double[count];

            while (idx < count)
            {
                Console.Write($"Wertungsrichter {idx + 1} [0-20]: ");
                input = Console.ReadLine();
                if (double.TryParse(input, out result[idx]) 
                    && result[idx] >= 0 
                    && result[idx] <= 20 
                    && (result[idx] % 1 == 0 || result[idx] % 1 == 0.5))
                {
                    idx++;
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe!");
                }
            }
            return result;
        }

        /// <summary>
        /// Reads the jump distance in meters from the user.
        /// </summary>
        /// <returns>The jump distance in meters.</returns>
        private static double ReadJumpFar()
        {
            double result;
            string input;
            bool valid = false;

            do
            {
                Console.Write($"Weite in Meter [0-200]: ");
                input = Console.ReadLine();
                if (double.TryParse(input, out result) && result >= 0 && result <= 200)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe!");
                }

            } while (valid == false);
            return result;
        }
    }
}
