using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Erep.ViewModels.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Erep.Areas.Analyze.Controllers
{
    public class GoldPriceController : Controller
    {
        //
        // GET: /Read/GoldPrice/
        public ActionResult Index()
        {
            GoldPriceViewModel GoldPriceNow = new GoldPriceViewModel();
            string WebApiHostAddress = System.Configuration.ConfigurationManager.AppSettings["WebApiHostAddress"];
            string StringApiUrl = WebApiHostAddress + "/api/GoldPrice";
            using (HttpClient HttpClient = new HttpClient())
            {
                Task<string> response = HttpClient.GetStringAsync(StringApiUrl);
                GoldPriceNow = JsonConvert.DeserializeObjectAsync<GoldPriceViewModel>(response.Result).Result;
            }
            return View(GoldPriceNow);
        }
	}
}