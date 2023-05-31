using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StrategyPatterns.PaymentSystems
{
    public class CreditCardPayment : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Credit card payment");
        }
    }
}
