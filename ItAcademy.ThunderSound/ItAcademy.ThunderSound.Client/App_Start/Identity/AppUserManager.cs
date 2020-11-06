using ItAcademy.ThunderSound.DataLayer.Context;
using ItAcademy.ThunderSound.DomainLayer.Entities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ItAcademy.ThunderSound.Client.App_Start.Identity
{
    public class AppUserManager : UserManager<ApplicationUser>
    {
        public AppUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static AppUserManager Create(
            IdentityFactoryOptions<AppUserManager> options,
            IOwinContext context)
        {
            var manager = new AppUserManager(new UserStore<ApplicationUser>(context.Get<ThunderSoundDbContext>()))
            {
                PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 4,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false
                }
            };

            return manager;
        }
    }
}