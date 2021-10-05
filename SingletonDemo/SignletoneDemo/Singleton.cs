using System;
using System.Collections.Generic;
using System.Text;

namespace SignletoneDemo
{
   public sealed class Singleton
    {
        private static int count = 0;
        private Singleton()
        {
            //to check how many times constructor is called.
            count++;
            Console.WriteLine(count+" time constructor call is ");

        }
        //lazy initialization
        // type 1: using lazy keyword
        private static readonly Lazy<Singleton> instance =
            new Lazy<Singleton>(()=>new  Singleton());
        public static Singleton GetInstance()
        {
            return instance.Value;
        }

        //type 2: using Lock 

        //private static readonly Singleton instance=null;
        //private static readonly object Obj = new object();
        //public static Singleton GetInstance()
        //{
        //    if (instance == null)
        //    {
        //        lock (obj)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new Singleton();
        //            }

        //        }

        //    }
        //    return instance;    
        //}



        //Eager Initialization

        //private static Singleton instance = new Singleton();
        //public static Singleton GetInstance()
        //{
        //    return instance;
        //}


          public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
