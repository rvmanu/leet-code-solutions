using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.First_Unique_Character_in_a_String
{
    class First_Unique_Character
    {
        public int FirstUniqChar1(string s)
        {
            var charMap = new Dictionary<char, int>();
            for (var i = 0; i < s.Length; i++)
            {
                if (charMap.ContainsKey(s[i]))
                {
                    charMap[s[i]]++;
                }
                else
                {
                    charMap.Add(s[i], 1);
                }
            }

            for (var i = 0; i < s.Length; i++)
            {
                if (charMap[s[i]] == 1)
                    return i;
            }

            return -1;
        }

        public int FirstUniqChar2(string s)
        {
            int[] charMap = new int[26];
            foreach (var c in s)            // found that foreach is improving the performance here than using a for
            {
                charMap[c - 'a']++;
            }

            for (var i = 0; i < s.Length; i++)
            {
                if (charMap[s[i] - 'a'] == 1)
                    return i;
            }

            return -1;
        }
    }
}
