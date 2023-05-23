using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySanXuatDuoc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Home()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user, string password)
        {
            /*if (user.ToLower() == "admin" && password == "123456")*/
            if (password.Equals("123456"))
            {
                Session["user"] = "admin";
                return View();
            }
            else
            {
                ViewBag.error = "Tài Khoản Đăng Nhập Không Đúng!";
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("user");
            return RedirectToAction("Login");
        }
    }
}