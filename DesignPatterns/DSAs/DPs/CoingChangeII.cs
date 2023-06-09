using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.DPs
{
    public class CoingChangeII
    {
        public CoingChangeII()
        {
            int[] coins = new int[] { 1, 2, 5,6,7,8 };
            int amount =17;
           var ans = Change(amount, coins);
        }
        int[,] dp;
        private int Change(int amount, int[] coins)
        {
            dp = new int[amount + 1, coins.Length + 1];
            for (int i = 0; i <= amount; i++)
            {
                for (int j = 0; j <= coins.Length; j++)
                {
                    dp[i, j] = -1;
                }
            }
            int ans = helper(amount, coins, 0);
            return ans;

        }
        private int helper(int amount, int[] coins, int ind)
        {

            if (amount <= 0)
            {
                if (amount == 0)
                {
                    return 1;
                }
                return 0;
            }
            else if (dp[amount, ind] != -1)
            {
                return dp[amount, ind];
            }
            int total = 0;
            for (int i = ind; i < coins.Length; i++)
            {
                int temp = helper(amount - coins[i], coins, i);
                total = temp + total;
            }
            dp[amount, ind] = total;
            return total;
        }
    }
}
