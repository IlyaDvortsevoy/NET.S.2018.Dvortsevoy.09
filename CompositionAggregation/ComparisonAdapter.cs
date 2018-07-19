using System;
using System.Collections.Generic;

namespace CompositionAggregation
{
    /// <summary>
    /// Adaptes object of <see cref="T:System.Comparison{T}"/> class
    /// for using in method requiring <see cref="T:System.Collections.Generic.IComparer{T}"/>
    /// inteface parameters
    /// </summary>
    public class ComparisonAdapter : IComparer<int[]>
    {
        private Comparison<int[]> _comparison;

        public ComparisonAdapter(Comparison<int[]> comparison)
        {
            ValidateComparison(comparison);

            _comparison = comparison;
        }

        public int Compare(int[] leftArray, int[] rightArray)
        {
            return _comparison.Invoke(leftArray, rightArray);
        }

        private void ValidateComparison(Comparison<int[]> comparison)
        {
            if (comparison == null)
            {
                throw new ArgumentNullException(
                    "Parameter can't be null",
                    nameof(comparison));
            }
        }
    }
}
