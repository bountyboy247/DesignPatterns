using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesignPatterns.DSAs.BackTrackings {
    public class CombinationSumIII {
        public CombinationSumIII() {
            //        Input: k = 3, n = 9
            //Output: [[1,2,6],[1,3,5],[2,3,4]]
            //Explanation:
            //            1 + 2 + 6 = 9
            //1 + 3 + 5 = 9
            //2 + 3 + 4 = 9
            //There are no other valid combinations.
            int k = 3;
            int n = 9;
            var ans = CombinationSum3(k, n);
        }
        public IList<IList<int>> CombinationSum3(int k, int n) {
            var ans = new List<IList<int>>();   
            f(k, n, 1,new List<int>(), ans) ;
            return ans ;
        }
        private void f(int k, int n, int index,IList<int> ls,  IList<IList<int>> ans) {
            if(n == 0 && k == 0) {

                ans.Add(new List<int>(ls));
                return;
            }
            else if(n < 0 || k < 0) return;
            for(int i = index; i <= 9; i++) {
                ls.Add(i);
                f(k-1, n - i, i + 1,ls,ans);
                ls.Remove(i);
            }
        }
    }
}
