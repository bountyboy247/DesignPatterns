using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CommandPatterns.SmartHomeSystem {
    public class TurnOnCommand : ICommand {
        private Device device;
        public TurnOnCommand(Device device) {
            this.device = device;
        }

        public void Execute() {
            this.device.turnOn();
        }

        public void undo() {
           this.device.turnOff();
        }
    }
}
