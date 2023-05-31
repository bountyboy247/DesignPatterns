using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StrategyPatterns.PaymentSystems
{
    public class PaypalPayment : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Paypal payment");
        }
    }
}
