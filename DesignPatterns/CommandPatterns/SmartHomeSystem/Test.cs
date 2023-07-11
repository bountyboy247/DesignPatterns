using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CommandPatterns.SmartHomeSystem {
    public class Test {
        public Test() {
            RemoteControl remote = new RemoteControl();
            Light l1 = new Light();
            remote.addDevice(l1);
            remote.setCommand(l1, new TurnOnCommand(l1));
            remote.executeCommand(l1);
            remote.undoCommand();
            remote.redoCommand();
        }
    }
}
