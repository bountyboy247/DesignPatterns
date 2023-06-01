using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DesignPatterns.CommandPatterns
{
   public class HomeAutomationSystem
    {

    //        Sure! Here's a problem related to the Command design pattern:

    //Problem: Design a simple remote control application for a home automation system.
    //The application should allow users to control different devices in their home, such as lights,
    //fans, and doors. The system should support multiple devices and provide an undo/redo
    //functionality
    //for the user's commands.

    //Requirements:

    //The application should have a set of buttons or controls representing different devices.
    //Each device should have specific actions that can be performed, such as turning on/off lights,
    //adjusting fan speed, and opening/closing doors.
    //Users should be able to execute commands to perform specific actions on devices, and
    //these commands
    //should be stored in a command history.
    //The system should provide undo and redo functionality, allowing users to revert or
    //repeat their
    //commands.
    //Design a solution using the Command design pattern to address the above problem.Describe the
    //classes, interfaces, and relationships involved in your design, and explain how the Command pattern
    //helps achieve the desired undo/redo functionality and decouples the invoker from the receiver.
    }
    public interface ICommand
    {
        public void Action();
    }
    public class Light : ICommand
    {
        private bool _isLight = false;
        public void Action()
        {
            if(_isLight )
            {
                _isLight = true;
            }
            else
            {
                _isLight = false;
            }
        }

    }
    public class Remote : ICommand
    {
        private ICommand command;
        private Stack<ICommand> stack;
        
        public Remote(ICommand command)
        {
            this.command = command; 
            this.stack = new Stack<ICommand>();
        }

        public void Action()
        {
            this.command.Action();
            this.stack.Push(this.command);
        }

        public void Redo()
        {
           
        }

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void Undo()
        {
           
        }
    }
}
