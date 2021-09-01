using Commonlayer.Models.RequestModel;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace EmployeePayrollProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public class CustomAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
        {
            public void OnAuthentication(AuthenticationContext filterContext)
            {
                if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["Id"])) || string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["EmailAddress"])) || string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["Role"])))
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
            public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
            {
                if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
                {
                    filterContext.HttpContext.Session["loginfailed"] = "loginfailed";
                    //Redirecting the user to the Login View of Account Controller  
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                     { "controller", "Admin" },
                     { "action", "Login" }
                    });
                }
            }
        }

        public class CustomAuthorizeAttribute : AuthorizeAttribute
        {
            public static readonly string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            public SqlConnection con = new SqlConnection(strcon);
            private readonly string[] allowedroles;
            public CustomAuthorizeAttribute(params string[] roles)
            {
                this.allowedroles = roles;
            }
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                bool authorize = false;
                var Id = Convert.ToString(httpContext.Session["Id"]);
                var EmailAddress = Convert.ToString(httpContext.Session["EmailAddress"]);
                SqlCommand com = new SqlCommand("spAuthorize", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);
                com.Parameters.AddWithValue("@EmailAddress", EmailAddress);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                Credential result = new Credential();
                while (dr.Read())
                {
                    result.Role = Convert.ToString(dr["Role"]);
                }
                con.Close();

                if (!string.IsNullOrEmpty(Id))
                {
                    foreach (var role in allowedroles)
                    {
                        if (role == result.Role)
                            authorize = true; 
                    }
                }

                return authorize;
            }

            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                filterContext.Result = new RedirectToRouteResult(
                   new RouteValueDictionary
                   {
                    { "controller", "Home" },
                    { "action", "UnAuthorized" }
                   });
            }
        }
    }
}
