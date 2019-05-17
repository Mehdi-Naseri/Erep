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
    /// برگرداندن بهترین قیمتها در حال حاضر
    /// </summary>
    public class BestPricesApiController : ApiController
    {
        /// <summary>
        /// برگرداندن بهترین حقوقها در حال حاضر
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            string UrlParameter = null;
            int intType, intSubtype = 1;
            if (id < 10)
            {
                switch (id)
                {
                    case 5:
                        intType = 7;
                        break;
                    case 6:
                        intType = 12;
                        break;
                    case 7:
                        intType = 17;
                        break;
                    //از یک تا چهار
                    default:
                        intType = id;
                        break;
                }
                
                UrlParameter = "?id=" + intType;
            }
            else
            {
                intType = id / 10;
                intSubtype = id % 10;
                UrlParameter = "?id=" + intType + "&calidad=" + intSubtype;
            }

            string URL = "http://erepublikanalyzer.com/MercadoRanking.aspx" + UrlParameter;
            try
            {
                WebRequest http = (HttpWebRequest)WebRequest.Create(URL);
                WebResponse response = http.GetResponse();
                System.IO.Stream stream = response.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(stream);
                string stringWebpage = sr.ReadToEnd();

                List<BestPricesViewModel> JsonResult = ExtractData(stringWebpage);
                BestPricesCollectionViewModel Result = new BestPricesCollectionViewModel();
                Result.BestPricesCollection = JsonResult;
                Result.ProductType = intType;
                Result.ProductSubType = intSubtype;
                return Ok(Result);
            }
            catch (Exception ex)
            {
                return NotFound();
                //stringJsonResult = ex.Message;
            }
        }


        private List<BestPricesViewModel> ExtractData(string stringWebpage)
        {
            List<BestPricesViewModel> result = new List<BestPricesViewModel>();
            string[] stringTableRows = stringWebpage.Split(new string[] { "<tr>" }, StringSplitOptions.None);

            foreach (string stringTableRow in stringTableRows.Skip(2))
            {
                try
                {
                    BestPricesViewModel BestPrice = new BestPricesViewModel();
                    string[] stringCountryCode = stringTableRow.Split(new string[] { "banderas/", ".png" }, StringSplitOptions.None);
                    BestPrice.CountryCode = int.Parse(stringCountryCode[1]);

                    //string[] stringCountry = stringTableRow.Split(new string[] { "alt='", "' title" }, StringSplitOptions.None);
                    //BestPrice.Country = stringCountry[1];

                    string[] stringDiv = stringTableRow.Split(new string[] { "<div>", "</div>", " cc" }, StringSplitOptions.None);
                    BestPrice.Price = double.Parse(stringDiv[15]);


                    BestPrice.Unit = int.Parse(stringDiv[4].Split(new string[] { "(" }, StringSplitOptions.None).First());

                    string[] stringNumber = stringDiv[4].Split(new string[] { "(", ")" }, StringSplitOptions.None);
                    //int intOffersCount;
                    if (stringNumber.Count() > 1)
                    {
                        BestPrice.OffersCount = int.Parse(stringNumber[1]);
                    }
                    else
                    {
                        BestPrice.OffersCount = 1;
                    }

                    CountryEntity CountryEntity = new DomainClasses.Entities.CountryEntity();
                    BestPrice.Country = CountryEntity.Countries.First(r => r.Id == BestPrice.CountryCode).NamePersian;

                    //string stringFileStreamPath = "http://erepublikanalyzer.com/" + stringTableCot[5];
                    //using (System.IO.FileStream FileStream = new System.IO.FileStream(stringFileStreamPath,System.IO.FileMode.Open,System.IO.FileAccess.Read))
                    //{
                    //    FileStream.Read(JobMarket.CountryFlag,0,System.Convert.ToInt32(FileStream.Length));
                    //    FileStream.Close();
                    //}

                    result.Add(BestPrice);
                }
                catch (Exception ex)
                {
                    string test = ex.Message;
                }
            }
            return result;
        }
    }
}
