using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using cuoiki.Models;

namespace cuoiki.Controllers
{
    public class LoginController : Controller
    {
        barbecue db = new barbecue();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public static string GetMD5(string pass)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
            StringBuilder hashSb = new StringBuilder();
            foreach (byte b in hash)
            {
                hashSb.Append(b.ToString("X2"));
            }
            return hashSb.ToString();
        }

        [HttpPost]
        public ActionResult Index(FormCollection field)
        {   
            string username = field["username"];
            string password = field["password"];
            
            password = GetMD5(password);
            var v = (from t in db.Account
                    where t.username == username && t.password == password
                    select t).Take(1);
            if(v.Count() > 0)
            {
                var accounts = v.FirstOrDefault();
                Session["User"] = accounts.TenBan;
                Session["id"] = accounts.idAcc;
                if (accounts.username.Equals("admin"))
                    return RedirectToAction("Index", "Default", new {area = "admin"});
                if (accounts.username.Equals("kitchen"))
                    return RedirectToAction("Index", "Default", new { area = "kitchen" });
                return RedirectToAction("Index", "Default");
            }
            ViewBag.error = "Sai tài khoản hoặc mật khẩu";
            return View();
        }

        public ActionResult logout()
        {
            Session["User"] = "";
            Session["id"] = "";
            return RedirectToAction("Index");
        }
    }
}