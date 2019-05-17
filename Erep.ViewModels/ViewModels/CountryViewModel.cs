using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Erep.ViewModels.ViewModels
{
    public class CountryViewModel
    {
        [Key]
        [Display(Name = "ردیف")]
        [Required]
        public int Id;

        [Display(Name = "کشور")]
        [Required]
        public string Name;

        [Display(Name = "کشور")]
        [Required]
        public string NamePersian;
    }
}
