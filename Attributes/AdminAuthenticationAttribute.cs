using Courier_Management_REST_WEB_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Courier_Management_REST_WEB_API.Attributes
{
    public class AdminAuthenticationAttribute : AuthorizationFilterAttribute
    {
        UserRepository userRepo = new UserRepository();
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string encodedString = actionContext.Request.Headers.Authorization.Parameter;

                int usertype = userRepo.Validate(encodedString);

                if (usertype == 0)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(usertype.ToString()), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}