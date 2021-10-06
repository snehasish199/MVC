using DecoratorDesignPatternExample.Component;
using DecoratorDesignPatternExample.ConcreteComponent;
using DecoratorDesignPatternExample.ConcreteDecorator;
using System;

namespace DecoratorDesignPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ICar bmwCar1 = new BMWCar();
            bmwCar1.ManufactureCar();
            Console.WriteLine(bmwCar1 + "\n");
          
            DieselEngineCarDecorator carWithDieselEngine = new DieselEngineCarDecorator(bmwCar1);
            carWithDieselEngine.ManufactureCar();
            Console.WriteLine();

        }
    }
}
