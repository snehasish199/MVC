using DecoratorDesignPatternExample.Component;
using DecoratorDesignPatternExample.ConcreteComponent;
using DecoratorDesignPatternExample.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorDesignPatternExample.ConcreteDecorator
{
    public class DieselEngineCarDecorator : CarDecorator
    {
        public DieselEngineCarDecorator(ICar car):base(car)
        {

        }

       
        public override ICar ManufactureCar()
        {
            car.ManufactureCar();
            AddEngine(car);
            return car;
        }
        public void AddEngine(ICar car)
        {
            if (car is BMWCar)
            {
                BMWCar BMWCar = (BMWCar)car;
                BMWCar.Engine = "Diesel Engine";
                Console.WriteLine("DieselCarDecorator added Diesel Engine to the Car : " + car);
            }
        }
    }
}
