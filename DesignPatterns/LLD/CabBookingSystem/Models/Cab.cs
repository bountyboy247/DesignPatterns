using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CabBookingSystem.Models {
    public class Cab {
        public string cabId { get; private set; }
        public string driverName { get; private set; }

        private Trip currentTrip;
        private Location currentlocation;
        private bool IsAvailbale;

        public Cab(string cabId, string driverName) {
            this.cabId = cabId;
            this.driverName = driverName;
            this.IsAvailbale = true;
        }
        public bool getIsAvailable() => this.IsAvailbale;
        public Location getLocation() => this.currentlocation;
        public Trip getTrip() => this.currentTrip;
        public void setIsAvailable(bool avail) {
            this.IsAvailbale= avail;    
        }
        public void setTrip(Trip trip) {
            this.currentTrip = trip;
        }
        public void setCurrentLocation(Location newLocation) {
            this.currentlocation = newLocation;
        }
        public override string ToString() {
            return "Cab id = "+cabId +" driver name is "+driverName;
        }
    }
}
