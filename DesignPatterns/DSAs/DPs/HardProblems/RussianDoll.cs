using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.DPs.HardProblems {
    public class RussianDoll {
        public RussianDoll() {
            int[][] env = new int[][] {
//[[5,4],[6,4],[6,7],[2,3],[1,9]]
              new int[]{1,3},
              new int[]{3,5}, 
              new int[]{8,4},
              new int[]{9,5},
             // new int[]{1,9}
            };

            int[][] env1 = new int[][] {
//[[5,4],[6,4],[6,7],[2,3],[1,9]]
              new int[]{2,3},
              new int[]{4,6},
              new int[]{3,7},
              new int[]{4,8},

            };
            int ans = MaxEnvelopes(env1);
        }
        public int MaxEnvelopes(int[][] envelopes) {
            int[][] arr = envelopes.OrderBy(x => x[0]).ThenByDescending(x => x[1]).ToArray();
            int sum = 0;
            List<int> ls = new List<int>();
            for(int i = 0; i < arr.Length; i++) {
                int bx = arr[i][1];
                if(ls.Count == 0) {
                    ls.Add(bx);
                }
                else if(ls[ls.Count-1] < bx) {
                    ls.Add(bx);
                }
                else {
                    int start = 0;
                    int end = ls.Count - 1;
                    int ind = -1;
                    while(start <= end) {
                        int mid = (start + end) / 2;
                        if(ls[mid] > bx) {
                            ind = mid;
                            end = mid - 1;
                        }
                        else {
                            start = mid + 1;
                        }
                    }
                    ls[ind] = bx;
                }
            }
            return ls.Count;
        }
    }
}
