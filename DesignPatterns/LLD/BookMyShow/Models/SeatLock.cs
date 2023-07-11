using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.BookMyShow.Models {
    internal class SeatLock {
        private Seat seat;
        private Show show;
        private int timeOutInSeconds;
        private DateTime lockTime;
        private string lockedBy;

        public bool isLockExpired() {

            DateTime lockInstant = lockTime.AddSeconds(timeOutInSeconds);
            DateTime currentInstant = DateTime.Now;

            return lockInstant < currentInstant;
        }
    }
}
