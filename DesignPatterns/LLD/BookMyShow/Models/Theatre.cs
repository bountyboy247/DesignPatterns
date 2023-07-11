using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.BookMyShow.Models {
    internal class Theatre {
        private string theatreID;
        private string name;
        private List<Screen> screens;

        public Theatre(string theatreID, string name) {
            this.theatreID = theatreID;
            this.name = name;
            screens= new List<Screen>();
        }
        public string getTheatreID() => theatreID;
        public void addScreen(Screen screen) {
            screens.Add(screen);    
        }
    }
}
