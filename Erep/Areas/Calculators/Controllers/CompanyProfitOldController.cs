using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Erep.Areas.Calculators.Controllers
{
    public class CompanyProfitOldController : Controller
    {
        //
        // GET: /Calculators/CompanyProfit/
        public ActionResult Index()
        {
            List<SelectListItem> itemsWorkerType = new List<SelectListItem>();
            itemsWorkerType.Add(new SelectListItem { Text = "بدون کارگر", Value = "0", Selected = true });
            itemsWorkerType.Add(new SelectListItem { Text = "با یک کارگر", Value = "1" });
            ViewBag.WorkerType = itemsWorkerType;
            return View();
        }

        public JsonResult GetCompanyTypes(int id)
        {
            List<SelectListItem> CompanyTypes = new List<SelectListItem>();
            int caseSwitch = id;
            switch (caseSwitch)
            {
                case 0:
                    CompanyTypes.Add(new SelectListItem { Value = "0-1", Text = "مواد اولیه غذا", Selected = true });
                    CompanyTypes.Add(new SelectListItem { Value = "0-2", Text = "مواد اولیه اسلحه" });
                    CompanyTypes.Add(new SelectListItem { Value = "0-3", Text = "غذا" });
                    CompanyTypes.Add(new SelectListItem { Value = "0-4", Text = "اسلحه" });
                    break;
                case 1:
                    CompanyTypes.Add(new SelectListItem { Value = "1-1", Text = "مواد اولیه غذا", Selected = true });
                    CompanyTypes.Add(new SelectListItem { Value = "1-2", Text = "مواد اولیه اسلحه" });
                    CompanyTypes.Add(new SelectListItem { Value = "1-3", Text = "مواد اولیه خانه" });
                    CompanyTypes.Add(new SelectListItem { Value = "1-4", Text = "غذا" });
                    CompanyTypes.Add(new SelectListItem { Value = "1-5", Text = "اسلحه" });
                    CompanyTypes.Add(new SelectListItem { Value = "1-6", Text = "خانه" });
                    break;
                default:
                    break;
            }
            return Json(CompanyTypes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanyQuality(string id)
        {
            List<SelectListItem> CompanyQuality = new List<SelectListItem>();
            string caseSwitch = id;
            switch (caseSwitch)
            {
                    //کار خانه های غذا و اسلحه
                case "0-3":
                case "0-4":
                case "1-4":
                case "1-5":
                    CompanyQuality.Add(new SelectListItem { Value = "1", Text = "1", Selected = true });
                    CompanyQuality.Add(new SelectListItem { Value = "2", Text = "2" });
                    CompanyQuality.Add(new SelectListItem { Value = "3", Text = "3" });
                    CompanyQuality.Add(new SelectListItem { Value = "4", Text = "4" });
                    CompanyQuality.Add(new SelectListItem { Value = "5", Text = "5" });
                    CompanyQuality.Add(new SelectListItem { Value = "6", Text = "6" });
                    CompanyQuality.Add(new SelectListItem { Value = "7", Text = "7" });
                    break;
                    //سایر کارخانه ها 
                default:
                    CompanyQuality.Add(new SelectListItem { Value = "1", Text = "1", Selected = true });
                    CompanyQuality.Add(new SelectListItem { Value = "2", Text = "2" });
                    CompanyQuality.Add(new SelectListItem { Value = "3", Text = "3" });
                    CompanyQuality.Add(new SelectListItem { Value = "4", Text = "4" });
                    CompanyQuality.Add(new SelectListItem { Value = "5", Text = "5" });
                    break;
            }
            return Json(CompanyQuality, JsonRequestBehavior.AllowGet);
        }
    }
}