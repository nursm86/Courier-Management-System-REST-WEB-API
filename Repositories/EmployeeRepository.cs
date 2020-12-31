using Courier_Management_REST_WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Courier_Management_REST_WEB_API.Repositories
{
    public class EmployeeRepository:Repository<Employee>
    {
        UserRepository userRepo = new UserRepository();
        public int getBranchId(int id)
        {
            return (int)GetByUid(id).Branch_id;
        }

        public Employee GetByUid(int id)
        {
            return this.GetAll().Where<Employee>(x => x.userId == id).FirstOrDefault();
        }

        public void UpdateE(Employee e)
        {
            Employee ne = GetByUid(e.userId);
            ne.Name = e.Name;
            ne.Contact = e.Contact;
            ne.Address = e.Address;
            ne.UpdatedDate = DateTime.Now;
            Update(ne);
        }
        public void UpdateEmployee(Employee e)
        {
            userRepo.verifyUser(e.userId);
            Employee ne = GetByUid(e.userId);
            ne.Name = e.Name;
            ne.DOB = e.DOB;
            ne.Contact = e.Contact;
            ne.Address = e.Address;
            ne.Blood_Group = e.Blood_Group;
            ne.Qualification = e.Qualification;
            ne.UpdatedDate = DateTime.Now;
            Update(ne);
        }

        public void UpdateEmployeeInfo(Employee e)
        {
            userRepo.verifyUser(e.userId);
            Employee ne = GetByUid(e.userId);
            ne.Name = e.Name;
            ne.Designation = e.Designation;
            ne.Branch_id = e.Branch_id;
            ne.Salary = e.Salary;
            ne.Bonus = e.Bonus;
            ne.UpdatedDate = DateTime.Now;
            Update(ne);
        }

        public void addEmployee(User user, Employee employee)
        {
            user.Status = 0;
            user.UserType = 1;
            user.UpdatedDate = DateTime.Now;
            this.context.Users.Add(user);
            this.context.SaveChanges();
            employee.userId = userRepo.getByUserName(user.UserName);
            employee.Joining_date = DateTime.Now;
            employee.UpdatedDate = DateTime.Now;
            this.context.Employees.Add(employee);
            this.context.SaveChanges();
        }

        public string getContact(int id)
        {
            Employee e = GetAll().Where<Employee>(x => x.Branch_id == id).FirstOrDefault();
            return e.Contact;
        }

    }
}