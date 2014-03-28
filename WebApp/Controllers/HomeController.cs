using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Autofac;
using Repositories;
using Services.Identity;
using Services.Membership;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MembershipService _membershipService;
        public static IContainer DependencyResolver { get; private set; }
        public HomeController()
        {
            _membershipService = DependencyResolver.Resolve<MembershipService>();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user =_membershipService.LogIn(model.UserName, model.Password);
                if (user != null)
                {
                    var ui = new UserInfo {UserId = user.Id};
                    var t = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddHours(1),
                        model.RememberMe, ui.ToString());
                    var s = FormsAuthentication.Encrypt(t);
                    var c = new HttpCookie("asdf", s);
                    Response.Cookies.Add(c);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // Появление этого сообщения означает наличие ошибки; повторное отображение формы
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}