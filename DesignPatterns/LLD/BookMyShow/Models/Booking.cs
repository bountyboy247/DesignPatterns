using DesignPatterns.LLD.BookMyShow.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.BookMyShow.Models {
    internal class Booking {
        private string bookingID;
        private string user;
        private Show show;
        private List<Seat> seatsbooked;
        private BookingStatus bookingStatus;

        public Booking(string bookingID, string user, Show show, List<Seat> seatsBooked) {
            this.bookingID = bookingID;
            this.user = user;
            this.show = show;
            this.seatsbooked= seatsBooked;
            this.bookingStatus = BookingStatus.CREATED;
        }

        public bool isConfirmed() => this.bookingStatus == BookingStatus.CONFIRMED;

        public void confirmBooking() {
            if(this.bookingStatus != BookingStatus.CREATED) {
                throw new InvalidStateException();
            }
            this.bookingStatus= BookingStatus.CONFIRMED;
        }
        public void expireBooking() {
            if(this.bookingStatus!= BookingStatus.CREATED) {
                throw new InvalidStateException();
            }
            this.bookingStatus = BookingStatus.EXPIRED;
        }
    }
}
