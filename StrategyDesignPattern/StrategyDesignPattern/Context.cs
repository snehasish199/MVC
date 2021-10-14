using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyDesignPattern
{
    public class Context
    {
        private IPaymentStrategy _paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;


        }

        public void Pay(double amount)
        {
            _paymentStrategy.Pay(amount);
        }
    }

}
