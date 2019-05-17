using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erep.ViewModels.ViewModels
{
    public class MonetaryMarketViewModel
    {
        public IEnumerable<MonetaryMarketDateTimeViewModel> MonetaryMarketDateTimes { get; set; }
        public IEnumerable<MonetaryMarketHourlyViewModel> MonetaryMarketHourlys { get; set; }
    }
}
