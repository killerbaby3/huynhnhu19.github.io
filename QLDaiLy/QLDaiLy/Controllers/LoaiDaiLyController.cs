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
    public class LoaiDaiLyController : Controller
    {
        private DaiLyContext db = new DaiLyContext();

        // GET: LoaiDaiLy
        public async Task<ActionResult> Index()
        {
            return View(await db.LoaiDaiLys.ToListAsync());
        }

        // GET: LoaiDaiLy/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDaiLy loaiDaiLy = await db.LoaiDaiLys.FindAsync(id);
            if (loaiDaiLy == null)
            {
                return HttpNotFound();
            }
            return View(loaiDaiLy);
        }

        // GET: LoaiDaiLy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiDaiLy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaLoaiDL,TenLoaiDL,GhiChu,MaDaiLy")] LoaiDaiLy loaiDaiLy)
        {
            if (ModelState.IsValid)
            {
                db.LoaiDaiLys.Add(loaiDaiLy);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(loaiDaiLy);
        }

        // GET: LoaiDaiLy/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDaiLy loaiDaiLy = await db.LoaiDaiLys.FindAsync(id);
            if (loaiDaiLy == null)
            {
                return HttpNotFound();
            }
            return View(loaiDaiLy);
        }

        // POST: LoaiDaiLy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaLoaiDL,TenLoaiDL,GhiChu,MaDaiLy")] LoaiDaiLy loaiDaiLy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiDaiLy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(loaiDaiLy);
        }

        // GET: LoaiDaiLy/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDaiLy loaiDaiLy = await db.LoaiDaiLys.FindAsync(id);
            if (loaiDaiLy == null)
            {
                return HttpNotFound();
            }
            return View(loaiDaiLy);
        }

        // POST: LoaiDaiLy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LoaiDaiLy loaiDaiLy = await db.LoaiDaiLys.FindAsync(id);
            db.LoaiDaiLys.Remove(loaiDaiLy);
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
