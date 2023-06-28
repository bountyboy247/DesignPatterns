using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CarRentalSystem {
    public class VehicleInventoryManagement {
        public List<Vehicle> vehicles;
        public VehicleInventoryManagement() {
            vehicles = new List<Vehicle>(); 
        }
        //do crud operation
        public void add(Vehicle vehicle) {
            vehicles.Add(vehicle);
        }
        public void remove(Vehicle vehicle) {
            vehicles.Remove(vehicle);   
        }
        public Vehicle getVehicle(int id) {
            return vehicles[id];
        }
        public List<Vehicle> getAllVehicles() {
            return vehicles;
        }
        public List<Vehicle> getAvailableVehicles(VehicleType vt) { 
            return vehicles.Where(x => x.IsAvailable).Where(y => y.vehicleType == vt).ToList();
        }
    }
}
