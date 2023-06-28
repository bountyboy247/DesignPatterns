using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.BFS {
    public  class MinMoveWithRotations {
        public MinMoveWithRotations() {
            //Leetcode 1210 problem
            Solution sol = new Solution();
            int[][] grid = new int[4][];
            int ans = sol.MinimumMoves(grid);
        }

    }
    internal class Solution {
        public int MinimumMoves(int[][] grid) {
            //the problem is easy if we can understand how
            //the snakes position changes in each//
            //right, down, and rotate moves
            int n = grid.Length;
            Queue<(int r1, int c1, int r2, int c2, int move)> q =
            new Queue<(int, int, int, int, int)>();
            q.Enqueue((0, 0, 0, 1, 0));
            HashSet<string> map = new HashSet<string>();
            while(q.Count > 0) {
                int r1 = q.Peek().r1;
                int c1 = q.Peek().c1;
                int r2 = q.Peek().r2;
                int c2 = q.Peek().c2;
                int move = q.Peek().move;
                if(r1 == n - 1 && c1 == n - 2 && r2 == n - 1 && c2 == n - 1) {
                    return move;
                }

                q.Dequeue();
                string key = "R1C1-" + r1 + "-" + c1 + "-R2C2-" + r2 + "-" + c2;
                if(map.Contains(key)) continue;
                map.Add(key);
                //when snake is flat or in right position
                if(r1 == r2) {
                    if(c2 + 1 < n && c1 + 1 < n && grid[r1][c1 + 1] == 0 && grid[r2][c2 + 1] == 0) {
                        q.Enqueue((r1, c1 + 1, r2, c2 + 1, move + 1));
                    }
                    //check down position
                    if(r1 + 1 < n && r2 + 1 < n && grid[r1 + 1][c1] == 0 && grid[r2 + 1][c2] == 0) {
                        q.Enqueue((r1 + 1, c1, r2 + 1, c2, move + 1));
                        //we can also do rotate clockwise - intuition careful observation from example 1 test case
                        q.Enqueue((r1, c1, r2 + 1, c1, move + 1));
                    }
                }
                //when snake is in vertical position
                if(c1 == c2) {
                    if(c2 + 1 < n && c1 + 1 < n && grid[r1][c1 + 1] == 0 && grid[r2][c2 + 1] == 0) {
                        q.Enqueue((r1, c1 + 1, r2, c2 + 1, move + 1));
                        //this is rotate counter clockwise
                        q.Enqueue((r1, c1, r1, c2 + 1, move + 1));
                    }
                    //check down position
                    if(r1 + 1 < n && r2 + 1 < n && grid[r1 + 1][c1] == 0 && grid[r2 + 1][c2] == 0) {
                        q.Enqueue((r1 + 1, c1, r2 + 1, c2, move + 1));
                    }
                }
            }
            return -1;
        }
    }
}
