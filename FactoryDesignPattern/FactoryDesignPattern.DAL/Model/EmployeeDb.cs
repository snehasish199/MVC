using FactoryDesignPattern.Business;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.DAL
{
   public class EmployeeDb:DbContext
    {
        public DbSet<Employee> Employees { get; set; }

      
    }
}
