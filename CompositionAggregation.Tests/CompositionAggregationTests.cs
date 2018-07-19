using System;
using System.Collections.Generic;
using CompositionAggregation.Tests.TestTypes;
using NUnit.Framework;

namespace CompositionAggregation.Tests
{
    public class CompositionAggregationTests
    {
        #region Private Readonly Fields
        private static readonly List<int[][]> SourceSum = new List<int[][]>()
        {
            new int[][]
            {
                new int[] { 12, 5, 7, 6, 8 },
                new int[] { 120, 300 },
                new int[] { 1, 0, -7, -1, 1, 2, 1, 1, 1 }
            },

            new int[][]
            {
                new int[] { 12, 5, 7, 6, 8 },
                new int[] { 120, 300 },
                new int[] { 10, 308, -77, 0, 11 },
                new int[] { 321, 111, 17, 0, 14 },
                new int[] { 1, 2, 3, 0, 4 }
            },

            new int[][]
            {
                new int[] { -1, -13, -44, 0, 8 },
                new int[] { -120, -413 }
            }
        };

        private static readonly List<int[][]> SourceMaxMin = new List<int[][]>()
        {
            new int[][]
            {
                new int[] { 15, 66, 34, 623, 82 },
                new int[] { -1, -300, -437, 8, 1 },
                new int[] { 2, 2, 14, 54, 0, -1 }
            },

            new int[][]
            {
                new int[] { 12, 5, 7, 6, 8 },
                new int[] { 120, 300 },
                new int[] { 10, 308, -77, 0, 11 },
                new int[] { 321, 111, 17, 0, 14 },
                new int[] { 1, 2, 3, 0, 4 }
            },

            new int[][]
            {
                new int[] { -1, -13, -44, 0, 8 },
                new int[] { -120, -413 }
            },

            new int[][]
            {
                new int[] { 3, -13, 144, 0, 11 },
                new int[] { 120, -413, 34 },
                new int[] { 77, -3, 14 }
            }
        };

        private static readonly List<int[][]> ResultSumAsc = new List<int[][]>()
        {
            new int[][]
            {
                new int[] { 1, 0, -7, -1, 1, 2, 1, 1, 1 }, // -1
                new int[] { 12, 5, 7, 6, 8 }, // 38
                new int[] { 120, 300 } // 420
            },

            new int[][]
            {
                new int[] { 1, 2, 3, 0, 4 }, // 10
                new int[] { 12, 5, 7, 6, 8 }, // 38
                new int[] { 10, 308, -77, 0, 11 }, // 252
                new int[] { 120, 300 }, // 420
                new int[] { 321, 111, 17, 0, 14 } // 463
            },

            new int[][]
            {
                new int[] { -120, -413 }, // -533
                new int[] { -1, -13, -44, 0, 8 } // -50
            }
        };

        private static readonly List<int[][]> ResultSumDesc = new List<int[][]>()
        {
            new int[][]
            {
                new int[] { 120, 300 }, // 420
                new int[] { 12, 5, 7, 6, 8 }, // 38
                new int[] { 1, 0, -7, -1, 1, 2, 1, 1, 1 } // -1
            },

            new int[][]
            {
                new int[] { 321, 111, 17, 0, 14 }, // 463
                new int[] { 120, 300 }, // 420
                new int[] { 10, 308, -77, 0, 11 }, // 252
                new int[] { 12, 5, 7, 6, 8 }, // 38
                new int[] { 1, 2, 3, 0, 4 } // 10
            },

            new int[][]
            {
                new int[] { -1, -13, -44, 0, 8 }, // -50
                new int[] { -120, -413 } // -533
            }
        };

        private static readonly List<int[][]> ResultMaxAsc = new List<int[][]>()
        {
            new int[][]
            {
                new int[] { -1, -300, -437, 8, 1 }, // 8
                new int[] { 2, 2, 14, 54, 0, -1 }, // 54
                new int[] { 15, 66, 34, 623, 82 } // 623
            },

            new int[][]
            {
                new int[] { 1, 2, 3, 0, 4 }, // 4
                new int[] { 12, 5, 7, 6, 8 }, // 12
                new int[] { 120, 300 }, // 300
                new int[] { 10, 308, -77, 0, 11 }, // 308
                new int[] { 321, 111, 17, 0, 14 } // 321
            },

            new int[][]
            {
                new int[] { -120, -413 }, // -120
                new int[] { -1, -13, -44, 0, 8 } // 8
            },

            new int[][]
            {
                new int[] { 77, -3, 14 }, // 77
                new int[] { 120, -413, 34 }, // 120
                new int[] { 3, -13, 144, 0, 11 } // 144
            }
        };

        private static readonly List<int[][]> ResultMaxDesc = new List<int[][]>()
        {
            new int[][]
            {
                new int[] { 15, 66, 34, 623, 82 }, // 623
                new int[] { 2, 2, 14, 54, 0, -1 }, // 54
                new int[] { -1, -300, -437, 8, 1 } // 8
            },

            new int[][]
            {
                new int[] { 321, 111, 17, 0, 14 }, // 321
                new int[] { 10, 308, -77, 0, 11 }, // 308
                new int[] { 120, 300 }, // 300
                new int[] { 12, 5, 7, 6, 8 }, // 12
                new int[] { 1, 2, 3, 0, 4 } // 4
            },

            new int[][]
            {
                new int[] { -1, -13, -44, 0, 8 }, // 8
                new int[] { -120, -413 } // -120
            },

            new int[][]
            {
                new int[] { 3, -13, 144, 0, 11 }, // 144
                new int[] { 120, -413, 34 }, // 120
                new int[] { 77, -3, 14 } // 77
            }
        };

