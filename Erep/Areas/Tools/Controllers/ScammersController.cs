using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Erep.DataAccessLayer.DataContext;

using Erep.DataAccessLayer.IUnitOfWork;
using Erep.DomainClasses.Models;
using Erep.ViewModels.ViewModels;
using Erep.ServiceLayer.Interfaces;
using Erep.Extentions.MapperConfigure.Extention;

namespace Erep.Areas.Tools.Controllers
{
    public class ScammersController : Controller
    {
        private IUnitOfWorkErep _uow;
        private IScammerService _scammerService;
        public ScammersController(IUnitOfWorkErep uow, IScammerService projectService)
        {
            _uow = uow;
            _scammerService = projectService;
        }


        // GET: Tools/Scammers
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            IEnumerable<ScammerViewModel> a = _scammerService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        // GET: Tools/Scammers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scammer scammer = _scammerService.FindById((int)id);
            if (scammer == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", scammer.MapModelToViewModel());
        }

        // GET: Tools/Scammers/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: Tools/Scammers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Link,Description")] ScammerViewModel scammerViewModel)
        {
            ModelState.Remove("ReportedBy");
            if (ModelState.IsValid)
            {
                if (!_scammerService.Exist(scammerViewModel.Link))
                {
                    scammerViewModel.ReportedBy = (User.Identity.IsAuthenticated ? User.Identity.Name : "کاربر میهمان");
                    _scammerService.Add(scammerViewModel.MapViewModelToModel());
                    _uow.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    ModelState.AddModelError("DuplicateRecord", "این کلاهبردار قبلا ثبت گردیده است.");
                }
            }
            return PartialView("_Create", scammerViewModel);
        }

        // GET: Tools/Scammers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scammer scammer = _scammerService.FindById((int)id);
            if (scammer == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", scammer.MapModelToViewModel());
        }

        // POST: Tools/Scammers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Link,ReportedBy,Description")] ScammerViewModel scammerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_scammerService.FindById(scammerViewModel.Id).Name == scammerViewModel.Name ||
                        !_scammerService.Exist(scammerViewModel.Name))
                {
                    Scammer scammer = _scammerService.FindById(scammerViewModel.Id);
                    scammer.Name = scammerViewModel.Name;
                    scammer.Link = scammerViewModel.Link;
                    scammer.ReportedBy = scammerViewModel.ReportedBy;
                    scammer.Description = scammerViewModel.Description;
                    _uow.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    ModelState.AddModelError("DuplicateRecord", "این کلاهبردار قبلا ثبت گردیده است.");
                }
            }
            return PartialView("_Edit", scammerViewModel);
        }

        // GET: Tools/Scammers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scammer scammer = _scammerService.FindById((int)id);
            if (scammer == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", scammer.MapModelToViewModel());
        }

        // POST: Tools/Scammers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _scammerService.DeleteById(id);
            _uow.SaveChanges();
            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            base.Dispose(disposing);
        }
    }
}
