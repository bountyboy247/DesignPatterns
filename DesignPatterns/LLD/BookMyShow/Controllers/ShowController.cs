using DesignPatterns.LLD.BookMyShow.Models;
using DesignPatterns.LLD.BookMyShow.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.BookMyShow.Controllers {
    internal class ShowController {
        private SeatAvailabilityService seatAvailabilityService;
        private MovieService movieService;
        private TheatreService theatreService;
        private ShowService showService;

        public string createShow(string movieID, string screenID, DateTime startTime, int durationInSeconds) {
            var screen = theatreService.getScreen(screenID);
            var movie = movieService.getMovie(movieID);

            return showService.createShow(movie, screen,startTime, durationInSeconds).getShowID();
        }
        public List<string> getAvailableSeats(string showID) {
            Show show = showService.getShow(showID);
            //List<Seat>  availableSeats = s

        }
    }
}
