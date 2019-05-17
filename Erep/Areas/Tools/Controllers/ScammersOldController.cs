using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Erep.DomainClasses.Models;
using Erep.ViewModels.ViewModels;
using Erep.DataAccessLayer.DataContext;
using System.Text;

namespace Erep.Areas.Tools.Controllers
{
    [Authorize(Roles = "Admin , ScammerAdmin")]
    public class ScammersOldController : Controller
    {
        private ErepDbContext db = new ErepDbContext();
        //[AllowAnonymous]
        // GET: /Tools/ScammersList/
        //public ActionResult Index()
        //{
        //    return View(db.Scammers.ToList());

        //}

        [AllowAnonymous]
        public ActionResult Index(string SortBy = null, bool SortOrder = true)
        {
            IEnumerable<Scammer> Scammers = db.Scammers;
            if (!String.IsNullOrEmpty(SortBy))
            {
                if (SortOrder)
                {
                    Scammers = Scammers.OrderBy(i => i.GetType().GetProperty(SortBy).GetValue(i, null)).ToList();
                }
                else
                {
                    Scammers = Scammers.OrderByDescending(i => i.GetType().GetProperty(SortBy).GetValue(i, null)).ToList();
                }
            }
            ViewBag.NameSortOrder = SortBy == "Name" ? !SortOrder : true;
            ViewBag.LinkSortOrder = SortBy == "Link" ? !SortOrder : true;
            ViewBag.ReportedBySortOrder = SortBy == "ReportedBy" ? !SortOrder : true;
            ViewBag.DescriptionSortOrder = SortBy == "Description" ? !SortOrder : true;
            //switch (SortBy)
            //{
            //    case "Name"
            //        Scammers.OrderBy( r => r.Name );
            //        break;
            //    case "Link":
            //        Scammers.OrderBy(r => r.Link);
            //        break;
            //    case "ReportedBy":
            //        Scammers.OrderBy(r => r.ReportedBy);
            //        break;
            //    case "Description":
            //        Scammers.OrderBy(r => r.Description);
            //        break;
            return View(Scammers.ToList());
        }

        [AllowAnonymous]
        // GET: /Tools/ScammersList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return HttpNotFound();
            }
            Scammer scammer = db.Scammers.Find(id);
            if (scammer == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", scammer);
        }

        // GET: /Tools/ScammersList/Create
        [Authorize(Roles = "Admin , ScammerAdmin , ScammerCreator")]
        public ActionResult Create()
        {
            //return PartialView("_Create");
            var ScammerViewModel = new ScammerViewModel();
            return PartialView("_Create", ScammerViewModel);
        }

        // POST: /Tools/ScammersList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin , ScammerAdmin , ScammerCreator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Link,ReportedBy,Description")] ScammerViewModel ScammerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!db.Scammers.Any(r => r.Link == ScammerViewModel.Link))
                {
                    Scammer scammer = new Scammer();
                    scammer.Name = ScammerViewModel.Name;
                    scammer.Link = ScammerViewModel.Link;
                    scammer.Description = ScammerViewModel.Description;
                    scammer.ReportedBy = User.Identity.Name;
                    db.Scammers.Add(scammer);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                else
                    ModelState.AddModelError("", "پروفایل شخص مورد نظر قبلا در لیست ثبت شده است.");

            }
            return PartialView("_Create", ScammerViewModel);
            //return Json(scammer, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Admin , ScammerAdmin")]
        // GET: /Tools/ScammersList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return HttpNotFound();
            }
            Scammer scammer = db.Scammers.Find(id);
            if (scammer == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", scammer);
        }

        [Authorize(Roles = "Admin , ScammerAdmin ")]
        // POST: /Tools/ScammersList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Link,ReportedBy,Description")] Scammer scammer)
        {
            if (ModelState.IsValid)
            {
                if (!db.Scammers.Any(r => r.Link == scammer.Link))
                {
                    db.Entry(scammer).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true });
                    //return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "پروفایل شخص مورد نظر قبلا در لیست ثبت شده است.");
                }
            }
            return PartialView("_Edit", scammer);
        }

        [Authorize(Roles = "Admin , ScammerAdmin")]
        // GET: /Tools/ScammersList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return HttpNotFound();
            }
            Scammer scammer = db.Scammers.Find(id);
            if (scammer == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", scammer);
        }

        [Authorize(Roles = "Admin , ScammerAdmin")]
        // POST: /Tools/ScammersList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scammer scammer = db.Scammers.Find(id);
            db.Scammers.Remove(scammer);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [AllowAnonymous]
        public void ExportExcel()
        {
            IEnumerable<Scammer> Scammers = db.Scammers;
            //if (Scammers != null)
            //{
            System.Web.UI.WebControls.GridView GridView1 = new System.Web.UI.WebControls.GridView();
            GridView1.DataSource = Scammers.Select(r => new { r.Name, r.Link, r.ReportedBy, r.Description }).ToList();
            GridView1.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Scammers.xls");
            //Response.ContentType = "application/ms-excel";
            Response.ContentType = "application/vnd.ms-excel";

            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            Response.Charset = "";
            System.IO.StringWriter StringWriter1 = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter HtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(StringWriter1);
            GridView1.RenderControl(HtmlTextWriter1);
            //string style1 = @"<style> .textmode {mso-number-format:General}</style>";
            string style = @"<style> TD {mso-number-format:\@;}</style>";
            Response.Output.Write(style);
            Response.Output.Write(StringWriter1.ToString());
            Response.Flush();
            Response.End();
            //}
            //else
            //{
            //    ModelState.AddModelError("", "هیچ موردی جهت نمایش وجود ندارد");
            //    //return RedirectToAction("Index");
            //    //return Content("There is no item to display.");
            //}
        }
    }
}
