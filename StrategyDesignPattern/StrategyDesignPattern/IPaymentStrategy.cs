using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyDesignPattern
{
    public interface IPaymentStrategy
    {
        void Pay(double amount);
    }
}
