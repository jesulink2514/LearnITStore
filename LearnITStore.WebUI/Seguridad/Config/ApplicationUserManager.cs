using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearnITStore.WebUI.Seguridad.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;

namespace LearnITStore.WebUI.Seguridad.Config
{
    public class ApplicationUserManager
        :UserManager<AppUser>
    {
        public ApplicationUserManager
            (IUserStore<AppUser> store) : base(store)
        {
        }

        public static ApplicationUserManager Create(
            IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var manager = new
                ApplicationUserManager(
                new UserStore<AppUser>(
                    context.Get<UsersDbContext>()));

            manager.UserValidator = new UserValidator<AppUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = false,
                RequireUppercase = false
            };

            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            var dp = options.DataProtectionProvider;
            if (dp != null)
            {

                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<AppUser>
                    (dp.Create("ASP.Net Identity"));
            }

            return manager;
        }
    }
}