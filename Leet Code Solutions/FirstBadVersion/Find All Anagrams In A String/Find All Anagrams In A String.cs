using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Find_All_Anagrams_In_A_String
{
    class Find_All_Anagrams_In_A_String
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            if (s == p) return new List<int> { 0 };
            if (s.Length < p.Length) return new List<int>();
            var list = new List<int>();
            var pMap = new int[26];
            var map = new int[26];
            foreach (var c in p)
            {
                pMap[c - 'a']++;
            }

            var left = 0;
            var right = p.Length - 1;

            for (var i = left; i <= right; i++)
            {
                map[s[i] - 'a']++;
            }

            while (right < s.Length)
            {
                var isMatch = true;
                for (var i = 0; i < p.Length; i++)
                {
                    if (pMap[p[i] - 'a'] != map[p[i] - 'a'])
                    {
                        isMatch = false;
                        break;
                    }
                }

                if (isMatch)
                {
                    list.Add(left);
                }

                map[s[left] - 'a']--;
                left++;
                right++;
                if (right < s.Length)
                {
                    map[s[right] - 'a']++;
                }
            }

            return list;
        }
    }
}
