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
    public class TypeFoodsController : SecurityController
    {
        private barbecue db = new barbecue();

        // GET: admin/TypeFoods
        public ActionResult Index()
        {
            return View(db.TypeFood.ToList());
        }

        // GET: admin/TypeFoods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeFood typeFood = db.TypeFood.Find(id);
            if (typeFood == null)
            {
                return HttpNotFound();
            }
            return View(typeFood);
        }

        // GET: admin/TypeFoods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/TypeFoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTypeFood,name,meta,hide")] TypeFood typeFood)
        {
            if (ModelState.IsValid)
            {
                db.TypeFood.Add(typeFood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeFood);
        }

        // GET: admin/TypeFoods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeFood typeFood = db.TypeFood.Find(id);
            if (typeFood == null)
            {
                return HttpNotFound();
            }
            return View(typeFood);
        }

        // POST: admin/TypeFoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTypeFood,name,meta,hide")] TypeFood typeFood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeFood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeFood);
        }

        // GET: admin/TypeFoods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeFood typeFood = db.TypeFood.Find(id);
            if (typeFood == null)
            {
                return HttpNotFound();
            }
            return View(typeFood);
        }

        // POST: admin/TypeFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeFood typeFood = db.TypeFood.Find(id);
            db.TypeFood.Remove(typeFood);
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
