using CDA.YourStoreApp.WebPortal;
using JH.BuyShiny.WebApp.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JH.BuyShiny.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private BuyShinyUserManager _userManager;
        private BuyShinySignInManager _signInManager;

        public AccountController(BuyShinyUserManager userManager, BuyShinySignInManager signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
    }
}
