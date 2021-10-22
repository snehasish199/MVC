using FactoryDesignPattern.Business;
using FactoryDesignPattern.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.DAL.Classs
{
  public  class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDb _context;
        public EmployeeRepository()
        {
            _context = new EmployeeDb();
        }
        public int Add(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return emp.Id;
        }

        public bool Delete(int id)
        {
            var Emp = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (Emp != null)
            {
                _context.Employees.Remove(Emp);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }


        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Employee employee)
        {
            //_context.Employees.Attach(employee);
            _context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
