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

        [Route("{id}/Dashboard")]
        public IHttpActionResult GetDashboard(int id)
        {
            return Ok(cusRepo.GetByUid(id));
        }
        [Route("{id}/profile")]
        public IHttpActionResult GetProfile(int id)
        {
            return Ok(cusRepo.GetByUid(id));
        }
        [Route("{id}/profile")]
        public IHttpActionResult PutUpdateProfile([FromUri]int id,[FromBody]Customer customer)
        {
            customer.userId = id;
            cusRepo.UpdateU(customer);
            return Ok(customer);
        }

        [Route("{id}/TrackProducts")]
        public IHttpActionResult GetOrders(int id)
        {
            return Ok(proRepo.GetOrders(id));
        }

        [Route("{id}/ServiceHistory")]
        public IHttpActionResult GetReleasedProducts(int id)
        {
            return Ok(proRepo.GetReleasedProdctById(id));
        }

        [Route("{id}/NewOrder")]
        public IHttpActionResult PostNewOrder(int id,Product product)
        {
            product.Customer_id = id;
            proRepo.insertProduct(product);
            return Ok(product);
        }

        [Route("{id}/updatePassword")]
        public IHttpActionResult PutUpdatePass([FromUri] int id, [FromBody] User user)
        {
            userRepo.UpdatePassword(id, user.Password);
            return Ok(userRepo.Get(id));
        }
    }
}
