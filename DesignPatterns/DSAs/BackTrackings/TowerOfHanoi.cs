using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.BackTrackings {
    public class TowerOfHanoi {
        class TOH {
            public Stack<int>[] stacks;
            public Queue<string> moves;
            public int move;
        }
        public TowerOfHanoi() {
            int n = 16;
            int ans = toh(n);

        }
        //The tower of Hanoi is a famous puzzle where we have three rods and N disks.
        //The objective of the puzzle is to move the entire stack to another rod.
        //You are given the number of discs N. Initially, these discs are in the rod 1.
        //You need to print all the steps of discs movement so that all the discs reach the 3rd rod.
        //Also, you need to find the total moves.
        //Note: The discs are arranged such that the top disc is numbered 1 and the bottom-most disc
        //is numbered N. Also, all the discs have different sizes and a bigger disc cannot be put on
        //the top of a smaller disc. Refer the provided link to get a better clarity about the puzzle.


        //Example 1:

        //Input:
        //N = 2
        //Output:
        //move disk 1 from rod 1 to rod 2
        //move disk 2 from rod 1 to rod 3
        //move disk 1 from rod 2 to rod 3
        //3
        //Explanation: For N = 2, steps will be
        //as follows in the example and total
        //3 steps will be taken.

        //Example 2:

        //Input:
        //N = 3
        //Output:
        //move disk 1 from rod 1 to rod 3
        //move disk 2 from rod 1 to rod 2
        //move disk 1 from rod 3 to rod 2
        //move disk 3 from rod 1 to rod 3
        //move disk 1 from rod 2 to rod 1
        //move disk 2 from rod 2 to rod 3
        //move disk 1 from rod 1 to rod 3
        //7
        //Explanation: For N = 3, steps will be
        //as follows in the example and total
        //7 steps will be taken.

        //Your Task:
        //You don't need to read input or print anything. You only need to complete the function toh()
        //that takes following parameters: N (number of discs), from (The rod number from which we move
        //the disc), to (The rod number to which we move the disc), aux (The rod that is used as an
        //auxiliary rod) and prints the required moves inside function body (See the example for the
        //format of the output) as well as return the count of total moves made. The total number of
        //moves are printed by the driver code.
        //Please take care of the case of the letters.

        //Expected Time Complexity: O(2^N).
        //Expected Auxiliary Space: O(N).

        //Constraints:
        //0 <= N <= 16
        //Complete this function
        public long toh(int n, int from, int to, int aux) {
            //Your code here
            int[] rod1 = new int[] { 1, 2, 3 };
            int[] rod2 = new int[] { 0, 0, 0 };
            int[] rod3 = new int[] { 0, 0, 0 };
            Queue<( int frm, int to, int aux, int move)> q =
                new Queue<( int frm, int to, int aux, int move)>();
            q.Enqueue((1, 0, 0, 0));
            while(q.Count > 0) {
                int frm = q.Peek().frm;
                int t = q.Peek().to;
                int ax = q.Peek().aux;
                int move = q.Peek().move;
                if(t == n) {
                    return move;
                }


            }
            return 0;
        }
        public int toh(int N) {
            int ans = 0;
            Stack<int>[] stacks = new Stack<int>[3];
            for(int i = 0; i < 3; i++) {
                stacks[i] = new Stack<int>();
            }
            for(int i = N; i >= 1; i--) {
                stacks[0].Push(i);
            }
            Queue<string> moves = new Queue<string>();
            Queue<TOH> q = new Queue<TOH>();
           
            HashSet<string> map = new HashSet<string>();
            TOH th = new TOH() {
                stacks = stacks,
                move = 0,
                moves = moves,
            };
            q.Enqueue(th);
            while(q.Count > 0) {
                Stack<int>[] remStacks = q.Peek().stacks;
                Queue<string> movs = q.Peek().moves;
                int move = q.Peek().move;
                var s0 = remStacks[0];
                var s1 = remStacks[1];
                var s2 = remStacks[2];
                if(s2.Count == N) {
                    while(movs.Count > 0)
                        Console.WriteLine(movs.Dequeue());
                    return move;
                }
                q.Dequeue();
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i < 3; i++) {
                    sb.Append("S" + i);
                    int[] arr = remStacks[i].ToArray();
                    for(int j = 0; j < arr.Length; j++) {
                        sb.Append('-');
                        sb.Append(arr[j]);
                        
                    }
                }
                string key = sb.ToString();
                if(map.Contains(key)) {
                    continue;
                }
                map.Add(key);
                if(s0.Count > 0) {
                  
                    var temp = new Stack<int>[3];
                    temp[0] = new Stack<int>(new Stack<int>(s0));
                    temp[1] = new Stack<int>(new Stack<int>(s1));
                    temp[2] = new Stack<int>(new Stack<int>(s2));
                    int rem1 = temp[0].Pop();
                    if(temp[1].Count == 0 || temp[1].Peek() > rem1) {
                        var m1 = new Queue<string>(movs);
                        m1.Enqueue($"Move disc no.{rem1} From Rod1 to Rod2");
                        temp[1].Push(rem1);
                        TOH th1 = new TOH() {
                            stacks = temp,
                            move = move + 1,
                            moves = m1
                        };
                        q.Enqueue(th1);
                    }

                    var temp1 = new Stack<int>[3];
                    temp1[0] = new Stack<int>(new Stack<int>(s0));
                    temp1[1] = new Stack<int>(new Stack<int>(s1));
                    temp1[2] = new Stack<int>(new Stack<int>(s2));
                    rem1 = temp1[0].Pop();
    
                    if(temp1[2].Count==0 || temp1[2].Peek() > rem1) {
                        temp1[2].Push(rem1);
                        var m1 = new Queue<string>(movs);
                        m1.Enqueue($"Move disc no.{rem1} From Rod1 to Rod3");
                        TOH th1 = new TOH() {
                            stacks = temp1,
                            move = move + 1,
                            moves = m1
                        };
                        q.Enqueue(th1);
                    }
                   
                    
                }
                if(s1.Count > 0) {
                    
                    var temp = new Stack<int>[3];
                    temp[0] = new Stack<int>(new Stack<int>(s0));
                    temp[1] = new Stack<int>(new Stack<int>(s1));
                    temp[2] = new Stack<int>(new Stack<int>(s2));
                    int rem1 = temp[1].Pop();
                    if(temp[0].Count == 0 || temp[0].Peek() > rem1) {
                        temp[0].Push(rem1);
                        var m1 = new Queue<string>(movs);
                        m1.Enqueue($"Move disc no.{rem1} From Rod2 to Rod1");
                        
                        TOH th1 = new TOH() {
                            stacks = temp,
                            move = move + 1,
                            moves = m1
                        };
                        q.Enqueue(th1);
                    }
                   

                    var temp1 = new Stack<int>[3];
                    temp1[0] = new Stack<int>(new Stack<int>(s0));
                    temp1[1] = new Stack<int>(new Stack<int>(s1));
                    temp1[2] = new Stack<int>(new Stack<int>(s2));
                    rem1 = temp1[1].Pop();
                    if(temp1[2].Count == 0 || temp1[2].Peek() > rem1) {
                        temp1[2].Push(rem1);
                        var m1 = new Queue<string>(movs);
                        m1.Enqueue($"Move disc no.{rem1} From Rod2 to Rod3"); 
                        TOH th1 = new TOH() {
                            stacks = temp1,
                            move = move + 1,
                            moves = m1
                        };
                       
                        q.Enqueue(th1);
                    }

                   
                }
                if(s2.Count > 0) {
                    
                    var temp = new Stack<int>[3];
                    temp[0] = new Stack<int>(new Stack<int>(s0));
                    temp[1] = new Stack<int>(new Stack<int>(s1));
                    temp[2] = new Stack<int>(new Stack<int>(s2));
                    int rem1 = temp[2].Pop();

                    if(temp[0].Count == 0 || temp[0].Peek() > rem1) {
                        temp[0].Push(rem1);
                        var m1 = new Queue<string>(movs);
                        m1.Enqueue($"Move disc no.{rem1} From Rod3 to Rod1");
                        TOH th1 = new TOH() {
                            stacks = temp,
                            move = move + 1,
                            moves = m1
                        };
                        q.Enqueue(th1);
                    }
               

                    var temp1 = new Stack<int>[3];
                    temp1[0] = new Stack<int>(new Stack<int>(s0));
                    temp1[1] = new Stack<int>(new Stack<int>(s1));
                    temp1[2] = new Stack<int>(new Stack<int>(s2));
                    rem1 = temp1[2].Pop();

                    if(temp1[1].Count == 0 || temp1[1].Peek() > rem1) {
                        temp1[1].Push(rem1);
                        var m1 = new Queue<string>(movs);
                        m1.Enqueue($"Move disc no.{rem1} From Rod3 to Rod2");
                        TOH th1 = new TOH() {
                            stacks = temp1,
                            move = move + 1,
                            moves = m1
                        };
                        q.Enqueue(th1);
                    }
                }
            }
            return ans;
        }
    }
}