        private static readonly List<int[][]> ResultMinAsc = new List<int[][]>()
        {
            new int[][]
            {
                new int[] { -1, -300, -437, 8, 1 }, // -437
                new int[] { 2, 2, 14, 54, 0, -1 }, // -1
                new int[] { 15, 66, 34, 623, 82 } // 15
            },

            new int[][]
            {
                new int[] { 10, 308, -77, 0, 11 }, // -77
                new int[] { 321, 111, 17, 0, 14 }, // 0
                new int[] { 1, 2, 3, 0, 4 }, // 0
                new int[] { 12, 5, 7, 6, 8 }, // 5
                new int[] { 120, 300 } // 120
            },

            new int[][]
            {
                new int[] { -120, -413 }, // -413
                new int[] { -1, -13, -44, 0, 8 } // -44
            },

            new int[][]
            {
                new int[] { 120, -413, 34 }, // -413
                new int[] { 3, -13, 144, 0, 11 }, // -13
                new int[] { 77, -3, 14 } // -3
            }
        };

        private static readonly List<int[][]> ResultMinDesc = new List<int[][]>()
        {
            new int[][]
            {
                new int[] { 15, 66, 34, 623, 82 }, // 15
                new int[] { 2, 2, 14, 54, 0, -1 }, // -1
                new int[] { -1, -300, -437, 8, 1 } // -437
            },

            new int[][]
            {
                new int[] { 120, 300 }, // 120
                new int[] { 12, 5, 7, 6, 8 }, // 5
                new int[] { 321, 111, 17, 0, 14 }, // 0
                new int[] { 1, 2, 3, 0, 4 }, // 0
                new int[] { 10, 308, -77, 0, 11 } // -77
            },

            new int[][]
            {
                new int[] { -1, -13, -44, 0, 8 }, // -44
                new int[] { -120, -413 } // -413
            },

            new int[][]
            {
                new int[] { 77, -3, 14 }, // -3
                new int[] { 3, -13, 144, 0, 11 }, // -13
                new int[] { 120, -413, 34 } // -413
            }
        };
        #endregion

        #region Validation Tests
        [Test]
        public void ValidateArray_Method_Throws_ArgumentNullException_If_Array_Is_Null()
        {
            Assert.That(
                () => BubbleSort.Sort(null, new MaxSortAsc()),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ValidateComparer_Method_Throws_ArgumentNullException_If_Comparer_Is_Null()
        {
            var array = new int[1][];

            Assert.That(
                () => BubbleSort.Sort(array, comparer: null),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ValidateArray_Method_Throws_ArgumentException_If_Array_Is_Empty()
        {
            var array = new int[0][];

            Assert.That(
                () => BubbleSort.Sort(array, comparer: null),
                Throws.TypeOf<ArgumentException>());
        }
        #endregion

        #region Main Functionality Tests
        [Test, Sequential]
        public void SumSortAsc_pass_tests_successfully(
            [ValueSource(nameof(SourceSum))] int[][] initial,
            [ValueSource(nameof(ResultSumAsc))] int[][] result)
        {          
            BubbleSort.Sort(initial, new SumSortAsc());

            CollectionAssert.AreEqual(initial, result);
        }

        [Test, Sequential]
        public void SumSortDesc_pass_tests_successfully(
            [ValueSource(nameof(SourceSum))] int[][] initial,
            [ValueSource(nameof(ResultSumDesc))] int[][] result)
        {
            BubbleSort.Sort(initial, new SumSortDesc());

            CollectionAssert.AreEqual(initial, result);
        }

        [Test, Sequential]
        public void MaxSortAsc_pass_tests_successfully(
            [ValueSource(nameof(SourceMaxMin))] int[][] initial,
            [ValueSource(nameof(ResultMaxAsc))] int[][] result)
        {
            BubbleSort.Sort(initial, new MaxSortAsc());

            CollectionAssert.AreEqual(initial, result);
        }

        [Test, Sequential]
        public void MaxSortDesc_pass_tests_successfully(
            [ValueSource(nameof(SourceMaxMin))] int[][] initial,
            [ValueSource(nameof(ResultMaxDesc))] int[][] result)
        {
            BubbleSort.Sort(initial, new MaxSortDesc());

            CollectionAssert.AreEqual(initial, result);
        }

        [Test, Sequential]
        public void MinSortAsc_pass_tests_successfully(
            [ValueSource(nameof(SourceMaxMin))] int[][] initial,
            [ValueSource(nameof(ResultMinAsc))] int[][] result)
        {
            BubbleSort.Sort(initial, new MinSortAsc());

            CollectionAssert.AreEqual(initial, result);
        }

        [Test, Sequential]
        public void MinSortDesc_pass_tests_successfully(
            [ValueSource(nameof(SourceMaxMin))] int[][] initial,
            [ValueSource(nameof(ResultMinDesc))] int[][] result)
        {
            BubbleSort.Sort(initial, new MinSortDesc());

            CollectionAssert.AreEqual(initial, result);
        }
        #endregion
    }
}