using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erep.DomainClasses.Models
{
    public class GoldPrice
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Display(Name = "تاریخ")]
        [Required(ErrorMessage = "تاریخ را وارد نمایید")]
        public DateTime DateTime { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "قیمت را وارد نمایید")]
        public double LowestPrice { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
