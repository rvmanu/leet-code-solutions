using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Interval_List_Intersections
{
    class Interval_List_Intersections
    {
        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            var result = new List<int[]>();
            var output = new List<int[]>();
            var i = 0;
            var j = 0;
            while (i < A.Length && j < B.Length)
            {
                //Scenario 1:
                //      aMin          aMax
                //       1             5
                //             bMin            bMax
                //              3               6

                //Scenario 2:
                //      aMin          aMax
                //       1             3
                //                              bMin            bMax
                //                               7               9

                //Scenario 3: (No need to process this scenario at this time, since bMax < aMax, it will increment list B's pointer and it will reach to become Scenario 1)
                //              aMin          aMax
                //                2             5
                //      bMin            bMax
                //       1               4
                var a = A[i][0];
                var b = A[i][1];
                var c = B[j][0];
                var d = B[j][1];

                if (c <= b && a <= d)
                {
                    output.Add(new int[2] { Math.Max(a, c), Math.Min(b, d) });
                }

                if (b > d)
                    j++;
                else
                    i++;
            }

            return output.ToArray();
        }
    }
}
