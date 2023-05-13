using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySanXuatDuoc.Models;

namespace QuanLySanXuatDuoc.Controllers
{
    public class DSPhanCongController : Controller
    {
        QuanLySanXuatXiNghiepDuocEntities4 db = new QuanLySanXuatXiNghiepDuocEntities4();
        // GET: DSPhanCong
        public ActionResult Index()
        {
            var ds = from phancong in db.tPhanCongs select phancong;
            return View(ds);
        }

        /*public ActionResult Delete(int id)
        {
            tPhanCong phancong = db.tPhanCongs.Find(id);
            db.tPhanCongs.Remove(phancong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            tPhanCong phancong = db.tPhanCongs.Find(id);
            return View(phancong);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            int So = Convert.ToInt32(f.Get("SoPhanCong"));
            tPhanCong phancong = db.tPhanCongs.Find(So);
            phancong.MaPhanXuong = f.Get("MaPhanXuong");
            phancong.SoPhieu = Convert.ToInt32(f.Get("SoPhieu"));
            phancong.MaThuoc = f.Get("MaThuoc");
            phancong.SoLuong = Convert.ToInt32(f.Get("SoLuong"));
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/
    }
}