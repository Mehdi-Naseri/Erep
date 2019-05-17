using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Erep.ViewModels.ViewModels
{
    public class MonetaryMarketDateTimeViewModel
    {
        [Display(Name = "تاریخ و ساعت")]
        [Required]
        public DateTime DateTime { get; set; }

        [Display(Name = "حداقل")]
        [Required]
        public Double Min { get; set; }

        [Display(Name = "حداکثر")]
        [Required]
        public Double Max { get; set; }

        [Display(Name = "میانگین")]
        [Required]
        public Double Avg { get; set; }
    }
}
