using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LearnITStore.WebUI.Seguridad.Models
{
    public class AppUser:IdentityUser
    {
        public async Task<ClaimsIdentity> 
            GenerateUserIdentity(UserManager<AppUser> manager)
        {
            var user = await manager
                .CreateIdentityAsync(this, 
                DefaultAuthenticationTypes.ApplicationCookie);

            return user;
        }
    }
}