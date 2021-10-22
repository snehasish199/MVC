using FactoryDesignPattern.Business.Manager.Class;
using FactoryDesignPattern.Business.Manager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.Business.ManagerFactory
{
   public class EmployeeManagerFactory
    {
        public IEmployeeManager GetEmployeeManager(string empType)
        {
            if (empType.Equals("Permanent"))
            {
                return new PermanentEmployeeManager();
            }
            else if (empType.Equals("Contractual"))
            {
                return new ContractualEmployeeManager();
            }
            return null;
        }
    }
}
