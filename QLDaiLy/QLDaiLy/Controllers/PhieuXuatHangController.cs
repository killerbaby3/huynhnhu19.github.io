using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLDaiLy.DAL;
using QLDaiLy.Models;

namespace QLDaiLy.Controllers
{
    public class PhieuXuatHangController : Controller
    {
        private DaiLyContext db = new DaiLyContext();

        // GET: PhieuXuatHang
        public async Task<ActionResult> Index()
        {
            var phieuXuatHangs = db.PhieuXuatHangs.Include(p => p.phieuThuTien);
            return View(await phieuXuatHangs.ToListAsync());
        }

        // GET: PhieuXuatHang/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatHang phieuXuatHang = await db.PhieuXuatHangs.FindAsync(id);
            if (phieuXuatHang == null)
            {
                return HttpNotFound();
            }
            return View(phieuXuatHang);
        }

        // GET: PhieuXuatHang/Create
        public ActionResult Create()
        {
            ViewBag.MaPhieuThuTien = new SelectList(db.PhieuThuTiens, "MaPhieuThuTien", "MaPhieuThuTien");
            return View();
        }

        // POST: PhieuXuatHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaPhieuXuat,NgayLapPhieuDat,NgayLapPhieuXuat,MaDL,MaCTPhieu,MaPhieuThuTien")] PhieuXuatHang phieuXuatHang)
        {
            if (ModelState.IsValid)
            {
                db.PhieuXuatHangs.Add(phieuXuatHang);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MaPhieuThuTien = new SelectList(db.PhieuThuTiens, "MaPhieuThuTien", "MaPhieuThuTien", phieuXuatHang.MaPhieuThuTien);
            return View(phieuXuatHang);
        }

        // GET: PhieuXuatHang/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatHang phieuXuatHang = await db.PhieuXuatHangs.FindAsync(id);
            if (phieuXuatHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhieuThuTien = new SelectList(db.PhieuThuTiens, "MaPhieuThuTien", "MaPhieuThuTien", phieuXuatHang.MaPhieuThuTien);
            return View(phieuXuatHang);
        }

        // POST: PhieuXuatHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaPhieuXuat,NgayLapPhieuDat,NgayLapPhieuXuat,MaDL,MaCTPhieu,MaPhieuThuTien")] PhieuXuatHang phieuXuatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuXuatHang).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhieuThuTien = new SelectList(db.PhieuThuTiens, "MaPhieuThuTien", "MaPhieuThuTien", phieuXuatHang.MaPhieuThuTien);
            return View(phieuXuatHang);
        }

        // GET: PhieuXuatHang/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatHang phieuXuatHang = await db.PhieuXuatHangs.FindAsync(id);
            if (phieuXuatHang == null)
            {
                return HttpNotFound();
            }
            return View(phieuXuatHang);
        }

        // POST: PhieuXuatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PhieuXuatHang phieuXuatHang = await db.PhieuXuatHangs.FindAsync(id);
            db.PhieuXuatHangs.Remove(phieuXuatHang);
            await db.SaveChangesAsync();
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
