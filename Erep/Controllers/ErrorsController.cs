using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Erep.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult Index()
        {
            //ExceptionLog(0);
            return View("Index");
        }
        public ActionResult NotFound()
        {
            //ExceptionLog(404);
            Response.StatusCode = 404;
            ViewBag.ErrorMessagePersian = "صفحه مورد نظر پیدا نشد.";
            //return View("NotFound");
            return View("Index");
        }
    }
}