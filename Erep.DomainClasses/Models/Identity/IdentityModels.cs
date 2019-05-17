using Microsoft.AspNet.Identity.EntityFramework;

using System.ComponentModel.DataAnnotations;

namespace Erep.DomainClasses.Models.Identity
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [StringLength(255)]
        //[RegularExpression("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$", ErrorMessage = "ایمیل معتبر نیست")]
        [DataType(DataType.EmailAddress, ErrorMessage = "ایمیل معتبر وارد نمایید.")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }
}