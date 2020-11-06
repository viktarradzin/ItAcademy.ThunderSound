using System.Web;
using System.Web.Mvc;
using ItAcademy.ThunderSound.Client.App_Start.Identity;
using ItAcademy.ThunderSound.DomainLayer.Entities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace ItAcademy.ThunderSound.Client.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public virtual ActionResult Login(string username, string password, string returnURL)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

            var authManager = HttpContext.GetOwinContext().Authentication;

            ApplicationUser user = userManager.Find(username, password);

            if (user != null)
            {
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

                if (!string.IsNullOrWhiteSpace(returnURL))
                {
                    return Redirect(returnURL);
                }

                return Redirect("/Home/Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string username, string password)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

            var newUser = new ApplicationUser
            {
                UserName = username
            };

            userManager.Create(newUser, password);

            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<ApplicationRole>>();

            const string roleName = "User";

            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new ApplicationRole { Name = roleName });
            }

            var existUser = userManager.Find(username, password);

            userManager.AddToRole(existUser.Id, roleName);

            return Redirect("/Home/Index");
        }

        public virtual ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;

            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return Redirect("/Home/Index");
        }

        public ActionResult AdminRegister(string userName, string password)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

            var newUser = new ApplicationUser
            {
                UserName = userName
            };

            userManager.Create(newUser, password);

            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<ApplicationRole>>();

            const string roleName = "Admin";

            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new ApplicationRole { Name = roleName });
            }

            var existUser = userManager.Find(userName, password);

            userManager.AddToRole(existUser.Id, roleName);

            return Redirect("/Home/Index");
        }
    }
}