using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CarRentalSystem {
    public class Car : Vehicle {
        public Car(int vehicleId, string manufacturer, VehicleType vehicleType, int hourlyPrice, int dailyPrice, bool isAvailable) : base(vehicleId, manufacturer, vehicleType, hourlyPrice, dailyPrice, isAvailable) {
        }
    }
}
