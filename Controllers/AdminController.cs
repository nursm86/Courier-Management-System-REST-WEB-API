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

        [Route("{id}")]
        public IHttpActionResult GetDashboard(int id)
        {
            return Ok(userRepo.Get(id));
        }
        [Route("{id}/profile")]
        public IHttpActionResult GetProfile(int id)
        {
            return Ok(userRepo.Get(id));
        }
        [Route("{id}/profile")]
        public IHttpActionResult PutUpdateProfile(int id,User user)
        {
            var modelState = ActionContext.ModelState;
            if (modelState.IsValid)
            {
                user.Id = id;
                userRepo.Update(user);
                return Ok(userRepo.Get(id));
            }
            return BadRequest(modelState);
            
        }
        [Route("BranchList")]
        public IHttpActionResult GetAllBranch()
        {
            return Ok(branchRepo.GetAll());
        }

        [Route("Branch/{id}")]
        public IHttpActionResult GetBranch(int id)
        {
            return Ok(branchRepo.Get(id));
        }

        [Route("addBranch")]
        public IHttpActionResult PostAddBranch(Branch branch)
        {
            var modelState = ActionContext.ModelState;
            if (modelState.IsValid)
            {
                branchRepo.Insert(branch);
                return Ok(branch);
            }
            return BadRequest(modelState);
            
        }
        [Route("AllEmployee")]
        public IHttpActionResult GetAllEmployee(Branch branch)
        {
            return Ok(empRepo.GetAll());
        }
        [Route("Employee/{id}")]
        public IHttpActionResult GetEmployee(int id)
        {
            return Ok(empRepo.GetByUid(id));
        }
        [Route("Employee/{id}")]
        public IHttpActionResult PutUpdateEmployee(int id,Employee employee)
        {
            var modelState = ActionContext.ModelState;
            if (modelState.IsValid)
            {
                employee.userId = id;
                empRepo.UpdateEmployeeInfo(employee);
                return Ok(empRepo.GetByUid(id));
            }
            return BadRequest(modelState);
        }
        [Route("addEmployee")]
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
        [Route("employeeProblems")]
        public IHttpActionResult GetAllProblems()
        {
            return Ok(epRepo.GetAll());
        }

        [Route("solveProblem/{id}")]
        public IHttpActionResult DeleteProblem(int id)
        {
            epRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}/updatePassword")]
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
