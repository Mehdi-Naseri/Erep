using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Erep.ViewModels.ViewModels;
using System.Text;
using Erep.DomainClasses.Entities;

namespace Erep.Areas.WebApi.Controllers
{
    /// <summary>
    /// برگرداندن بهترین حقوقها در حال حاضر
    /// </summary>
    public class MonetaryMarketApiController : ApiController
    {
        /// <summary>
        /// برگرداندن تغییرات قیمت ارز
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            string URL = "http://erepublikanalyzer.com/MercadoMonetario.aspx";
            try
            {
                WebRequest http = (HttpWebRequest)WebRequest.Create(URL);
                WebResponse response = http.GetResponse();
                System.IO.Stream stream = response.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(stream);
                string stringWebpage = sr.ReadToEnd();

                MonetaryMarketViewModel JsonResult = ExtractData(stringWebpage);
                return Ok(JsonResult);
            }
            catch (Exception ex)
            {
                return NotFound();
                //stringJsonResult = ex.Message;
            }
        }

        private MonetaryMarketViewModel ExtractData(string stringWebpage)
        {
            MonetaryMarketViewModel result = new MonetaryMarketViewModel();
            string[] stringChartSeprators = new string[] { "RadHtmlChart" };
            string[] stringChart = stringWebpage.Split(stringChartSeprators, StringSplitOptions.None);

            //خواندن اطلاعات چارت اول
            string stringTableChart1 = stringChart[1];
            List<MonetaryMarketDateTimeViewModel> ListMonetaryMarketDateTime = new List<MonetaryMarketDateTimeViewModel>();
            string Stringchart1Data = stringTableChart1.Split(new string[] { "[{", "}]" }, StringSplitOptions.None).Skip(1).First();
            string[] Stringchart1Items = Stringchart1Data.Split(new char[] { '{' }, StringSplitOptions.None);
            foreach (string StringchartItem in Stringchart1Items)
            {
                MonetaryMarketDateTimeViewModel MonetaryMarketDateTime = new MonetaryMarketDateTimeViewModel();
                string[] StringchartItemsField = StringchartItem.Split(new string[] { "\":", "," }, StringSplitOptions.None);
                MonetaryMarketDateTime.DateTime = DateTime.Parse(StringchartItemsField[13].Trim(new char[]{'"','\\'}));
                MonetaryMarketDateTime.Max = double.Parse(StringchartItemsField[15]);
                MonetaryMarketDateTime.Min = double.Parse(StringchartItemsField[17]);
                MonetaryMarketDateTime.Avg = double.Parse(StringchartItemsField[19].Substring(0, StringchartItemsField[19].Length - 1));
                ListMonetaryMarketDateTime.Add(MonetaryMarketDateTime);
            }


            //خواندن اطلاعات چارت دوم
            string stringTableChart2 = stringChart[2];
            List<MonetaryMarketHourlyViewModel> ListMonetaryMarketHourly = new List<MonetaryMarketHourlyViewModel>();
            string Stringchart2Data = stringTableChart2.Split(new string[] { "[{", "}]" }, StringSplitOptions.None).Skip(1).First();
            string[] Stringchart2Items = Stringchart2Data.Split(new char[] { '{' }, StringSplitOptions.None);
            foreach (string StringchartItem in Stringchart2Items)
            {
                MonetaryMarketHourlyViewModel MonetaryMarketHourly = new MonetaryMarketHourlyViewModel();
                string[] StringchartItemsField = StringchartItem.Split(new char[] { ':', ',' }, StringSplitOptions.None);
                MonetaryMarketHourly.hour = int.Parse(StringchartItemsField[1]);
                MonetaryMarketHourly.Max = double.Parse(StringchartItemsField[3]);
                MonetaryMarketHourly.Min = double.Parse(StringchartItemsField[5]);
                MonetaryMarketHourly.Avg = double.Parse(StringchartItemsField[7].Substring(0, StringchartItemsField[7].Length-1));
                ListMonetaryMarketHourly.Add(MonetaryMarketHourly);
            }

            result.MonetaryMarketDateTimes = ListMonetaryMarketDateTime;
            result.MonetaryMarketHourlys = ListMonetaryMarketHourly;
            //result.Add();
            //JobMarketViewModel JobMarketTest = new JobMarketViewModel() { Country = "Iran", Employer = "Test", Link = "test", Salary = 49.00, NetSalary = 45.00 };
            //result.Add(JobMarketTest);
            return result;
        }
    }
}
