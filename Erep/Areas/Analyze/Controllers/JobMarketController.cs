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
    public class JobMarketController : Controller
    {
        //
        // GET: /Read/JobMarket/
        public ActionResult Index()
        {
            List<JobMarketViewModel> result = new List<JobMarketViewModel>();
            string stringHost = Request.ServerVariables.GetValues("HTTP_HOST")[0];
            string StringApiUrl = "http://" + stringHost + "/api/JobMarketApi";
            using (HttpClient HttpClient = new HttpClient())
            {
                Task<string> response = HttpClient.GetStringAsync(StringApiUrl);
                result = JsonConvert.DeserializeObjectAsync<List<JobMarketViewModel>>(response.Result).Result;
            }
            return View(result);
        }
    }
}