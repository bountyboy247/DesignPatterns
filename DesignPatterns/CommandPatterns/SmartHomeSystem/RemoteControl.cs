using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CommandPatterns.SmartHomeSystem {
    public class RemoteControl {
        private Dictionary<Device, ICommand> commands;
        private Stack<ICommand> executedStacks;
        private Stack<ICommand> undoStacks;

        public RemoteControl() {
            this.commands = new Dictionary<Device, ICommand>();
            this.executedStacks= new Stack<ICommand>();
            this.undoStacks= new Stack<ICommand>(); 
        }
        public void addDevice(Device device) {
            if(!this.commands.ContainsKey(device)) {
                commands[device] = null;
            }
        }
        public void setCommand(Device device, ICommand command) {
            if(this.commands.ContainsKey(device)) {
                commands[device] = command;               
            }         
        }
        public void executeCommand(Device device) {
            if(commands.TryGetValue(device, out ICommand command)) {
                command.Execute();
                executedStacks.Push(command);
                //clear redo stacks
                undoStacks.Clear();
            }
        }
        public void undoCommand() {
            if(executedStacks.Count > 0) {
                ICommand command = executedStacks.Pop();
                command.undo();
                undoStacks.Push(command);
            }
        }
        public void redoCommand() {
            if(undoStacks.Count > 0) {
                ICommand command = undoStacks.Pop();
                command.Execute();
                executedStacks.Push(command);
            }
        }
    }
}
