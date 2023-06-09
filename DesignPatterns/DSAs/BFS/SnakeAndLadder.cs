using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.BFS
{
    public class SnakeAndLadder
    {
        public SnakeAndLadder()
        {
            string xx = "1123333";
            string yy = "1123337";
            int nn = string.CompareOrdinal(xx, yy);
//            You are given an n x n integer matrix board where the cells are labeled from 1
//            to n2 in a Boustrophedon style starting from the bottom left of the
//            board(i.e.board[n - 1][0]) and alternating direction each row.

//You start on square 1 of the board.In each move, starting from square curr, do the following:

//    Choose a destination square next with a label in the range[curr + 1, min(curr + 6, n2)].
//        This choice simulates the result of a standard 6 - sided die roll: i.e., there are always
//        at most 6 destinations, regardless of the size of the board.
//    If next has a snake or ladder, you must move to the destination of that snake or ladder.
//    Otherwise, you move to next.
//    The game ends when you reach the square n2.

//A board square on row r and column c has a snake or ladder if board[r][c] != -1.The destination
//of that snake or ladder is board[r][c].Squares 1 and n2 do not have a snake or ladder.

//Note that you only take a snake or ladder at most once per move. If the destination to a snake
//or ladder is the start of another snake or ladder, you do not follow the subsequent snake or ladder.

//    For example, suppose the board is [ [-1, 4], [-1, 3]], and on the first move, your destination
//    square is 2.You follow the ladder to square 3, but do not follow the subsequent ladder to 4.

//Return the least number of moves required to reach the square n2. If it is not 
               // possible to reach the square, return -1.
            //board = [[-1,-1,-1,-1,-1,-1],
            //[-1,-1,-1,-1,-1,-1],
            //[-1,-1,-1,-1,-1,-1],
            //[-1,35,-1,-1,13,-1],
            //[-1,-1,-1,-1,-1,-1],
            //[-1,15,-1,-1,-1,-1]]
            int[][] board = new int[][]
            {
                new int[]{ -1, -1, -1, -1, -1, -1 },
                new int[]{ -1, -1, -1, -1, -1, -1 },
                new int[]{ -1, -1, -1, -1, -1, -1 },
                new int[]{ -1, 35, -1, -1, 13, -1 },
                new int[]{ -1, -1, -1, -1, -1, -1 },
                new int[]{ -1, 15, -1, -1, -1, -1 }
            };
            int ans = SnakesAndLadders(board);
        }
        public int SnakesAndLadders(int[][] board)
        {
            int num = 1;
            int count = 0;
            //construct the board matrix first
            Dictionary<int, (int r, int c)> map = new Dictionary<int, (int r, int c)>();
            bool[][] visited = new bool[board.Length][];
            for (int i = board.Length - 1; i >= 0; i--)
            {
                visited[i] = new bool[board[i].Length];
                if (count % 2 == 0)
                {
                    for (int j = 0; j < visited[i].Length; j++)
                    {
                        map[num] = (i, j);
                        num++;
                    }
                }
                else
                {
                    for (int j = visited[i].Length - 1; j >= 0; j--)
                    {
                        map[num] = (i, j);
                        num++;
                    }
                }
                count++;
            }

            int n2 = board.Length * board.Length;

            Queue<(int row, int col, int curr, int cost)> q = new Queue<(int row, int col, int curr, int cost)>();
            q.Enqueue((board.Length - 1, 0, 1, 0));

            while (q.Count > 0)
            {
                int curr = q.Peek().curr;
                int row = q.Peek().row;
                int col = q.Peek().col;
                int cost = q.Peek().cost;
                if (curr == n2)
                {
                    return cost;
                }
                q.Dequeue();
                if (visited[row][col]) continue;
                visited[row][col] = true; 

                int range = Math.Min(curr + 6, n2);
                for (int i = curr + 1; i <= range; i++)
                {
                    var o = map[i];
                    int bv = board[o.r][o.c];
                    if (bv == -1)
                    {
                        q.Enqueue((o.r, o.c, i, cost + 1));
                    }
                    else
                    {
                        var n = map[board[o.r][o.c]];
                        q.Enqueue((n.r, n.c, board[o.r][o.c], cost + 1));
                    }
                }
            }
            return -1;
        }
    }
}
