using DesignPatterns.LLD.CabBookingSystem.Exceptions;
using DesignPatterns.LLD.CabBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CabBookingSystem.Database {
    public class CabsManager {
        Dictionary<string , Cab> cabs = new Dictionary<string, Cab>();
        public void createCab(Cab cab) {
            if(cabs.ContainsKey(cab.cabId)) {
                throw new CabAlreadyExistException();
            }

            cabs.Add(cab.cabId, cab);
        }
        public Cab getCab(string cabId) {
            if(!cabs.ContainsKey(cabId)) {
                throw new CabNotFoundException();
            }

            return cabs[cabId];
        }
        public void updateCabLocation(string id, Location newLocation) {
            if(!cabs.ContainsKey(id)) {
                throw new CabNotFoundException();
            }
            cabs[id].setCurrentLocation(newLocation);
        }
        public void updateCabAvailability(string id, bool newAvail) {
            if(!cabs.ContainsKey(id)) {
                throw new CabNotFoundException();
            }
            cabs[id].setIsAvailable(newAvail);
        }
        public List<Cab> getCabs(Location fromPoint, double distance) {
            var results = new List<Cab>();  

            foreach(var cab in cabs.Values) {
                if(cab.getIsAvailable() && cab.getLocation().Distance(fromPoint) <= distance) {
                    results.Add(cab);
                }
            }

            return results;
        }
        public void endTrip() {

        }
    }
}
