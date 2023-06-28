using DesignPatterns.LLD.ParkingLotSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.ParkingLotSystem {
    public class Test {
        //Sure! Here's a problem for you to tackle:

        //Design a parking lot system.The parking lot has multiple levels,
        //    each containing multiple parking spots.There are different types 
        //        of parking spots, such as regular, compact, and handicapped spots.Vehicles
        //        of different sizes (small, medium, large) need to be accommodated in the
        //        parking lot.The system should support functionalities 
        //        like finding an available spot, assigning a spot to a vehicle, and calculating
        //        the parking fee based on the duration of stay.

        //Please provide your solution in C# by designing the necessary classes and interfaces.
        //
        //Vehicle comes to an entrance of a parking Lot
        //Press button to get ticket
        //Ticket contains information of Parking Level, Parking spot number, Arrival time etc.
        //Parking level 1 may contain compact vehicles, 
        //Level 2 may contain mid size vehicles
        //Vehicle parks 
        //Vehicle drives to exit gate
        //Vehicle submits ticket to the machine slot
        //Payment is made
        //Bill is generated
        //Parking is completed.

        //The objects are
        //Vehicle, Ticket, ParkingLevel, ParkingSpot, Payment, Bill

        //Assumption : Building is 2 floor, 
        //1st floor has 10 regular parking spots, 2 handicapped, and 2 reserved
        //2nd floor has 12 regular spots, 3 handicapped and 1 reserved
        public Test() {

        }
        public IList<ParkingLevel> addParkingLevels() {
            IList<ParkingLevel> parkingLevels= new List<ParkingLevel>();

            return parkingLevels;
        }
        public IList<ParkingSpot> addParkingSpots() {
            IList<ParkingSpot> parkingSpots= new List<ParkingSpot>();

            return parkingSpots;
        }
    }
}
