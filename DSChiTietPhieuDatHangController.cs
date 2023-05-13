using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySanXuatDuoc.Models;

namespace QuanLySanXuatDuoc.Controllers
{
    public class DSChiTietPhieuDatHangController : Controller
    {
        QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
        // GET: DSChiTietPhieuDatHang
        public ActionResult Index()
        {
            var ds = from chitietphieudathang in db.tChiTietPhieuDatHangs select chitietphieudathang;
            return View(ds);
        }

        public ActionResult Delete(int id_0, string id_1)
        {
            tChiTietPhieuDatHang chitietphieudathang = db.tChiTietPhieuDatHangs.Find(id_0, id_1);
            db.tChiTietPhieuDatHangs.Remove(chitietphieudathang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Detail(int id_0, string id_1)
        {
            tChiTietPhieuDatHang chitietphieudathang = db.tChiTietPhieuDatHangs.Find(id_0, id_1);
            return View(chitietphieudathang);
        }

        [HttpGet]
        public ActionResult Edit(int id_0, string id_1)
        {
            tChiTietPhieuDatHang chitietphieudathang = db.tChiTietPhieuDatHangs.Find(id_0, id_1);
            return View(chitietphieudathang);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            int So = Convert.ToInt32(f.Get("SoPhieu"));
            string Ma = f.Get("MaThuoc");
            tChiTietPhieuDatHang chitietphieudathang = db.tChiTietPhieuDatHangs.Find(So, Ma);
            chitietphieudathang.SoLuongDat = Convert.ToInt32(f.Get("SoLuongDat"));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}