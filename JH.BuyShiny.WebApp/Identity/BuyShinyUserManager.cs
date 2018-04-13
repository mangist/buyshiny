using JH.BuyShiny.WebApp.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDA.YourStoreApp.WebPortal
{
    public class BuyShinyUserManager : UserManager<BuyShinyUser>
    {
        public BuyShinyUserManager (
            IUserStore<BuyShinyUser> store, 
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<BuyShinyUser> passwordHasher, 
            IEnumerable<IUserValidator<BuyShinyUser>> userValidators, 
            IEnumerable<IPasswordValidator<BuyShinyUser>> passwordValidators, 
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<BuyShinyUser>> logger)
                : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer,
                      errors, services, logger)
        {
        }
    }
}