using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.Business.Manager.Interface
{
  public interface IEmployeeManager
    {
        int GetPay();
        int GetBonus();
    }
}
