using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quan_Ly_Thu_Vien.Models;

namespace Quan_Ly_Thu_Vien.Controllers
{
    public class THUEPHONGsController : Controller
    {
        private Quan_Ly_Thu_VienEntities1 db = new Quan_Ly_Thu_VienEntities1();

        // GET: THUEPHONGs
        public ActionResult Index()
        {
            var tHUEPHONGs = db.THUEPHONGs.Include(t => t.HOIVIEN).Include(t => t.PHONGHOP);
            return View(tHUEPHONGs.ToList());
        }

        // GET: THUEPHONGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUEPHONG tHUEPHONG = db.THUEPHONGs.Find(id);
            if (tHUEPHONG == null)
            {
                return HttpNotFound();
            }
            return View(tHUEPHONG);
        }

        // GET: THUEPHONGs/Create
        public ActionResult Create()
        {
            ViewBag.MaHV = new SelectList(db.HOIVIENs, "MaHV", "TenHV");
            ViewBag.MaPH = new SelectList(db.PHONGHOPs, "MaPH", "MaPH");
            return View();
        }

        // POST: THUEPHONGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHV,MaPH,NgayThue,ThoiGian,DonGia")] THUEPHONG tHUEPHONG)
        {
            SetAlert("Tạo thành công!", 1);
            if (tHUEPHONG.DonGia <= 0 )
            {
                SetAlert("Đơn giá không đúng", 3);
            }
            if (tHUEPHONG.ThoiGian <= 0)
            {
                SetAlert("Vui lòng nhập thời gian", 3);
            }
            if (tHUEPHONG.NgayThue == null)
            {
                SetAlert("Vui lòng nhập ngày thuê", 3);
            }

            try
            {
                db.THUEPHONGs.Add(tHUEPHONG);
                db.SaveChanges();
                ViewBag.MaHV = new SelectList(db.HOIVIENs, "MaHV", "TenHV", tHUEPHONG.MaHV);
                ViewBag.MaPH = new SelectList(db.PHONGHOPs, "MaPH", "MaPH", tHUEPHONG.MaPH);
                return View(tHUEPHONG);
            }
            catch
            {
                ViewBag.MaHV = new SelectList(db.HOIVIENs, "MaHV", "TenHV", tHUEPHONG.MaHV);
                ViewBag.MaPH = new SelectList(db.PHONGHOPs, "MaPH", "MaPH", tHUEPHONG.MaPH);
                return View(tHUEPHONG);
            }
            
        }

        protected void SetAlert(string message, int type)
        {
            TempData["AlertMessage"] = message;
            if (type == 1)
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == 2)
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == 3)
            {
                TempData["AlertType"] = "alert-danger";
            }
            else
            {
                TempData["AlertType"] = "alert-info";
            }
        }

        // GET: THUEPHONGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUEPHONG tHUEPHONG = db.THUEPHONGs.Find(id);
            if (tHUEPHONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHV = new SelectList(db.HOIVIENs, "MaHV", "TenHV", tHUEPHONG.MaHV);
            ViewBag.MaPH = new SelectList(db.PHONGHOPs, "MaPH", "MaPH", tHUEPHONG.MaPH);
            return View(tHUEPHONG);
        }

        // POST: THUEPHONGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHV,MaPH,NgayThue,ThoiGian,DonGia")] THUEPHONG tHUEPHONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHUEPHONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHV = new SelectList(db.HOIVIENs, "MaHV", "TenHV", tHUEPHONG.MaHV);
            ViewBag.MaPH = new SelectList(db.PHONGHOPs, "MaPH", "MaPH", tHUEPHONG.MaPH);
            return View(tHUEPHONG);
        }

        // GET: THUEPHONGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUEPHONG tHUEPHONG = db.THUEPHONGs.Find(id);
            if (tHUEPHONG == null)
            {
                return HttpNotFound();
            }
            return View(tHUEPHONG);
        }

        // POST: THUEPHONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THUEPHONG tHUEPHONG = db.THUEPHONGs.Find(id);
            db.THUEPHONGs.Remove(tHUEPHONG);
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
