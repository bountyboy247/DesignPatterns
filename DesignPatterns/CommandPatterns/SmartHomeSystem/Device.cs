using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CommandPatterns.SmartHomeSystem {
    public abstract class Device {
        public abstract void turnOn();
        public abstract void turnOff();
    }
}
