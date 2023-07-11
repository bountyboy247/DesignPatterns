using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.BookMyShow.Models {
    internal class Screen {
        private string screenID;
        private string name;
        private Theatre theatre;

        private List<Seat> seats;

        public Screen(string screenID, string name, Theatre theatre) {
            this.screenID = screenID;
            this.name = name;
            this.theatre = theatre;
        }
        public string getScreenID() => screenID;
        public void addSeat(Seat seat) {
            this.seats.Add(seat);
        }
    }
}
