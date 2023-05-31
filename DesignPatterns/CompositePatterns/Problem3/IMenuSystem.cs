using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
namespace DesignPatterns.CompositePatterns.Problem3
{
    public interface IMenuSystem
    {
    //    Problem: You are developing a menu system for a restaurant.
    //    The menu can contain different types of items, such as dishes, beverages, and combos.
    //    Each item has a name, description, and price. Some items, like combos, can contain other
    //    items as sub-items.You need to implement the menu system using the Composite design pattern
    //    and provide a way to calculate the total price of a menu, including its sub-items.
    //Please present your solution in C# code.
        double totalPrice();
        void display();
    }
}
