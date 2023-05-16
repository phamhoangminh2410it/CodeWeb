using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySanXuatDuoc.Models;

namespace QuanlySanXuatDuoc.Controllers
{
    public class DSPhieuDatHangController : Controller
    {
        QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
        // GET: DSPhieuDatHang
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            var ds = from phieu in db.tPhieuDatHangs select phieu;
            return View(ds);
        }

        public ActionResult Edit(string id)
        {
            tPhieuDatHang phieu = db.tPhieuDatHangs.Find(id);
            return View(phieu);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tPhieuDatHang phieu = db.tPhieuDatHangs.Find(id);
            return View(phieu);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string id = f.Get("SoPhieu");
            var phieu1 = (from ds in db.tPhanCongs where ds.SoPhieu == id select ds).FirstOrDefault();
            var phieu2 = (from ds in db.tChiTietPhieuDatHangs where ds.SoPhieu == id select ds).FirstOrDefault();
            if ((phieu1 == null) && (phieu2 == null))
            {
                tPhieuDatHang phieu = db.tPhieuDatHangs.Find(id);
                db.tPhieuDatHangs.Remove(phieu);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("SoPhieu");
            tPhieuDatHang phieu = db.tPhieuDatHangs.Find(ma);
            phieu.NgayLapPhieu = f.Get("NgayLapPhieu");
            phieu.MaKH = f.Get("MaKH");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tPhieuDatHang themphieu)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            db.tPhieuDatHangs.Add(themphieu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tPhieuDatHang chitiet = db.tPhieuDatHangs.Find(id);
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
            string SoPhieu = f.Get("SoPhieu");
            var phieu = db.tPhieuDatHangs.Find("SoPhieu");
            return RedirectToAction("details/" + SoPhieu);
        }
    }
}