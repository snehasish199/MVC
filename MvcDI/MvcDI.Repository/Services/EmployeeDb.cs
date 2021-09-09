using MvcDI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDI.Repository.Services
{
   public class EmployeeDb:DbContext
    {
        public DbSet<Employee> Employees{ get; set; }
    }
}
