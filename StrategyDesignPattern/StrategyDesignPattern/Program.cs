using System;

namespace StrategyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            //pay by credit card
            context.SetPaymentStrategy(new CreditCardPayConcreteStrategy());
            context.Pay(1000);
            Console.WriteLine("\n");

            // Pay by cash
            context.SetPaymentStrategy(new CashConcreteStrategy());
            context.Pay(500);
            Console.WriteLine("\n");

            //pay by debit card
            context.SetPaymentStrategy(new DebitCardConcreteStrategy());
            context.Pay(2000);
        }
    }
}
