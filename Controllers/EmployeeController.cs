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
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        UserRepository userRepo = new UserRepository();
        EmployeeRepository empRepo = new EmployeeRepository();
        CustomerRepository cusRepo = new CustomerRepository();
        ProductRepository proRepo = new ProductRepository();
        Employee_ProblemRepository epRepo = new Employee_ProblemRepository();

        [Route("{id}"),EmployeeAuthenticaiton]
        public IHttpActionResult GetDashBoard(int id)
        {
            return Ok();
        }
        [Route("{id}/profile"), EmployeeAuthenticaiton]
        public IHttpActionResult GetProfile(int id)
        {
            Employee employee = empRepo.GetByUid(id);
            employee.User.links = EmployeeLinks.getLinks(id, 2);
            return Ok(employee);
        }

        [Route("{id}/profile"), EmployeeAuthenticaiton]
        public IHttpActionResult PutUpdateInfo([FromUri]int id,[FromBody]Employee emp)
        {
            var modelState = ActionContext.ModelState;
            if (modelState.IsValid)
            {
                empRepo.UpdateEmployee(emp);
                return Ok(emp);
            }
            return BadRequest(modelState);
            
        }

        [Route("{id}/updateProfile"), EmployeeAuthenticaiton]
        public IHttpActionResult PutProfile([FromUri]int id,[FromBody] Employee employee)
        {
            var modelState = ActionContext.ModelState;
            if (modelState.IsValid)
            {
                employee.userId = id;
                empRepo.UpdateE(employee);
                return Ok(empRepo.GetByUid(id));
            }
            return BadRequest(modelState);
            
        }

        [Route("{id}/serviceHistory"), EmployeeAuthenticaiton]
        public IHttpActionResult GetServiceHistory(int id)
        {
            return Ok(proRepo.serviceHistory(id));
        }

        [Route("CustomersList"), EmployeeAuthenticaiton]
        public IHttpActionResult GetAllCustomers()
        {
            return Ok(cusRepo.GetAll());
        }
        [Route("Customer/{id}",Name = "GetCustomerById"), EmployeeAuthenticaiton]
        public IHttpActionResult GetCustomer(int id)
        {
            return Ok(cusRepo.GetByUid(id));
        }

        [Route("Customer/{id}/verify"), EmployeeAuthenticaiton]

        public IHttpActionResult PutVerify(int id)
        {
            userRepo.verifyUser(id);
            return Ok();
        }

        [Route("Customer/{id}/block"), EmployeeAuthenticaiton]

        public IHttpActionResult PutBlock(int id)
        {
            userRepo.blockUser(id);
            return Ok();
        }
        [Route("Customer/{id}/unblock"), EmployeeAuthenticaiton]
        public IHttpActionResult PutUnBlock(int id)
        {
            userRepo.UnblockUser(id);
            return Ok();
        }

        [Route("createCustomer"), EmployeeAuthenticaiton]
        public IHttpActionResult PostCreateCustomer(Customer customer)
        {
            var modelState = ActionContext.ModelState;
            customer.User.Status = 1;
            if (modelState.IsValid)
            {
                userRepo.insertUser(customer.User, customer);
                string uri = Url.Link("GetCustomerById", new { id = customer.User.Id });
                return Created(uri, customer);
            }
            return BadRequest(modelState);
            
        }
        [Route("{id}/receivedProducts"), EmployeeAuthenticaiton]
        public IHttpActionResult GetReceivedProduct(int id)
        {
            int bid = empRepo.getBranchId(id);
            return Ok(proRepo.receivedProduct(id));
        }
        [Route("Product/{id}"), EmployeeAuthenticaiton]
        public IHttpActionResult GetProduct(int id)
        {
            return Ok(proRepo.Get(id));
        }

        [Route("{id}/shipableProducts"), EmployeeAuthenticaiton]
        public IHttpActionResult GetShipableProducts(int id)
        {
            return Ok(proRepo.shipAbleProduct(id));
        }

        [Route("{id}/releaseAbleProducts"), EmployeeAuthenticaiton]
        public IHttpActionResult GetreleseAbleProducts(int id)
        {
            return Ok(proRepo.releaseAbleProduct(id));
        }

        [Route("{id}/receiveProductFromCustomer/{pid}"), EmployeeAuthenticaiton]
        public IHttpActionResult PutReceiveProductFromCustomer(int id,int pid)
        {

            proRepo.receieveFromCustomer(pid, id);
            return Ok(proRepo.Get(pid));
        }

        [Route("{id}/receiveProductFromBranch/{pid}"), EmployeeAuthenticaiton]
        public IHttpActionResult PutReceiveProductFromBranch(int id, int pid)
        {
            proRepo.receieveFromBranch(pid, id);
            return Ok(proRepo.Get(pid));
        }

        [Route("{id}/shipProduct/{pid}"), EmployeeAuthenticaiton]
        public IHttpActionResult PutShipProduct(int id,int pid)
        {
            proRepo.shipProduct(pid);
            return Ok(proRepo.Get(pid));
        }

        [Route("{id}/releaseProduct/{pid}"), EmployeeAuthenticaiton]
        public IHttpActionResult PutReleaseProduct(int id, int pid)
        {
            proRepo.releaseProduct(pid);
            return Ok(proRepo.Get(pid));
        }

        [Route("{id}/helpline"), EmployeeAuthenticaiton]
        public IHttpActionResult PostHelp([FromUri]int id,[FromBody]Employee_Problems ep)
        {
            var modelState = ActionContext.ModelState;
            if (modelState.IsValid)
            {
                epRepo.UpdateProblem(id, ep);
                return Ok(ep);
            }
            return BadRequest(modelState);
            
        }

        [Route("{id}/updatePassword")]
        public IHttpActionResult PutUpdatePass([FromUri]int id,[FromBody]User user)
        {
            if (user.Password.Length>3)
            {
                userRepo.UpdatePassword(id, user.Password);
                return Ok(userRepo.Get(id));
            }
            return BadRequest("Password Must be 4 character Long!!!");
            
        }
    }
}
