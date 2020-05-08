using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.JewelsAndStones
{
    class JewelsAndStones
    {
        public int NumJewelsInStones(string J, string S)
        {
            //Lookup is more hence use a dictionary to reduce the lookup time to O(1)
            var charMap = new Dictionary<char, int>();
            for (var i = 0; i < J.Length; i++)
            {
                charMap.Add(J[i], 0);
            }

            var count = 0;
            for (var j = 0; j < S.Length; j++)
            {
                //TODO: Use HashSet instead of Dictionary
                //Dictionary is not the ideal DS for this purpose since we are not fetching the value.
                //But this is more performant than using nested loops
                if (charMap.ContainsKey(S[j]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
