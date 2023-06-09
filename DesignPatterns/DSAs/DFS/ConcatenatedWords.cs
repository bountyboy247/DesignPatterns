using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.DFS
{
    public class ConcatenatedWords
    {
        class Trie
        {
            public bool EOL;
            //public char c;

            public Dictionary<char, Trie> childrens;
            public Trie()
            {
                childrens= new Dictionary<char, Trie>();
                EOL=false;
                //c = '*';
            }
        }
        public ConcatenatedWords()
        {
            string[] words = new string[] { "cat", "cats", "catsdogcats", "dog", "dogcatsdog",
                "hippopotamuses", "rat", "ratcatdogcat" };
            var ans = FindAllConcatenatedWordsInADict(words);
        }
        private IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            IList<string> result = new List<string>();
            //sort the word by the length
            
            Array.Sort(words, (s1,s2) => s1.Length.CompareTo(s2.Length));
            Queue<string> q = new Queue<string>();
            Trie head = new Trie();
            foreach(string word in words)
            {
                IList<string> ls = new List<string>();  
                Trie temp = head;
                //q.Enqueue(word);
                foreach(char c in word)
                {
                    if (!temp.childrens.ContainsKey(c))
                    {
                        if (q.Count > 0)
                        {
                            q.Dequeue();
                        }
                        temp.childrens.Add(c, new Trie());
                        temp = temp.childrens[c];
                    }
                    else if (temp.childrens.ContainsKey(c) && temp.childrens[c].EOL)
                    {
                        q.Enqueue(word);
                    }
                    else
                    {
                        temp = temp.childrens[c];
                    }
                }
                temp.EOL= true;
            }
            return result;
        }
    }
}
