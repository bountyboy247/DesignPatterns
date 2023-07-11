using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.CabBookingSystem.Models {
    public class Rider {
        private string riderId;
        private string name;

        public Rider(string riderId, string name) {
            this.riderId = riderId;
            this.name = name;
        }
        public string getRiderId() => riderId;
        public string getName() => name;
        public void setId(string id) {
            this.riderId = id;  
        }
        public void setName(string name) {
            this.name = name;
        }
    }
}
