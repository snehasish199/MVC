using System;

namespace SignletoneDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton SingletonObj = Singleton.GetInstance();
            SingletonObj.PrintDetails("Hello from 1st invocation");

            Singleton Obj = Singleton.GetInstance();
            Obj.PrintDetails("Hello from 2nd invocation");


            Console.ReadKey();
        }
    }
}
