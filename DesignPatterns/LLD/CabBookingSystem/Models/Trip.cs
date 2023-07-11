using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CabBookingSystem.Models {
    public class Trip {
        private Rider rider;
        private Cab cab;
        private TripStatus status;
        private double price;
        private Location startLocation;
        private Location endLocation;

        public Trip(Rider rider, Cab cab, double price, Location startLocation, Location endLocation) {
            this.rider = rider;
            this.cab = cab;
            this.status = TripStatus.IN_PROGRESS;
            this.price = price;
            this.startLocation = startLocation;
            this.endLocation = endLocation;
        }
        public void endTrip() {
            this.status = TripStatus.FINISHED;
        }
    }
}
