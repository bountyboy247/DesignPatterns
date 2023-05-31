using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignPatterns.CompositePatterns.Problem3
{
    public class Dish : IMenuSystem
    {
        private string name;
        private string description;
        private double price;
        public Dish(string name, string description, double price)
        {
            this.name = name;
            this.description = description;
            this.price = price;
        }

        public void display()
        {
            Console.WriteLine($"Dish name: {name}, Description: {description}, Price: {price}");
        }

        public double totalPrice()
        {
            return price;
        }
    }
}
