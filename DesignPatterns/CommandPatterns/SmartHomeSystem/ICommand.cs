using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CommandPatterns.SmartHomeSystem {
    public interface ICommand {
        void Execute();
        void undo();
    }
}
