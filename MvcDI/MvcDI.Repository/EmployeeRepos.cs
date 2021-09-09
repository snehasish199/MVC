
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcDI.Models;

namespace MvcDI.Repository
{
    public class EmployeeRepos : IEmployeeRepos
    {
        List<Employee> EmployeeList = null;

        public EmployeeRepos()
        {
            EmployeeList = new List<Employee>();
            AllEmployee();
        }
        private List<Employee>  AllEmployee()
        {
            EmployeeList.Add(new Employee()
            {
                Id = 1,
                Name = "Snehasish",
                Email = "snehasish@gmail.com"
            });

            EmployeeList.Add(new Employee()
            {
                Id = 2,
                Name = "Subhasish",
                Email = "subhasish@gmail.com"
            });
            EmployeeList.Add(new Employee()
            {
                Id = 3,
                Name = "Sandeep",
                Email = "sandeep@gmail.com"
            });
            EmployeeList.Add(new Employee()
            {
                Id = 4,
                Name = "Rajib",
                Email = "rajib@gmail.com"
            });
            return EmployeeList;
        }

        public bool Add(Employee emp)
        {
            try
            {
                emp.Id = EmployeeList.Count+1;
                EmployeeList.Add(emp);
              
                
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
           
        }

        public bool Delete(int id)
        {
            try
            {
                if (id <= EmployeeList.Count)
                {
                   // return EmployeeList.Remove(GetEmployee(id));
                    return EmployeeList.Remove(EmployeeList.FirstOrDefault(x => x.Id == id));
                }
                else
                    return false;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return EmployeeList;
        }

        public Employee GetEmployee(int id)
        {
            try
            {
                if (id <= EmployeeList.Count)
                {
                    return EmployeeList.FirstOrDefault(x => x.Id == id);
                }
                else
                    return null;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool Update(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
