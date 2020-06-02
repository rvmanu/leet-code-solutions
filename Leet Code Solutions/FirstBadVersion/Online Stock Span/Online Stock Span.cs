using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Online_Stock_Span
{
    class StockSpanner
    {
        /**
         * Your StockSpanner object will be instantiated and called as such:
         * StockSpanner obj = new StockSpanner();
         * int param_1 = obj.Next(price);
         */
         
        Stack<int> stack = null;
        List<int> priceList = null;
        public StockSpanner()
        {
            stack = new Stack<int>();
            priceList = new List<int>();
        }

        public int Next(int price)
        {
            if (priceList.Count == 0)
            {
                priceList.Add(price);

                // For the first time, then wont any previous element. So insert it as 0 and the span will be 1
                stack.Push(0);
                return 1;
            }
            else
            {
                priceList.Add(price);

                // Maintain the stack in decreasing order of elements to get the next largest element for comparison
                // No need to maintain the duplicate element in the stack, so <= instead of <
                while (stack.Count > 0 && priceList[stack.Peek()] <= price)
                {
                    stack.Pop();
                }

                var result = 0;
                if (stack.Count == 0)
                {
                    // When all the elements are popped out - means, the current price is higher than all other prices
                    // So span will be the total no of elements.
                    result = priceList.Count;
                }
                else
                {
                    // If there is some element in the stack, then the difference of the indices between the current price and the stack top will give the span.
                    // Since the stack maintains the indices in the decreasing order of price and indices are consecutive.
                    // Both operations are based on indices and indices start from 0 to N-1 (so use priceList.Count - 1 instead of priceList.Count)
                    result = priceList.Count - 1 - stack.Peek();
                }

                // Push the index on the stack, since its consecutive so can represent days
                stack.Push(priceList.Count - 1);
                return result;
            }
        }
    }
}
