using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Reverse_a_String
{
    class Reverse_s_String
    {
        public void ReverseString(char[] s)
        {
            for (var i = 0; i < s.Length / 2; i++)
            {
                var temp = s[i];
                s[i] = s[s.Length - 1 - i];
                s[s.Length - 1 - i] = temp;
            }
        }
    }
}
