using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JH.BuyShiny.WebApp.Identity
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<BuyShinyUser, BuyShinyRole>
    {
        public AppClaimsPrincipalFactory(
            UserManager<BuyShinyUser> userManager
            , RoleManager<BuyShinyRole> roleManager
            , IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
        { }

        public async override Task<ClaimsPrincipal> CreateAsync(BuyShinyUser user)
        {
            var principal = await base.CreateAsync(user);

            if (!string.IsNullOrWhiteSpace(user.Email))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                    new Claim("EmailAddress", user.Email)
                });
            }

            return principal;
        }
    }
}
