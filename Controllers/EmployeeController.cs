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

        [Route("dashboard")]
        public IHttpActionResult GetDashBoard()
        {
            return Ok();
        }
        [Route("{id}/profile")]
        public IHttpActionResult GetProfile(int id)
        {
            return Ok(empRepo.GetByUid(id));
        }

        [Route("{id}/updateInfo")]
        public IHttpActionResult PutUpdateInfo([FromUri]int id,[FromBody]Employee emp)
        {
            empRepo.UpdateEmployee(emp);
            return Ok(emp);
        }

        [Route("{id}/updateProfile")]
        public IHttpActionResult PutProfile([FromUri]int id,[FromBody] Employee employee)
        {
            employee.userId = id;
            empRepo.UpdateE(employee);
            return Ok(empRepo.GetByUid(id));
        }

        [Route("{id}/serviceHistory")]
        public IHttpActionResult GetServiceHistory(int id)
        {
            return Ok(proRepo.serviceHistory(id));
        }

        [Route("CustomersList")]
        public IHttpActionResult GetAllCustomers()
        {
            return Ok(cusRepo.GetAll());
        }
        [Route("Customer/{id}",Name = "GetCustomerById")]
        public IHttpActionResult GetCustomer(int id)
        {
            return Ok(cusRepo.GetByUid(id));
        }

        [Route("Customer/{id}/verify")]

        public IHttpActionResult PutVerify(int id)
        {
            userRepo.verifyUser(id);
            return Ok();
        }

        [Route("Customer/{id}/block")]

        public IHttpActionResult PutBlock(int id)
        {
            userRepo.blockUser(id);
            return Ok();
        }
        [Route("Customer/{id}/unblock")]
        public IHttpActionResult PutUnBlock(int id)
        {
            userRepo.UnblockUser(id);
            return Ok();
        }

        [Route("createCustomer")]
        public IHttpActionResult PostCreateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                userRepo.insertUser(customer.User, customer);
            }
            string uri = Url.Link("GetCustomerById", new { id = customer.User.Id });
            return Created(uri, customer);
        }
        [Route("{id}/receivedProducts")]
        public IHttpActionResult GetReceivedProduct(int id)
        {
            int bid = empRepo.getBranchId(id);
            return Ok(proRepo.receivedProduct(id));
        }
        [Route("Product/{id}")]
        public IHttpActionResult GetProducts(int id)
        {
            return Ok(proRepo.Get(id));
        }

        [Route("{id}/shipableProducts")]
        public IHttpActionResult GetShipableProducts(int id)
        {
            return Ok(proRepo.shipAbleProduct(id));
        }

        [Route("{id}/releaseAbleProducts")]
        public IHttpActionResult GetreleseAbleProducts(int id)
        {
            return Ok(proRepo.releaseAbleProduct(id));
        }

        [Route("{id}/receiveProductFromCustomer/{pid}")]
        public IHttpActionResult PutReceiveProductFromCustomer(int id,int pid)
        {
            proRepo.receieveFromCustomer(pid, id);
            return Ok(proRepo.Get(pid));
        }

        [Route("{id}/receiveProductFromBranch/{pid}")]
        public IHttpActionResult PutReceiveProductFromBranch(int id, int pid)
        {
            proRepo.receieveFromBranch(pid, id);
            return Ok(proRepo.Get(pid));
        }

        [Route("{id}/shipProduct/{pid}")]
        public IHttpActionResult PutShipProduct(int id,int pid)
        {
            proRepo.shipProduct(pid);
            return Ok(proRepo.Get(pid));
        }

        [Route("{id}/releaseProduct/{pid}")]
        public IHttpActionResult PutReleaseProduct(int id, int pid)
        {
            proRepo.releaseProduct(pid);
            return Ok(proRepo.Get(pid));
        }

        [Route("{id}/helpline")]
        public IHttpActionResult PostHelp([FromUri]int id,[FromBody]Employee_Problems ep)
        {
            epRepo.UpdateProblem(id, ep);
            return Ok(ep);
        }

        [Route("{id}/updatePassword")]
        public IHttpActionResult PutUpdatePass([FromUri]int id,[FromBody]User user)
        {
            userRepo.UpdatePassword(id, user.Password);
            return Ok(userRepo.Get(id));
        }
    }
}
