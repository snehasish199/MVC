using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDesignPatternExample.Target
{
    public interface ITarget
    {
       
            void ProcessCompanySalary(string[,] employeesArray);

    }
}
