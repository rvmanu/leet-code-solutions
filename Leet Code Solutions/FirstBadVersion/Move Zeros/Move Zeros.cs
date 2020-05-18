using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Move_Zeros
{
    class Move_Zeros
    {
        //Approach 1 - Two pointer technique
        public void MoveZeroes(int[] nums)
        {
            var left = 0;
            var right = 0;
            while (right < nums.Length)
            {
                while (right < nums.Length && nums[right] == 0)
                    right++;

                if (left < nums.Length && right < nums.Length && nums[left] == 0 && nums[right] != 0)
                {
                    var temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;
                }

                left++;
                right++;
            }
        }

        // Approach 2 - Overwrite the zero elements with the next available non zero element
        public void MoveZeroes2(int[] nums)
        {
            var index = 0;
            var zCount = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[index++] = nums[i];
                }
                else
                {
                    zCount++;
                }
            }

            for (var i = 0; i < zCount; i++)
            {
                nums[nums.Length - i - 1] = 0;
            }
        }

        // Approach 3 - Overwrite the zero elements with the next available non zero element
        public void MoveZeroes3(int[] nums)
        {
            var index = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[index++] = nums[i];
                }
            }

            for (var i = index; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
    }
}
