using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.BookMyShow.Models {
    internal class Show {
        private string showID;
        private DateTime startTime;
        private int duration;
        private Screen screen;
        private Movie movie;

        public Show(string showID, Screen screen, Movie movie, DateTime startTime, int duration)
        {
            this.showID = showID;
            this.screen = screen;
            this.movie = movie;
            this.duration = duration;
            this.startTime = startTime;
        }

        public string getShowID() => showID;
        public Screen getScreen() => screen;    
    }
}
