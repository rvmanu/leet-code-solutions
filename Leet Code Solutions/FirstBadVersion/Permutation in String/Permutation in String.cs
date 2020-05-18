using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Permutation_in_String
{
    class Permutation_in_String
    {
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                return false;
            else if (s1 == s2)
                return true;

            var s1Map = new int[26];
            var s2Map = new int[26];
            var left = 0;
            var right = s1.Length - 1;
            foreach (var c in s1)
            {
                s1Map[c - 'a']++;
            }

            for (var i = left; i <= right; i++)
            {
                s2Map[s2[i] - 'a']++;
            }

            while (right < s2.Length)
            {
                var isFound = true;
                for (var i = 0; i < s1.Length; i++)
                {
                    if (s2Map[s1[i] - 'a'] != s1Map[s1[i] - 'a'])
                    {
                        isFound = false;
                        break;
                    }
                }

                if (isFound)
                {
                    return isFound;
                }

                s2Map[s2[left] - 'a']--;
                left++;
                right++;

                if (right < s2.Length)
                {
                    s2Map[s2[right] - 'a']++;
                }
            }

            return false;
        }
    }
}
