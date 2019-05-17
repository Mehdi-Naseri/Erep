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
    public class JobMarketApiController : ApiController
    {
        /// <summary>
        /// برگرداندن بهترین حقوقها در حال حاضر
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            string URL = "http://erepublikanalyzer.com/MercadoLaboral.aspx";
            try
            {
                WebRequest http = (HttpWebRequest)WebRequest.Create(URL);
                WebResponse response = http.GetResponse();
                System.IO.Stream stream = response.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(stream);
                string stringWebpage = sr.ReadToEnd();

                List<JobMarketViewModel> JsonResult = ExtractData(stringWebpage);
                return Ok(JsonResult);
            }
            catch (Exception ex)
            {
                return NotFound();
                //stringJsonResult = ex.Message;
            }
        }

        private List<JobMarketViewModel> ExtractData(string stringWebpage)
        {
            List<JobMarketViewModel> result = new List<JobMarketViewModel>();
            string[] stringTableRowSeprators = new string[] { "<tr>" };
            string[] stringTableRows = stringWebpage.Split(stringTableRowSeprators, StringSplitOptions.None);

            foreach (string stringTableRow in stringTableRows.Skip(2))
            {
                JobMarketViewModel JobMarket = new JobMarketViewModel();

                string[] stringTableDivSeprators = new string[] { "<div>" };
                string[] stringTableDiv = stringTableRow.Split(stringTableDivSeprators, StringSplitOptions.None);
                JobMarket.Employer = stringTableDiv[1].Split(new string[] { "</div>" }, StringSplitOptions.None).FirstOrDefault().Trim();
                JobMarket.Salary = double.Parse(stringTableDiv[2].Split(new char[] { ' ' }).FirstOrDefault().Trim());
                JobMarket.NetSalary = double.Parse(stringTableDiv[3].Split(new char[] { ' ' }).FirstOrDefault().Trim());

                char[] stringTableCotSeprators = new char[] { '\'' };
                string[] stringTableCot = stringTableRow.Split(stringTableCotSeprators, StringSplitOptions.None);

                JobMarket.CountryCode = int.Parse(stringTableCot[1].Split(new char[] { '/' }).Last());
                //JobMarket.Country = stringTableCot[5];
                CountryEntity CountryEntity = new DomainClasses.Entities.CountryEntity();
                JobMarket.Country = CountryEntity.Countries.First(r => r.Id == JobMarket.CountryCode).NamePersian;

                //string stringFileStreamPath = "http://erepublikanalyzer.com/" + stringTableCot[5];
                //using (System.IO.FileStream FileStream = new System.IO.FileStream(stringFileStreamPath,System.IO.FileMode.Open,System.IO.FileAccess.Read))
                //{
                //    FileStream.Read(JobMarket.CountryFlag,0,System.Convert.ToInt32(FileStream.Length));
                //    FileStream.Close();
                //}

                result.Add(JobMarket);
            }
            //JobMarketViewModel JobMarketTest = new JobMarketViewModel() { Country = "Iran", Employer = "Test", Link = "test", Salary = 49.00, NetSalary = 45.00 };
            //result.Add(JobMarketTest);
            return result;
        }
    }


}
