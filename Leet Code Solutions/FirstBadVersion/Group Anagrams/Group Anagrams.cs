using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Group_Anagrams
{
    class Group_Anagrams
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new List<IList<string>>();
            if (strs.Length == 0)
            {
                result.Add(new List<string>());
                return result as IList<IList<string>>;
            }
            else if (strs.Length == 1)
            {
                result.Add(new List<string>() { strs[0] });
                return result as IList<IList<string>>;
            }

            result.Add(new List<string>() { strs[0] });

            for (var i = 1; i < strs.Length; i++)
            {
                var k = 0;
                var isFound = false;
                while (k < result.Count)
                {
                    var areSame = isAnagram(result[k][0], strs[i]);
                    if (areSame)
                    {
                        isFound = true;
                        result[k].Add(strs[i]);
                        break;
                    }

                    k++;
                }

                if (!isFound)
                {
                    result.Add(new List<string>() { strs[i] });
                }
            }

            return result as IList<IList<string>>;
        }

        private bool isAnagram(string x, string y)
        {
            if (x.Length != y.Length)
                return false;
            else
            {
                var charMap = new int[26];
                foreach (var c in y)
                {
                    charMap[c - 'a']++;
                }

                foreach (var c in x)
                {
                    charMap[c - 'a']--;
                }

                foreach (var c in y)
                {
                    if (charMap[c - 'a'] != 0)
                        return false;
                }

                return true;
            }
        }
    }
}
