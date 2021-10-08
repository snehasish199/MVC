using CompositeDesignPatternExample.Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompositeDesignPatternExample.Composites
{
    public class Composite : IComponent
    {
        public string Name { get; set; }
       

        List<IComponent> components = new List<IComponent>();
        public Composite(string name)
        {
            this.Name = name;
           
        }
        public void AddComponent(IComponent icomponent)
        {
            components.Add(icomponent);
        }
        public bool RemoveComponent(IComponent icomponent)
        {
            if (components.Contains(icomponent))
            {
                components.Remove(icomponent);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ShowPrice()
        {
            Console.WriteLine(Name + ": \n");
            foreach(var component in components)
            {
               component.ShowPrice();
            }
        }
    }
}
