using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.ParkingLotSystems {
    public class Ticket {
        public int TicketId;
        public ParkingSpot parkingSpot;
        public DateTime ticketGenerateDateTime;

        public ParkingSpot receiveTicket() {

            return null;
        }
        public void submitTicket() {
            parkingSpot = null;
            
        }
    }
}
