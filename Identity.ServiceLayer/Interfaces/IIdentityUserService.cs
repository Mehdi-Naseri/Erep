using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Identity.Models.Models;
using Microsoft.AspNet.Identity;

namespace Identity.ServiceLayer.Interfaces
{
    public interface IIdentityUserService : IDisposable
    {
        string FindUserNameById(string id);

        Task<ApplicationUser> FindUserById(string id);

        string FindUserIdByName(string userName);

        IEnumerable<string> GetAllUserNames();

        IEnumerable<ApplicationUser> GetAllUsers();

        Task<IdentityResult> CreateUserAsync(string userName , string email,string password);

        Task<IdentityResult> DeleteUserByIdAsync(string id);

        Task<IdentityResult> UpdateUserAsync(ApplicationUser applicationUser);
    }
}
