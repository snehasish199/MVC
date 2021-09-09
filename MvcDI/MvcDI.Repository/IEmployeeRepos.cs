using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcDI.Models;

namespace MvcDI.Repository
{
    public interface IEmployeeRepos
    {
        bool Add(Employee emp);
        List<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        bool Update(Employee emp);
        bool Delete(int id);

    }
}
