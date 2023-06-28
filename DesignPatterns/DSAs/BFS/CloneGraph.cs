using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignPatterns.DSAs.BFS {
    public class CloneGraph {
        public CloneGraph() {
//        Input: adjList = [[2, 4],[1,3],[2,4],[1,3]]
//Output: [[2,4],[1,3],[2,4],[1,3]]
//Explanation: There are 4 nodes in the graph.
//1st node(val = 1)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
//2nd node(val = 2)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).
//3rd node(val = 3)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
//4th node(val = 4)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).
           Node n1 = new Node(1);
           Node n2 = new Node(2);
           Node n3 = new Node(3);
           Node n4 = new Node(4);
            n1.neighbors.Add(n2);
            n1.neighbors.Add(n4);
            n2.neighbors.Add(n1);
            n2.neighbors.Add(n3);
            n3.neighbors.Add(n2);
            n3.neighbors.Add(n4);
            n4.neighbors.Add(n1);
            n4.neighbors.Add(n3);
            var ans = CloneGraphs(n1);  
        }
        public class Node {
            public int val;
            public IList<Node> neighbors;

            public Node() {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val) {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors) {
                val = _val;
                neighbors = _neighbors;
            }
        }
        public Node CloneGraphs(Node node) {
            HashSet<Node> visited = new HashSet<Node>();
            Node n = new Node(node.val);
           Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            while(q.Count> 0) {
                Node rem = q.Dequeue();
                if(visited.Contains(rem)) {
                    continue;
                }
                visited.Add(rem);
                if(n == null) {
                    n = new Node(rem.val);
                }
                else {
                       n.neighbors.Add(rem);
                }
                foreach(Node x in rem.neighbors) {
                        q.Enqueue(x);
                }
            }
            n = n.neighbors[0];
            return n;
        }
    }


}
