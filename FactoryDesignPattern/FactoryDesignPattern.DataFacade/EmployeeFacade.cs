using FactoryDesignPattern.Business;
using FactoryDesignPattern.DAL;
using FactoryDesignPattern.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.DataFacade
{
    public class EmployeeFacade : IEmployeeFacade
    {
        private readonly IEmployeeRepository repository;

        public EmployeeFacade(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        public int Add(Employee emp)
        {
            return repository.Add(emp);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return repository.GetAllEmployees();
        }

        public Employee GetById(int id)
        {
            return repository.GetById(id);
        }

        public bool Update(Employee employee)
        {
            return repository.Update(employee);
        }
    }
}
