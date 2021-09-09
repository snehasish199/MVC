using MvcDI.Models;
using MvcDI.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDI.Repository
{
    public class EmployeeDbRepos : IEmployeeRepos
    {
        private readonly EmployeeDb db;
        public EmployeeDbRepos(EmployeeDb _db)
        {
            this.db = _db;
        }
        public bool Add(Employee emp)
        {
            try
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
           
        }

        public bool Delete(int id)
        {
            try
            {
                db.Employees.Remove(GetEmployee(id));
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return db.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return db.Employees.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Employee emp)
        {
            try
            {
                var entry = db.Entry(emp);
                entry.State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
