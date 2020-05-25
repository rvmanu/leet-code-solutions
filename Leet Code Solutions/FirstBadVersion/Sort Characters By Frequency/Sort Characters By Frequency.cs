using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstBadVersion.Sort_Characters_By_Frequency
{
    class Sort_Characters_By_Frequency
    {
        public string FrequencySort(string s)
        {
            var dict = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            var result = new StringBuilder();
            foreach (var item in dict.OrderByDescending(x => x.Value))
            {
                result.Append(item.Key, item.Value);
            }

            return result.ToString();
        }

        public string FrequencySort(string s)
        {
            var dict = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            var result = new StringBuilder();
            while (dict.Count > 0)
            {
                var maxCount = -1;
                var maxCountChar = '#';
                foreach (var item in dict)
                {
                    if (maxCount < item.Value)
                    {
                        maxCount = item.Value;
                        maxCountChar = item.Key;
                    }
                }

                for (var i = 0; i < maxCount; i++)
                {
                    result.Append(maxCountChar);
                }

                dict.Remove(maxCountChar);
            }

            return result.ToString();
        }
    }
}
