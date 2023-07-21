using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.Sortings {
    public class NonOverlappingIntervals {
        public NonOverlappingIntervals() {
            int[][] arr = new int[][] {
                new int[]{1,2},
                new int[] {2,3},
                new int[] {1,3},
                new int[] {3,4},
                new int[]{1,9}
            };

            int ans = EraseOverlapIntervals(arr);
        }
        public int EraseOverlapIntervals(int[][] intervals) {
            intervals = intervals.OrderBy(x => x[1]).ThenBy(x => x[0]).ToArray();
            int currX = intervals[0][0];
            int currY = intervals[0][1];
            int count = 0;
            for(int i = 1; i < intervals.Length; i++) {
                int x = intervals[i][0];
                int y = intervals[i][1];
                int ly = y - 1;
                if((x >= currX && x < currY)||(ly >= currX && ly < currY)) {
                    count++;
                    continue;
                }
                currY = y;
            }
            return count;
        }
    }
}
