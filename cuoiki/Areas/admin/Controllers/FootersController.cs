using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cuoiki.Models;

namespace cuoiki.Areas.admin.Controllers
{
    public class FootersController : SecurityController
    {
        private barbecue db = new barbecue();

        // GET: admin/Footers
        public ActionResult Index()
        {
            return View(db.Footer.ToList());
        }

        // GET: admin/Footers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footer footer = db.Footer.Find(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // GET: admin/Footers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Footers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFooter,timeOpen,intro,address,email,sdt,hide,datebegin")] Footer footer)
        {
            if (ModelState.IsValid)
            {
                footer.datebegin = DateTime.Now;
                db.Footer.Add(footer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footer);
        }

        // GET: admin/Footers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footer footer = db.Footer.Find(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // POST: admin/Footers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFooter,timeOpen,intro,address,email,sdt,hide,datebegin")] Footer footer)
        {
            if (ModelState.IsValid)
            {
                footer.datebegin = DateTime.Now;
                db.Entry(footer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footer);
        }

        // GET: admin/Footers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footer footer = db.Footer.Find(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // POST: admin/Footers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Footer footer = db.Footer.Find(id);
            db.Footer.Remove(footer);
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
