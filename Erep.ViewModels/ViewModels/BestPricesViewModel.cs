using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Erep.ViewModels.ViewModels
{
    public class BestPricesViewModel
    {
        [Display(Name = "کشور")]
        [Required]
        public string Country { get; set; }

        [Display(Name = "کد کشور")]
        [Required]
        public int CountryCode { get; set; }

        [Display(Name = "قیمت")]
        [Required]
        public double Price { get; set; }

        [Display(Name = "مقدار")]
        [Required]
        public int Unit { get; set; }

        [Display(Name = "تعداد پیشنهادات")]
        [Required]
        public int OffersCount { get; set; }
    }
}
