using DesignPatterns.LLD.CabBookingSystem.Exceptions;
using DesignPatterns.LLD.CabBookingSystem.Models;
using DesignPatterns.LLD.CabBookingSystem.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CabBookingSystem.Database {
    public class TripsManager {
        private const double Max_Allowed_Trip_MatchingDistance = 50;
        private Dictionary<string, List<Trip>> trips = new Dictionary<string, List<Trip>>();

        private CabsManager cabsManager;
        private RidersManager ridersManager;
        private ICabMatchingStrategy cabMatchingStrategy;
        private IPricingStrategy pricingStrategy;

        public TripsManager( CabsManager cabsManager, RidersManager ridersManager, ICabMatchingStrategy cabMatchingStrategy, IPricingStrategy pricingStrategy) {
            this.cabsManager = cabsManager;
            this.ridersManager = ridersManager;
            this.cabMatchingStrategy = cabMatchingStrategy;
            this.pricingStrategy = pricingStrategy;
        }

        public void createTrip(Rider rider, Location fromPoint, Location toPoint) {
            List<Cab> closeByCabs = 
                this.cabsManager.getCabs(fromPoint, Max_Allowed_Trip_MatchingDistance);

            Cab selectedCabOpt = 
                this.cabMatchingStrategy.matchCabToRider(rider, closeByCabs, fromPoint, toPoint);

            if(!selectedCabOpt.getIsAvailable()) {
                throw new NoCabsAvailableException();
            }

            double price = pricingStrategy.findPrice(fromPoint, toPoint);
            Trip newTrip = new Trip(rider, selectedCabOpt, price, fromPoint, toPoint);
            if(!trips.ContainsKey(rider.getRiderId())){
                trips.Add(rider.getRiderId(), new List<Trip>());
            }
            trips[rider.getRiderId()].Add(newTrip);
            selectedCabOpt.setTrip(newTrip);
        }

        public List<Trip> tripHistory(Rider rider) {
            return trips[rider.getRiderId()];
        }
        public void endTrip(Cab cab) {
            if(cab.getTrip() == null) {
                throw new TripNotFoundException();
            }
            cab.getTrip().endTrip();
            cab.setTrip(null);
        }
    }
}
