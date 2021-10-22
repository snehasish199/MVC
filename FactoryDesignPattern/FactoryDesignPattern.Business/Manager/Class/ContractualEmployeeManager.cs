using FactoryDesignPattern.Business.Manager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.Business.Manager.Class
{
    public class ContractualEmployeeManager : IEmployeeManager
    {
        public int GetBonus()
        {
           return 50;
        }

        public int GetPay()
        {
           return 200;
        }
    }
}
