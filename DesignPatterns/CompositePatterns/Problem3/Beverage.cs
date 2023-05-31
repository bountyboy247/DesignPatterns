using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CompositePatterns.Problem3
{
    public class Beverage : IMenuSystem
    {
        private string name;
        private string description;
        private double price;
        public Beverage(string name, string description, double price)
        {
            this.name = name;
            this.description = description;
            this.price = price;
        }

        public void display()
        {
            Console.WriteLine($"Beverage name: {name}, Description: {description}, Price: {price}");
        }

        public double totalPrice()
        {
            return price;
        }
    }
}
