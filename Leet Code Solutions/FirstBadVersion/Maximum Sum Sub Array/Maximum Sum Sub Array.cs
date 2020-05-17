using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Maximum_Sum_Sub_Array
{
    class Maximum_Sum_Sub_Array
    {
        public int MaxSubArray(int[] nums)
        {
            var localSum = 0;
            var globalSum = int.MinValue;
            foreach (var num in nums)
            {
                localSum += num;
                if (localSum < num)
                    localSum = num;
                if (globalSum < localSum)
                    globalSum = localSum;
            }

            return globalSum;
        }

        public int MaxSubArray2(int[] nums)
        {
            var low = 0;
            var high = nums.Length - 1;

            return MaxSubArray(nums, low, high);
        }

        public int MaxSubArray(int[] nums, int low, int high)
        {
            if (low < high)
            {
                var mid = low + (high - low) / 2;

                var leftSum = MaxSubArray(nums, low, mid);
                var rightSum = MaxSubArray(nums, mid + 1, high);
                var crossSum = CrossSum(nums, low, high, mid);
                return Max(leftSum, rightSum, crossSum);
            }
            else //if(low == high)
                return nums[low];

        }

        public int Max(int a, int b, int c)
        {
            return Math.Max(Math.Max(a, b), c);
        }

        public int CrossSum(int[] nums, int low, int high, int mid)
        {
            var leftSum = 0;
            var leftMax = int.MinValue;
            for (var i = mid; i >= low; i--)
            {
                leftSum += nums[i];
                if (leftMax < leftSum)
                    leftMax = leftSum;
            }

            var rightSum = 0;
            var rightMax = int.MinValue;
            for (var i = mid + 1; i <= high; i++)
            {
                rightSum += nums[i];
                if (rightMax < rightSum)
                    rightMax = rightSum;
            }

            return Max(leftMax + rightMax, leftSum, rightSum);
        }
    }
}
