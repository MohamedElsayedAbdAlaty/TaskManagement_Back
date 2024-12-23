using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UserManagerService// : IUserManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserManagerService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterUserAsync(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            return await _userManager.CreateAsync(user, password);
        }

        //public async Task<string?> LoginUserAsync(string email, string password)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);
        //    if (user == null || !await _userManager.CheckPasswordAsync(user, password))
        //        return null;

        //    return GenerateJwtToken(user);
        //}


    }
   
}
