using System.ComponentModel.DataAnnotations;

namespace Erep.DomainClasses.Models.Identity
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required(ErrorMessage = "کلمه عبور فعلی الزامی است")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور فعلی")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "کلمه عبور جدید الزامی است")]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [StringLength(100, ErrorMessage = "{0} باید حداقل {2} کاراکتر باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور جدید")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تایید کلمه عبور جدید")]
        [Compare("NewPassword", ErrorMessage = "کلمه عبور جدید و تایید کلمه عبور یکسان نیستند.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "کلمه عبور الزامی است")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Display(Name = "من را به خاطر بسپار؟")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage="نام کاربری الزامی است")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "کلمه عبور الزامی است")]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [StringLength(100, ErrorMessage = "{0} باید حداقل {2} کاراکتر باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تایید کلمه عبور")]
        [Compare("Password", ErrorMessage = "کلمه عبور جدید و تایید کلمه عبور یکسان نیستند.")]
        public string ConfirmPassword { get; set; }

        [StringLength(255)]
        //[RegularExpression("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$", ErrorMessage = "ایمیل معتبر نیست")]
        [DataType(DataType.EmailAddress, ErrorMessage = "ایمیل معتبر وارد نمایید.")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }
}
