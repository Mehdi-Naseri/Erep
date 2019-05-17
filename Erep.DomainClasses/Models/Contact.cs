using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erep.DomainClasses.Models
{
    [Table("Contact", Schema = "Erep")]
    public class Contact
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }

        [MaxLength(100)]
        public string AttachmentFileName { get; set; }

        public byte[] AttachmentFile { get; set; }

        [MaxLength(255)]
        //[RegularExpression("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$", ErrorMessage = "ایمیل معتبر نیست")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public System.DateTime MessageDateTime { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
