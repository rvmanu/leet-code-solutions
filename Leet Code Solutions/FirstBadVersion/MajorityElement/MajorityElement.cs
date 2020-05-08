using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.MajorityElement
{
    class MajorityElement
    {
        public int MajorityElement(int[] nums)
        {
            int threshold = nums.Length / 2;
            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }

            foreach (var key in dict.Keys)
            {
                if (dict[key] > threshold)
                    return key;
            }

            return -1;
        }
    }
}
