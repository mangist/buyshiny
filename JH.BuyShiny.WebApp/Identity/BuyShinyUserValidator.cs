﻿using JH.BuyShiny.Database;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JH.BuyShiny.WebApp.Identity
{
    public class BuyShinyUserValidator : IUserValidator<BuyShinyUser>
    {
        public IdentityErrorDescriber Describer { get; }
        public BuyShinyUserValidator(IdentityErrorDescriber errors = null)
        {
            Describer = errors ?? new IdentityErrorDescriber();
        }

        public virtual async Task<IdentityResult> ValidateAsync(UserManager<BuyShinyUser> manager, BuyShinyUser user)
        {
            if (manager == null)
                throw new ArgumentNullException(nameof(manager));
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            var errors = new List<IdentityError>();
            await ValidateUserName(manager, user, errors);

            if (manager.Options.User.RequireUniqueEmail)
            {
                await ValidateEmail(manager, user, errors);
            }
            return errors.Count > 0 ? IdentityResult.Failed(errors.ToArray()) : IdentityResult.Success;
        }

        private async Task ValidateUserName(UserManager<BuyShinyUser> manager, BuyShinyUser user, ICollection<IdentityError> errors)
        {
            var userName = await manager.GetUserNameAsync(user);
            if (string.IsNullOrWhiteSpace(userName))
                errors.Add(Describer.InvalidUserName(userName));
            else if (!string.IsNullOrEmpty(manager.Options.User.AllowedUserNameCharacters) 
                && userName.Any(c => !manager.Options.User.AllowedUserNameCharacters.Contains(c)))
            {
                errors.Add(Describer.InvalidUserName(userName));
            }
        }

        private async Task ValidateEmail(UserManager<BuyShinyUser> manager, BuyShinyUser user, List<IdentityError> errors)
        {
            var email = await manager.GetEmailAsync(user);
            if (string.IsNullOrWhiteSpace(email))
                errors.Add(Describer.InvalidEmail(email));
            else if (!new EmailAddressAttribute().IsValid(email))
            {
                errors.Add(Describer.InvalidEmail(email));
            }
            else
            {
                var byEmailAsync = await manager.FindByEmailAsync(email);
                var flag = byEmailAsync != null;
                if (flag)
                {
                    var a = await manager.GetUserIdAsync(byEmailAsync);
                    flag = !string.Equals(a, await manager.GetUserIdAsync(user));
                }
                if (!flag)
                    return;
                errors.Add(Describer.DuplicateEmail(email));
            }
        }
    }
}
