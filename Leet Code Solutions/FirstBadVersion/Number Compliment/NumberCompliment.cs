using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Number_Compliment
{
    class NumberCompliment
    {
        public int FindComplement1(int num)
        {
            //num XOR 1s = comp
            var result = num;
            var digit = (int)Math.Log(num, 2) + 1;
            for (var i = 0; i < digit; i++)
            {
                result = result ^ (1 << i);
            }

            return result;
        }

        public int FindComplement2(int num)
        {
            //num XOR 1s = comp
            var result = num;
            var digit = 0;
            while (num > 0)
            {
                result = result ^ (1 << digit);
                num = num / 2;
                digit++;
            }

            return result;
        }

        public int FindComplement3(int num)
        {
            //num XOR 1s = comp
            return num ^ (int)Math.Pow(2, (int)Math.Log(num, 2) + 1) - 1;
        }

        public int FindComplement4(int num)
        {
            var result = 0;
            var stack = new Stack<int>();
            while (num != 0)
            {
                var digit = num % 2;
                stack.Push(digit == 0 ? 1 : 0);
                num = num / 2;
            }

            while (stack.Count > 0)
            {
                var digit = stack.Pop();
                result = result * 2 + digit;
            }

            return result;
        }
    }
}
