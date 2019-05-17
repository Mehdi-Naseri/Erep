using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Erep.ViewModels.ViewModels;
using Erep.CommonLibrary;

namespace Erep.Areas.WebApi.Controllers
{
    /// <summary>
    /// برگرداندن کمترین قیمت گولد در حال حاضر
    /// </summary>
    public class GoldPriceController : ApiController
    {
        /// <summary>
        /// کمترین قیمت گلد در حال حاضر برگردانده میشود
        /// </summary>
        /// <returns></returns>
        public GoldPriceViewModel Get()
        {
            GoldPriceViewModel GoldPriceViewModel1 = new GoldPriceViewModel();

            PersianDateTime PersianDateTime1 = new PersianDateTime();
            //دریافت قیمت فعلی کلد
            GoldPriceViewModel1.LowestPrice = 1;
            GoldPriceViewModel1.DateTime = PersianDateTime1.GregorianToShamsi(DateTime.UtcNow);
            return GoldPriceViewModel1;
        }
    }
}
