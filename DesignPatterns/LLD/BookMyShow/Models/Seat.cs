using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.BookMyShow.Models {
    internal class Seat {
        private string seatID;
        private int rowNum;
        private int seatNum;

        public Seat(string seatID, int rowNum, int seatNum) {
            this.seatID = seatID;
            this.rowNum = rowNum;
            this.seatNum = seatNum;
        }

        public string getSeatID() => seatID;    
    }
}
