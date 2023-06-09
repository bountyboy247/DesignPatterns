using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.DPs
{
    public class EarnPoints
    {
        public EarnPoints()
        {
            //target = 6, types = [[6,1],[3,2],[2,3]]
            // target = 18, types = [[6,1],[3,2],[2,3]]
            int target = 18;
            int[][] types = new int[][]
            {
            new int[] {6,1},
            new int[]{3,2},
            new int[]{2,3}
           // new int[]{50,5}
            };
            int i = 3;
            int j = 0;
            int n1 = i & (1 << j);
            j++;
            int n2 = i & (1 << j);
            j++;
            int n3 = i & (1 << j);

            int ans = WaysToReachTarget(target, types);
        }

        private int WaysToReachTarget(int target, int[][] types)
        {
            int[][] storage = new int[types.Length][];
            for(int i=0;i<types.Length; i++)
            {
                storage[i] = new int[types[i].Length];
                for(int j = 0; j < types[0].Length; j++)
                {
                    storage[i][j] = types[i][j];
                }
            }
            int[,] dp = new int[target+1,types.Length+1];
            for(int i=0; i<=target; i++)
            {
                for (int k = 0; k <= types.Length; k++)
                {
                    dp[i, k] = -1;
                }
            }
            int ans = 0;
           // int temp = helper(target, types, 0, 1, dp);
            for (int k = 0; k < types.Length; k++)
            {
                int temp = helper(target, types, 0, k, dp);
                ans += temp;
                for (int l = 0; l <= target; l++)
                {
                    for (int m = 0; m <= types.Length; m++)
                    {
                        dp[l, m] = -1;
                    }
                }
                types = storage;
            }

            return ans;
        }
        private int helper(int target, int[][] types, int typeCnt, int index, int[,] dp)
        {
            if (target <= 0)
            {
                if (target == 0) return 1;
                return 0;
            }
            else if (dp[target,index] != -1)
            {
                return dp[target,index];
            }
            int total = 0;
            for(int i=index;i<types.Length; i++)
            {
                int point = types[i][1];      
                int typeCount = types[i][0];
                types[i][0] = typeCount - 1;
                if (typeCount >= typeCnt)
                {
                    int temp = helper(target - point, types, typeCnt + 1, i,dp);
                    total += temp;
                }
                types[i][0] = typeCount + 1;
            }
            dp[target, index] = total;
            return total;
        }
    }
}
