using FactoryDesignPattern.Business;
using FactoryDesignPattern.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.DataFacade
{
    public interface IEmployeeFacade
    {
        int Add(Employee emp);
        bool Delete(int id);
        bool Update(Employee employee);
        IEnumerable<Employee> GetAllEmployees();
        Employee GetById(int id);

    }
}
