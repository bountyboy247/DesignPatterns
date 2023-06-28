using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CarRentalSystem {
    public enum VehicleType {
        compact, midsize, fullsize, premium
    }
    public class Vehicle {

        public int VehicleId;
        public string Manufacturer;
        public VehicleType vehicleType;
        public int hourlyPrice;
        public int dailyPrice;
        public bool IsAvailable;
        public Vehicle(int vehicleId, string manufacturer, VehicleType vehicleType, int hourlyPrice, int dailyPrice, bool isAvailable) {
            VehicleId = vehicleId;
            Manufacturer = manufacturer;
            this.vehicleType = vehicleType;
            this.hourlyPrice = hourlyPrice;
            this.dailyPrice = dailyPrice;
            IsAvailable = isAvailable;
        }
    }
}
