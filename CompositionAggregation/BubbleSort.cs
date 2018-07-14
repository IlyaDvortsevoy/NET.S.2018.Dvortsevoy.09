using System;
using System.Collections.Generic;

namespace CompositionAggregation
{
    /// <summary>
    /// Defines methods for sorting rows of jagged array according to certain criteria
    /// </summary>
    public static class BubbleSort
    {
        #region Fields
        private static SortedList<int, int> list =
            new SortedList<int, int>(new CustomComparer());
        #endregion

        #region Public Methods
        /// <summary>
        /// Fulfills ascending sortion of the rows of a jagged array according to the sum of row elements
        /// </summary>
        /// <param name="array"> The jagged array to sort </param>
        /// <returns> Sorted jagged array </returns>
        /// <exception cref="ArgumentNullException"> In case if the jagged array is null </exception>
        /// <exception cref="ArgumentException"> In case if the jagged array equals to zero </exception>
        public static int[][] SortBySumAsc(int[][] array)
        {
            ValidateArray(array);
            СountSums(array);

            return OrderRowsAscending(array);
        }

        /// <summary>
        /// Fulfills descending sortion of the rows of a jagged array according to the sum of row elements
        /// </summary>
        /// <param name="array"> The jagged array to sort </param>
        /// <returns> Sorted jagged array </returns>
        /// <exception cref="ArgumentNullException"> In case if the jagged array is null </exception>
        /// <exception cref="ArgumentException"> In case if the jagged array equals to zero </exception>
        public static int[][] SortBySumDesc(int[][] array)
        {
            ValidateArray(array);
            СountSums(array);

            return OrderRowsDescending(array);
        }

        /// <summary>
        /// Fulfills ascending sortion of the rows of a jagged array according to the maximum element of each row
        /// </summary>
        /// <param name="array"> The jagged array to sort </param>
        /// <returns> Sorted jagged array </returns>
        /// <exception cref="ArgumentNullException"> In case if the jagged array is null </exception>
        /// <exception cref="ArgumentException"> In case if the jagged array equals to zero </exception>
        public static int[][] SortByMaxAsc(int[][] array)
        {
            ValidateArray(array);
            СalculateMax(array);

            return OrderRowsAscending(array);
        }

        /// <summary>
        /// Fulfills descending sortion of the rows of a jagged array according to the maximum element of each row
        /// </summary>
        /// <param name="array"> The jagged array to sort </param>
        /// <returns> Sorted jagged array </returns>
        /// <exception cref="ArgumentNullException"> In case if the jagged array is null </exception>
        /// <exception cref="ArgumentException"> In case if the jagged array equals to zero </exception>
        public static int[][] SortByMaxDesc(int[][] array)
        {
            ValidateArray(array);
            СalculateMax(array);

            return OrderRowsDescending(array);
        }

        /// <summary>
        /// Fulfills ascending sortion of the rows of a jagged array according to the minimal element of each row
        /// </summary>
        /// <param name="array"> The jagged array to sort </param>
        /// <returns> Sorted jagged array </returns>
        /// <exception cref="ArgumentNullException"> In case if the jagged array is null </exception>
        /// <exception cref="ArgumentException"> In case if the jagged array equals to zero </exception>
        public static int[][] SortByMinAsc(int[][] array)
        {
            ValidateArray(array);
            СalculateMin(array);

            return OrderRowsAscending(array);
        }

        /// <summary>
        /// Fulfills descending sortion of the rows of a jagged array according to the minimal element of each row
        /// </summary>
        /// <param name="array"> The jagged array to sort </param>
        /// <returns> Sorted jagged array </returns>
        /// <exception cref="ArgumentNullException"> In case if the jagged array is null </exception>
        /// <exception cref="ArgumentException"> In case if the jagged array equals to zero </exception>
        public static int[][] SortByMinDesc(int[][] array)
        {
            ValidateArray(array);
            СalculateMin(array);

            return OrderRowsDescending(array);
        }
        #endregion

        #region Private Helper Methods
        private static void ValidateArray(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            else if (array.Length == 0)
            {
                throw new ArgumentException();
            }
        }

        private static void СountSums(int[][] array)
        {
            list.Clear();

            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;

                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }

                list.Add(sum, i);
            }
        }

        private static void СalculateMax(int[][] array)
        {
            list.Clear();

            for (int i = 0; i < array.Length; i++)
            {
                int max = array[i][0];

                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > max)
                    {
                        max = array[i][j];
                    }
                }

                list.Add(max, i);
            }
        }

        private static void СalculateMin(int[][] array)
        {
            list.Clear();

            for (int i = 0; i < array.Length; i++)
            {
                int min = array[i][0];

                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] < min)
                    {
                        min = array[i][j];
                    }
                }

                list.Add(min, i);
            }
        }

        private static int[][] OrderRowsAscending(int[][] array)
        {
            int[][] resultingArray = new int[array.Length][];
            int counter = 0;

            foreach (int value in list.Values)
            {
                resultingArray[counter++] = array[value];
            }

            return resultingArray;
        }

        private static int[][] OrderRowsDescending(int[][] array)
        {
            int[][] resultingArray = new int[array.Length][];
            int counter = array.Length - 1;

            foreach (int value in list.Values)
            {
                resultingArray[counter--] = array[value];
            }

            return resultingArray;
        }
        #endregion
    }
}