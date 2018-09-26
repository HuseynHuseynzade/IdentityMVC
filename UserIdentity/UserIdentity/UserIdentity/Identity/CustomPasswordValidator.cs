using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace UserIdentity.Identity
{
    public class CustomPasswordValidator:PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(string password)
        {
            var result = await base.ValidateAsync(password);

            if (password.Contains("12345"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Password cannot contain consecutive numeric expression");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}