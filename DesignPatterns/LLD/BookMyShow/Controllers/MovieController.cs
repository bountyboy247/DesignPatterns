using DesignPatterns.LLD.BookMyShow.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.BookMyShow.Controllers {
    internal class MovieController {

        private MovieService movieService;
        public MovieController(MovieService movieService)
        {
            this.movieService = movieService;
        }

        public string createMovie(string movieName) {
            return this.movieService.createMovie(movieName).getMovieID();
        }
    }
}
