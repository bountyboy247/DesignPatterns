using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CommandPatterns.SmartHomeSystem {
    public class Light : Device {
        public override void turnOff() {
            Console.WriteLine("turning off lights");
        }

        public override void turnOn() {
            Console.WriteLine("turning on lights");
        }
    }
}
