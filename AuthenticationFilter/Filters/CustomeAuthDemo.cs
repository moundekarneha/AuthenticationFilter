using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace AuthenticationFilter.Filters
{
    public class CustomeAuthDemo : ActionFilterAttribute, IAuthenticationFilter
    {

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "AuthenticatedView"
                };
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext fillterContext)
        {
            if (fillterContext.Result == null || fillterContext.Result is HttpUnauthorizedResult)
            {
                fillterContext.Result = new ViewResult()
                {
                    ViewName = "Error1"
                };
            }

        }
    }
}