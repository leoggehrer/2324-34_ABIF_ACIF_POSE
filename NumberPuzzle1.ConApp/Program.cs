/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 NumberPuzzel1
*                 Solve the system of equations a + bc = 2024 
*                 and ab + c = 2023. 
*                 Constraints a, b, c are natural numbers 
*                 and greater than 0. 
*----------------------------------------------------------
*/
#nullable disable

namespace NumberGuessing.ConApp
{
    /// <summary>
    /// Represents the entry point of the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            const int A_plus_B_x_C = 2024;
            const int A_x_B_plus_C = 2023;
            int a, b, c, equation_1, equation_2;
            bool solved;

            //Console.Clear();
            Console.WriteLine("Number Puzzel");
            Console.WriteLine("=============");
            Console.WriteLine();
            Console.WriteLine("Solve:");
            Console.WriteLine("  a + bc = 2024");
            Console.WriteLine("  ab + c = 2023");
            Console.WriteLine();

            // Input (I)
            a = 0;

            // Processing (P)
            do
            {
                a++;
                b = 0;
                do
                {
                    b++;
                    c = 0;
                    do
                    {
                        c++;
                        equation_1 = a + (b * c);
                        equation_2 = (a * b) + c;
                        solved = equation_1 == A_plus_B_x_C && equation_2 == A_x_B_plus_C;
                    } while (solved == false && equation_1 <= A_plus_B_x_C && equation_2 <= A_x_B_plus_C);
                } while (solved == false && equation_1 <= A_plus_B_x_C && equation_2 <= A_x_B_plus_C);
            } while (solved == false && a < A_plus_B_x_C);

            // Ouput (O)
            if (solved)
            {
                Console.WriteLine($"The solution: a == {a}, b == {b} and c == {c}");
            }
            else
            {
                Console.WriteLine("No solution found!");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
