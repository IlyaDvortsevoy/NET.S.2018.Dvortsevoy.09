using System.Collections.Generic;

namespace CompositionAggregation.Tests.TestTypes
{
    public class SumSortAsc : IComparer<int[]>
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

            if (x.Length == 0 && y.Length > 0 )
            {
                return -1;
            }

            if (y.Length == 0 && x.Length > 0)
            {
                return 1;
            }

            int SumX = 0;
            int SumY = 0;

            checked
            {
                foreach (int item in x)
                {
                    SumX += item;
                }

                foreach (int item in y)
                {
                    SumY += item;
                }
            }

            if (SumX == SumY)
            {
                return 0;
            }

            if (SumX > SumY)
            {
                return 1;
            }

            return -1;
        }
    }
}