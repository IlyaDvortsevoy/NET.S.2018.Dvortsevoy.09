using System.Collections.Generic;
using System.Linq;

namespace CompositionAggregation.Tests.TestTypes
{
    public class MaxSortDesc : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {

            if (x == null && y != null)
            {
                return 1;
            }

            if (y == null && x != null)
            {
                return -1;
            }

            if (x.Length == 0 && y.Length > 0)
            {
                return -1;
            }

            if (y.Length == 0 && x.Length > 0)
            {
                return 1;
            }

            int MaxX = x.Max();
            int MaxY = y.Max();

            if (MaxX == MaxY)
            {
                return 0;
            }

            if (MaxX > MaxY)
            {
                return -1;
            }

            return 1;
        }
    }
}
