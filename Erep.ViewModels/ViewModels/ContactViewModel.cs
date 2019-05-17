using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Erep.ViewModels.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "نام را وارد نمایید")]
        [StringLength(100)]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Required(ErrorMessage = "پیام را وارد نمایید")]
        [StringLength(1000)]
        [Display(Name = "پیام")]
        public string Message { get; set; }

        [StringLength(100)]
        [Display(Name = "نام فایل ضمیمه")]
        public string AttachmentFileName { get; set; }


        [Display(Name = "فایل ضمیمه")]
        public HttpPostedFileBase AttachmentFile { get; set; }

        [StringLength(255)]
        //[RegularExpression("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$",ErrorMessage="ایمیل معتبر نیست")]
        [DataType(DataType.EmailAddress, ErrorMessage = "ایمیل معتبر وارد نمایید.")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }
}
