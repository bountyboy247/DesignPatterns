using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.BFS
{
    public class SmallestString
    {
        public SmallestString()
        {
            string s = "5525";
            int a = 9;
            int b = 2;
            string ans = FindLexSmallestString(s, a, b);
        }
        public string FindLexSmallestString(string s, int a, int b)
        {
            HashSet<string> map = new HashSet<string>();
            Queue<string> q = new Queue<string>();
            q.Enqueue(s);
            string min = s;
            Queue<char> rot = new Queue<char>();

            while (q.Count > 0)
            {
                string rem = q.Dequeue();
                if (map.Contains(rem)) continue;
                map.Add(rem);
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    rot.Enqueue(rem[i]);
                }
                string s1 = "";
                string s2 = "";
                for (int i = 0; i < s.Length; i++)
                {
                    if (i % 2 != 0)
                    { // odd indices
                        char c = rem[i];
                        int num = c - '0';
                        int sum = num + a;
                        int rmo = sum % 10;
                        s1 = s1 + rmo;
                    }
                    else
                    {
                        s1 = s1 + rem[i];
                    }
                }
                int x = 0;
                while (x < b)
                {
                    char rm = rot.Dequeue();
                    rot.Enqueue(rm);
                    x++;
                }
                while (rot.Count > 0)
                {
                    s2 = rot.Dequeue() + s2;
                }
                int c1 = string.CompareOrdinal(min, s1);
                if (c1 > 0)
                {

                    min = s1;
                }
                c1 = string.CompareOrdinal(min, s2);
                if (c1 > 0)
                {
                    min = s2;
                }
                q.Enqueue(min);
               // q.Enqueue(s2);
            }
            return min;
        }
    }
}
