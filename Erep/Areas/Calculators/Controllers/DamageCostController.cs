using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Erep.Areas.Calculators.Controllers
{
    public class DamageCostController : Controller
    {
        //
        // GET: /Tools/DamageCost/
        public ActionResult Index()
        {
            Erep.DomainClasses.Entities.Rank Rank = new DomainClasses.Entities.Rank();

            List<SelectListItem> items = new List<SelectListItem>();
            for (int i = 0; i < Rank.Ranks.Count; i++)
            {
                items.Add(new SelectListItem { Text = Rank.Ranks[i], Value = i.ToString() });
            }
            ViewBag.Ranks = items;

            return View();
        }
	}
}