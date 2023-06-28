using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CarRentalSystem {
    public class Store {
        public int StoreId;
        public Location storeLocation;
        public VehicleInventoryManagement vehicleInventory;
        public List<Reservation> reservationList;
        public Store(int storeId, Location storeLocation) {
            StoreId = storeId;
            this.storeLocation = storeLocation;
            this.reservationList = new List<Reservation>();
        }
        //add reservation
        public void  addReservation(Vehicle vehicle, User user) {
            Reservation reservation = new Reservation(); 
        }
        //remove reservation
        public void removeReservation(Reservation reservation) { 
            reservationList.Remove(reservation);
        }
        //update reservation
    }
}
