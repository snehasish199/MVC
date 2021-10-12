using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverDesignPatternExample
{
    public class Observer : IObserver
    {
        public string UserName { get; set; }
        public Observer(string userName)
        {
            UserName = userName;
          
        }

        public void update(string availabiliy)
        {
            Console.WriteLine("Hello " + UserName + ", Product is now " + availabiliy + " on Amazon");
        }
    }
}
