using System.Diagnostics;

namespace SortingAlgorithms.ConApp
{
    public static partial class Sort
    {
        /// <summary>
        /// Sorts an array using the brute force sorting algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public static void BruteForceSort(int[] array)
        {
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an array of integers using the Bubble Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public static void BubbleSort(int[] array)
        {
            bool exchange;
            int length = array.Length;

            do
            {
                exchange = false;
                for (int i = 0; i < length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(ref array[i], ref array[i + 1]);
                        exchange = true;
                    }
                }
                length--;
            } while (exchange);
        }

        /// <summary>
        /// Sorts an array of integers using the Insertion Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                int current = array[i];

                while (j > 0 && array[j - 1] > current)
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = current;
            }
        }

        /// <summary>
        /// Sorts an array of integers using the Selection Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIdx = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIdx])
                    {
                        minIdx = j;
                    }
                }
                if (minIdx != i)
                {
                    Swap(ref array[i], ref array[minIdx]);
                }
            }
        }

        /// <summary>
        /// Swaps the values of two integers.
        /// </summary>
        /// <param name="v1">The first integer.</param>
        /// <param name="v2">The second integer.</param>
        public static void Swap(ref int v1, ref int v2)
        {
            int tmp = v1;

            v1 = v2;
            v2 = tmp;
        }
    }
}
