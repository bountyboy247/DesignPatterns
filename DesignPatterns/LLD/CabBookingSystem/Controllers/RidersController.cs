using DesignPatterns.LLD.CabBookingSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CabBookingSystem.Controllers {
    public class RidersController {
        private RidersManager ridersMgr;

        public RidersController(RidersManager ridersMgr) {
            this.ridersMgr = ridersMgr;
        }
    }
}
