using DesignPatterns.LLD.CabBookingSystem.Exceptions;
using DesignPatterns.LLD.CabBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CabBookingSystem.Database {
    public class RidersManager {
        private Dictionary<string, Rider> riders = new Dictionary<string, Rider>();

        public void createRider(Rider rider) {
            if(riders.ContainsKey(rider.getRiderId())) {
                throw new RiderAlreadyExistsException();
            }
            riders[rider.getRiderId()] = rider;
        }
        public Rider getRider(string riderId) {
            if(!riders.ContainsKey(riderId)) {
                throw new RiderNotFoundException();
            }

            return riders[riderId];
        }
    }
}
