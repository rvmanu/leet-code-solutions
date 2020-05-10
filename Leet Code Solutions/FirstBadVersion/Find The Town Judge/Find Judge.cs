using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.FindJudge
{
    class Find_Judge
    {
        public int FindJudge(int N, int[][] trust)
        {
            if (trust.Length == 0 && N == 1) return 1;

            var dict = new Dictionary<int, int>();
            for (var i = 0; i < trust.Length; i++)
            {
                if (dict.ContainsKey(trust[i][1]))
                {
                    dict[trust[i][1]]++;
                }
                else
                {
                    dict.Add(trust[i][1], 1);
                }
            }

            // Not so optimal since we have nested loops.
            foreach (var item in dict)
            {
                if (dict[item.Key] == N - 1)
                {
                    var isJudge = true;
                    for (var i = 0; i < trust.Length; i++)
                    {
                        if (trust[i][0] == item.Key)
                        {
                            isJudge = false;
                            break;
                        }
                    }

                    if (isJudge)
                    {
                        return item.Key;
                    }
                }
            }

            return -1;
        }

        public int FindJudge(int N, int[][] trust)
        {
            if (trust.Length == 0 && N == 1) return 1;

            // Judge wont trust anybody - judge wont have any outbounds
            // Everybody trusts the judge - inbounds for judge will be N-1
            // so, 1 could be a contains search and the other needs a count. 
            // hence ideal DS would be Dictionary and HashSet
            // But this logic is also not an optimal one.

            var leftSet = new HashSet<int>();
            var dictRight = new Dictionary<int, int>();
            for (var i = 0; i < trust.Length; i++)
            {
                if (!leftSet.Contains(trust[i][0]))
                {
                    leftSet.Add(trust[i][0]);
                }

                if (dictRight.ContainsKey(trust[i][1]))
                {
                    dictRight[trust[i][1]]++;
                }
                else
                {
                    dictRight.Add(trust[i][1], 1);
                }
            }

            foreach (var item in dictRight)
            {
                if (!leftSet.Contains(item.Key) && dictRight[item.Key] == N - 1)
                    return item.Key;
            }

            return -1;
        }

        public int FindJudge(int N, int[][] trust)
        {
            if (trust.Length == 0 && N == 1) return 1;

            var count = new int[N + 1];
            for (var i = 0; i < trust.Length; i++)
            {
                count[trust[i][0] - 1]--;
                count[trust[i][1] - 1]++;
            }

            for (var i = 0; i < N; i++)
            {
                if (count[i] == N - 1)
                {
                    return i + 1;
                }
            }

            return -1;
        }
    }
}
