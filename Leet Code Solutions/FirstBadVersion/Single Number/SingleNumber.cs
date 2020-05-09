using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Single_Number
{
    class Single_Number
    {
        public int SingleNumber(int[] nums)
        {
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

            foreach (var item in dict)
            {
                if (dict[item.Key] == 1)
                    return item.Key;
            }

            return -1;
        }

        public int SingleNumber2(int[] nums)
        {
            var result = 0;
            foreach (var num in nums)
                result = result ^ num;

            return result;
        }
    }
}
