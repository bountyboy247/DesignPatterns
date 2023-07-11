using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CabBookingSystem.Models {
    public class Location {

        public double x { get; private set; }
        public double y { get;private set; }

        public Location(double x, double y) {
            this.x = x;
            this.y = y;
        }
        public double Distance(Location loc) {

            return Math.Sqrt(Math.Pow(x - loc.x, 2) +  Math.Pow(y - loc.y, 2)); 
        }
    }
}
