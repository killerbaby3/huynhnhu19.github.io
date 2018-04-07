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
    public class MatHangController : Controller
    {
        private DaiLyContext db = new DaiLyContext();

        // GET: MatHang
        public async Task<ActionResult> Index()
        {
            var matHangs = db.MatHangs.Include(m => m.CTPhieuXuat).Include(m => m.Donvi).Include(m => m.LoaiMatHang);
            return View(await matHangs.ToListAsync());
        }

        // GET: MatHang/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = await db.MatHangs.FindAsync(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }

        // GET: MatHang/Create
        public ActionResult Create()
        {
            ViewBag.MaCTPhieuXuat = new SelectList(db.ChiTietPhieuXuats, "MaCTPhieuXuat", "TinhTrang");
            ViewBag.MaDonVi = new SelectList(db.DonVis, "MaDonVi", "TenDonVi");
            ViewBag.MaLoaiMH = new SelectList(db.LoaiMatHangs, "MaLoaiMH", "TenLoaiMH");
            return View();
        }

        // POST: MatHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaMH,TenMH,DonGia,SoLuongCon,MaLoaiMH,MaDonVi,MaCTPhieuXuat")] MatHang matHang)
        {
            if (ModelState.IsValid)
            {
                db.MatHangs.Add(matHang);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MaCTPhieuXuat = new SelectList(db.ChiTietPhieuXuats, "MaCTPhieuXuat", "TinhTrang", matHang.MaCTPhieuXuat);
            ViewBag.MaDonVi = new SelectList(db.DonVis, "MaDonVi", "TenDonVi", matHang.MaDonVi);
            ViewBag.MaLoaiMH = new SelectList(db.LoaiMatHangs, "MaLoaiMH", "TenLoaiMH", matHang.MaLoaiMH);
            return View(matHang);
        }

        // GET: MatHang/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = await db.MatHangs.FindAsync(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCTPhieuXuat = new SelectList(db.ChiTietPhieuXuats, "MaCTPhieuXuat", "TinhTrang", matHang.MaCTPhieuXuat);
            ViewBag.MaDonVi = new SelectList(db.DonVis, "MaDonVi", "TenDonVi", matHang.MaDonVi);
            ViewBag.MaLoaiMH = new SelectList(db.LoaiMatHangs, "MaLoaiMH", "TenLoaiMH", matHang.MaLoaiMH);
            return View(matHang);
        }

        // POST: MatHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaMH,TenMH,DonGia,SoLuongCon,MaLoaiMH,MaDonVi,MaCTPhieuXuat")] MatHang matHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matHang).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaCTPhieuXuat = new SelectList(db.ChiTietPhieuXuats, "MaCTPhieuXuat", "TinhTrang", matHang.MaCTPhieuXuat);
            ViewBag.MaDonVi = new SelectList(db.DonVis, "MaDonVi", "TenDonVi", matHang.MaDonVi);
            ViewBag.MaLoaiMH = new SelectList(db.LoaiMatHangs, "MaLoaiMH", "TenLoaiMH", matHang.MaLoaiMH);
            return View(matHang);
        }

        // GET: MatHang/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = await db.MatHangs.FindAsync(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }

        // POST: MatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MatHang matHang = await db.MatHangs.FindAsync(id);
            db.MatHangs.Remove(matHang);
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
