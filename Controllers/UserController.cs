using finalAssignment__APWDN.Attributes;
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
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        UserRepository userRepo = new UserRepository();

        [Route("")]

        public IHttpActionResult Get()
        {
            return Ok(userRepo.GetAll());
        }

        [Route("login")]
        public IHttpActionResult PostValidate(User user)
        {
            if (userRepo.Validate(user))
            {
                return Ok(userRepo.getIdbyUserName(user));
            }
            return StatusCode(HttpStatusCode.Unauthorized);
        }

        [Route("{id}", Name = "GetUserById"),BasicAuthentication]
        public IHttpActionResult Get(int id)
        {
            User user = userRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(user);
        }

        [Route(""),BasicAuthentication]
        public IHttpActionResult Post(User user)
        {
            var modelState = ActionContext.ModelState;
            if (modelState.IsValid)
            {
                userRepo.Insert(user);
                string uri = Url.Link("GetUserById", new { id = user.Id });
                return Created(uri, user);
            }
            return BadRequest(modelState);
        }

        [Route("{id}"), BasicAuthentication]
        public IHttpActionResult Put([FromUri] int id, [FromBody] User user)
        {
            user.Id = id;
            if (userRepo.UpdateUser(user))
            {
                return Ok(user);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("{id}"), BasicAuthentication]
        public IHttpActionResult Delete(int id)
        {
            if (userRepo.Get(id) == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            userRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [Route("Registration")]
        public IHttpActionResult PostNewUser(Customer customer)
        {
            var modelState = ActionContext.ModelState;
            customer.User.Status = 0;
            if (modelState.IsValid)
            {
                userRepo.insertUser(customer.User, customer);
                string uri = Url.Link("GetUserById", new { id = customer.User.Id });
                return Created(uri, customer);
            }
            return BadRequest(modelState);
        }
    }
}
