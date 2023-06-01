using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesignPatterns.DSAs.Graphs
{
    public class CheapestFlights
    {
        public CheapestFlights()
        {
            //Example
            //        Input: n = 4, flights = [[0, 1, 100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]],
            //        src = 0,
            //        dst = 3, k = 1
            //Output: 700
            //Explanation:
            //            The graph is shown above.
            //The optimal path with at most 1 stop from city 0 to 3 is marked in red
            //and has cost 100 + 600 = 700.
            //Note that the path through cities[0, 1, 2, 3] is cheaper but is invalid because it
            //uses 2 stops.

            //Problem description
            //There are n cities connected by some number of flights.
            //You are given an array flights where flights[i] = [fromi, toi, pricei] indicates that
            //there is a flight from city fromi to city toi with cost pricei.

            //You are also given three integers src, dst, and k, return the cheapest price
            //from src to dst with at most k stops.If there is no such route, return -1.
            //[[0, 1, 5],[1,2,5],[0,3,2],[3,1,2],[1,4,1],[4,2,1]]
            int n = 5;
            int[][] flights = new int[][]
            {
                new int[]{ 0, 1, 5 },
                new int[]{1,2,5},
                new int[]{ 0,3,2},
                new int[]{3,1,2 },
                new int[]{ 1, 4, 1 },
                new int[]{4,2,1}
            };
            int src = 0;
            int dst = 2;
            int k = 2;
            int ans = FindCheapestPrice(n, flights, src, dst,k);
        }
        private int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {

            List<List<(int to, int cost)>> adj = new List<List<(int, int)>>();
            bool[] visited = new bool[n];
            int[] costMat = new int[n];

            for (int i = 0; i < n; i++)
            {
                adj.Add(new List<(int to, int cost)>());
                costMat[i] = (int)1e9;
            }
           

            costMat[src] = 0;
            for (int i = 0; i < flights.Length; i++)
            {
                int from = flights[i][0];
                int to = flights[i][1];
                int cost = flights[i][2];
                adj[from].Add((to, cost));
            }
            //check if it is reachable
            bool IsValid = false;
            helper(adj, src, dst, visited, ref IsValid);
            if (!IsValid) return -1;
            PriorityQueue<(int node, int stops, int cost), int> q =
                new PriorityQueue<(int node, int stops, int cost), int>();

            q.Enqueue((src, 0, 0), 0);
            int totCost = (int)1e9;
            while (q.Count > 0)
            {
                int node = q.Peek().node;
                int stops = q.Peek().stops;
                int cost = q.Peek().cost;

                q.Dequeue();
                if (node == dst)
                {
                    totCost = Math.Min(totCost, cost);
                }
                else if (stops > k) continue;
                foreach (var o in adj[node])
                {
                    int tentativeCost = o.cost + cost;
                    if (tentativeCost < costMat[o.to] || stops <= k)
                    {
                        costMat[o.to] = tentativeCost;
                        q.Enqueue((o.to, stops + 1, tentativeCost), tentativeCost);
                    }

                }
            }
            if (totCost >= (int)1e9) return -1;
            return totCost;
        }
        private void helper(List<List<(int to, int dist)>> adj, int s, int d, bool[] visited, ref bool IsValid)
        {

            if (s == d)
            {
                IsValid = true;
                return;
            }
            else if (IsValid) return;
            foreach (var node in adj[s])
            {
                if (visited[node.to]) continue;
                visited[node.to] = true;
                helper(adj, node.to, d, visited, ref IsValid);
            }
        }
    }
}
