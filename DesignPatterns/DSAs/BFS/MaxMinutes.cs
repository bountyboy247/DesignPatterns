using DesignPatterns.LLD.CarRentalSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignPatterns.DSAs.BFS {
    public class MaxMinutes {
        public MaxMinutes() {
            //Input: grid = [[0,2,0,0,0,0,0],
            //[0,0,0,2,2,1,0],[0,2,0,0,1,2,0],[0,0,2,2,2,0,2],[0,0,0,0,0,0,0]]
            //        Output: 3
            //Explanation: The figure above shows the scenario where you stay in the initial
            //position for 3 minutes.
            //You will still be able to safely reach the safehouse.
            //Staying for more than 3 minutes will not allow you to safely reach the safehouse.
            int[][] grid = new int[][] {
                new int[]{ 0, 2, 0, 0, 0, 0, 0 },
                new int[]{ 0, 0, 0, 2, 2, 1, 0 },
                new int[]{ 0, 2, 0, 0, 1, 2, 0 },
                new int[]{ 0, 0, 2, 2, 2, 0, 2 },
                new int[]{ 0, 0, 0, 0, 0, 0, 0 }
            };
        }
        private int helper(int[][] grid) {

            int start = 0;
            int end = (int)1e9;
            int[] rx = new int[] { -1, 0, 1, 0 };
            int[] cx = new int[] { 0, 1, 0, -1 };
            Queue<(int r, int c)> q = new Queue<(int r, int c)>();
            for(int i=0;i < grid.Length; i++) {
                for(int j = 0; j < grid[0].Length; j++) {
                    if(grid[i][j] == 1) {
                        q.Enqueue((i, j));
                    }
                }
            }
            Queue<(int r, int c)> bq = initializeQueue(q);
            int[][] temp = resetArray(grid);
            int time = 0;
            while(start <= end) {
                int mid = (start + end) / 2;
                //can I stay in the same grid till mid time and still able to reach the safe house
                // This BFS is to set fires
                bool[,] visited = new bool[grid.Length, grid[0].Length];
                while(q.Count > 0) {

                    int size = q.Count;
                    time++;
                    while(size > 0) {
                        int r = q.Peek().r;
                        int c = q.Peek().c;
                        q.Dequeue();
                        if(visited[r, c] || grid[r][c] == 2) continue;
                        for(int i = 0; i < rx.Length; i++) {
                            int row = r + rx[i];
                            int col = c + cx[i];
                            if(row < 0 || col < 0
                               || row >= grid.Length || col >= grid[0].Length) continue;
                            int curr = grid[row][col];
                            if(curr == 0) {
                                q.Enqueue((r, c));
                            }

                        }
                        size--;
                    }
                }
            }
            return 0;
        }
        private int[][] resetArray(int[][] grid) {
            int[][] reset = new int[grid.Length][];
            for(int i=0;i<grid.Length;i++) {
                reset[i] = new int[grid[i].Length];
                for(int j = 0; j < grid[i].Length;j++) {
                    reset[i][j] = grid[i][j];   
                }
            }

            return reset;
        }
        private Queue<(int r, int c)> initializeQueue(Queue<(int r, int c)> q) {
            var qu = new Queue<(int r, int c)>(q);

            return qu;
        }
    }
}
