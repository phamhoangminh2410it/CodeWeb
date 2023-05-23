using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySanXuatDuoc.Models;
using PagedList;

namespace QuanlySanXuatDuoc.Controllers
{
    public class DSKhachHangController : Controller
    {
        QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
        // GET: DSKhachHang
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds = (from kh in db.tKhachHangs select kh).OrderBy(x => x.MaKH);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        /*[HttpGet]
        public ActionResult Delete(string id)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tKhachHang khachhang = db.tKhachHangs.Find(id);
            return View(khachhang);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            string id = f.Get("MaKH");
            var khach = (from ds in db.tPhieuDatHangs where ds.MaKH == id select ds).FirstOrDefault();
            if (khach == null)
            {
                tKhachHang khachhang = db.tKhachHangs.Find(id);
                db.tKhachHangs.Remove(khachhang);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }*/
        [HttpGet]

        public ActionResult Delete(string id)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tKhachHang khachhang = db.tKhachHangs.Single(x => x.MaKH == id);

            return View(khachhang);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tKhachHang khachhang = db.tKhachHangs.Single(x => x.MaKH == id);
            db.tKhachHangs.Remove(khachhang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tKhachHang khachhang = db.tKhachHangs.Find(id);
            return View(khachhang);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaKH");
            tKhachHang khachhang = db.tKhachHangs.Find(ma);
            khachhang.TenKH = f.Get("TenKH");
            khachhang.DiaChi = f.Get("DiaChi");
            khachhang.SoDienThoai = f.Get("SoDienThoai");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tKhachHang themkhachhang)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            db.tKhachHangs.Add(themkhachhang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tKhachHang chitiet = db.tKhachHangs.Find(id);
            return View(chitiet);
        }
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection f)
        {
            string MaKH = f.Get("MaKH");
            var khachhang = db.tKhachHangs.Find("MaKH");
            return RedirectToAction("details/" + MaKH);
        }
    }
}