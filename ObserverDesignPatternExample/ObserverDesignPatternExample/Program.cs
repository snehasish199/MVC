using System;

namespace ObserverDesignPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject AppleIphone13 = new Subject("Red MI Mobile", 10000, "Out Of Stock");
            //User Anurag will be created and user1 object will be registered to the subject
            Observer user1 = new Observer("Anurag", AppleIphone13);
            //User Pranaya will be created and user1 object will be registered to the subject
            Observer user2 = new Observer("Pranaya", AppleIphone13);
            //User Priyanka will be created and user3 object will be registered to the subject
            Observer user3 = new Observer("Priyanka", AppleIphone13);


            

            Console.WriteLine("Apple iphone 13 Mobile current state : " + AppleIphone13.getAvailability());
            Console.WriteLine();
            // Now product is available
            AppleIphone13.setAvailability("Available");
            Console.Read();
        }
    }
}
