using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cuoiki.Models;

namespace cuoiki.Areas.admin.Controllers
{
    public class AboutsController : SecurityController
    {
        private barbecue db = new barbecue();

        // GET: admin/Abouts
        public ActionResult Index()
        {
            return View(db.About.ToList());
        }

        // GET: admin/Abouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.About.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // GET: admin/Abouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Abouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,title,content,img,hide,datebegin")] About about, HttpPostedFileBase fileImage)
        {
            if (ModelState.IsValid)
            {
                if (fileImage != null)
                {
                    var path = "";
                    var filename = "";
                    filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + fileImage.FileName;
                    path = Path.Combine(Server.MapPath("~/Uploads/images/about"), filename);
                    fileImage.SaveAs(path);
                    about.img = filename;
                }
                else
                {
                    about.img = "logo.png";
                }
                about.datebegin = DateTime.Now;
                db.About.Add(about);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(about);
        }

        // GET: admin/Abouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.About.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: admin/Abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,title,content,img,hide,datebegin")] About about, HttpPostedFileBase fileImage)
        {
            if (ModelState.IsValid)
            {
                if (fileImage != null)
                {
                    var path = "";
                    var filename = "";
                    filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + fileImage.FileName;
                    path = Path.Combine(Server.MapPath("~/Uploads/images/about"), filename);
                    fileImage.SaveAs(path);
                    about.img = filename;
                }
                else
                {
                    about.img = db.About.Find(about.id).img;
                }
                about.datebegin = DateTime.Now;
                db.About.AddOrUpdate(about);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }

        // GET: admin/Abouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.About.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: admin/Abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            About about = db.About.Find(id);
            db.About.Remove(about);
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
    }
}
