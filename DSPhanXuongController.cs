using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySanXuatDuoc.Models;

namespace QuanlySanXuatDuoc.Controllers
{
    public class DSPhanXuongController : Controller
    {
        QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
        // GET: DSPhanXuong
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            var ds = from phanxuong in db.tPhanXuongs select phanxuong;
            return View(ds);
        }

        public ActionResult Edit(string id)
        {
            tPhanXuong phanxuong = db.tPhanXuongs.Find(id);
            return View(phanxuong);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tPhanXuong phanxuong = db.tPhanXuongs.Find(id);
            return View(phanxuong);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string id = f.Get("MaPhanXuong");
            var px = (from ds in db.tPhanCongs where ds.MaPhanXuong == id select ds).FirstOrDefault();
            if (px == null)
            {
                tPhanXuong phanxuong = db.tPhanXuongs.Find(id);
                db.tPhanXuongs.Remove(phanxuong);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaPhanXuong");
            tPhanXuong phanxuong = db.tPhanXuongs.Find(ma);
            phanxuong.TenPhanXuong = f.Get("TenPhanXuong");
            phanxuong.DiaChi = f.Get("DiaChi");
            phanxuong.DienThoai = f.Get("DienThoai");
            phanxuong.HoTenQuanDoc = f.Get("HoTenQuanDoc");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tPhanXuong themphanxuong)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            db.tPhanXuongs.Add(themphanxuong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tPhanXuong chitiet = db.tPhanXuongs.Find(id);
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
            string MaPhanXuong = f.Get("MaPhanXuong");
            var phanxuong = db.tPhanXuongs.Find("MaPhanXuong");
            return RedirectToAction("details/" + MaPhanXuong);
        }
    }
}