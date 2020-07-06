using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using PatientCare.Repository;


namespace PatientCare.AppAdmin.Filters
{
    public class AuthorizeActionFilter : IActionFilter
    {
        private readonly UnitOfWork UnitOfWork;
        private string _ControlerName;
        private readonly int _Fk_AccessLevel;
        private readonly ISession Session;

        public AuthorizeActionFilter(int Fk_AccessLevel, UnitOfWork UnitOfWork, IHttpContextAccessor HttpContextAccessor)
        {
            _Fk_AccessLevel = Fk_AccessLevel;
            this.UnitOfWork = UnitOfWork;
            Session = HttpContextAccessor.HttpContext.Session;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string Email = Session.GetString("Email");

            _ControlerName = context.RouteData.Values["controller"].ToString();

            if (string.IsNullOrEmpty(Email))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            else if (!UnitOfWork.SystemUserPermissionRepository.CheckAuthorization(_ControlerName, _Fk_AccessLevel, Email))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Error" }));
            }
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }

    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(int Fk_AccessLevel)
            : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { Fk_AccessLevel };
        }
    }
}
