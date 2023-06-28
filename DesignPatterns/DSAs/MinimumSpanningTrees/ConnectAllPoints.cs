using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.MinimumSpanningTrees {
    public class ConnectAllPoints {

        public ConnectAllPoints() {
            //0,0],[2,2],[3,10],[5,2],[7,0]
            int[][] points = new int[][] {
                new int[]{ 0, 0},
                new int[]{ 2, 2},
                new int[]{ 3, 10},
                new int[]{ 5, 2},
                new int[]{ 7, 0},
            };
            Solution sol = new Solution();
            int ans = sol.MinCostConnectPoints(points);
        }
    }
    internal class Solution {
        public int MinCostConnectPoints(int[][] points) {
            HashSet<int> map = new HashSet<int>();
            PriorityQueue<int[],int>pq = new PriorityQueue<int[], int>();
            pq.Enqueue(new int[] { 0, 0 }, 0);
            int d = 0;
            while(map.Count < points.Length) {
                int[] x = pq.Dequeue();
                
                int current = x[1];
                int prev = x[0];
                int[] p1 = new int[] { points[current][0], points[current][1] };
                int[] p2 = new int[] { points[prev][0], points[prev][1] };
                if(map.Contains(x[1])) { continue; }
                map.Add(x[1]);
                d += Math.Abs(p1[0] - p2[0]) + Math.Abs(p1[1] - p2[1]);

                for(int i=0;i<points.Length;i++) {
                    if(!map.Contains(i)) {
                        int[] p3 = points[i];
                        int t = Math.Abs(p1[0] - p3[0]) + Math.Abs(p1[1] - p3[1]);
                        pq.Enqueue(new int[] { x[1], i }, t);
                    }
                }

            }
            return d;
        }
    }
}
