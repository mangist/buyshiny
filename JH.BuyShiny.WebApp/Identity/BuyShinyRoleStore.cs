using JH.BuyShiny.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using JH.BuyShiny.WebApp.Identity;

namespace CDA.YourStoreApp.WebPortal
{
    public class BuyShinyRoleStore : RoleStore<BuyShinyRole, BuyShinyContext, int>
    {
        public BuyShinyRoleStore(BuyShinyContext context) : base(context)
        {
        }
    }
}