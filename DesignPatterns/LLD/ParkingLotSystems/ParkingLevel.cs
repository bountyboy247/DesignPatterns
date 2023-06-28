using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.ParkingLotSystems {
    public class ParkingLevel {
        public Dictionary<int,IList<ParkingSpot>> ParkingSpots;

        public void setParkingLevel(int level,ParkingSpot parkingSpot) {
          if(ParkingSpots.ContainsKey(level)) {
                ParkingSpots[level].Add(parkingSpot);
            }
            else {
                ParkingSpots.Add(level, new List<ParkingSpot>() { parkingSpot});
            }
        }
    }
}
