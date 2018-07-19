using System.Collections.Generic;
using System.Linq;

namespace BubbleSort_DelegateCircuitTests.TestTypes
{
    public class MaxSortAsc : IComparer<int[]>
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

            int maxX = x.Max();
            int maxY = y.Max();

            if (maxX == maxY)
            {
                return 0;
            }

            if (maxX > maxY)
            {
                return 1;
            }

            return -1;
        }
    }
}