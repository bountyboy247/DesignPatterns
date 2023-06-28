using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CarRentalSystem {
    public class Location {
        public int LocationID;
        public int ZipCode;
        public int StreetNumber;
        public string City;
        public string State;
        public Location(int locationID, int zipCode, int streetNumber, string city, string state) {
            LocationID = locationID;
            ZipCode = zipCode;
            StreetNumber = streetNumber;
            City = city;
            State = state;
        }
    }
}
