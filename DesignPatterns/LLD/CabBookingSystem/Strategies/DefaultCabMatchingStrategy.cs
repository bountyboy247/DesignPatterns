using DesignPatterns.LLD.CabBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CabBookingSystem.Strategies {
    public class DefaultCabMatchingStrategy : ICabMatchingStrategy {
        public Cab matchCabToRider(Rider rider, List<Cab> candidtateCabs, Location fromPoint, Location toPoint) {

            Cab cab = candidtateCabs.FirstOrDefault(x => x.getTrip() == null);
            return cab;
        }
    }
}
