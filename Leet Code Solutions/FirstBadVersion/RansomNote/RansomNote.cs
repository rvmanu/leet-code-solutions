using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.RansomNote
{
    class RansomNote
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            if (ransomNote.Length > magazine.Length)
                return false;
            else if (ransomNote.Length == 0 || ransomNote == magazine)
            {
                return true;
            }
            else if (ransomNote.Length > 0)
            {
                var charMap = new int[26];
                for (var i = 0; i < magazine.Length; i++)
                {
                    charMap[magazine[i] - 'a']++;
                }

                for (var i = 0; i < ransomNote.Length; i++)
                {
                    if (charMap[ransomNote[i] - 'a'] > 0)
                    {
                        charMap[ransomNote[i] - 'a']--;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CanConstructRansomNote(string ransomNote, string magazine)
        {
            if (ransomNote.Length > magazine.Length)
                return false;
            else if (ransomNote.Length == 0)
            {
                return true;
            }
            else if (ransomNote.Length > 0)
            {
                var charMap = new Dictionary<char, int>();
                for (var i = 0; i < magazine.Length; i++)
                {
                    if (charMap.ContainsKey(magazine[i]))
                    {
                        charMap[magazine[i]]++;
                    }
                    else
                    {
                        charMap.Add(magazine[i], 1);
                    }
                }

                for (var i = 0; i < ransomNote.Length; i++)
                {
                    if (charMap.ContainsKey(ransomNote[i]) && charMap[ransomNote[i]] > 0)
                    {
                        charMap[ransomNote[i]]--;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
