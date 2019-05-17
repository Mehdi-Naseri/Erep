using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Erep.ViewModels.ViewModels
{
    public class ScammerViewModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "نام کلاهبردار را وارد نمایید")]
        [StringLength(100)]
        [Display(Name = "نام کلاهبردار")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لینک کلاهبردار را وارد نمایید")]
        [StringLength(500)]
        [Display(Name = "لینک کلاهبردار")]
        public string Link { get; set; }

        [Required(ErrorMessage = "نام خود را وارد نمایید")]
        [StringLength(100)]
        [Display(Name = "ثبت کننده")]
        public string ReportedBy { get; set; }

        [StringLength(1000)]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }
}
