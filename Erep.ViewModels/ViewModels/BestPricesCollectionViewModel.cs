using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Erep.ViewModels.ViewModels
{
    public class BestPricesCollectionViewModel
    {
        [Display(Name = "نوع")]
        [Required]
        public int ProductType { get; set; }

        [Display(Name = "نوع زیر مجموعه")]
        [Required]
        public int ProductSubType { get; set; }

        public virtual ICollection<BestPricesViewModel> BestPricesCollection { get; set; }
    }

}
