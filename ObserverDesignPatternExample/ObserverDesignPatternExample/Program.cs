using System;

namespace ObserverDesignPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject AppleIphone13 = new Subject("Red MI Mobile", 10000, "Out Of Stock");
            //User Anurag will be created and user1 object will be registered to the subject
            Observer user1 = new Observer("Anurag");
            //User Pranaya will be created and user1 object will be registered to the subject
            Observer user2 = new Observer("Pranaya");
            //User Priyanka will be created and user3 object will be registered to the subject
            Observer user3 = new Observer("Priyanka");

            //Register the observer for a particular subject to stay updated
            AppleIphone13.RegisterObserver(user1);
            AppleIphone13.RegisterObserver(user2);
            AppleIphone13.RegisterObserver(user3);


            

            Console.WriteLine("Apple iphone 13 Mobile current state : " + AppleIphone13.getAvailability());
            Console.WriteLine();
            // Now product is available
            AppleIphone13.setAvailability("Available");
            AppleIphone13.NotifyObservers();

            //De-register a user 
            AppleIphone13.RemoveObserver(user2);
            AppleIphone13.NotifyObservers();
            Console.Read();
        }
    }
}
