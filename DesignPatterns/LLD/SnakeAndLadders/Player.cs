using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.SnakeAndLadders {
    public class Player {
        public string ID;
        public int CurrentPosition;
        public Player(string iD, int currentPosition) {
            ID = iD;
            CurrentPosition = currentPosition;
        }
    }
}
