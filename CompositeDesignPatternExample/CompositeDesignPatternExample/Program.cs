using CompositeDesignPatternExample.Component;
using CompositeDesignPatternExample.Composites;
using CompositeDesignPatternExample.Leafs;
using System;

namespace CompositeDesignPatternExample
{
  public  class Program
    {
     public  static void Main(string[] args)
        {
            IComponent hardDisk = new Leaf("HDD", 2222);
            IComponent ram = new Leaf("RAM", 3000);
            IComponent cpu = new Leaf("CPU", 2000);
            IComponent mouse = new Leaf("Mouse", 2000);
            IComponent keyboard = new Leaf("Keyboard", 2000);
            //Creating composite objects
            Composite motherBoard = new Composite("MotherBoard");
            Composite cabinet = new Composite("Cabinet");
            Composite peripherals = new Composite("Peripherals");
            Composite computer = new Composite("Computer");
           
            //Creating tree structure
            
            //Ading CPU and RAM in Mother board
            motherBoard.AddComponent(cpu);
            motherBoard.AddComponent(ram);
            
            //Ading mother board and hard disk in Cabinet
            cabinet.AddComponent(motherBoard);
            cabinet.AddComponent(hardDisk);
            
            //Ading mouse and keyborad in peripherals
            peripherals.AddComponent(mouse);
            peripherals.AddComponent(keyboard);
            
            //Ading cabinet and peripherals in computer
            computer.AddComponent(cabinet);
            computer.AddComponent(peripherals);

            //To display the Price of Computer
            computer.ShowPrice();
            Console.WriteLine();
            //To display the Price of Keyboard
            //keyboard.ShowPrice();
            //Console.WriteLine();
            ////To display the Price of Cabinet
            //cabinet.ShowPrice();
            //Console.Read();

        }
    }
}
