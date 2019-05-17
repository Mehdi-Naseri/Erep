using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.ServiceLayer.Interfaces
{
    public interface IIdentityRoleService : IDisposable
    {
        string FindRoleNameById(string id);

        string FindRoleIdByName(string roleName);

        IEnumerable<string> GetAllRoleNames();

        IEnumerable<IdentityRole> GetAllRoles();

        Task<IdentityRole> FindRoleByIdAsync(string id);

        Task<IdentityResult> CreateRoleByNameAsync(string roleName);

        Task<IdentityResult> DeleteRoleByIdAsync(string id);

        Task<IdentityResult> UpdateRoleAsync(IdentityRole identityRole);
    }
}
