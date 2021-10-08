using CompositeDesignPatternExample.Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompositeDesignPatternExample.Leafs
{
    public class Leaf : IComponent
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public Leaf(string name,int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public void ShowPrice()
        {
            Console.WriteLine(Name + " : " + Price);
        }
    }
}
