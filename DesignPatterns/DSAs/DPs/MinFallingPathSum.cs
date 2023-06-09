using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.DPs
{
    public class MinFallingPathSum
    {
        public MinFallingPathSum()
        {
            //[[2,1,3,4],[5,6,5,4],[7,3,8,9],[1,2,3,4]]
            int[][] grid = new int[][] { new int[] { 2,2,1,2,2},new int[]
          {2, 2, 1, 2, 2}, new int[]{ 2,2,1,2,2}, new int[]{ 2, 2, 1, 2, 2 },new int[]{ 2, 2, 1, 2, 2 } };
            int[][] matrix = new int[][] { new int[] { 1,2,3 },new int[]
          { 4,5,6 }, new int[]{ 7, 8, 9 } };

            int ans = M2(grid); 
        }
        public int GetMinFallingPathSum(int[][] matrix)
        {
            int minSum = (int)1e9;
            int r = matrix.Length;
            int c = matrix[0].Length;
            int[,] dp = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = matrix[i][j];
                    }
                    else if (i == 0)
                    {
                        dp[i, j] = matrix[i][j];
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = matrix[i][j] + Math.Min(dp[i - 1, j], dp[i - 1, j + 1]);
                    }
                    else if (j == c - 1)
                    {
                        dp[i, j] = matrix[i][j] + Math.Min(dp[i - 1, j], dp[i - 1, j - 1]);
                    }
                    else
                    {
                        dp[i, j] = matrix[i][j] + Math.Min(Math.Min(dp[i - 1, j], dp[i - 1, j - 1]), dp[i - 1, j + 1]);
                    }
                    if (i == r - 1)
                    {
                        minSum = Math.Min(minSum, dp[i, j]);
                    }
                }
            }
           
            return minSum;
        }
        public int MinFallingPathSum2(int[][] grid)
        {
            int minSum = (int)1e9;
            int r = grid.Length;
            int c = grid[0].Length;
            int[,] dp = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = grid[i][j];
                        continue;
                    }
                    int temp = (int)1e9;
                    for (int k = 0; k < c; k++)
                    {
                        if (k != j)
                        {
                            temp = Math.Min(dp[i - 1,k],temp);
                        }
                    }
                    dp[i, j] = grid[i][j] + temp;
                    if(i == r - 1)
                    {
                        minSum = Math.Min(minSum, dp[i, j]);
                    }
                }
            }

            return minSum;
        }
        public int M2(int[][] grid)
        {
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            int r = grid.Length;
            int c = grid.Length;
            for (int i = 0; i < c; i++)
            {
                minHeap.Enqueue(grid[0][i], grid[0][i]);
            }
            for (int i = 1; i < r; i++)
            {
                int min1 = minHeap.Dequeue();
                int min2 = minHeap.Dequeue();
                minHeap = new PriorityQueue<int, int>();
                for (int j = 0; j < c; j++)
                {
                    if (grid[i - 1][j] == min1)
                    {
                        grid[i][j] += min2;
                    }
                    else
                    {
                        grid[i][j] += min1;                  
                    }
                    minHeap.Enqueue(grid[i][j], grid[i][j]);
                }
            }

            return minHeap.Peek();
        }
    }
}
