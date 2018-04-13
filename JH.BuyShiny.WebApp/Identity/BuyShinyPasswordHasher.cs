using JH.BuyShiny.WebApp;
using JH.BuyShiny.WebApp.Identity;
using Microsoft.AspNetCore.Identity;

namespace CDA.YourStoreApp.WebPortal
{
    // This is using a custom implementation of the password hash algorithm
    public class BuyShinyPasswordHasher : IPasswordHasher<BuyShinyUser>
    {
        public string HashPassword(BuyShinyUser user, string password)
        {
            return PasswordHash.CreateHash(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(BuyShinyUser user, string hashedPassword, string providedPassword)
        {
            bool valid = PasswordHash.ValidatePassword(providedPassword, hashedPassword);

            return valid ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}