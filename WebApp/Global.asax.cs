using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Autofac;
using Autofac.Integration.Mvc;
using Repositories;
using Services.Identity;

namespace WebApp
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_AuthenticateRequest()
        {
            var c = Request.Cookies["asdf"];
            if (c == null) return;
            var t = FormsAuthentication.Decrypt(c.Value);
            if (t == null) return;
            var st = t.UserData;
            var ui = UserInfo.FromString(st);
            var i = new UserIdIdentity { IsAuthenticated = true, Name = t.Name, UserId = ui.UserId };
            var gp = new GenericPrincipal(i, null);
            HttpContext.Current.User = gp;
        }

        protected void Application_Start()
        {
            var db = new EntityContext();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Dependencies.Configure(new ContainerBuilder(),db)));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
