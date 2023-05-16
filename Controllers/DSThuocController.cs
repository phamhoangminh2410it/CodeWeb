using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySanXuatDuoc.Models;

namespace QuanlySanXuatDuoc.Controllers
{
    public class DSThuocController : Controller
    {
        QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
        // GET: DSThuoc
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            var ds = from thuoc in db.tThuocs select thuoc;
            return View(ds);
        }

        public ActionResult Edit(string id)
        {
            tThuoc thuoc = db.tThuocs.Find(id);
            return View(thuoc);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tThuoc thuoc = db.tThuocs.Find(id);
            return View(thuoc);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string id = f.Get("MaThuoc");
            var thuoc1 = (from ds in db.tPhanCongs where ds.MaThuoc == id select ds).FirstOrDefault();
            var thuoc2 = (from ds in db.tChiTietPhieuDatHangs where ds.MaThuoc == id select ds).FirstOrDefault();
            if ((thuoc1 == null) && (thuoc2 == null))
            {
                tThuoc thuoc = db.tThuocs.Find(id);
                db.tThuocs.Remove(thuoc);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaThuoc");
            tThuoc thuoc = db.tThuocs.Find(ma);
            thuoc.TenThuoc = f.Get("TenThuoc");
            thuoc.QuyCach = f.Get("QuyCach");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tThuoc themthuoc)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            db.tThuocs.Add(themthuoc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tThuoc chitiet = db.tThuocs.Find(id);
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
            string MaThuoc = f.Get("MaThuoc");
            var thuoc = db.tThuocs.Find("MaThuoc");
            return RedirectToAction("details/" + MaThuoc);
        }
    }
}