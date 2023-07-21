using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.TopologicalSorts {
    public class LearningExample1 {
        public LearningExample1() {
            //g.addEdge(5, 2);
            //g.addEdge(5, 0);
            //g.addEdge(4, 0);
            //g.addEdge(4, 1);
            //g.addEdge(2, 3);
            //g.addEdge(3, 1);
            //[[1,2],[2,3],[5],[0],[5],[],[]]
            int[][] edges = new int[][] {
                new int[]{1,2},
                new int[]{2,3},
                new int[]{5},
                new int[]{0},
                new int[]{5},
                new int[]{},
                new int[]{}
            };
            int n = 7;
          //  var ans1 = tp(edges, n);
        }

        public List<int> tp(int[][] edges, int n) {
            
            List<List<int>> adj = new List<List<int>>();
            for(int i=0;i<n; i++) { adj.Add(new List<int>()); }
            for(int i = 0; i < edges.Length; i++) {
                int a = edges[i][0];
                int b = edges[i][1];
                adj[a].Add(b);
            }
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[n];
            for(int i = 0; i < n; i++) {
                if(visited[i] ) continue;
                dfs(adj,i, visited, stack);
            }
           
            return stack.ToList();
        }
        private void dfs(List<List<int>> adj,int v, bool[] visited, Stack<int> st) {
            if(visited[v]) { return; }
            visited[v] = true;
            foreach(int node in adj[v]) {
                if(visited[node]) continue;
                dfs(adj, node, visited, st);    
            }
            st.Push(v);
        }
    }
}
