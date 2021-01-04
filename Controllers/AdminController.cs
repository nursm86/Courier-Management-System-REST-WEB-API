using Courier_Management_REST_WEB_API.Attributes;
using Courier_Management_REST_WEB_API.Links;
using Courier_Management_REST_WEB_API.Models;
using Courier_Management_REST_WEB_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Courier_Management_REST_WEB_API.Controllers
{
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        UserRepository userRepo = new UserRepository();
        BranchRepository branchRepo = new BranchRepository();
        EmployeeRepository empRepo = new EmployeeRepository();
        Employee_ProblemRepository epRepo = new Employee_ProblemRepository();

        [Route("{id}"),AdminAuthentication]
        public IHttpActionResult GetDashboard(int id)
        {
            User user = userRepo.Get(id);
            user.links = AdminLinks.getLinks(id, 1);
            return Ok(user);
        }
        [Route("{id}/profile"),AdminAuthentication]
        public IHttpActionResult GetProfile(int id)
        {
            User user = userRepo.Get(id);
            user.links = AdminLinks.getLinks(id,2);
            return Ok(user);
        }
        [Route("{id}/profile"), AdminAuthentication]
        public IHttpActionResult PutUpdateProfile(int id,User user)
        {
            var modelState = ActionContext.ModelState;
            if (modelState.IsValid)
            {
                user.Id = id;
                userRepo.Update(user);
                user.links = AdminLinks.getLinks(id, 3);
                return Ok(userRepo.Get(id));
            }
            return BadRequest(modelState);
            
        }
        [Route("BranchList"), AdminAuthentication]
        public IHttpActionResult GetAllBranch()
        {
            return Ok(branchRepo.GetAll());
        }
        [Route("report/{id}")]
        public IHttpActionResult GetReport(int id)
        {
            return Ok(userRepo.Report(id));
        }

        [Route("Branch/{id}"), AdminAuthentication]
        public IHttpActionResult GetBranch(int id)
        {
            return Ok(branchRepo.Get(id));
        }

        [Route("Branch/{id}"), AdminAuthentication]
        public IHttpActionResult PutBranch([FromUri]int id,[FromBody]Branch branch)
        {
            branch.Id = id;
            branch.updatedDate = DateTime.Now;
            branchRepo.Update(branch);
            return Ok(branch);
        }
        [Route("addBranch"), AdminAuthentication]
        public IHttpActionResult PostAddBranch(Branch branch)
        {
            var modelState = ActionContext.ModelState;
            branch.updatedDate = DateTime.Now;
            if (modelState.IsValid)
            {
                branchRepo.Insert(branch);
                return Ok(branch);
            }
            return BadRequest(modelState);
            
        }
        [Route("AllEmployee"), AdminAuthentication]
        public IHttpActionResult GetAllEmployee()
        {
            return Ok(empRepo.GetAll());
        }
        [Route("Employee/{id}"), AdminAuthentication]
        public IHttpActionResult GetEmployee(int id)
        {
            return Ok(empRepo.GetByUid(id));
        }
        [Route("Employee/{id}"), AdminAuthentication]
        public IHttpActionResult PutUpdateEmployee(int id,Employee employee)
        {
            employee.userId = id;
            empRepo.UpdateEmployeeInfo(employee);
            return Ok(empRepo.GetByUid(id));
        }
        [Route("addEmployee"), AdminAuthentication]
        public IHttpActionResult PostAddEmployee(Employee employee)
        {
            var modelState = ActionContext.ModelState;
            if (modelState.IsValid)
            {
                empRepo.addEmployee(employee.User, employee);
                return Ok(employee);
            }
            return BadRequest(modelState);
        }
        [Route("employeeProblems"), AdminAuthentication]
        public IHttpActionResult GetAllProblems()
        {
            return Ok(epRepo.GetAll());
        }

        [Route("problem/{id}"), AdminAuthentication]
        public IHttpActionResult GetProblem(int id)
        {
            return Ok(epRepo.Get(id));
        }

        [Route("removeEmploye/{id}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = empRepo.GetByUid(id);
            empRepo.Delete(employee.Id);
            userRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("solveProblem/{id}"), AdminAuthentication]
        public IHttpActionResult DeleteProblem(int id)
        {
            epRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}/updatePassword"), AdminAuthentication]
        public IHttpActionResult PutUpdatePass([FromUri] int id, [FromBody] User user)
        {
            if (user.Password.Length > 3)
            {
                userRepo.UpdatePassword(id, user.Password);
                return Ok(userRepo.Get(id));
            }
            return BadRequest("Password Must be 4 character Long!!!");
        }
    }
}
