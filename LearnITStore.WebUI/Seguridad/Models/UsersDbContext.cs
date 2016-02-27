using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LearnITStore.WebUI.Seguridad.Models
{
    public class UsersDbContext:
        IdentityDbContext<AppUser>
    {
        public UsersDbContext()
            :base("EFDbContext", throwIfV1Schema:false)
        {            
        }
        public static UsersDbContext Create()
        {
            return new UsersDbContext();
        }
    }
}