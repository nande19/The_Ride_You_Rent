using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using The_Ride_You_Rent.Models;

namespace The_Ride_You_Rent.Controllers
{
    [Authorize]
    public class RENTALsController : Controller
    {
        private Entities db = new Entities();

        // GET: RENTALs
        public async Task<ActionResult> Index()
        {
            var rENTALs = db.RENTALs.Include(r => r.CAR).Include(r => r.DRIVER).Include(r => r.INSPECTOR);
            return View(await rENTALs.ToListAsync());
        }

        // GET: RENTALs/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RENTAL rENTAL = await db.RENTALs.FindAsync(id);
            if (rENTAL == null)
            {
                return HttpNotFound();
            }
            return View(rENTAL);
        }

        // GET: RENTALs/Create
        public ActionResult Create()
        {
            ViewBag.CARNO = new SelectList(db.CARs, "CARNO", "CAR_MAKE");
            ViewBag.DRIVER_NAME = new SelectList(db.DRIVERs, "DRIVER_NAME", "DRIVER_ADDRESS");
            ViewBag.INSPECTORID = new SelectList(db.INSPECTORs, "INSPECTORID", "INSPECTOR_NAME");
            return View();
        }

        // POST: RENTALs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RENTALID,CARNO,INSPECTORID,DRIVER_NAME,RENTAL_FEE,STARTDATE,ENDDATE")] RENTAL rENTAL)
        {
            if (ModelState.IsValid)
            {
                db.RENTALs.Add(rENTAL);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CARNO = new SelectList(db.CARs, "CARNO", "CAR_MAKE", rENTAL.CARNO);
            ViewBag.DRIVER_NAME = new SelectList(db.DRIVERs, "DRIVER_NAME", "DRIVER_ADDRESS", rENTAL.DRIVER_NAME);
            ViewBag.INSPECTORID = new SelectList(db.INSPECTORs, "INSPECTORID", "INSPECTOR_NAME", rENTAL.INSPECTORID);
            return View(rENTAL);
        }

        // GET: RENTALs/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RENTAL rENTAL = await db.RENTALs.FindAsync(id);
            if (rENTAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.CARNO = new SelectList(db.CARs, "CARNO", "CAR_MAKE", rENTAL.CARNO);
            ViewBag.DRIVER_NAME = new SelectList(db.DRIVERs, "DRIVER_NAME", "DRIVER_ADDRESS", rENTAL.DRIVER_NAME);
            ViewBag.INSPECTORID = new SelectList(db.INSPECTORs, "INSPECTORID", "INSPECTOR_NAME", rENTAL.INSPECTORID);
            return View(rENTAL);
        }

        // POST: RENTALs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RENTALID,CARNO,INSPECTORID,DRIVER_NAME,RENTAL_FEE,STARTDATE,ENDDATE")] RENTAL rENTAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rENTAL).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CARNO = new SelectList(db.CARs, "CARNO", "CAR_MAKE", rENTAL.CARNO);
            ViewBag.DRIVER_NAME = new SelectList(db.DRIVERs, "DRIVER_NAME", "DRIVER_ADDRESS", rENTAL.DRIVER_NAME);
            ViewBag.INSPECTORID = new SelectList(db.INSPECTORs, "INSPECTORID", "INSPECTOR_NAME", rENTAL.INSPECTORID);
            return View(rENTAL);
        }

        // GET: RENTALs/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RENTAL rENTAL = await db.RENTALs.FindAsync(id);
            if (rENTAL == null)
            {
                return HttpNotFound();
            }
            return View(rENTAL);
        }

        // POST: RENTALs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            RENTAL rENTAL = await db.RENTALs.FindAsync(id);
            db.RENTALs.Remove(rENTAL);
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
