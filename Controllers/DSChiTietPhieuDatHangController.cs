﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using QuanLySanXuatDuoc.Models;

namespace QuanLySanXuatDuoc.Controllers
{
    public class DSChiTietPhieuDatHangController : Controller
    {
        QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
        // GET: DSChiTietPhieuDatHang
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            var ds = from chitiet in db.tChiTietPhieuDatHangs select chitiet;
            return View(ds);
        }
        [HttpGet]
        public ActionResult Edit(string id, string id2)
        {
            tChiTietPhieuDatHang chitiet = db.tChiTietPhieuDatHangs.Find(id, id2);

            return View(chitiet);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("SoPhieu");
            string ma2 = f.Get("MaThuoc");
            tChiTietPhieuDatHang chitiet = db.tChiTietPhieuDatHangs.Find(ma, ma2);
            chitiet.SoLuongDat = f.Get("SoLuongDat");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tChiTietPhieuDatHang themchitiet)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            db.tChiTietPhieuDatHangs.Add(themchitiet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id, string id2)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tChiTietPhieuDatHang mimi = db.tChiTietPhieuDatHangs.Find(id, id2);
            return View(mimi);
        }
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection f)
        {
            string SoPhieu = f.Get("SoPhieu");
            string MaPhieu = f.Get("MaPhieu");
            return RedirectToAction("details/" + SoPhieu + "/" + MaPhieu);

        }
        [HttpGet]

        public ActionResult Delete(string id, string id2)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tChiTietPhieuDatHang chitiet = db.tChiTietPhieuDatHangs.Find(id, id2);

            return View(chitiet);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string id2)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tChiTietPhieuDatHang chitiet = db.tChiTietPhieuDatHangs.Find(id, id2);
            db.tChiTietPhieuDatHangs.Remove(chitiet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}