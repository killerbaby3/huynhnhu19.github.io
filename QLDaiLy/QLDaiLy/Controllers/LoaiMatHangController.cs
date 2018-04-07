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
    public class LoaiMatHangController : Controller
    {
        private DaiLyContext db = new DaiLyContext();

        // GET: LoaiMatHang
        public async Task<ActionResult> Index()
        {
            return View(await db.LoaiMatHangs.ToListAsync());
        }

        // GET: LoaiMatHang/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMatHang loaiMatHang = await db.LoaiMatHangs.FindAsync(id);
            if (loaiMatHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiMatHang);
        }

        // GET: LoaiMatHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiMatHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaLoaiMH,TenLoaiMH,GhiChu,MaMH")] LoaiMatHang loaiMatHang)
        {
            if (ModelState.IsValid)
            {
                db.LoaiMatHangs.Add(loaiMatHang);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(loaiMatHang);
        }

        // GET: LoaiMatHang/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMatHang loaiMatHang = await db.LoaiMatHangs.FindAsync(id);
            if (loaiMatHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiMatHang);
        }

        // POST: LoaiMatHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaLoaiMH,TenLoaiMH,GhiChu,MaMH")] LoaiMatHang loaiMatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiMatHang).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(loaiMatHang);
        }

        // GET: LoaiMatHang/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMatHang loaiMatHang = await db.LoaiMatHangs.FindAsync(id);
            if (loaiMatHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiMatHang);
        }

        // POST: LoaiMatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LoaiMatHang loaiMatHang = await db.LoaiMatHangs.FindAsync(id);
            db.LoaiMatHangs.Remove(loaiMatHang);
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
