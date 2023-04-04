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
    public class SlidesShowsController : SecurityController
    {
        private barbecue db = new barbecue();

        // GET: admin/SlidesShows
        public ActionResult Index()
        {
            return View(db.SlidesShow.ToList());
        }

        // GET: admin/SlidesShows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlidesShow slidesShow = db.SlidesShow.Find(id);
            if (slidesShow == null)
            {
                return HttpNotFound();
            }
            return View(slidesShow);
        }

        // GET: admin/SlidesShows/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/SlidesShows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSlidesShow,title,description,link,meta,hide,order,datebegin")] SlidesShow slidesShow)
        {
            if (ModelState.IsValid)
            {
                db.SlidesShow.Add(slidesShow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slidesShow);
        }

        // GET: admin/SlidesShows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlidesShow slidesShow = db.SlidesShow.Find(id);
            if (slidesShow == null)
            {
                return HttpNotFound();
            }
            return View(slidesShow);
        }

        // POST: admin/SlidesShows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSlidesShow,title,description,link,meta,hide,order,datebegin")] SlidesShow slidesShow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slidesShow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slidesShow);
        }

        // GET: admin/SlidesShows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlidesShow slidesShow = db.SlidesShow.Find(id);
            if (slidesShow == null)
            {
                return HttpNotFound();
            }
            return View(slidesShow);
        }

        // POST: admin/SlidesShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SlidesShow slidesShow = db.SlidesShow.Find(id);
            db.SlidesShow.Remove(slidesShow);
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
