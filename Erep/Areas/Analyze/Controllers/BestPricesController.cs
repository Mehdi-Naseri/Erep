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
    public class BestPricesController : Controller
    {
        //
        // GET: /Analyze/BestPrices/
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GetData(int id)
        {
            BestPricesCollectionViewModel result = new BestPricesCollectionViewModel();
            string stringHost = Request.ServerVariables.GetValues("HTTP_HOST")[0];
            string StringApiUrl = "http://" + stringHost + "/api/BestPricesApi/" + id;
            using (HttpClient HttpClient = new HttpClient())
            {
                Task<string> response = HttpClient.GetStringAsync(StringApiUrl);
                result = JsonConvert.DeserializeObjectAsync<BestPricesCollectionViewModel>(response.Result).Result;
            }
            if (!Request.IsAjaxRequest())
                return View();
            else
                return PartialView("_BestPrices", result);
        }
    }
}