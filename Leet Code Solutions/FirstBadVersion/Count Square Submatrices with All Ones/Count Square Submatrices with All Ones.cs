using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Count_Square_Submatrices_with_All_Ones
{
    class Count_Square_Submatrices_with_All_Ones
    {
        #region DP Based Solution
        public int CountSquares(int[][] matrix)
        {
            var dp = new int[matrix.Length][];

            var sum = 0;
            for (var i = 0; i < matrix.Length; i++)
            {
                dp[i] = new int[matrix[0].Length];
                for (var j = 0; j < matrix[0].Length; j++)
                {
                    // For the first row & col, copy the same values from the source matrix since we cant create any new square matrix just by using them.
                    // Dont consider values with 0 since we need matrix with all 1s
                    if (i == 0 || j == 0 || matrix[i][j] == 0)
                    {
                        dp[i][j] = matrix[i][j];
                    }
                    else if (matrix[i][j] == 1)
                    {
                        // The square matrix will have the same no of rows, cols and diagonals, the no of squares can be constructed will the min of rows, cols and diagonals
                        // '1+' is the n by n square matrix resulted in by placing 1 on the right most corner
                        dp[i][j] = 1 + Math.Min(Math.Min(dp[i - 1][j], dp[i][j - 1]), dp[i - 1][j - 1]);
                    }

                    sum += dp[i][j];
                }
            }

            return sum;
        }
        #endregion

        #region DP using Flag Technique
        public int CountSquares2(int[][] matrix)
        {
            var dp = new int[2][];
            var result = 0;
            var flag = 0;
            for (var i = 0; i < matrix.Length; i++)
            {
                dp[flag] = new int[matrix[0].Length];
                for (var j = 0; j < matrix[0].Length; j++)
                {
                    if (i == 0 || j == 0 || matrix[i][j] == 0)
                    {
                        dp[flag][j] = matrix[i][j];
                    }
                    else
                    {
                        // It just needs the previous rows data to calculate the current row. So instead of keeping the entire DP array use an array with 2 rows
                        // and overwrite the previous row once the current row is calculated. The flag and flag ^ 1 will toggle the rows and keep just the previous row
                        dp[flag][j] = 1 + Math.Min(Math.Min(dp[flag ^ 1][j], dp[flag][j - 1]), dp[flag ^ 1][j - 1]);
                    }

                    result += dp[flag][j];
                }

                // toggle the flag
                flag = flag ^ 1;
            }

            return result;
        }
        #endregion
    }
}
