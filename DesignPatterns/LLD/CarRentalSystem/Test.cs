using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CarRentalSystem {
    public class Test {
        //what is the flow
        //user goes to car rental portal
        //first things looks for car rental place using Location
        //Shows all the car rentals places
        //User selects one of the car rental place (Store)
        //Car rental place shows list of vehicles -car, trucks, motorcyles
        //User selects one of the desired vehicle
        //Vehicle contains information of type, mileage, totalmiles, price for day
        //User does reservation of the car
        //User makes payment
        //Bill is generated
        //Booking is confirmed
        public Test() {
            //Store
            Location location= new Location(1,85202,889, "Mesa", "AZ");
            
            

        }
        public IList<Vehicle> addVehicles() {
            IList<Vehicle> list = new List<Vehicle>();  
            Vehicle car1 = new Car(vehicleId: 1,
                                        manufacturer: "Toyota",
                                        vehicleType: VehicleType.compact,
                                        hourlyPrice: 20,
                                        dailyPrice: 100,
                                        isAvailable: true);
            Vehicle car2 = new Car(vehicleId: 1,
                            manufacturer: "Ford",
                            vehicleType: VehicleType.midsize,
                            hourlyPrice: 30,
                            dailyPrice: 110,
                            isAvailable: true);
            Vehicle car3 = new Car(vehicleId: 1,
                            manufacturer: "Kia",
                            vehicleType: VehicleType.fullsize,
                            hourlyPrice: 40,
                            dailyPrice: 120,
                            isAvailable: true);
            Vehicle car4 = new Car(vehicleId: 1,
                            manufacturer: "Honda",
                            vehicleType: VehicleType.premium,
                            hourlyPrice: 50,
                            dailyPrice: 130,
                            isAvailable: true);

            list.Add(car1);
            list.Add(car2);
            list.Add(car3);
            list.Add(car4);

            return list;
        }
        public IList<User> addUsers() {
            List<User> users = new List<User>();    
            User user = new User(userId: 1, "D1234", "Samy timalsina");
            users.Add(user);

            return users;
        }
        public void addStores() {
            Location location1 = new Location(1, 85202, 889, "Mesa", "AZ");
            Location location2 = new Location(2, 85204, 182, "Chandler", "AZ");
            Location location3 = new Location(3, 85222, 289, "Tempe", "AZ");

            //Store store = new Store(storeId: 1, storeLocation: location1,
             //   vehicleInventory: new VehicleInventoryManagement(), reservationList: new List<Reservation>());
        }
    }
}
