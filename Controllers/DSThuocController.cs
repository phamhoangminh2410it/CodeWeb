using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySanXuatDuoc.Models;
using PagedList;

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
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds = (from thuoc in db.tThuocs select thuoc).OrderBy(x => x.MaThuoc);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tThuoc thuoc = db.tThuocs.Single(x => x.MaThuoc == id);

            return View(thuoc);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            QuanLySanXuatXiNghiepDuocEntities db = new QuanLySanXuatXiNghiepDuocEntities();
            tThuoc thuoc = db.tThuocs.Single(x => x.MaThuoc == id);
            db.tThuocs.Remove(thuoc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tThuoc thuoc = db.tThuocs.Find(id);
            return View(thuoc);
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