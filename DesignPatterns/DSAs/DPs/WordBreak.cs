using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.DPs
{
    public class WordBreak
    {
        public WordBreak()
        {
            //["cat","cats","and","sand","dog"]
            string ns = "catsanddog";
            IList<string> w1 = new List<string>() { "cat", "cats", "and", "sand", "dog" };
            var ans1 = WordBreakList(ns, w1);
            IList<string> w = new List<string>(){ "a", "abc", "b", "cd"};
           bool ans =  WB("abcd", w);
        }
        bool IsValid = false;
        Dictionary<string, bool> map = new Dictionary<string, bool>();
        private bool WB(string s, IList<string> wordDict)
        {
            if (s.Length == 0)
            {
                IsValid = true;
                return true;
            }
            else if (IsValid) return true;
            else if (map.ContainsKey(s)) return map[s];
            bool IsWord = false;
            foreach (string word in wordDict)
            {
                int len = word.Length;
                if (s.Length >= len)
                {
                    string ss = s.Substring(0, len);
                    if (string.Equals(ss, word))
                    {
                        string remStr = s.Substring(len, s.Length - len);
                        IsWord = WB(remStr, wordDict);
                    }
                }
            }
            map[s] = IsWord;
            return IsWord;
        }
        public IList<string> WordBreakList(string s, IList<string> wordDict)
        {
            IList<string> ans = new List<string>();
            Queue <(string word, string ns)> q = new Queue<(string, string)>();
            q.Enqueue((s, ""));

            while (q.Count > 0)
            {
                string rem = q.Peek().word;
                string ns = q.Peek().ns;
                if (rem.Length == 0)
                {
                    ans.Add(ns);
                }
                q.Dequeue();
                foreach (string word in wordDict)
                {
                    if (rem.Length >= word.Length)
                    {
                        string ss = rem.Substring(0, word.Length);
                        if (string.Equals(ss, word))
                        {
                            string remStr = rem.Substring(word.Length, rem.Length - word.Length);
                            if(ns.Length == 0)
                            {
                                q.Enqueue((remStr,word));
                            }
                            else
                            {
                                q.Enqueue((remStr, ns + " " + word));
                            }
                            
                        }
                    }
                }
            }

            return ans;
        }
    }
}
