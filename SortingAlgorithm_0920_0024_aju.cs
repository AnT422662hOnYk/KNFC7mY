// 代码生成时间: 2025-09-20 00:24:31
 * It provides a method to sort an array of integers using bubble sort algorithm.
 * Error handling is included to ensure robustness.
 * Comments and documentation are provided for clarity and maintainability.
 */

using System;

public class SortingAlgorithm
{
    /*
     * Method: SortArray
     * Description: Sorts an array of integers using bubble sort algorithm.
     * Parameters:
     *   int[] array - The array of integers to be sorted.
     * Returns:
     *   int[] - The sorted array of integers.
     * Throws:
     *   ArgumentNullException - If the input array is null.
     */
    public int[] SortArray(int[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "Input array cannot be null.");
        }

        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Swap the elements
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }

        return array;
    }
}

/*
 * Sample usage:
 * int[] unsortedArray = { 5, 3, 8, 4, 2 };
 * SortingAlgorithm sorter = new SortingAlgorithm();
 * int[] sortedArray = sorter.SortArray(unsortedArray);
 * foreach (int value in sortedArray)
 * {
 *     Console.WriteLine(value);
 * }
 * Output:
 * 2
 * 3
 * 4
 * 5
 * 8
 */