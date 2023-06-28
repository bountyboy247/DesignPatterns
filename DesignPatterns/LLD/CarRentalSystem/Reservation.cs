using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CarRentalSystem {
    public enum ReservationStatus {
        InComplete,
        Complete,
        Pending
    }
    public class Reservation {
        public int ReservationId;
        public ReservationStatus reservationStatus;
        public User user;
        public Location pickUpLocation;
        public Location dropOffLocation;
        public Vehicle vehicle;

    }
}
