using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CompositePatterns.Problem3
{
    public class Combos : IMenuSystem
    {
        private string name;
        private string description;
        private double price;
        private List<IMenuSystem> _menus;

        public Combos(string name, string description, double price)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            _menus = new List<IMenuSystem>();
        }

        public void display()
        {
           foreach(IMenuSystem menu in _menus)
            {
                menu.display();
            }
        }

        public double totalPrice()
        {         
            double price = 0;
           foreach(IMenuSystem menu in _menus)
            {
              price +=  menu.totalPrice();
            }
           return price;
        }
        public void Add(IMenuSystem menu)
        {
          _menus.Add(menu);
        }
        public void Remove(IMenuSystem menu)
        {
           _menus.Remove(menu);
        }
    }
}
