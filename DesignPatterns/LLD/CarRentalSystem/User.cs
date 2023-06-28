using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CarRentalSystem {
    public class User {
        public int UserId;
        public string DriverLicenseNo;
        public string DriverName;

        public User(int userId, string driverLicenseNo, string driverName) {
            UserId = userId;
            DriverLicenseNo = driverLicenseNo;
            DriverName = driverName;
        }
    }
}
