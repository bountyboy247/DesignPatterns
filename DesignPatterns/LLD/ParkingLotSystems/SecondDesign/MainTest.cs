using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.ParkingLotSystems.SecondDesign {
    //This is simple parking lot design
    public class MainTest {
        //We want to design a parking lot where certain vehicles can be parked in
        //the open area
        //Parking lot can have multiple slots and each slot can have vehicle in it
        //Parking Lot
        //list of parking spots - 
        // count of compact, large, bike slots
        //parkvehcile

        //Parking Spot
            //compact, large, Bikes


        //Vehicle
            //truck, 
            //car
            //bike
        

        //there is one to one mapping between vehicle and parkingspot
    }
    public enum VehicleType {
        truck, car, bike
    }
    public class Vehicle {
        private string VehicleNumber;
        private VehicleType vehicleType;
        private ParkingSpot parkingSpot;

        public Vehicle(VehicleType vt) {
            this.vehicleType = vt;
        }
        public void SetVehicleNo(string vn) {
            this.VehicleNumber= vn;
        }
        public void SetVehicleType(VehicleType vt) {
            this.vehicleType = vt;
        }
        public void SetParkingSpot(ParkingSpot ps) {
            this.parkingSpot = ps;
        }
        public VehicleType GetVehicleType() => this.vehicleType;
        public  virtual ParkingSpot GetParkingSpot() => this.parkingSpot;
        public string GetVehicleNumber() => VehicleNumber;
    }
    public enum SpotType {
        compact, large, Bikes
    }
    public class ParkingSpot {
        private SpotType ParkingSpotType;
        private Vehicle vehicle;
        private bool IsAvailable = true;
        public ParkingSpot(SpotType st) {
            this.ParkingSpotType = st;
        }
        //getter and setters
        public void SetVehicle(Vehicle vehicle) {
            this.vehicle = vehicle;
        }
        public Vehicle GetVehicle() {
            return this.vehicle;
        }
        public void SetIsAvailable(bool isAvailable) {
            this.IsAvailable = isAvailable;
        }
        public bool GetIsAvailable() => this.IsAvailable;
        public void SetParkingSpotType(SpotType parkingSpotType) {
            this.ParkingSpotType = parkingSpotType;
        }
        public SpotType GetParkingSpotType() => this.ParkingSpotType;
    }
    public class CompactParkingSpot : ParkingSpot {
        public CompactParkingSpot(SpotType st) : base(st) {
        }
    }
    public class LargeParkingSpot : ParkingSpot {
        public LargeParkingSpot(SpotType st) : base(st) {
        }
        
    }
    public class BikeParkingSpot : ParkingSpot {
        public BikeParkingSpot(SpotType st) : base(st) {
        }
    }
    public class ParkingLot {
        public List<CompactParkingSpot> CompactParkingSpots;
        public List<LargeParkingSpot> LargeParkingSpots;
        public List<BikeParkingSpot> BikeParkingSpots;
        private int freeCompactSpots;
        private int freeBikeSpots;
        private int freeTruckSpots;
        public ParkingLot(int compactSpots, int bikeSpots, int truckSpots) {
            this.freeBikeSpots = bikeSpots;
            this.LargeParkingSpots = new List<LargeParkingSpot>();
            this.CompactParkingSpots = new List<CompactParkingSpot>();
            this.BikeParkingSpots = new List<BikeParkingSpot>();
            this.freeCompactSpots = compactSpots;
            this.freeTruckSpots = truckSpots;   
        }

        public void parkVehicle(Vehicle vehicle) {
            if(vehicle.GetVehicleType().Equals(VehicleType.bike)) {
                if(BikeParkingSpots.Count < freeBikeSpots) {
                    parkYourBike(vehicle);
                }
                else {
                    Console.WriteLine("Bike cannot be parked, it's full!")
;                }
            }
            else if(vehicle.GetVehicleType().Equals(VehicleType.car)) {
                if(CompactParkingSpots.Count < freeCompactSpots) {

                }
            }
            else if(vehicle.GetVehicleType().Equals(VehicleType.truck)) {
                if(LargeParkingSpots.Count < freeTruckSpots) {

                }
            }
        }

        private void parkYourBike(Vehicle vehicle) {
            BikeParkingSpot bikeSpot = new BikeParkingSpot(SpotType.Bikes);
            bikeSpot.SetIsAvailable(false);
            bikeSpot.SetVehicle(vehicle);
            vehicle.SetParkingSpot(bikeSpot);

            BikeParkingSpots.Add(bikeSpot);
        }

        public void removeVehicle(Vehicle vehicle) {
            if(vehicle.GetVehicleType().Equals(VehicleType.bike)) {
                removeBike(vehicle);
            }
            else if(vehicle.GetVehicleType().Equals(VehicleType.car)) {

            }
            else if(vehicle.GetVehicleType().Equals(VehicleType.truck)) {

            }
        }

        private void removeBike(Vehicle vehicle) {
            BikeParkingSpot bikeParkingSpot = (BikeParkingSpot)vehicle.GetParkingSpot();
            bikeParkingSpot.SetVehicle(null);
            bikeParkingSpot.SetIsAvailable(true);
            vehicle.SetParkingSpot(null);
            BikeParkingSpots.Remove(bikeParkingSpot);
        }
    }

}
