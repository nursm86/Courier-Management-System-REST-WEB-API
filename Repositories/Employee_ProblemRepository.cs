using Courier_Management_REST_WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Courier_Management_REST_WEB_API.Repositories
{
    public class Employee_ProblemRepository:Repository<Employee_Problems>
    {
        EmployeeRepository empRepo = new EmployeeRepository();
        BranchRepository branchRepo = new BranchRepository();
        public void UpdateProblem(int id, Employee_Problems ep)
        {
            Employee e = empRepo.GetByUid(id);
            ep.Branch_id = (int)e.Branch_id;
            ep.employeeId = id;
            ep.UpdatedDate = DateTime.Now;
            this.context.Employee_Problems.Add(ep);
            this.context.SaveChanges();
        }
    }
}