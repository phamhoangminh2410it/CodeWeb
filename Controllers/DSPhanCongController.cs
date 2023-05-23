using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySanXuatDuoc.Models;
using PagedList;

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
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds = (from pc in db.tPhanCongs select pc).OrderBy(x => x.SoPhanCong);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
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
        public ActionResult Find(string id)
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
            tPhanCong chitiet = db.tPhanCongs.Find(id);
            return View(chitiet);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tPhanCong phancong = db.tPhanCongs.Find(id);
            return View(phancong);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tPhanCong phancong = db.tPhanCongs.Find(id);
            db.tPhanCongs.Remove(phancong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}