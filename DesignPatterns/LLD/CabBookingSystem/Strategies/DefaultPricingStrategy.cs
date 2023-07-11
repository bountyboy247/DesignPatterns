using DesignPatterns.LLD.CabBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CabBookingSystem.Strategies {
    public class DefaultPricingStrategy : IPricingStrategy {
        public static double PER_KM_RATE = 10.0;
        public double findPrice(Location fromPoint, Location toPoint) {
            return fromPoint.Distance(toPoint) * PER_KM_RATE;
        }
    }
}
