using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Maximum_Sum_Circular_Sub_Array
{
    class MaxSumCircularSubArray
    {
        public int MaxSubarraySumCircular(int[] A)
        {

            var oneIntervalSum = GetMaxSum(A);

            var total = 0;
            var isAllNegative = true;
            for (var i = 0; i < A.Length; i++)
            {
                total += A[i];

                if (A[i] > 0)
                    isAllNegative = false;

                A[i] = -A[i];
            }

            var minSum = GetMaxSum(A) * -1;

            if (isAllNegative) return oneIntervalSum;
            return Math.Max(oneIntervalSum, total - minSum);
        }

        private int GetMaxSum(int[] A)
        {
            var sum = 0;
            var maxSum = int.MinValue;

            for (var i = 0; i < A.Length; i++)
            {
                sum += A[i];

                if (sum < A[i])
                {
                    sum = A[i];
                }

                if (maxSum < sum)
                {
                    maxSum = sum;
                }
            }

            return maxSum;
        }

        public int MaxSubarraySumCircular2(int[] A)
        {

            var oneIntervalSum = GetMaxSum(A);

            var total = 0;
            var isAllNegative = true;
            for (var i = 0; i < A.Length; i++)
            {
                total += A[i];
                if (A[i] > 0)
                    isAllNegative = false;
            }

            var minSum = GetMinSum(A);
            if (isAllNegative)
            {
                return oneIntervalSum;
            }

            return Math.Max(oneIntervalSum, total - minSum);
        }

        private int GetMinSum(int[] A)
        {
            var sum = 0;
            var minSum = int.MaxValue;

            for (var i = 0; i < A.Length; i++)
            {
                sum += A[i];

                if (sum > A[i])
                {
                    sum = A[i];
                }

                if (minSum > sum)
                {
                    minSum = sum;
                }
            }

            return minSum;
        }
    }
}
