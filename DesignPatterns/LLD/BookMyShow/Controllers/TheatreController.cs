using DesignPatterns.LLD.BookMyShow.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.BookMyShow.Controllers {
    internal class TheatreController {
        private TheatreService theatreService;

        public TheatreController(TheatreService theatreService) {
            this.theatreService = theatreService;
        }

        public string createTheatre(string theatreName) {
            return theatreService.createTheatre(theatreName).getTheatreID();
        }
        public string createScreenInTheatre(string screenName, string theatreId) {
            var theatre = theatreService.getTheatre(theatreId);
            return theatreService.createScreenInTheatre(screenName, theatre).getScreenID();
        }

        public string createSeatInScreen(int rowNum, int seatNum, string screenID) {
            var screen = theatreService.getScreen(screenID);

            return theatreService.createSeatInScreen(rowNum, seatNum, screen).getSeatID();
        }
    }
}
