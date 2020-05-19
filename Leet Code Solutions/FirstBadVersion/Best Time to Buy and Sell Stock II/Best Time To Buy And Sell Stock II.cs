using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.NewFolder
{
    class Best_Time_To_Buy_And_Sell_Stock_II
    {
        public int MaxProfit(int[] prices)
        {
            // one day eithor buy/sell/skip transaction on any no of units and price during that day remains constant.
            // We get profit when buy at low and sell at high
            // One will get max profit wheh all such instances are utilized
            var profit = 0;
            for (var i = 0; i < prices.Length - 1; i++)
            {
                // buy at low and sell at high
                if (prices[i] < prices[i + 1])
                    profit += (prices[i + 1] - prices[i]);
            }

            return profit;
        }
    }
}
