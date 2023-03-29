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
    public class MenuBarsController : Controller
    {
        private barbecue db = new barbecue();

        // GET: admin/MenuBars
        public ActionResult Index()
        {
            return View(db.MenuBar.ToList());
        }

        // GET: admin/MenuBars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuBar menuBar = db.MenuBar.Find(id);
            if (menuBar == null)
            {
                return HttpNotFound();
            }
            return View(menuBar);
        }

        // GET: admin/MenuBars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/MenuBars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMenuBar,name,link,meta,hide,order,datebegin")] MenuBar menuBar)
        {
            if (ModelState.IsValid)
            {
                db.MenuBar.Add(menuBar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuBar);
        }

        // GET: admin/MenuBars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuBar menuBar = db.MenuBar.Find(id);
            if (menuBar == null)
            {
                return HttpNotFound();
            }
            return View(menuBar);
        }

        // POST: admin/MenuBars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMenuBar,name,link,meta,hide,order,datebegin")] MenuBar menuBar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuBar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuBar);
        }

        // GET: admin/MenuBars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuBar menuBar = db.MenuBar.Find(id);
            if (menuBar == null)
            {
                return HttpNotFound();
            }
            return View(menuBar);
        }

        // POST: admin/MenuBars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuBar menuBar = db.MenuBar.Find(id);
            db.MenuBar.Remove(menuBar);
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
