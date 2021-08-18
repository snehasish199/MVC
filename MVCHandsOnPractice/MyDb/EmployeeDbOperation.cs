using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCHandsOnPractice.Models;

namespace MVCHandsOnPractice.MyDb
{
    public class EmployeeDbOperation
    {
       public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            using(var context=new MVCPracticeEntities())
            {
                var AllEmp = context.Employee.Select(x => new EmployeeModel()
                {
                    Id=x.Id,
                    Name=x.Name,
                    Address=x.Address,
                    Email=x.Email,
                    DateOfBirth=x.DateOfBirth,
                    AddressId=x.AddressId

                }).ToList();
                return AllEmp;
            }
        }
        public EmployeeModel GetEmployee(int id)
        {
            using(var context=new MVCPracticeEntities())
            {
               var Emp = context.Employee.FirstOrDefault(x => x.Id == id);
                EmployeeModel EmpObj = new EmployeeModel()
                {
                    Id = Emp.Id,
                    Name = Emp.Name,
                    Address = Emp.Address,
                    Gender=Emp.Gender,
                    DateOfBirth = Emp.DateOfBirth,
                    Email = Emp.Email,
                    AddressId = Emp.AddressId,
                    Address1 = new AddressModel()
                    {
                        Details=Emp.Address1.Details,
                        State=Emp.Address1.State,
                        PinCode=Emp.Address1.PinCode,
                        Country=Emp.Address1.Country
                    }
                    

                };
                return EmpObj;
            }
        }
        public int AddEmployee(EmployeeModel emp)
        {
            using (var context = new MVCPracticeEntities())
            {
                var EmpObj = new Employee()
                {
                    Name = emp.Name,
                    Gender = emp.Gender,
                    DateOfBirth = emp.DateOfBirth,
                    Email = emp.Email,
                    Address = emp.Address,
                    Address1=new Address()
                    {
                        Details=emp.Address1.Details,
                        State=emp.Address1.State,
                        Country=emp.Address1.Country,
                        PinCode=emp.Address1.PinCode
                    }

                };
                context.Employee.Add(EmpObj);
                context.SaveChanges();
                
                return EmpObj.Id;
            } 
            
        }

        public bool Delete(int id)
        {
            using(var context=new MVCPracticeEntities())
            {
                var Emp = context.Employee.FirstOrDefault(x => x.Id == id);
                
                if (Emp == null)
                {
                    return false;
                }
                var EmpAddr = context.Address.FirstOrDefault(y => y.AddressId == Emp.AddressId);
                context.Address.Remove(EmpAddr);
                context.Employee.Remove(Emp);
                context.SaveChanges();
                return true;
            }
        }


        public int Edit(EmployeeModel emp)
        {
            using (var context = new MVCPracticeEntities())
            {

                var Emp = context.Employee.FirstOrDefault(x => x.Id == emp.Id);
                Emp.Name = emp.Name;
                Emp.Address = emp.Address;
                Emp.DateOfBirth = emp.DateOfBirth;
                Emp.Email = emp.Email;
                Emp.Gender = emp.Gender;
                Emp.Address1 = new Address()
                {
                    Details = emp.Address1.Details,
                    State=emp.Address1.State,
                    Country=emp.Address1.Country,
                    PinCode=emp.Address1.PinCode

                };
             
                context.SaveChanges();
                return Emp.Id;


            }
        }
        }
}