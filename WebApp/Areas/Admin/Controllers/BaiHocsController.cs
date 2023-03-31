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
    public class BaiHocsController : KiemTraController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/BaiHocs
        public ActionResult Index(string search)
        {

            if (KiemTraDangNhapAdmin())
            {

                var khoahocs = db.KhoaHocs.Where(p => p.TenKhoaHoc.Contains(search)).ToList();
                ViewBag.Search = search;    
                foreach (var item in khoahocs)
                {
                    if (Equals(item.TenKhoaHoc,search))
                    {

                        ViewBag.TenKhoaHoc = item.TenKhoaHoc;
                        List<BaiHoc> baiHocs = db.BaiHocs.Where(x => x.IdKhoaHoc == item.IDKhoaHoc).ToList();
                        return View(baiHocs);
                    }
                }
               
                return View();

        }

            
            return RedirectToAction("Login", "User");
        }



        public ActionResult IndexKhoaHoc()
        {
            return View(db.KhoaHocs.ToList());
        }

        public ActionResult KhoaHoc(string SearchId)
        {
            int id = int.Parse(SearchId);
            var baiHocs = db.BaiHocs.Where(p => p.IdKhoaHoc == id).ToList();
            return View(baiHocs);
        }

        // GET: Admin/BaiHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHoc baiHoc = db.BaiHocs.Find(id);
            if (baiHoc == null)
            {
                return HttpNotFound();
            }
            return View(baiHoc);
        }

        // GET: Admin/BaiHocs/Create
        public ActionResult Create()
        {
            ViewBag.IdKhoaHoc = new SelectList(db.KhoaHocs, "IDKhoaHoc", "TenKhoaHoc");
            return View();
        }

        // POST: Admin/BaiHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBaiHoc,TenBaiHoc,IdKhoaHoc")] BaiHoc baiHoc)
        {
            if (ModelState.IsValid)
            {
                db.BaiHocs.Add(baiHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHocs, "IdKhoaHoc", "TenKhoaHoc", baiHoc.IdKhoaHoc);
            return View(baiHoc);
        }
    /*    ViewBag.IdBaiHoc = new SelectList(db.BaiHocs, "IdBaiHoc", "TenBaiHoc");*/
        // GET: Admin/BaiHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHoc baiHoc = db.BaiHocs.Find(id);
            if (baiHoc == null)
            {
                return HttpNotFound();
            }
            return View(baiHoc);
        }

        // POST: Admin/BaiHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBaiHoc,TenBaiHoc,IdKhoaHoc")] BaiHoc baiHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baiHoc);
        }

        // GET: Admin/BaiHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHoc baiHoc = db.BaiHocs.Find(id);
            if (baiHoc == null)
            {
                return HttpNotFound();
            }
            return View(baiHoc);
        }

        // POST: Admin/BaiHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiHoc baiHoc = db.BaiHocs.Find(id);
            db.BaiHocs.Remove(baiHoc);
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
