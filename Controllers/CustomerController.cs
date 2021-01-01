using Courier_Management_REST_WEB_API.Attributes;
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
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        UserRepository userRepo = new UserRepository();
        CustomerRepository cusRepo = new CustomerRepository();
        ProductRepository proRepo = new ProductRepository();
        BranchRepository branchRepo = new BranchRepository();
        EmployeeRepository empRepo = new EmployeeRepository();

        [Route("{id}/Dashboard"),CustomerAuthentication]
        public IHttpActionResult GetDashboard(int id)
        {
            return Ok(cusRepo.GetByUid(id));
        }
        [Route("{id}/profile"), CustomerAuthentication]
        public IHttpActionResult GetProfile(int id)
        {
            return Ok(cusRepo.GetByUid(id));
        }
        [Route("{id}/profile"), CustomerAuthentication]
        public IHttpActionResult PutUpdateProfile([FromUri]int id,[FromBody]Customer customer)
        {
            var modelState = ActionContext.ModelState;
            if (modelState.IsValid)
            {
                customer.userId = id;
                cusRepo.UpdateU(customer);
                return Ok(customer);
            }
            return BadRequest(modelState);
        }

        [Route("{id}/TrackProducts"), CustomerAuthentication]
        public IHttpActionResult GetOrders(int id)
        {
            return Ok(proRepo.GetOrders(id));
        }

        [Route("{id}/ServiceHistory"), CustomerAuthentication]
        public IHttpActionResult GetReleasedProducts(int id)
        {
            return Ok(proRepo.GetReleasedProdctById(id));
        }

        [Route("{id}/NewOrder"), CustomerAuthentication]
        public IHttpActionResult PostNewOrder(int id,Product product)
        {
            var modelState = ActionContext.ModelState;
            if (modelState.IsValid)
            {
                product.Customer_id = id;
                proRepo.insertProduct(product);
                return Ok(product);
            }
            return BadRequest(modelState);
        }

        [Route("{id}/updatePassword"), CustomerAuthentication]
        public IHttpActionResult PutUpdatePass([FromUri] int id, [FromBody] User user)
        {
            if (user.Password.Length > 3)
            {
                userRepo.UpdatePassword(id, user.Password);
                return Ok(userRepo.Get(id));
            }
            return BadRequest("Password Must be 4 character Long!!!"); ;
        }
    }
}
