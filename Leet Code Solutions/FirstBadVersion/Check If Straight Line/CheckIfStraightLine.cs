using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Check_If_Straight_Line
{
    class CheckIfStraightLine
    {
        public bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates.Length == 2)
            {
                return true;
            }

            //(x1,y1), (x2,y2), (x3,y3) => (y2-y1)*(x3-x2) = (x2-x1)*(y3-y2) 
            var xDiff1 = coordinates[1][0] - coordinates[0][0];
            var yDiff1 = coordinates[1][1] - coordinates[0][1];
            for (var i = 1; i < coordinates.Length - 1; i++)
            {
                var xDiff2 = coordinates[i + 1][0] - coordinates[i][0];
                var yDiff2 = coordinates[i + 1][1] - coordinates[i][1];

                if (yDiff1 * xDiff2 != xDiff1 * yDiff2)
                {
                    return false;
                }

                xDiff1 = xDiff2;
                yDiff1 = yDiff2;
            }

            return true;
        }

        public bool CheckStraightLine2(int[][] coordinates)
        {
            if (coordinates.Length == 2)
            {
                return true;
            }

            //Equation of a line passing through the point (x1,y1) given the slope
            // y-y1 = m * (x-x1)
            // the slope, m = (y2-y1)/(x2-x1)
            // (x1,y1), (x2,y2), (x,y) => (y-y1)*(x2-x1) = (x-x1)*(y2-y1) 
            var x1 = coordinates[0][0];
            var y1 = coordinates[0][1];
            var x2 = coordinates[1][0];
            var y2 = coordinates[1][1];

            for (var i = 1; i < coordinates.Length - 1; i++)
            {
                var x = coordinates[i][0];
                var y = coordinates[i][1];
                if (((y - y1) * (x2 - x1)) != ((x - x1) * (y2 - y1)))
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckStraightLine3(int[][] coordinates)
        {
            if (coordinates.Length == 2)
            {
                return true;
            }

            //Area of a triangle formed by 3 points: 1/2 * [ x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2) ]
            var x1 = coordinates[0][0];
            var y1 = coordinates[0][1];
            var x2 = coordinates[1][0];
            var y2 = coordinates[1][1];
            var x3 = coordinates[2][0];
            var y3 = coordinates[2][1];
            for (var i = 1; i < coordinates.Length - 2; i++)
            {
                var area = 0.5 * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
                if (area != 0)
                    return false;

                x1 = coordinates[i][0];
                y1 = coordinates[i][1];
                x2 = coordinates[i + 1][0];
                y2 = coordinates[i + 1][1];
                x3 = coordinates[i + 2][0];
                y3 = coordinates[i + 2][1];
            }
            return true;
        }
    }
}
