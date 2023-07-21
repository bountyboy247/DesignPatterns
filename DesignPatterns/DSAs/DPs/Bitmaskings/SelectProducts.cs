using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.DPs.Bitmaskings {
    public class SelectProducts {

        public SelectProducts() {
            int[][] price = new int[][] {
            new int[]{6,9,5,12,8,9,11,6},
            new int[]{8,2,6,12,7,5,7,22},
            new int[]{5,3,9,7,13,15,11,4}
            };
            int masking = (1 << price[0].Length) - 1;
            int[,] dp = new int[price.Length,(1 << price[0].Length)];
            int ans = minCost(price, masking, 0, dp);

        }

        private int minCost(int[][] price, int masking ,int i,int[,] dp) {
            if(i >= price.Length) { return 0; }
            if(dp[i,masking] != 0) return dp[i,masking];
            int max = (int)1e9;
            for(int j = 0; j < price[0].Length; j++) {
                int ss = masking & (1 << j);
                if(ss == 0) continue;
                int cost = price[i][j] + minCost(price, masking ^ (1 << j), i + 1, dp);

                if(max > cost) {
                    max = cost;
                }
            }
            dp[i, masking] = max;
            return max;
        }
    }
    
}
