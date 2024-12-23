using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IUserManager
    {
      
        Task<IdentityResult> RegisterUserAsync(string email, string password);
        Task<string?> LoginUserAsync(string email, string password);
       
    }
}
