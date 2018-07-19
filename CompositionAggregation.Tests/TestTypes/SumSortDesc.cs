using System.Collections.Generic;

namespace CompositionAggregation.Tests.TestTypes
{
    public class SumSortDesc : IComparer<int[]>
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

            int sumX = 0;
            int sumY = 0;

            checked
            {
                foreach (int item in x)
                {
                    sumX += item;
                }

                foreach (int item in y)
                {
                    sumY += item;
                }
            }

            if (sumX == sumY)
            {
                return 0;
            }

            if (sumX > sumY)
            {
                return -1;
            }

            return 1;
        }
    }
}