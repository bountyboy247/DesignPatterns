using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.Trees {
    public class LinkedListInBT {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null) {
                this.val = val;
                this.next = next;
            }
        }

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
        public LinkedListInBT() {
            ListNode l1 = new ListNode(1);
            ListNode h1 = new ListNode(4);
            ListNode h2 = new ListNode(2);
            ListNode h3 = new ListNode(6);
            //ListNode h4 = new ListNode(8);

            l1.next= h1;
            h1.next= h2;
            h2.next= h3;
          //  h3.next= h4;
            TreeNode r1 = new TreeNode(1);
            TreeNode r2 = new TreeNode(4);
            TreeNode r3 = new TreeNode(4);
            TreeNode r4 = new TreeNode(2);
            TreeNode r5 = new TreeNode(1);
            TreeNode r6 = new TreeNode(2);
            TreeNode r7 = new TreeNode(6);
            TreeNode r8 = new TreeNode(8);
            TreeNode r9 = new TreeNode(1);
            TreeNode r10 = new TreeNode(3);
       
            r1.left= r2;
            r1.right= r3;

            r2.right= r4;
            r4.left = r5;

            r3.left = r6;
            r6.left = r7;
            r6.right = r8;

            r8.left = r9;
            r9.right = r10;

            bool isAns = IsSubPath(l1, r1);
        }
        ListNode mainH = null;
        public bool IsSubPath(ListNode head, TreeNode root) {
            //check every node 
            bool IsValid = false;
            mainH = head;
            //Queue<TreeNode> q = new Queue<TreeNode>();
            //q.Enqueue(root);
            //while(q.Count > 0) {
            //    TreeNode rem = q.Dequeue();

               // if(rem.val == head.val) {
                    dfs(root, head, ref IsValid);
              //  }
                if(IsValid) return true;
            //    if(rem.left != null) q.Enqueue(rem.left);
            //    if(rem.right != null) q.Enqueue(rem.right);
            //}

            return IsValid;
        }
        private void dfs(TreeNode root, ListNode head, ref bool IsValid) {
            if(head == null) {
                IsValid = true;
                return;
            }
            else if(root == null) return;
            if(root.val == head.val) {
                dfs(root.left, head.next, ref IsValid);
                dfs(root.right, head.next, ref IsValid);
            }
            else {
                dfs(root.left, mainH, ref IsValid);
                dfs(root.right, mainH, ref IsValid);
            }
        }
    }
}
