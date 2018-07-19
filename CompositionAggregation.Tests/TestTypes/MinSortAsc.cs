using System.Collections.Generic;
using System.Linq;

namespace CompositionAggregation.Tests.TestTypes
{
    public class MinSortAsc : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null && y != null)
            {
                return -1;
            }

            if (y == null && x != null)
            {
                return 1;
            }

            if (x.Length == 0 && y.Length > 0)
            {
                return -1;
            }

            if (y.Length == 0 && x.Length > 0)
            {
                return 1;
            }

            int minX = x.Min();
            int minY = y.Min();

            if (minX == minY)
            {
                return 0;
            }

            if (minX > minY)
            {
                return 1;
            }

            return -1;
        }
    }
}
