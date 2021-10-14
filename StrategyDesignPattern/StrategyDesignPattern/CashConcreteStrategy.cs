using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyDesignPattern
{
  public  class CashConcreteStrategy:IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Bill amount is " + amount + " and it is paid by Cash");

        }
    }
}
