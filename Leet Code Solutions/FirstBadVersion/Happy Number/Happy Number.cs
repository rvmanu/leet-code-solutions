using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Happy_Number
{
    class Happy_Number
    {
        public bool IsHappy(int n)
        {
            var sum = 0;
            var number = n;
            var set = new HashSet<int>();
            while (number > 0)
            {
                var digit = number % 10;
                sum = sum + (digit * digit);
                number = number / 10;

                if (number == 0 && sum != 1)
                {
                    if (set.Contains(sum))
                    {
                        return false;
                    }

                    set.Add(sum);
                    number = sum;
                    sum = 0;
                }
            }

            return true;
        }
    }
}
