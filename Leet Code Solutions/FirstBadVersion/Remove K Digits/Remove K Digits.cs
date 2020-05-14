using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Remove_K_Digits
{
    class Remove_K_Digits
    {
        public string RemoveKdigits(string num, int k)
        {
            if (num.Length == 0 || num.Length == k) return "0";

            var stack = new Stack<char>();
            var deletedCount = 0;
            for (var i = 0; i < num.Length; i++)
            {
                if (stack.Count == 0 && i == 0)
                {
                    stack.Push(num[i]);
                }
                else
                {
                    var topItem = stack.Peek();
                    while (stack.Count > 0 && topItem > num[i] && deletedCount < k)
                    {
                        stack.Pop();
                        deletedCount++;

                        if (stack.Count > 0)
                        {
                            topItem = stack.Peek();
                        }
                    }

                    stack.Push(num[i]);
                }
            }

            while (stack.Count > 0 && deletedCount < k)
            {
                stack.Pop();
                deletedCount++;
            }

            var result = new StringBuilder();
            var items = stack.ToArray();
            for (var i = items.Length - 1; i >= 0; i--)
            {
                if (result.Length > 0 && items[i] == '0')
                {
                    result.Append(items[i]);
                }
                else if (items[i] != '0')
                {
                    result.Append(items[i]);
                }
            }

            var output = result.ToString();
            return output.Length == 0 ? "0" : output;
        }
    }
}
