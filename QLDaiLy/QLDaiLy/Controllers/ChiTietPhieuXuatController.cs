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
    public class ChiTietPhieuXuatController : Controller
    {
        private DaiLyContext db = new DaiLyContext();

        // GET: ChiTietPhieuXuat
        public async Task<ActionResult> Index()
        {
            return View(await db.ChiTietPhieuXuats.ToListAsync());
        }

        // GET: ChiTietPhieuXuat/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuXuat chiTietPhieuXuat = await db.ChiTietPhieuXuats.FindAsync(id);
            if (chiTietPhieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuXuat);
        }

        // GET: ChiTietPhieuXuat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiTietPhieuXuat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaCTPhieuXuat,SoLuongDat,TinhTrang,TongTien,MaMH")] ChiTietPhieuXuat chiTietPhieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietPhieuXuats.Add(chiTietPhieuXuat);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(chiTietPhieuXuat);
        }

        // GET: ChiTietPhieuXuat/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuXuat chiTietPhieuXuat = await db.ChiTietPhieuXuats.FindAsync(id);
            if (chiTietPhieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuXuat);
        }

        // POST: ChiTietPhieuXuat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaCTPhieuXuat,SoLuongDat,TinhTrang,TongTien,MaMH")] ChiTietPhieuXuat chiTietPhieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietPhieuXuat).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(chiTietPhieuXuat);
        }

        // GET: ChiTietPhieuXuat/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuXuat chiTietPhieuXuat = await db.ChiTietPhieuXuats.FindAsync(id);
            if (chiTietPhieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuXuat);
        }

        // POST: ChiTietPhieuXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ChiTietPhieuXuat chiTietPhieuXuat = await db.ChiTietPhieuXuats.FindAsync(id);
            db.ChiTietPhieuXuats.Remove(chiTietPhieuXuat);
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
