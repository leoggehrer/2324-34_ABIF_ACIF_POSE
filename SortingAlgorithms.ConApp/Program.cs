/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 SortingAlgorithms
*                 This program implements 3 different sorting 
*                 algorithms and compares them in terms of 
*                 performance.
*                 1. Bubble Sort
*                 2. Insertion Sort
*                 3. Selection Sort
*
*----------------------------------------------------------
*/
#nullable disable

using System.Diagnostics;

namespace SortingAlgorithms.ConApp
{
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            const int TEST_SIZE = 20;
            const int PERFORMANCE_SIZE = 50_000;
            int[] array;

            Console.WriteLine("Sort-Algorithmen!");
            Console.WriteLine("=================");
            Console.WriteLine();

            // Test BruteForceSort
            Console.WriteLine("Test BruteForceSort");
            array = CreateRandomArray(TEST_SIZE);
            PrintArray("Unsorted:", array);
            Sort.BruteForceSort(array);
            PrintArray("BruteForceSort:", array);
            Console.WriteLine();

            // Test BubbleSort
            Console.WriteLine("Test BubbleSort");
            array = CreateRandomArray(TEST_SIZE);
            PrintArray("Unsorted:", array);
            Sort.BubbleSort(array);
            PrintArray("BubbleSort:", array);
            Console.WriteLine();

            // Test InsertionSort
            Console.WriteLine("Test InsertionSort");
            array = CreateRandomArray(TEST_SIZE);
            PrintArray("Unsorted:", array);
            Sort.InsertionSort(array);
            PrintArray("InsertionSort:", array);
            Console.WriteLine();

            // Test SelectionSort
            Console.WriteLine("Test SelectionSort");
            array = CreateRandomArray(TEST_SIZE);
            PrintArray("Unsorted:", array);
            Sort.SelectionSort(array);
            PrintArray("SelectionSort:", array);
            Console.WriteLine();

            // Performance
            Console.WriteLine("Performance Testing");
            Console.WriteLine("===================");
            Console.WriteLine();

            Console.WriteLine("Machine:   " + Environment.MachineName);
            Console.WriteLine("Version:   " + Environment.Version);
            Console.WriteLine("Processor: Apple M2");
            Console.WriteLine("Processor: " + Environment.ProcessorCount + " cores");
            Console.WriteLine("OS:        " + Environment.OSVersion);
            Console.WriteLine();

            Stopwatch sw = new Stopwatch();
            int[] randomArray = CreateRandomArray(PERFORMANCE_SIZE);
            int[] arrayToSort;

            // Performance BruteForceSort
            arrayToSort = (int[])randomArray.Clone();
            Console.WriteLine($"{nameof(Sort.BruteForceSort)}(0...{randomArray.Length})");
            sw.Start();
            Sort.BruteForceSort(arrayToSort);
            sw.Stop();
            Console.WriteLine($"Zeitmessung: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine();

            // Performance BubbleSort
            arrayToSort = (int[])randomArray.Clone();
            Console.WriteLine($"{nameof(Sort.BubbleSort)}(0...{randomArray.Length})");
            sw.Restart();
            Sort.BubbleSort(arrayToSort);
            sw.Stop();
            Console.WriteLine($"Zeitmessung: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine();

            // Performance InsertionSort
            arrayToSort = (int[])randomArray.Clone();
            Console.WriteLine($"{nameof(Sort.InsertionSort)}(0...{randomArray.Length})");
            sw.Restart();
            Sort.InsertionSort(arrayToSort);
            sw.Stop();
            Console.WriteLine($"Zeitmessung: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine();

            // Performance SelectionSort
            arrayToSort = (int[])randomArray.Clone();
            Console.WriteLine($"{nameof(Sort.SelectionSort)}(0...{randomArray.Length})");
            sw.Restart();
            Sort.SelectionSort(arrayToSort);
            sw.Stop();
            Console.WriteLine($"Zeitmessung: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine();

            // Performance Array.Sort
            arrayToSort = (int[])randomArray.Clone();
            Console.WriteLine($"Array.Sort(0...{randomArray.Length})");
            sw.Restart();
            Array.Sort(arrayToSort);
            sw.Stop();
            Console.WriteLine($"Zeitmessung: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine();

            Console.WriteLine("Exit with ENTER...");
            Console.ReadLine();
        }

        /// <summary>
        /// Prints the given array with a specified title.
        /// </summary>
        /// <param name="title">The title to be displayed before printing the array.</param>
        /// <param name="array">The array to be printed.</param>
        private static void PrintArray(string title, int[] array)
        {
            Console.WriteLine(title);
            PrintArray(array);
        }
        /// <summary>
        /// Prints the elements of an integer array.
        /// </summary>
        /// <param name="array">The integer array to be printed.</param>
        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0)
                {
                    Console.Write(" ");
                }
                Console.Write(array[i]);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Creates a random array of integers with the specified size.
        /// </summary>
        /// <param name="size">The size of the array to create.</param>
        /// <returns>A random array of integers.</returns>
        private static int[] CreateRandomArray(int size)
        {
            return CreateRandomArray(size, 0, size);
        }
        /// <summary>
        /// Creates an array of random integers within the specified range.
        /// </summary>
        /// <param name="size">The size of the array.</param>
        /// <param name="min">The minimum value (inclusive) of the random integers.</param>
        /// <param name="max">The maximum value (exclusive) of the random integers.</param>
        /// <returns>An array of random integers.</returns>
        private static int[] CreateRandomArray(int size, int min, int max)
        {
            int[] result = new int[size];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Random.Shared.Next(min, max);
            }
            return result;
        }
    }
}
