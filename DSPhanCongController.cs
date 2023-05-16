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
        QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
        // GET: DSPhanCong
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            var ds = from phancong in db.tPhanCongs select phancong;
            return View(ds);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            tPhanCong phancong = db.tPhanCongs.Find(id);
            return View(phancong);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("SoPhanCong");
            tPhanCong phancong = db.tPhanCongs.Find(ma);
            phancong.MaPhanXuong = f.Get("MaPhanXuong");
            phancong.SoPhieu = f.Get("SoPhieu");
            phancong.MaThuoc = f.Get("MaThuoc");
            phancong.SoLuong = f.Get("SoLuong");
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tPhanCong themphancong)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            db.tPhanCongs.Add(themphancong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection f)
        {
            string SoPhanCong = f.Get("SoPhanCong");
            var phancong = db.tPhanCongs.Find("SoPhanCong");
            return RedirectToAction("details/" + SoPhanCong);
        }
        public ActionResult Details(string id)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tPhanCong mimi = db.tPhanCongs.Find(id);
            return View(mimi);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tPhanCong phancong = db.tPhanCongs.Find(id);
            return View(phancong);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string sophancong = f.Get("SoPhanCong");
            var cthd = (from t in db.tPhanCongs where t.SoPhanCong == sophancong select t).FirstOrDefault();
            {
                tPhanCong phancong = db.tPhanCongs.Find(sophancong);
                db.tPhanCongs.Remove(phancong);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}