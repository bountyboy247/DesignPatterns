using DesignPatterns.LLD.CabBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CabBookingSystem.Strategies {
    public interface ICabMatchingStrategy {
        Cab matchCabToRider(Rider rider, List<Cab> candidtateCabs, Location fromPoint, Location toPoint); 
    }
}
