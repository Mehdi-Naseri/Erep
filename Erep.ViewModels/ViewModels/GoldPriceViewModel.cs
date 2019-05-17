using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Erep.ViewModels.ViewModels
{
    public class GoldPriceViewModel
    {
        [Display(Name = "تاریخ")]
        [Required(ErrorMessage = "تاریخ را وارد نمایید")]
        public DateTime DateTime { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "قیمت را وارد نمایید")]
        public double LowestPrice { get; set; }
    }
}
