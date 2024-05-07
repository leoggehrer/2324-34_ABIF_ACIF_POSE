/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Recursive functions
*                 Samples of recursive functions
*----------------------------------------------------------
*/
#nullable disable
namespace Recursion.ConApp
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
            Console.WriteLine("Fibonacci numbers:");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Recursive {i, -3}: = {FibonacciRecursive(i)}");
                Console.WriteLine($"Iterative {i, -3}: = {FibonacciIterative(i)}");
            }

            // Test the Add function.
            Console.WriteLine("Add rekursive:");
            for (int i = 1; i <= 10; i++)
            {
                int a = Random.Shared.Next(0, 100);
                int b = Random.Shared.Next(0, 100);

                Console.WriteLine($"Add({a, 2}, {b, 2}): = {AddRecursive(a, b)}");
            }

            // Test the Mul function.
            Console.WriteLine("Mul rekursive:");
            for (int i = 1; i <= 10; i++)
            {
                int a = Random.Shared.Next(0, 10);
                int b = Random.Shared.Next(0, 10);

                Console.WriteLine($"Mul({a, 2}, {b, 2}): = {MulRecursive(a, b)}");
            }

            // Test GGT function.
            Console.WriteLine("GGT rekursive:");
            for (int i = 1; i <= 10; i++)
            {
                int a = Random.Shared.Next(0, 100);
                int b = Random.Shared.Next(0, 100);

                Console.WriteLine($"GGT({a, 2}, {b, 2}): = {CgdRecursive(a, b)}");
            }

            // Test IsPrime function.
            Console.WriteLine("IsPrime rekursive:");
            for (int i = 1; i <= 10; i++)
            {
                int n = Random.Shared.Next(2, 100);

                Console.WriteLine($"IsPrime({n, 2}): = {IsPrime(n)}");
            }

            // Test Function f(n):= 1, fuer n == 1
            //               f(n):= f(n - 1) + 2 * n -1 fuer n > 1
            Console.WriteLine("Function rekursive:");
            for (int i = 1; i <= 10; i++)
            {
                int n = Random.Shared.Next(1, 100);

                Console.WriteLine($"f({n, 2}): = {Function(n)}");
            }

            // Test IsPalindrome function.
            string text = "otto";
            Console.WriteLine($"IsPalindrome({text}): = {IsPalindrome(text)}");

            text = "Reittier";
            Console.WriteLine($"IsPalindrome({text}): = {IsPalindrome(text)}");

            text = "Das ist kein Palindrom";
            Console.WriteLine($"IsPalindrome({text}): = {IsPalindrome(text)}");

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

        /// <summary>
        /// Adds two numbers recursively (only for positiv numbers).
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The sum of the two numbers.</returns>
        static int AddRecursive(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }
            else
            {
                return 2 + AddRecursive(a - 1, b - 1);
            }
        }

        /// <summary>
        /// Calculates the product of two integers recursively.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The product of the two integers.</returns>
        static int MulRecursive(int a, int b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }
            else if (a == 1)
            {
                return b;
            }
            else if (b == 1)
            {
                return a;
            }
            else
            {
                return a + MulRecursive(a, b - 1);
            }
        }

        /// <summary>
        /// Calculates the greatest common divisor (GCD) of two integers using the recursive method.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The greatest common divisor of the two integers.</returns>
        static int CgdRecursive(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return CgdRecursive(b, a % b);
            }
        }

        /// <summary>
        /// Determines whether the given number is prime.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <returns><c>true</c> if the number is prime; otherwise, <c>false</c>.</returns>
        static bool IsPrime(int n)
        {
            return IsPrimeRecursive(n, n - 1);
        }
        /// <summary>
        /// Determines whether a number is prime recursively.
        /// </summary>
        /// <param name="n">The number to check for primality.</param>
        /// <param name="p">The current divisor to check.</param>
        /// <returns><c>true</c> if the number is prime; otherwise, <c>false</c>.</returns>
        static bool IsPrimeRecursive(int n, int p)
        {
            if (p == 1)
            {
                return true;
            }
            else if (n % p == 0)
            {
                return false;
            }
            else
            {
                return IsPrimeRecursive(n, p - 1);
            }
        }

        /// <summary>
        /// Calculates the result of a recursive function.
        /// </summary>
        /// <param name="n">The input value.</param>
        /// <returns>The result of the recursive function.</returns>
        static int Function(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return Function(n - 1) + 2 * n - 1;
            }
        }

        /// <summary>
        /// Determines whether a given string is a palindrome.
        /// </summary>
        /// <param name="text">The string to check.</param>
        /// <returns>True if the string is a palindrome; otherwise, false.</returns>
        static bool IsPalindrome(string text)
        {
            return IsPalindromeRecursive(text, 0, text.Length - 1);
        }
        /// <summary>
        /// Determines whether a given string is a palindrome using an iterative approach.
        /// </summary>
        /// <param name="text">The string to check for palindrome.</param>
        /// <param name="start">The starting index of the substring to check.</param>
        /// <param name="end">The ending index of the substring to check.</param>
        /// <returns>True if the substring is a palindrome, false otherwise.</returns>
        static bool IsPalindromeRecursive(string text, int start, int end)
        {
            if (start >= end)
            {
                return true;
            }
            else if (char.ToLower(text[start]) != char.ToLower(text[end]))
            {
                return false;
            }
            else
            {
                return IsPalindromeRecursive(text, start + 1, end - 1);
            }
        }
    }
}
