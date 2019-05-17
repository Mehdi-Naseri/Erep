using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Erep.ViewModels.ViewModels
{
    class LogViewModel
    {
        [Display(Name = "پیام")]
        [Required(ErrorMessage = "پیام را وارد نمایید")]
        public string Message { get; set; }
    }
}
