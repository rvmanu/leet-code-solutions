using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Valid_Perfect_Square
{
    class Valid_Perfect_Square
    {
        public bool IsPerfectSquare(int num)
        {
            long result = 0;
            long number = num;
            for (long i = 1; (i * i) <= number; i++)
            {
                result = i * i;
            }

            return result == number;
        }

        public bool IsPerfectSquare(int num)
        {
            if (num == 0 || num == 1) return true;

            // starting from low = 2 improves execution time
            var low = 2;
            var high = num;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;

                // using division instead of multiplication improves execution time
                if (mid == num / mid)       
                {
                    return num % mid == 0;
                }
                else if (mid > num / mid)
                {
                    high = mid - 1;
                }
                else if (mid < num / mid)
                {
                    low = mid + 1;
                }
            }

            return false;
        }
    }
}
