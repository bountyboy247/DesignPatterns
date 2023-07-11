using DesignPatterns.LLD.CabBookingSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CabBookingSystem.Controllers {
    public class CabsController {
        private CabsManager cabMgr;
        private TripsManager tripsMgr;

        public CabsController(CabsManager cabMgr, TripsManager tripsMgr) {
            this.cabMgr = cabMgr;
            this.tripsMgr = tripsMgr;
        }
        //api to register driver/cab
        // /register/cab
        public void registerCab(string id, string name) {

        }
        public void updateLocation(string id, double newX, double newY) {

        }
        public void updateCabAvailability(string id, bool newAvailability) {

        }
        public void endTrip(string id) {

        }
    }
}
