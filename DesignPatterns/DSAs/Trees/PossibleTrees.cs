using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.DSAs.Trees.LinkedListInBT;

namespace DesignPatterns.DSAs.Trees {
    public class PossibleTrees {

        // Definition for a binary tree node.
        public class TreeNode {
              public int val;
              public TreeNode left;
              public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
         }
        public PossibleTrees()
        {
            var ans = AllPossibleFBT(5);
        }
        public IList<TreeNode> AllPossibleFBT(int n) {
            if(n == 1) {
                return new List<TreeNode>() { new TreeNode(0) };
            }
            if(n % 2 == 0) return new List<TreeNode>();

            IList<TreeNode> ls = AllPossibleFBT(n - 2);
            int count = ls.Count;
            if(count == 1 && (ls[0].left ==null && ls[0].right==null)) {
                ls[0].left = new TreeNode(0);
                ls[0].right = new TreeNode(0);
            }
            else {
                while(count > 0) {
                    TreeNode node = ls[count - 1];
                    TreeNode ans = null;
                    dfs(node, ans, ls);
                    //ls.Add(ans);
                    count--;
                }
            }
            return ls;
        }
        private void dfs(TreeNode node,TreeNode ans, IList<TreeNode> ls) {
            if(node.left == null && node.right == null) {
               // if(ans != null)
                    ans.left = new TreeNode(0);
                //if(ans != null)
                    ans.right = new TreeNode(0);

                if(ans != null) ls.Add(ans);
                return;
            }
            if(node == null) return;
           // ans = new TreeNode(node.val);
            dfs(node.left, node, ls);
            dfs(node.right, node, ls);
        }
    }
}
