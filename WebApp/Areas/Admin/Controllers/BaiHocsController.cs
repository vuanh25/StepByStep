using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Areas.Admin.Controllers
{
    public class BaiHocsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/BaiHocs
        public ActionResult Index(int? id)
        {
            List<BaiHoc> baiHocs = db.BaiHocs.ToList();
            ViewBag.Id = id;
            foreach (var item in baiHocs)
            {

                if (item.IdKhoaHoc == id)
                {

                    return View(db.BaiHocs.FirstOrDefault(p => p.IdKhoaHoc == id));
                }
            }
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
            return View();
        }

        // POST: Admin/BaiHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBaiHoc,TenBaiHoc,NoiDung1,NoiDung2,NoiDung3,NoiDung4,NoiDung5,NoiDung6,NoiDung7,NoiDung8,NoiDung9,NoiDung10,IdKhoaHoc")] BaiHoc baiHoc)
        {
            if (ModelState.IsValid)
            {
                db.BaiHocs.Add(baiHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baiHoc);
        }

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
        public ActionResult Edit([Bind(Include = "IdBaiHoc,TenBaiHoc,NoiDung1,NoiDung2,NoiDung3,NoiDung4,NoiDung5,NoiDung6,NoiDung7,NoiDung8,NoiDung9,NoiDung10,IdKhoaHoc")] BaiHoc baiHoc)
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
