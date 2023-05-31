using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StrategyPatterns.PaymentSystems
{
    public class PaymentStrategy : IPayment
    {
        private IPayment payment;
        public PaymentStrategy(IPayment payment)
        {
            this.payment = payment;
        }

        public void ProcessPayment()
        {
           this.payment.ProcessPayment();
        }
    }
}
