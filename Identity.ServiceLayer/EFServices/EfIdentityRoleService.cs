using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Identity.ServiceLayer.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Erep.DataAccessLayer.DataContext;

namespace Identity.ServiceLayer.EFServices
{
    public class EfIdentityRoleService : IIdentityRoleService
    {
        private readonly ErepDbContext _dbContext = new ErepDbContext();

        public string FindRoleNameById(string id)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
            return roleManager.FindByIdAsync(id).Result.Name;
        }

        public string FindRoleIdByName(string roleName)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
            return roleManager.FindByNameAsync(roleName).Result.Id;
        }

        public IEnumerable<string> GetAllRoleNames()
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
            return roleManager.Roles.Select(r => r.Name);
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
            return roleManager.Roles;
        }

        public async Task<IdentityRole> FindRoleByIdAsync(string id)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
            var result = await roleManager.FindByIdAsync(id);
            return result;
        }

        public async Task<IdentityResult> CreateRoleByNameAsync(string roleName)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
            IdentityRole identityRole = new IdentityRole(roleName);
            var result = await roleManager.CreateAsync(identityRole);
            return result;
        }

        public async Task<IdentityResult> DeleteRoleByIdAsync(string id)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
            IdentityRole identityRole = await roleManager.FindByIdAsync(id);
            var result = await roleManager.DeleteAsync(identityRole);
            return result;
        }

        public async Task<IdentityResult> UpdateRoleAsync(IdentityRole identityRole)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
            var result = await roleManager.UpdateAsync(identityRole);
            return result;
        }


        #region IDisposable Members
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
