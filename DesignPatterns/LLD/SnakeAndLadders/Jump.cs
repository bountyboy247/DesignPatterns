using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.SnakeAndLadders {
    public class Jump {
        public int start = 0;
        public int end = 0;

        public Jump(int start, int end) {
            this.start = start;
            this.end = end;
        }
    }
}
