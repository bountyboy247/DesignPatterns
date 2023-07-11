﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.BookMyShow.Models {
    internal class Movie {
        private string movieID;
        private string movieName;

        public Movie(string movieID, string movieName) {
            this.movieID = movieID;
            this.movieName = movieName;
        }
        public string getMovieID() => movieID;
    }
}
