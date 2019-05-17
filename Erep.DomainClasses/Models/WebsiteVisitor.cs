using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erep.DomainClasses.Models
{
    [Table("WebsiteVisitor", Schema = "Management")]
    public class WebsiteVisitor
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "تاریخ")]
        public System.DateTime Date { get; set; }
        [Required]
        [Display(Name = "آدرس")]
        public string HostAddress { get; set; }
        [Required]
        [Display(Name = "نام سیستم")]
        public string HostName { get; set; }
        [Required]
        [Display(Name = "مرورگر")]
        public string Browser { get; set; }
        [Required]
        [Display(Name = "آدرس")]
        public string Url { get; set; }
        [Display(Name = "آدرس ارجاع")]
        public string UrlReferrer { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
