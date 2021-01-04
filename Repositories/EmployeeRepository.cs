using Courier_Management_REST_WEB_API.Models;
using Courier_Management_REST_WEB_API.Report;
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

        public EmployeeReportData Report(int id)
        {
            UserRepository userRepo = new UserRepository();
            ProductRepository proRepo = new ProductRepository();
            EmployeeReportData crd = new EmployeeReportData();

            crd.Name = this.GetByUid(id).Name;
            crd.totalSentProduct = proRepo.GetAll().Where<Product>(x => x.Sending_Manager_id == id).Count();
            crd.totalReceivedProduct = proRepo.GetAll().Where<Product>(x => x.Receiving_Manager_id== id).Count();
            crd.totalVerifiedUser = userRepo.GetAll().Where<User>(x => x.Status == 1 && x.UserType == 1).Count();
            crd.totalInvalidUser = userRepo.GetAll().Where<User>(x => x.Status == 0 && x.UserType == 1).Count();
            crd.totalBlockedUser = userRepo.GetAll().Where<User>(x => x.Status == 2 && x.UserType == 1).Count();
            List<Product> pro = proRepo.GetAll();
            int e = 0, m = 0, a = 0, p = 0, pk = 0;
            double count = 0;
            foreach (var item in pro)
            {
                count += item.Delivery_charge;
                if (item.ProductCategory == 0)
                {
                    e++;
                }
                else if (item.ProductCategory == 1)
                {
                    m++;
                }
                else if (item.ProductCategory == 2)
                {
                    a++;
                }
                else if (item.ProductCategory == 3)
                {
                    p++;
                }
                else if (item.ProductCategory == 4)
                {
                    pk++;
                }
            }
            crd.TotalElectronisSent = e;
            crd.TotalMobilesSent = m;
            crd.TotalAccessoriesSent = a;
            crd.TotalPapersSent = p;
            crd.TotalPackagesSent = pk;
            return crd;
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

        public string getPhone(int bid)
        {
            Employee employee = this.GetAll().Where<Employee>(x => x.Branch_id == bid).FirstOrDefault();
            return employee.Contact;
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