using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Identity.ViewModels.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.ServiceLayer.Interfaces
{
    public interface IIdentityUserRoleService : IDisposable
    {
        IEnumerable<UserRoleViewModel> GetAllUsersRoles();

        Task<IdentityResult> AddUserRole(string userName, string roleName);

        Task<IdentityResult> DeleteUserRole(string userName , string roleName);


    }
}
