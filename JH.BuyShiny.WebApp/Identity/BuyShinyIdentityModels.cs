using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JH.BuyShiny.WebApp.Identity
{
    public class BuyShinyUser : IdentityUser<int>
    {
        public bool Active { get; set; }
    }

    public class BuyShinyRole : IdentityRole<int>
    {
        public BuyShinyRole() { }
        public BuyShinyRole(string name)
        {
            Name = name;
        }
    }

    public class BuyShinyUserRole : IdentityUserRole<int>
    {
    }

    public class BuyShinyLogin : IdentityUserLogin<int>
    {
    }

    public class BuyShinyClaim : IdentityUserClaim<int>
    {
    }
}
