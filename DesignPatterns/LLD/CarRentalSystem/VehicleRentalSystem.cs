using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CarRentalSystem {
    public class VehicleRentalSystem {
        public List<Store> Stores;
        public List<User> Users;
        public VehicleRentalSystem(List<Store> stores, List<User> users) {
            Stores = stores;
            Users = users;
        }
        public Store getStore(Location loc) {
            return Stores.Where(x => x.storeLocation == loc).First();
        }
    }
}
