using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Erep.ViewModels.ViewModels
{
    public class PlayerInfo
    {
        [Key]
        [Display(Name = "شماره بازیکن")]
        [Required(ErrorMessage = "تاریخ را وارد نمایید")]
        public int Id { get; set; }

        [Display(Name = "قدرت")]
        [Required(ErrorMessage = "قیمت را وارد نمایید")]
        public int Strenght { get; set; }
    }
}
