using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Erep.ViewModels.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

//چارت
using System.Web.Helpers;
using System.Collections;

namespace Erep.Areas.Analyze.Controllers
{
    public class MonetaryMarketController : Controller
    {

        //
        // GET: /Analyze/MonetaryMarket/
        public ActionResult Index()
        {
            MonetaryMarketViewModel result = new MonetaryMarketViewModel();
            //List<MonetaryMarketHourlyViewModel> result = new List<MonetaryMarketHourlyViewModel>();
            string stringHost = Request.ServerVariables.GetValues("HTTP_HOST")[0];
            string StringApiUrl = "http://" + stringHost + "/api/MonetaryMarketApi";
            using (HttpClient HttpClient = new HttpClient())
            {
                Task<string> response = HttpClient.GetStringAsync(StringApiUrl);
                result = JsonConvert.DeserializeObjectAsync<MonetaryMarketViewModel>(response.Result).Result;
            }

            TempData["MonetaryMarketHourlyList"] = result.MonetaryMarketHourlys;
            TempData["MonetaryMarketDateTimeList"] = result.MonetaryMarketDateTimes;
            return View();
        }

        #region نمودارها
        public ActionResult GetChartImage1()
        {
            List<MonetaryMarketDateTimeViewModel> result = (List<MonetaryMarketDateTimeViewModel>)TempData["MonetaryMarketDateTimeList"];
            ArrayList xValue = new ArrayList();
            ArrayList yValueMax = new ArrayList();
            ArrayList yValueAvg = new ArrayList();
            ArrayList yValueMin = new ArrayList();
            result.ToList().ForEach(rs => xValue.Add(rs.DateTime));
            result.ToList().ForEach(rs => yValueMax.Add(rs.Max));
            result.ToList().ForEach(rs => yValueAvg.Add(rs.Avg));
            result.ToList().ForEach(rs => yValueMin.Add(rs.Min));

            //IEnumerable<double> yValueMin = result.Select(r => r.Min);

            var key = new Chart(width: 800, height: 300, theme: ChartTheme.Blue)
                .AddTitle("تغییرات لحظه ای قیمت ارز در یک روز")
                .SetXAxis("تاریخ",min: result.First().DateTime.ToOADate())
                .SetYAxis("قیمت", min: result.Select(r => r.Min).Min() - 1, max: result.Select(r => r.Max).Max() + 1)
                .AddSeries(
                        chartType: "Line",
                        name: "حداکثر",
                        xValue: xValue,
                        yValues: yValueMax)
                .AddSeries(
                        chartType: "Line",
                        name: "میانگین",
                        xValue: xValue,
                        yValues: yValueAvg)
                .AddSeries(
                        chartType: "Line",
                        name: "حداقل",
                        xValue: xValue,
                        yValues: yValueMin)
                .AddLegend()
                ;
            return File(key.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult GetChartImage2()
        {
            List<MonetaryMarketHourlyViewModel> result = (List<MonetaryMarketHourlyViewModel>)TempData["MonetaryMarketHourlyList"];
            ArrayList xValue = new ArrayList();
            ArrayList yValueMax = new ArrayList();
            ArrayList yValueAvg = new ArrayList();
            ArrayList yValueMin = new ArrayList();
            result.ToList().ForEach(rs => xValue.Add(rs.hour));
            result.ToList().ForEach(rs => yValueMax.Add(rs.Max));
            result.ToList().ForEach(rs => yValueAvg.Add(rs.Avg));
            result.ToList().ForEach(rs => yValueMin.Add(rs.Min));

            //IEnumerable<double> yValueMin = result.Select(r => r.Min);

            var key = new Chart(width: 800, height: 300,theme: ChartTheme.Blue)
                .AddTitle("تغییرات ساعتی قیمت ارز در یک روز")
                .SetXAxis("ساعت",min:0,max:24)
                .SetYAxis("قیمت", min: result.Select(r => r.Min).Min()-1, max: result.Select(r => r.Max).Max()+1)
                .AddSeries(
                        chartType: "Line",
                        name: "حداکثر",
                        markerStep: 1,
                        xValue: xValue,
                        yValues: yValueMax)
                .AddSeries(
                        chartType: "Line",
                        name: "میانگین",
                        markerStep: 1,
                        xValue: xValue,
                        yValues: yValueAvg)
                .AddSeries(
                        chartType: "Line",
                        name: "حداقل",
                        markerStep: 1,
                        xValue: xValue,
                        yValues: yValueMin)
                .AddLegend()
                ;
            return File(key.ToWebImage().GetBytes(), "image/jpeg");
        }

        private string ChartStyleTemplate =
            @"<chart backcolor=""lightgray"" forecolor=""blue"">
                <chartareas>
                    <chartarea name=""default"" backcolor=""pink""></chartarea>
                </chartareas>
                <legends>
                    <legend _template_=""all"" backcolor="" transparent"" font=""trebuchet ms, 8.25pt, style=Bold"" istextautofit=""false"" />
                </legends>
                <borderskin skinstyle=""emboss"" />
            </chart>";
        #endregion
    }
}