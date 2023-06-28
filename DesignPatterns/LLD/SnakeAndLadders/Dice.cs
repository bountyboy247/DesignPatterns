using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.SnakeAndLadders {
    public class Dice {
        private int diceCount;
        private int min = 1;
        private int max = 6;
        public Dice(int diceCount) {
            this.diceCount = diceCount;
        }
        public int rollDice() {
            Random random= new Random();

            int totalSum = 0;
            int count = diceCount;
            while(count > 0) {
                totalSum += random.Next(min,max);
                count--;
            }

            return totalSum;
        }
    }
}
