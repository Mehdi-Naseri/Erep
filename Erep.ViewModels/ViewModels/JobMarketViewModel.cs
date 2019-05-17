using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Erep.ViewModels.ViewModels
{
    public class JobMarketViewModel
    {
        [Display(Name = "کشور")]
        [Required]
        public string Country { get; set; }

        [Display(Name = "کد کشور")]
        [Required]
        public int CountryCode { get; set; }

        [Display(Name = "کارفرما")]
        [Required]
        public string Employer { get; set; }

        [Display(Name = "لینک")]
        [Required]
        public string Link { get; set; }

        [Display(Name = "حقوق")]
        [Required]
        public double Salary { get; set; }

        [Display(Name = "حقوق خالص")]
        [Required]
        public double NetSalary { get; set; }
    }
}
