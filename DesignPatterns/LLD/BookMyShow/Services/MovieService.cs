using DesignPatterns.LLD.BookMyShow.Exceptions;
using DesignPatterns.LLD.BookMyShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.BookMyShow.Services {
    internal class MovieService {
        private Dictionary<string, Movie> movies;

        public MovieService()
        {
            movies = new Dictionary<string, Movie>();
        }
        public Movie getMovie(string movieID) {
            if(!movies.ContainsKey(movieID)) {
                throw new NotFoundException();
            }

            return movies[movieID];
        }
        public Movie createMovie(string movieName) {
            string movieID = Guid.NewGuid().ToString();
            Movie movie = new Movie(movieID, movieName);
            movies.Add(movieID, movie);

            return movie;
        }
    }
}
