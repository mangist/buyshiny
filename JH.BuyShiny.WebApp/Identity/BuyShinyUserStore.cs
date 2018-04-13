using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using JH.BuyShiny.WebApp.Identity;
using JH.BuyShiny.Database;
using Microsoft.AspNetCore.Identity;

namespace CDA.YourStoreApp.WebPortal
{
    public class BuyShinyUserStore : UserStore<BuyShinyUser, BuyShinyRole, BuyShinyContext, int>
    {
        #region Constructor 

        public BuyShinyUserStore(BuyShinyContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }

        #endregion

        #region IUserClaimStore

        public Task AddClaimAsync(BuyShinyUser user, Claim claim)
        {
            throw new NotImplementedException();
        }
        public Task<IList<Claim>> GetClaimsAsync(BuyShinyUser user)
        {
            // This is just faked for now until we know what Claims even are and how to use them
            return Task.FromResult((IList<Claim>)new List<Claim>());
        }

        public Task RemoveClaimAsync(BuyShinyUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserLoginStore

        public Task AddLoginAsync(BuyShinyUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }
        public Task<BuyShinyUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }
        public Task<IList<UserLoginInfo>> GetLoginsAsync(BuyShinyUser user)
        {
            throw new NotImplementedException();
        }
        public Task RemoveLoginAsync(BuyShinyUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserRoleStore

        public Task AddToRoleAsync(BuyShinyUser user, string roleName)
        {
            var dbUser = GetUserById(user);
            var dbRole = Context.Roles.Single(r => r.Description == roleName);

            dbUser.Roles.Add(dbRole);
            return Context.SaveChangesAsync();
        }

        public Task<IList<string>> GetRolesAsync(BuyShinyUser user)
        {
            var dbUser = GetUserById(user);
            return Task.FromResult((IList<string>)dbUser.Roles.Select(r => r.Description).ToList());
        }

        public Task<bool> IsInRoleAsync(BuyShinyUser user, string roleName)
        {
            var dbUser = GetUserById(user);
            return Task.FromResult(dbUser.Roles.Any(r => r.Description == roleName));
        }

        public Task RemoveFromRoleAsync(BuyShinyUser user, string roleName)
        {
            var dbUser = GetUserById(user);
            var dbRole = Context.Roles.Single(r => r.Description == roleName);

            dbUser.Roles.Remove(dbRole);
            return Context.SaveChangesAsync();
        }
        #endregion

        #region IUserStore

        public Task CreateAsync(BuyShinyUser user)
        {
            Context.Users.Add(
                new User
                {
                    Username = user.UserName,
                    PasswordHash = user.PasswordHash,
                    EmailAddress = user.Email,
                    EmailVerified = user.EmailConfirmed,
                    Active = true
                });
            return Context.SaveChangesAsync();
        }

        public Task DeleteAsync(BuyShinyUser user)
        {
            var dbUser = Context.Users.Find(user.Id);
            Context.Users.Remove(dbUser);

            return Context.SaveChangesAsync();
        }

        public Task<BuyShinyUser> FindByIdAsync(int userId)
        {
            var dbUser = GetUserById(userId);
            if (dbUser == null)
                return null;
            else
                return Task.FromResult((BuyShinyUser)DbUserToWebUser(dbUser));
        }

        public Task<BuyShinyUser> FindByNameAsync(string userName)
        {
            var dbUser = Context.Users.SingleOrDefault(u => u.Username == userName);
            if (dbUser == null)
                return null;
            else
                return Task.FromResult((BuyShinyUser)DbUserToWebUser(dbUser));
        }

        public Task UpdateAsync(BuyShinyUser user)
        {
            var dbUser = GetUserById(user);
            dbUser.Username = user.UserName;
            dbUser.EmailAddress = user.Email;
            dbUser.PasswordHash = user.PasswordHash;
            dbUser.EmailVerified = user.EmailConfirmed;
            dbUser.Active = user.Active;
            
            return Context.SaveChangesAsync();
        }

        #endregion

        #region Helper Methods

        private User GetUserById(BuyShinyUser user)
        {
            return GetUserById(user.Id);
        }

        private User GetUserById(int userId)
        {
            return Context.Users.Find(userId);
        }

        private BuyShinyUser DbUserToWebUser(User dbUser)
        {
            return new BuyShinyUser
            {
                Id = dbUser.Id,
                UserName = dbUser.Username,
                Email = dbUser.EmailAddress, // Just mapping the db email address to IdentityUser<TUser>.Email
                PasswordHash = dbUser.PasswordHash,
                Active = dbUser.Active,
                EmailConfirmed = dbUser.EmailVerified,
                SecurityStamp = Guid.NewGuid().ToString() // ASP.NET Identity requires this
            };
        }

        #endregion

        #region IUserPasswordStore

        public Task SetPasswordHashAsync(BuyShinyUser user, string passwordHash)
        {
            var dbUser = GetUserById(user);

            dbUser.PasswordHash = passwordHash;
            return Context.SaveChangesAsync();
        }

        public Task<string> GetPasswordHashAsync(BuyShinyUser user)
        {
            var dbUser = GetUserById(user);
            return Task.FromResult(dbUser.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(BuyShinyUser user)
        {
            var dbUser = GetUserById(user);
            return Task.FromResult(
                !String.IsNullOrEmpty(dbUser.PasswordHash));
        }

        #endregion

        #region IUserLockoutStore

        public Task<DateTimeOffset> GetLockoutEndDateAsync(BuyShinyUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(BuyShinyUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(BuyShinyUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(BuyShinyUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(BuyShinyUser user)
        {
            // Just fake this implementation
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(BuyShinyUser user)
        {
            // Just fake the implementation
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(BuyShinyUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserTwoFactorStore

        public Task SetTwoFactorEnabledAsync(BuyShinyUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(BuyShinyUser user)
        {
            return Task.FromResult(false);
        }

        #endregion

    }
}