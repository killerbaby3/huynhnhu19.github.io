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
    public class DaiLyController : Controller
    {
        private DaiLyContext db = new DaiLyContext();

        // GET: DaiLy
        public async Task<ActionResult> Index()
        {
            return View(await db.DaiLys.ToListAsync());
        }

        // GET: DaiLy/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DaiLy daiLy = await db.DaiLys.FindAsync(id);
            if (daiLy == null)
            {
                return HttpNotFound();
            }
            return View(daiLy);
        }

        // GET: DaiLy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DaiLy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaDL,TenDL,DiaChi,DienThoai,Quan,NgayTiepNhan,TienNo,MaLoaiDL,MaLoaiDaiLy")] DaiLy daiLy)
        {
            if (ModelState.IsValid)
            {
                db.DaiLys.Add(daiLy);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(daiLy);
        }

        // GET: DaiLy/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DaiLy daiLy = await db.DaiLys.FindAsync(id);
            if (daiLy == null)
            {
                return HttpNotFound();
            }
            return View(daiLy);
        }

        // POST: DaiLy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaDL,TenDL,DiaChi,DienThoai,Quan,NgayTiepNhan,TienNo,MaLoaiDL,MaLoaiDaiLy")] DaiLy daiLy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(daiLy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(daiLy);
        }

        // GET: DaiLy/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DaiLy daiLy = await db.DaiLys.FindAsync(id);
            if (daiLy == null)
            {
                return HttpNotFound();
            }
            return View(daiLy);
        }

        // POST: DaiLy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DaiLy daiLy = await db.DaiLys.FindAsync(id);
            db.DaiLys.Remove(daiLy);
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
