using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesignPatterns.DSAs.BFS
{
    public class MaxCandies
    {
        //1298. Maximum Candies You Can Get from Boxes
        //Problem statement
        //    You have n boxes labeled from 0 to n - 1. You are given four arrays: status,
        //    candies, keys, and containedBoxes where:

        //status[i] is 1 if the ith box is open and 0 if the ith box is closed,
        //candies[i] is the number of candies in the ith box,
        //keys[i] is a list of the labels of the boxes you can open after opening the ith box.
        //    containedBoxes[i] is a list of the boxes you found inside the ith box.
        //    You are given an integer array initialBoxes that contains the labels of the boxes
        //    you initially have.
        //    You can take all the candies in any open box and you can use the keys in it
        //    to open new boxes and you also can use the boxes you find in it.
        //    Return the maximum number of candies you can get following the rules above.

        //        Input: status = [1,0,1,0], candies = [7,5,4,100], keys = [[],[],[1],[]],
        //        containedBoxes = [[1,2],[3],[],[]], initialBoxes = [0]
        //        Output: 16
        //Explanation: You will be initially given box 0. You will find 7 candies in it and boxes 1
        //and 2.
        //Box 1 is closed and you do not have a key for it so you will open box 2.
        //You will find 4 candies
        //and a key to box 1 in box 2.
        //In box 1, you will find 5 candies and box 3 but you will not find a key to box 3 so box 3
        //will remain closed.
        //Total number of candies collected = 7 + 4 + 5 = 16 candy.
        public MaxCandies()
        {
            int[] status = new int[] { 1, 0, 1, 0 };
            int[] candies = new int[] { 7, 5, 4, 100 };
            int[][] keys = new int[][]
                            { new int[0], new int[0],  new int[] { 1 }, new int[0] };
            // containedBoxes = [[1, 2],[3],[],[]],
            int[][] containedBoxes = new int[][] { new int[] { 1, 2 }, new int[] { 3 }, new int[0], new int[0] };
            int[] initialBoxes = new int[] { 0 };

            int ans = MaxCandies1(status,candies,keys, containedBoxes, initialBoxes);
        }
        public int MaxCandies1(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
        {
            int ans = 0;
            bool[] visited = new bool[containedBoxes.Length];
            Queue<(int box, bool HasKey)> q = new Queue<(int, bool)>();
            foreach(int box in initialBoxes)
            {
                q.Enqueue((box, false));
            }

            while(q.Count > 0)
            {
                int box = q.Peek().box;
                bool HasKey = q.Peek().HasKey;
                q.Dequeue();
                if (visited[box]) { continue; }
                visited[box] = true;
                //count total no. of candies
                if (status[box] == 1) //if box is open
                {
                    ans += candies[box];
                    foreach (int containedBox in containedBoxes[box])
                    {
                        
                        if (keys[box].Contains(containedBox))
                        {
                            q.Enqueue((containedBox, true));
                        }
                        else
                        {
                            q.Enqueue((containedBox, false));
                        }
                    }
                }
                else //box is closed
                {
                    //check if you have key to open it
                    if (HasKey)
                    {
                        ans += candies[box];
                        foreach (int containedBox in containedBoxes[box])
                        {
                            if (keys[box].Contains(containedBox))
                            {
                                q.Enqueue((containedBox, true));
                            }
                            else
                            {
                                q.Enqueue((containedBox, false));
                            }
                        }
                    }
                }
            }
            return ans;
        }
    }
}
