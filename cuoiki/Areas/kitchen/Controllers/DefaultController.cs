using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cuoiki.Models;

namespace cuoiki.Areas.kitchen.Controllers
{
    public class DefaultController : SecurityController
    {
        barbecue db = new barbecue();
        // GET: kitchen/Default
        public ActionResult Index()
        {
            var list = from bill in db.Bill
                       where bill.status == false
                       select bill;
            return View(list.ToList());
        }
        public ActionResult detailOrder(int? id)
        {
            ViewBag.idBill = id;
            ViewBag.title = db.Bill.Find(id).Account.TenBan;
            var list = from detailBill in db.DetailBill
                       where detailBill.idBill == id
                       select detailBill;

            return View(list.ToList());
        }

        [HttpPost]
        public JsonResult finish(int id)
        {
            try
            {
                Bill b = db.Bill.Find(id);
                b.status = true;
                b.timeFinish = DateTime.Now;
                db.Bill.AddOrUpdate(b);
                db.SaveChanges();
                return Json(new { code = 1}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 0}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}