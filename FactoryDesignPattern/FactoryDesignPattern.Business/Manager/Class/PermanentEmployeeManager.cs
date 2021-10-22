using FactoryDesignPattern.Business.Manager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.Business.Manager.Class
{
    public class PermanentEmployeeManager : IEmployeeManager
    {
        public int GetBonus()
        {
            return 75;
        }

        public int GetPay()
        {
            return 300;
        }
    }
}
