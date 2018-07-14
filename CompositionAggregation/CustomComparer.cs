using System.Collections.Generic;

namespace CompositionAggregation
{
    /// <summary>
    /// Defines method that compares two <see cref="System.Int32"/> objects
    /// </summary>
    internal class CustomComparer : IComparer<int>
    {
        /// <summary>
        /// Redefines standard comparison behaviour allowing duplicate values
        /// </summary>
        /// <param name="x"> The first object to compare </param>
        /// <param name="y"> The second object to compare </param>
        /// <returns> 1 in case objects are equal, the standard comparison result otherwise </returns>
        public int Compare(int x, int y)
        {
            int result = x.CompareTo(y);

            if (result == 0)
            {
                return 1;
            }
            else
            {
                return result;
            }
        }
    }
}