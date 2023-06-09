using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.DPs
{
    public class UniquePathWithObstacles
    {
        public UniquePathWithObstacles()
        {
            //[[0,0,0],[0,1,0],[0,0,0]]
            int[][] o = new int[][]
            {
                new int[]{0,1,0,0,0,0,0},
                new int[]{0,0,0,0,0,1,0},
                new int[]{ 0, 0, 0, 0, 0, 0, 0 }
            };
            int ans = f(o);
        }
        private int f(int[][] obstacleGrid)
        {
            int[,] dp = new int[obstacleGrid.Length, obstacleGrid[0].Length];
            for(int i = 0; i < obstacleGrid.Length; i++)
            {
                for(int j = 0; j < obstacleGrid[0].Length; j++)
                {
                    if (obstacleGrid[i][j] != 1)
                    {
                        if(i == 0 && j == 0)
                        {
                            dp[i,j] = 1;    
                        }
                        else if(i == 0)
                        {
                            dp[i, j] = dp[i, j - 1];
                        }
                        else if(j == 0)
                        {
                            dp[i, j] = dp[i-1, j];
                        }
                        else
                        {
                            dp[i,j] = dp[i-1,j] + dp[i,j-1];
                        }
                    }
                    else
                    {
                        dp[i, j] = 0;
                    }
                }
            }
            return dp[obstacleGrid.Length-1, obstacleGrid[0].Length-1];
        }
    }
}
