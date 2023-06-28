using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.SuffixArrays {
    public class LongestDupSubstrings {
        public LongestDupSubstrings() {
            //Input: s = "banana"
            //Output: "ana"
            // string s = "banana";
            // string s = "hellobabyhellofromanotherhello";
            string s = "skfjksadklfskldfsldakfslkdafhskladfhskladfhkasldfhklsadfhskladfhslakdh" +
                 "asklffhaskldfhaskfhasjkdfhsjkdafhaskdfjhaskldfh";
            //string ans = "fhsklafhsa";
            var ans = LongestDupSubstring(s);
        }
        public string LongestDupSubstring(string s) {
            string ans = "";
            //construct suffix tree
            //use hashset to count occurences of dup strings
            List<string> suffixStrings = new List<string>();
            for(int i=0;i<s.Length;i++) {
                suffixStrings.Add(s.Substring(i));
            }
            List<string> storage = new List<string>(suffixStrings);
            suffixStrings.Sort();
            int[] suffixArray = new int[suffixStrings.Count];
            for(int i = 0; i < suffixArray.Length; i++) {
                suffixArray[i] = s.Length - suffixStrings[i].Length;
            }
            //"adfhskladfh"
            string prevString = suffixStrings[0];
            for(int i = 1; i < suffixArray.Length; i++) {
                string currString = suffixStrings[i];
                int start = 0;
                int end = currString.Length-1;
                while(start <= end) {
                    int mid = (start+end)/2;
                    if(currString.Length > mid) {
                        string ps = currString.Substring(0,mid);

                    }
                    else {
                        end = mid - 1;
                    }
                }
                //string suff = suffixStrings[i];
                //if(prevString[0] == suff[0]) {
                //    if(suffixStrings[i].Length >= prevString.Length) {
                //        string presentstr = suffixStrings[i].Substring(0, prevString.Length);
                //        if(string.Equals(presentstr, prevString) && presentstr.Length > ans.Length) {
                //            ans = presentstr;
                //        }
                //    }
                //    else {
                //        string presentStr = prevString.Substring(0, suffixStrings[i].Length);
                //        if(string.Equals(presentStr, suffixStrings[i]) && presentStr.Length > ans.Length) {
                //            ans = presentStr;
                //        }
                //    }
                //}
                //prevString = suff;
            }

            return ans;
        }
    }
}

////suffix array
//string str = "Hello, how are you doing? Hello, nice to meet you!";
//string find = "Hello";
//List<string> list = new List<string>();
//for(int i=0;i< str.Length; i++) {
//    list.Add(str.Substring(i));
//}

////0,1,2,3,4
////2,3,4
////3,4

//list.Sort();
//int[] suffixArray = new int[list.Count];
//for(int i=0;i<suffixArray.Length; i++) {
//    suffixArray[i] = str.Length - list[i].Length;
//}
////
//int count = 0;
//foreach(int index in suffixArray) {
//    if(index + find.Length < str.Length && str.Substring(index,find.Length) == find) count++;
//}

//int x = 90;