using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Core.Validation;
using IdSvrHost.Models;
using Microsoft.Data.Entity;
using IdentityServer4.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdSvrHost.Services
{
    public class SqlResourceOwnerPasswordValidator: IResourceOwnerPasswordValidator
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        public async Task<CustomGrantValidationResult> ValidateAsync(string userName, string password, ValidatedTokenRequest request)
        {
            var user = await _db.Users.SingleAsync(u => u.UserName == userName);

            // Not Found
            if (user == null) return new CustomGrantValidationResult("Invalid Username");

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            // Invalid password
            if (result != PasswordVerificationResult.Success) return new CustomGrantValidationResult("Invalid user credentials");

            // Success
            return new CustomGrantValidationResult(user.Id, "password");
        }
    }
}
