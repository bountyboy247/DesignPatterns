using DesignPatterns.LLD.CabBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CabBookingSystem.Strategies {
    public interface IPricingStrategy {
        public double findPrice(Location fromPoint, Location toPoint);
    }
}
