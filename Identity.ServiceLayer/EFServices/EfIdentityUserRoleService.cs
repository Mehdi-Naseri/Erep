using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Identity.Models.Models;
using Identity.ServiceLayer.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Erep.DataAccessLayer.DataContext;
using Identity.ViewModels.ViewModels;

namespace Identity.ServiceLayer.EFServices
{
    public class EfIdentityUserRoleService : IIdentityUserRoleService
    {
        private readonly ErepDbContext _dbContext = new ErepDbContext();


        public IEnumerable<UserRoleViewModel> GetAllUsersRoles()
        {
            List<UserRoleViewModel> userRoleViewModels = new List<UserRoleViewModel>();
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            List<ApplicationUser> applicationUsers = userManager.Users.ToList();
            foreach (ApplicationUser applicationUser in applicationUsers)
            {
                foreach (string roleName in userManager.GetRoles(applicationUser.Id))
                {
                    UserRoleViewModel userRoleViewModel = new UserRoleViewModel();
                    userRoleViewModel.UserName = applicationUser.UserName;
                    userRoleViewModel.RoleName = roleName;
                    userRoleViewModels.Add(userRoleViewModel);
                }
            }
            return userRoleViewModels;
        }

        public async Task<IdentityResult> AddUserRole(string userName, string roleName)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            string userId = userManager.FindByNameAsync(userName).Result.Id;
            var result = await userManager.AddToRoleAsync(userId, roleName);
            return result;
        }

        public async Task<IdentityResult> DeleteUserRole(string userName, string roleName)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            string userId = userManager.FindByNameAsync(userName).Result.Id;
            var result = await userManager.RemoveFromRoleAsync(userId, roleName);
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
