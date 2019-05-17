using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erep.DomainClasses.Models
{
    [Table("Log", Schema = "Management")]
    public class Log
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Display(Name = "تاریخ")]
        [Required(ErrorMessage = "تاریخ را وارد نمایید")]
        public DateTime DateTime { get; set; }

        [Display(Name = "عنوان پیام")]
        [Required(ErrorMessage = "عنوان پیام را وارد نمایید")]
        public string MessageTitle { get; set; }

        [Display(Name = "پیام")]
        [Required(ErrorMessage = "پیام را وارد نمایید")]
        public string Message { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
