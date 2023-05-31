using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StrategyPatterns.PaymentSystems
{
    public class BankTransferPayment : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Bank payment");
        }
    }
}
