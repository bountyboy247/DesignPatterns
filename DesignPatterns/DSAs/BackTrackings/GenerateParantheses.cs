using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.BackTrackings
{
    public class GenerateParantheses
    {
        public GenerateParantheses()
        {
            StringBuilder stringBuilder= new StringBuilder();
            stringBuilder.Append('c');
            stringBuilder.Append('a');
            stringBuilder.Append('r');
            string word = stringBuilder.ToString();
            stringBuilder.Remove(word.Length-1,1);
            var ans = GenerateParenthesis(5);
        }
        public IList<string> GenerateParenthesis(int n)
        {
            HashSet<string> map = new HashSet<string>();
            char[] arr = new char[2*n];
            for (int i = 0; i < 2 * n; i++)
            {
                if (i < n)
                {
                    arr[i] = '(';
                }
                else
                {
                    arr[i] = ')';
                }
            }
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('(', 0);
            dict.Add(')', 0);

            helper(arr, n, new Stack<char>(), map, dict);

            return map.ToList();
        }
        private void helper(char[] arr, int n, Stack<char> s, HashSet<string> map, Dictionary<char, int> dict)
        {

            if (dict['('] > n || dict[')'] > n) return;
            else if (s.Count >= 2 * n)
            {
                string str = "";
                //List<char> list = s.ToList();
                //for(int i=0;i<list.Count;i++) 
                //{
                //    str =list[i] + str ;
                //}
                map.Add(str);
                //s.Pop();
                return;
            }
            
            for (int i = 0; i < arr.Length; i++)
            {
                char curr = arr[i];
                dict[curr]++;
                s.Push(curr);
                helper(arr, n, s, map, dict);
                dict[curr]--;
                if(s.Count > 0)
                    s.Pop();
            }
        }
    }
}
