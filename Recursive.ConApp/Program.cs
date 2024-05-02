/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Recursive functions
*                 This program outputs all ASCII characters 
*                 in the range 32 to 127.
*----------------------------------------------------------
*/
#nullable disable
namespace Recursive.ConApp
{
    /// <summary>
    /// Represents the entry point of the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The entry point for the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            // Test the Fibonacci function.
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Recursive {i, -3}: = {FibonacciRecursive(i)}");
                Console.WriteLine($"Iterative {i, -3}: = {FibonacciIterative(i)}");
            }

            Console.WriteLine();
            Console.WriteLine("Press enter to exit: ");
            Console.ReadLine();
        }

        /// <summary>
        /// Calculates the Fibonacci number at the specified index using a recursive approach.
        /// </summary>
        /// <param name="n">The index of the Fibonacci number to calculate.</param>
        /// <returns>The Fibonacci number at the specified index.</returns>
        static long FibonacciRecursive(int n)
        {
            if (n < 2)
            {
                return n;
            }
            else 
            {
                return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
            }
        }

        /// <summary>
        /// Calculates the Fibonacci number at the specified index using an iterative approach.
        /// </summary>
        /// <param name="n">The index of the Fibonacci number to calculate.</param>
        /// <returns>The Fibonacci number at the specified index.</returns>
        static long FibonacciIterative(int n)
        {
            long result = 1;
            long n_2 = 1;

            while (n > 2)
            {
                result = result + n_2;
                n_2 = result - n_2;
                n--;
            }
            return result;
        }
    }
}
