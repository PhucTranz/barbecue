using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using cuoiki.Models;

namespace cuoiki.Controllers
{
    public class CartController : SecurityController
    {
        // GET: Cart
        barbecue db = new barbecue();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getCart()
        {
            int idAcc = Int32.Parse(Session["id"].ToString());
            var query = from f in db.Food
                        join tf in db.TypeFood on f.idTypeFood equals tf.idTypeFood
                        join dc in db.DetailCart on f.idFood equals dc.idFood
                        join c in db.Cart on dc.idCart equals c.idCart where c.idAcc == idAcc && c.status == 0
                        select new { idfood=f.idFood, tfmeta = tf.meta, FoodName = f.name, Price = f.price, TotalPrice = c.tongtien, Quantity = dc.soluong, img = f.img};

            String p = "";
            List<String[]> list = new List<String[]>();
            foreach (var i in query.ToList())
            {
                String[] array = new String[7];
                array[0] = i.tfmeta;
                array[1] = i.FoodName;
                array[2] = Convert.ToString(i.Price);
                array[3] = Convert.ToString(i.TotalPrice);
                p = array[3];
                array[4] = Convert.ToString(i.Quantity);
                array[5] = Convert.ToString(i.img);
                array[6] = Convert.ToString(i.idfood);
                list.Add(array);
            }
            if (p.Equals(""))
                ViewBag.m = "0";
            else
                ViewBag.m = p;
            ViewBag.list = list;
            return PartialView();
        }

        [HttpPost]
        public JsonResult addToCart(int idFood, int soluong)
        {
            if(soluong < 1)
                return Json(new { code = 0, msg = "Thêm thất bại"}, JsonRequestBehavior.AllowGet);
            try
            {
                Food f = db.Food.Find(idFood);
                int idAcc = Int32.Parse(Session["id"].ToString());
                var v = from t in db.Cart
                        where t.idAcc == idAcc && t.status == 0
                        select t;
                Cart c = v.FirstOrDefault();
                if (c == null)
                {
                    c = new Cart();
                    c.idAcc = idAcc;
                    c.status = 0;

                    c.tongtien = f.price * soluong;
                    db.Cart.Add(c);
                    db.SaveChanges();
                    v = from t in db.Cart
                            where t.idAcc == idAcc && t.status == 0
                            select t;
                    c = v.FirstOrDefault();
                }
                else
                {
                    c.tongtien = c.tongtien + f.price * soluong;
                    db.Cart.AddOrUpdate(c);
                }

                DetailCart dc = new DetailCart();
                dc.idCart = c.idCart;
                dc.idFood = idFood;
                dc.soluong = soluong;
                db.DetailCart.Add(dc);
                db.SaveChanges();
                return Json(new {code = 1, msg = "Thêm thành công"}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 0, msg = "Đã có trong giỏ hàng"}, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult del(int idFood)
        {
            try
            {
                Food f = db.Food.Find(idFood);
                int idAcc = Int32.Parse(Session["id"].ToString());
                var v = from t in db.Cart
                        where t.idAcc == idAcc && t.status == 0
                        select t;
                Cart c = v.FirstOrDefault();

                var d = from t in db.DetailCart
                        where t.idCart == c.idCart && t.idFood == idFood
                        select t;
                
                DetailCart dc = d.FirstOrDefault();
                c.tongtien = c.tongtien - f.price * dc.soluong;
                db.Cart.AddOrUpdate(c);
                db.DetailCart.Remove(dc);
                db.SaveChanges();
                return Json(new { code = 1, msg = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 0, msg = "Xóa thất bại: " + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult updateQuantity(int idFood, int soluong)
        {
            if (soluong < 1)
                return Json(new { code = 0, msg = "Thất bại: " }, JsonRequestBehavior.AllowGet);
            try
            {
                Food f = db.Food.Find(idFood);
                int idAcc = Int32.Parse(Session["id"].ToString());
                var v = from t in db.Cart
                        where t.idAcc == idAcc && t.status == 0
                        select t;
                Cart c = v.FirstOrDefault();

                var d = from t in db.DetailCart
                        where t.idCart == c.idCart && t.idFood == idFood
                        select t;

                DetailCart dc = d.FirstOrDefault();
                c.tongtien = c.tongtien - f.price * dc.soluong + f.price * soluong;
                db.Cart.AddOrUpdate(c);
                dc.soluong = soluong;
                db.DetailCart.AddOrUpdate(dc);
                db.SaveChanges();
                return Json(new { code = 1, msg = "Thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 0, msg = "Thất bại: " + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult order()
        {
            try
            {
                int idAcc = Int32.Parse(Session["id"].ToString());
                var v = from t in db.Cart
                        where t.idAcc == idAcc && t.status == 0
                        select t;
                Cart c = v.FirstOrDefault();
                c.status = 1;
                db.Cart.AddOrUpdate(c);

                Bill bill = new Bill();
                bill.idAcc = idAcc;
                bill.total = c.tongtien;
                bill.timeBegin = DateTime.Now;
                bill.status = false;
                db.Bill.Add(bill);
                db.SaveChanges();

                var b = from t in db.Bill
                         where t.idAcc == idAcc && t.status == false
                         select t;
                bill = b.FirstOrDefault();

                var listDC = from t in db.DetailCart
                        where t.idCart == c.idCart
                        select t;
                
                foreach(var i in listDC.ToList())
                {
                    DetailBill detailBill = new DetailBill();
                    detailBill.idBill = bill.idBill;
                    detailBill.idFood = i.idFood;
                    detailBill.quanlity = (int) i.soluong;
                    db.DetailBill.Add(detailBill);
                    db.SaveChanges();
                }
                db.SaveChanges();
                return Json(new { code = 1, msg = "Gọi món thành công, vui lòng đợi bếp làm món" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 0, msg = "Thất bại: " + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}