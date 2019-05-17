using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Identity.ServiceLayer.Interfaces;
using Microsoft.AspNet.Identity;
using Identity.Models.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Erep.DataAccessLayer.DataContext;

namespace Identity.ServiceLayer.EFServices
{
    public class EfIdentityUserService : IIdentityUserService
    {
        private readonly ErepDbContext _dbContext = new ErepDbContext();

        public string FindUserNameById(string id)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            return userManager.FindByIdAsync(id).Result.UserName;
        }

        public async Task<ApplicationUser> FindUserById(string id)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            var result = await userManager.FindByIdAsync(id);
            return result;
        }

        public string FindUserIdByName(string userName)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            return userManager.FindByName(userName).Id;
        }

        public IEnumerable<string> GetAllUserNames()
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            //Identity 2
            IEnumerable<string> userNames = userManager.Users.Select(r => r.UserName);
            //Identity 1
            //IEnumerable<string> UserNames = (new IdentityContext()).Users.Select(r => r.UserName);
            return userNames;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            return userManager.Users.ToList();
        }

        public async Task<IdentityResult> CreateUserAsync(string userName, string email, string password)
        {
            var user = new ApplicationUser() { UserName = userName, Email = email };
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            //جهت فعال کردن امکان ثبت نام فارسی
            //userManager.UserValidator = new UserValidator<ApplicationUser>(userManager) { AllowOnlyAlphanumericUserNames = false };
            var result = await userManager.CreateAsync(user, password);
            return result;
        }

        public async Task<IdentityResult> DeleteUserByIdAsync(string id)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            var result = await userManager.DeleteAsync(userManager.FindById(id));
            return result;

            //foreach (string UserRole1 in UserManager1.GetRoles(id))
            //{
            //    UserManager1.RemoveFromRole(id, UserRole1);
            //}
            //foreach (System.Security.Claims.Claim UserClaim1 in UserManager1.GetClaims(id))
            //{
            //    UserManager1.RemoveClaim(id, UserClaim1);
            //}
            //foreach (UserLoginInfo UserLoginInfo1 in UserManager1.GetLogins(id))
            //{
            //    UserManager1.RemoveLogin(id, UserLoginInfo1);
            //}
        }

        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser applicationUser)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbContext));
            //جهت فعال کردن امکان ثبت نام فارسی
            //userManager.UserValidator = new UserValidator<ApplicationUser>(userManager) { AllowOnlyAlphanumericUserNames = false };
            var result = await userManager.UpdateAsync(applicationUser);
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
