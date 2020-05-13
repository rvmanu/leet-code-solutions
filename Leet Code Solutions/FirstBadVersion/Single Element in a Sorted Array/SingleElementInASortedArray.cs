using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Single_Element_in_a_Sorted_Array
{
    class SingleElementInASortedArray
    {
        public int SingleNonDuplicate(int[] nums)
        {
            var low = 0;
            var high = nums.Length - 1;

            if (nums.Length == 1) return nums[0];
            if (nums[low] != nums[low + 1]) return nums[low];
            if (nums[high] != nums[high - 1]) return nums[high];

            while (low <= high)
            {
                var mid = low + (high - low) / 2;
                if (nums[mid] != nums[mid + 1] && nums[mid] != nums[mid - 1])
                {
                    return nums[mid];
                }
                // when mid is at an even index and numbers at mid and mid+1 are same, (first occurance is at an even index and ends at an odd index)
                // so the unique element will be after the mid element.
                // when mid is at an odd index and numbers at mid and mid-1 are same, (first occurance is at an even index and ends at an odd index)
                // so the unique element will be after the mid element.
                else if ((mid % 2 == 0 && mid + 1 < nums.Length && nums[mid] == nums[mid + 1]) ||
                         (mid % 2 == 1 && nums[mid] == nums[mid - 1]))
                {
                    low = mid + 1;
                }
                // when mid is at an even index and numbers at mid and mid-1 are same, (first occurance is at an odd index and ends at an even index)
                // so the unique element will be before the mid element.
                // when mid is at an odd index and numbers at mid and mid+1 are same, (first occurance is at an odd index and ends at an even index)
                // so the unique element will be before the mid element.
                else if ((mid % 2 == 0 && nums[mid] == nums[mid - 1]) ||
                         (mid % 2 == 1 && nums[mid] == nums[mid + 1]))
                {
                    high = mid - 1;
                }
            }

            return nums[low];
        }
    }
}
