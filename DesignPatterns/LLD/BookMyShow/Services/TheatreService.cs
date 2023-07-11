using DesignPatterns.LLD.BookMyShow.Exceptions;
using DesignPatterns.LLD.BookMyShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.BookMyShow.Services {
    internal class TheatreService {
        private Dictionary<string, Theatre> theatres;
        private Dictionary<string, Screen> screens;
        private Dictionary<string, Seat> seats;

        public TheatreService() {
            theatres= new Dictionary<string, Theatre>();
            screens= new Dictionary<string, Screen>();
            seats= new Dictionary<string, Seat>();
        }

        public Theatre createTheatre(string theatreName) {
            String theatreID = Guid.NewGuid().ToString();
            Theatre theatre = new Theatre(theatreID, theatreName);

            theatres.Add(theatreID, theatre);
            return theatre;
        }
        public Theatre getTheatre(string theatreID) {
            if(!theatres.ContainsKey(theatreID)) {
                throw new NotFoundException();
            }

            return theatres[theatreID];
        }
        public Screen getScreen(string screenID) {
            if(!screens.ContainsKey(screenID)) {
                throw new NotFoundException();
            }

            return screens[screenID];
        }
        public Seat getSeat(string seatID) {
            if(!seats.ContainsKey(seatID)) {
                throw new NotFoundException();
            }

            return seats[seatID];
        }
        public Screen createScreenInTheatre(string screenName, Theatre theatre) {
            Screen screen = createScreen(screenName, theatre);
            theatre.addScreen(screen);

            return screen;
        }
        private Screen createScreen(string screenName, Theatre theatre) {
            String screenID = Guid.NewGuid().ToString();
            Screen screen = new Screen(screenID, screenName, theatre);
            screens.Add(screenID, screen);

            return screen;
        }
        public Seat createSeatInScreen(int rowNo, int seatNo, Screen screen) {
            string seatID = Guid.NewGuid().ToString();
            Seat seat = new Seat(seatID, rowNo, seatNo);
            seats.Add(seatID, seat);
            screen.addSeat(seat);

            return seat;

        }
    }
}
