using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Controllers;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Areas.Admin.Controllers
{
    public class ChiTietBaiHocsController : KiemTraController
    {
        private ApplicationDbContext db = new ApplicationDbContext();




        // GET: Admin/ChiTietBaiHocs

     

        public ActionResult Index(int? IdBaiHoc)
        {
            if (KiemTraDangNhapAdmin())
            {
                var Chitietbaihocs = db.ChiTietBaiHocs.Where(p => p.IdBaiHoc == IdBaiHoc).ToList();
                var BaiHocs = db.BaiHocs.Where(p => p.IdBaiHoc == IdBaiHoc).ToList();
                foreach (var item in BaiHocs)
                {
                    ViewBag.tenBaiHoc = item.TenBaiHoc;
                }
                return View(Chitietbaihocs);
        }
            return RedirectToAction("Login", "User");
            

         }

        // GET: Admin/ChiTietBaiHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBaiHoc chiTietBaiHoc = db.ChiTietBaiHocs.Find(id);
            if (chiTietBaiHoc == null)
            {
                return HttpNotFound();
            }
            return View(chiTietBaiHoc);
        }

        // GET: Admin/ChiTietBaiHocs/Create
        public ActionResult Create()
        {
            ViewBag.IdBaiHoc = new SelectList(db.BaiHocs, "IdBaiHoc", "TenBaiHoc");
            return View();
        }

        // POST: Admin/ChiTietBaiHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdChiTietBaiHoc,NoiDung1,IdBaiHoc")] ChiTietBaiHoc chiTietBaiHoc)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietBaiHocs.Add(chiTietBaiHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBaiHoc = new SelectList(db.BaiHocs, "IdBaiHoc", "TenBaiHoc", chiTietBaiHoc.IdBaiHoc);

            return View(chiTietBaiHoc);
        }

        // GET: Admin/ChiTietBaiHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBaiHoc chiTietBaiHoc = db.ChiTietBaiHocs.Find(id);
            if (chiTietBaiHoc == null)
            {
                return HttpNotFound();
            }
            return View(chiTietBaiHoc);
        }

        // POST: Admin/ChiTietBaiHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ValidateInput(false)]
        [ValidateAntiForgeryToken]
  
        public ActionResult Edit([Bind(Include ="IdChiTietBaiHoc,NoiDung1,IdBaiHoc")] ChiTietBaiHoc chiTietBaiHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietBaiHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chiTietBaiHoc);
        }

        // GET: Admin/ChiTietBaiHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBaiHoc chiTietBaiHoc = db.ChiTietBaiHocs.Find(id);
            if (chiTietBaiHoc == null)
            {
                return HttpNotFound();
            }
            return View(chiTietBaiHoc);
        }

        // POST: Admin/ChiTietBaiHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietBaiHoc chiTietBaiHoc = db.ChiTietBaiHocs.Find(id);
            db.ChiTietBaiHocs.Remove(chiTietBaiHoc);
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
