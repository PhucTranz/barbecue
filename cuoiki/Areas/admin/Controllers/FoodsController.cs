using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cuoiki.Models;

namespace cuoiki.Areas.admin.Controllers
{
    public class FoodsController : SecurityController
    {
        private barbecue db = new barbecue();

        // GET: admin/Foods
        public ActionResult Index(int? id = null)
        {
            getTypeFood(id);
            return View();
        }

        public void getTypeFood(int? id = null)
        {
            ViewBag.typeFood = new SelectList(db.TypeFood.Where(x => x.hide == false), "idTypeFood", "name", id);
        }
        // GET: admin/Foods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Food.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // GET: admin/Foods/Create
        public ActionResult Create()
        {
            ViewBag.idTypeFood = new SelectList(db.TypeFood, "idTypeFood", "name");
            return View();
        }

        public ActionResult getFood(int? id)
        {
            if(id == null)
            {
                var foods = db.Food.Include(f => f.TypeFood);
                return PartialView(foods.ToList());
            }
            var food = db.Food.Where(x => x.idTypeFood == id && x.hide == false);
            return PartialView(food.ToList());
        }
        // POST: admin/Foods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFood,idTypeFood,name,price,description,meta,hide,img")] Food food, HttpPostedFileBase fileImage)
        {
            if (ModelState.IsValid)
            {
                if (fileImage != null)
                {
                    TypeFood tf = db.TypeFood.Find(food.idTypeFood);
                    var path = "";
                    var filename = "";
                    filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + fileImage.FileName;
                    path = Path.Combine(Server.MapPath("~/Uploads/images/"+tf.meta), filename);
                    fileImage.SaveAs(path);
                    food.img = filename; //Lưu ý
                }
                else
                {
                    food.img = "logo.png";
                }
                food.datebegin = DateTime.Now;
                db.Food.Add(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTypeFood = new SelectList(db.TypeFood, "idTypeFood", "name", food.idTypeFood);
            return View(food);
        }

        // GET: admin/Foods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Food.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTypeFood = new SelectList(db.TypeFood, "idTypeFood", "name", food.idTypeFood);
            return View(food);
        }

        // POST: admin/Foods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFood,idTypeFood,name,price,description,meta,hide,img")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTypeFood = new SelectList(db.TypeFood, "idTypeFood", "name", food.idTypeFood);
            return View(food);
        }

        // GET: admin/Foods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Food.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // POST: admin/Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = db.Food.Find(id);
            db.Food.Remove(food);
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
