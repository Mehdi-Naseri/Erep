using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Identity.ViewModels.ViewModels
{
    public class LoginViewModelwithUserName
    {
        [Required]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر داشته باش")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModelwithName
    {
        [Required]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        //[Required]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تایید کلمه عبور")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class UserRoleViewModel
    {
        [Required]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "نام گروه")]
        public string RoleName { get; set; }
    }

}
