using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.DPs {
    public class LongestCommonSubstring {
        int max = 0;
        public LongestCommonSubstring() {
            string s1 = "abcGeeksforGeeks";
            string s2 = "GeeksQuiz";

            int expectedOutput = 5;
            int actualOutput = LCS(s1, s2);
            bool IsGood = expectedOutput == actualOutput;
            Console.WriteLine("Test is " + IsGood);
        }
        private int LCS(string s1, string s2) {
            string s = "";
            string[,] dp = new string[s1.Length + 1, s2.Length + 1];
            for(int i = 0; i <= s1.Length; i++) {
                for(int j = 0; j <= s2.Length; j++) {
                    if(i == 0 || j == 0) dp[i, j] = string.Empty;
                    else if(s1[i - 1] == s2[j - 1]) {
                        dp[i, j] = dp[i - 1, j - 1] + s1[i - 1];
                        if(s.Length < dp[i, j].Length) {
                            s = dp[i, j];
                        }
                    }
                }
            }
            return 0;
          //  return ans;
        }
    }
}
