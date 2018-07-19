using System.Collections.Generic;
using System.Linq;

namespace BubbleSort_DelegateCircuitTests.TestTypes
{
    public class MinSortDesc : IComparer<int[]>
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

            int MinX = x.Min();
            int MinY = y.Min();

            if (MinX == MinY)
            {
                return 0;
            }

            if (MinX > MinY)
            {
                return -1;
            }

            return 1;
        }
    }
}