using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.BackTrackings
{
    //LetterCombinations
    public class LetterCombinations
    {
        public LetterCombinations()
        {
            int xor = 0;
            int[] num = new int[] { 1, 2, 1, 2, 3, 5 };
            for(int i = 0; i < num.Length; i++)
            {
                xor ^= num[i];
            }
            for(int i=0;i< num.Length; i++)
            {

            }

            string d = "7269";
            var ans = LC(d);
        }
        public IList<string> LC(string digits)
        {
            Dictionary<char, string> map = new Dictionary<char, string>();
            map['2'] = "abc"; map['3'] = "def";
            map['4'] = "ghi"; map['5'] = "jkl"; map['6'] = "mno";
            map['7'] = "pqrs"; map['8'] = "tuv"; map['9'] = "wxyz";

            IList<string> ls = new List<string>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            helper(0, digits,new StringBuilder(), map, ls);
            sw.Stop();
            var tt = sw.ElapsedMilliseconds;
            if (ls.Contains("samytimalsina"))
            {
                int x = 88;
            }
            return ls;
        }
        private void helper(int index, string digits, StringBuilder sb, Dictionary<char, string> map, IList<string> ls)
        {

            if (index >= digits.Length)
            {
                if(sb.Length> 0)
                    ls.Add(sb.ToString());
                return;
            }
            foreach (char c in map[digits[index]])
            {
                sb.Append(c);
                helper(index + 1, digits, sb, map, ls);
                if(sb.Length> 0)
                    sb.Remove(index, 1);
            }
        }
    }
}
