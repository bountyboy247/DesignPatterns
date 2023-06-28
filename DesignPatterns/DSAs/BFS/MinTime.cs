using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.BFS {
    public class MinTime {
        public MinTime() {
            int[][] grid = new int[][] {
               new int[]{0,1,3,2},
               new int[]{5,1,2,5},
               new int[]{4,3,8,6}
            };
            int ans = MinimumTime(grid);
        }
        class Cmp : IComparer<int> {
            public int Compare(int a, int b) => b.CompareTo(a);
        }
        public int MinimumTime(int[][] grid) {
            PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();
            int[] RC = new int[] { -1, 0, 1, 0 };
            int[] CC = new int[] { 0, 1, 0, -1 };
            int[,] timeMat = new int[grid.Length, grid[0].Length];
            for(int i = 0; i < grid.Length; i++) {
                for(int j = 0; j < grid[0].Length; j++) {
                    timeMat[i, j] = (int)1e9;
                }
            }
            HashSet<string> cache = new HashSet<string>();
            pq.Enqueue(new int[] { 0, 0, 0 }, 0);

            while(pq.Count > 0) {
                int[] rem = pq.Dequeue();
                int r = rem[0];
                int c = rem[1];
                int currTime = rem[2];
                if(r == grid.Length - 1 && c == grid[0].Length - 1) {
                    return currTime;
                }
                string key = "R" + r + "C" + c + "T" + currTime;
                if(cache.Contains(key)) {
                    continue;
                };
                cache.Add(key);
                int gv = grid[r][c];
                for(int i = 0; i < RC.Length; i++) {
                    int rx = r + RC[i];
                    int cx = c + CC[i];
                    if(rx < 0 || cx < 0
                       || rx >= grid.Length
                       || cx >= grid.Length) {
                        continue;
                    }
                    int xt = currTime + 1;
                    int ngv = grid[rx][cx];
                    if( xt >= ngv) {
                        pq.Enqueue(new int[] { rx, cx, xt }, ngv);
                    }
                   
                }
            }

            return -1;
        }
    }
}
