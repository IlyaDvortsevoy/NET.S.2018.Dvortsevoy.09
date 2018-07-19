using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort_DelegateCircuit
{
    /// <summary>
    /// Defines methods for sorting rows of jagged array according to certain criteria
    /// </summary>
    public class BubbleSort_delegate
    {
        #region Public Methods
        /// <summary>
        /// Fulfills <see cref="T:System.Collections.Generic.IComparer{T}"/> intreface closed
        /// sort of the rows of a jagged array according to the certain criteria
        /// </summary>
        /// <param name="array"> The jagged array to sort </param>
        /// <param name="comparer"> Interface reference to the object defining sorting criteria </param>
        public static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            ValidateArray(array);
            ValidateComparer(comparer);

            FulfillSort(array, comparer.Compare);
        }

        /// <summary>
        /// Sorts jagged array
        /// </summary>
        /// <param name="array"> The jagged array to sort </param>
        /// <param name="comparison"> Delegate defining sorting criteria </param>
        public static void Sort(int[][] array, Comparison<int[]> comparison)
        {
            ValidateArray(array);
            ValidateComparison(comparison);

            FulfillSort(array, comparison);
        }
        #endregion

        #region Private Methods
        private static void FulfillSort(int[][] array, Comparison<int[]> comparison)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparison.Invoke(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        private static void Swap(ref int[] leftArray, ref int[] rightArray)
        {
            int[] tempArray = leftArray;
            leftArray = rightArray;
            rightArray = tempArray;
        }

        private static void ValidateArray(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(
                    "Parameter can't be null",
                    nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(
                    "Array can't be empty",
                    nameof(array));
            }
        }

        private static void ValidateComparer(IComparer<int[]> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(
                    "Parameter can't be null",
                    nameof(comparer));
            }
        }

        private static void ValidateComparison(Comparison<int[]> comparison)
        {
            if (comparison == null)
            {
                throw new ArgumentNullException(
                    "Parameter can't be null",
                    nameof(comparison));
            }
        }
        #endregion
    }
}
