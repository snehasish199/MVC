using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverDesignPatternExample
{
    public interface IObserver
    {
        void update(string availability);
    }
}

