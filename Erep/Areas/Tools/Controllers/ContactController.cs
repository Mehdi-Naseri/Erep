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

using Erep.CommonLibrary;

namespace Erep.Areas.Tools.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private ErepDbContext db = new ErepDbContext();

        // GET: /Tools/Contact/
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        // GET: /Tools/Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [AllowAnonymous]
        // GET: /Tools/Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Tools/Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Message,AttachmentFile,Email")] ContactViewModel ContactViewModel1)
        {
            if (ModelState.IsValid)
            {
                Contact Contact1 = new Contact();
                Contact1.Name = ContactViewModel1.Name;
                Contact1.Message = ContactViewModel1.Message;
                Contact1.Email = ContactViewModel1.Email;

                PersianDateTime PersianDateTime1 = new PersianDateTime();
                Contact1.MessageDateTime = PersianDateTime1.GregorianToShamsi(DateTime.Now);

                if (ContactViewModel1.AttachmentFile != null)
                {
                    Contact1.AttachmentFileName = ContactViewModel1.AttachmentFile.FileName;
                    byte[] uploadFile = new byte[ContactViewModel1.AttachmentFile.InputStream.Length];
                    ContactViewModel1.AttachmentFile.InputStream.Read(uploadFile, 0, uploadFile.Length);
                    Contact1.AttachmentFile = uploadFile;
                    //byte[] uploadFile = new byte[file1.InputStream.Length];
                    //file1.InputStream.Read(uploadFile, 0, uploadFile.Length);
                    //Contact1.AttachmentFile = uploadFile;
                }

                db.Contacts.Add(Contact1);
                db.SaveChanges();
                return RedirectToAction("Thanks");
            }

            return View(ContactViewModel1);
        }

        // GET: /Tools/Contact/Edit/5


        // POST: /Tools/Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Message,AttachmentName,MessageDateTime,Timestamp")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: /Tools/Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: /Tools/Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
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
        public ActionResult Thanks()
        {
            return View();
        }

        public FileContentResult Download(int? id)
        {
            byte[] fileData;
            string fileName;

            Contact fileRecord = db.Contacts.Find(id);

            fileData = (byte[])fileRecord.AttachmentFile.ToArray();
            fileName = fileRecord.AttachmentFileName;
            return File(fileData, "Text", fileName);
        }
    }
}
