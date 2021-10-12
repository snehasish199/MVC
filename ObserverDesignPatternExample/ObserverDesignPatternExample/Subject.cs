using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverDesignPatternExample
{
  
        public class Subject : ISubject
        {
            private List<IObserver> observers = new List<IObserver>();
        //subject property
            private string ProductName { get; set; }
            private int ProductPrice { get; set; }
            private string Availability { get; set; }
        //constructor
            public Subject(string productName, int productPrice, string availability)
            {
                ProductName = productName;
                ProductPrice = productPrice;
                Availability = availability;
            }

            public string getAvailability()
            {
                return Availability;
            }

            public void setAvailability(string availability)
            {
                
                Console.WriteLine("Availability changed from {0} to {1} .",this.Availability,availability);
            this.Availability = availability;
           
            }

            public void RegisterObserver(IObserver observer)
            {
                Console.WriteLine("Observer Added : " + ((Observer)observer).UserName);
                observers.Add(observer);
            }

            public void AddObservers(IObserver observer)
            {
                observers.Add(observer);
            }

            public void RemoveObserver(IObserver observer)
            {
                observers.Remove(observer);
            }

            public void NotifyObservers()
            {
                Console.WriteLine("Product Name :"
                                + ProductName + ", product Price : "
                                + ProductPrice + " is Now "+this.Availability+" . So notifying all Registered users ");

                Console.WriteLine();
                foreach (IObserver observer in observers)
                {
                    observer.update(Availability);
                }
            }
        
    }
}
