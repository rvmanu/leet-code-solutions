using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.FirstBadVersion
{
    class FirstBadVersion
    {
        public int GetFirstBadVersion(int n)
        {
            var low = 0;
            var high = n;
            while (low < high)
            {
                // Calculating midpoint using (low + high)/2 vs low + ((high-low) / 2) : https://stackoverflow.com/questions/21101110/calculating-midpoint-index-in-binary-search
                // var midPoint = (low + high) / 2;

                // Best practice is to use this for finding mid-point
                //var midPoint = low + Convert.ToInt32(Math.Floor(Convert.ToDouble((high - low) / 2)));
                int midPoint = low + (high - low) / 2;
                var isMidPointBad = IsBadVersion(midPoint);
                if (isMidPointBad)
                {
                    // no need to decrement midpoint here as this could be the first bad version
                    high = midPoint;
                }
                else
                {
                    // Dont need to consider the midpoint since its not bad.
                    low = midPoint + 1;
                }
            }

            return low;
        }

        private static bool IsBadVersion(int midPoint)
        {
            return true;
        }
    }
}
