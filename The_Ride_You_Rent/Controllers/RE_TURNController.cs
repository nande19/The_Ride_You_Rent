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
    public class RE_TURNController : Controller
    {
        private Entities db = new Entities();

        // GET: RE_TURN
        public async Task<ActionResult> Index()
        {
            var rE_TURN = db.RE_TURN.Include(r => r.CAR).Include(r => r.DRIVER).Include(r => r.INSPECTOR).Include(r => r.RENTAL);
            return View(await rE_TURN.ToListAsync());
        }

        // GET: RE_TURN/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RE_TURN rE_TURN = await db.RE_TURN.FindAsync(id);
            if (rE_TURN == null)
            {
                return HttpNotFound();
            }
            return View(rE_TURN);
        }

        // GET: RE_TURN/Create
        public ActionResult Create()
        {
            ViewBag.CARNO = new SelectList(db.CARs, "CARNO", "CAR_MAKE");
            ViewBag.DRIVER_NAME = new SelectList(db.DRIVERs, "DRIVER_NAME", "DRIVER_ADDRESS");
            ViewBag.INSPECTORID = new SelectList(db.INSPECTORs, "INSPECTORID", "INSPECTOR_NAME");
            ViewBag.RENTALID = new SelectList(db.RENTALs, "RENTALID", "CARNO");
            return View();
        }

        // POST: RE_TURN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RETURNID,RENTALID,CARNO,INSPECTORID,DRIVER_NAME,RETURN_DATE,ELAPSED_DATE,FINE")] RE_TURN rE_TURN)
        {
            if (ModelState.IsValid)
            {
                db.RE_TURN.Add(rE_TURN);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CARNO = new SelectList(db.CARs, "CARNO", "CAR_MAKE", rE_TURN.CARNO);
            ViewBag.DRIVER_NAME = new SelectList(db.DRIVERs, "DRIVER_NAME", "DRIVER_ADDRESS", rE_TURN.DRIVER_NAME);
            ViewBag.INSPECTORID = new SelectList(db.INSPECTORs, "INSPECTORID", "INSPECTOR_NAME", rE_TURN.INSPECTORID);
            ViewBag.RENTALID = new SelectList(db.RENTALs, "RENTALID", "CARNO", rE_TURN.RENTALID);
            return View(rE_TURN);
        }

        // GET: RE_TURN/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RE_TURN rE_TURN = await db.RE_TURN.FindAsync(id);
            if (rE_TURN == null)
            {
                return HttpNotFound();
            }
            ViewBag.CARNO = new SelectList(db.CARs, "CARNO", "CAR_MAKE", rE_TURN.CARNO);
            ViewBag.DRIVER_NAME = new SelectList(db.DRIVERs, "DRIVER_NAME", "DRIVER_ADDRESS", rE_TURN.DRIVER_NAME);
            ViewBag.INSPECTORID = new SelectList(db.INSPECTORs, "INSPECTORID", "INSPECTOR_NAME", rE_TURN.INSPECTORID);
            ViewBag.RENTALID = new SelectList(db.RENTALs, "RENTALID", "CARNO", rE_TURN.RENTALID);
            return View(rE_TURN);
        }

        // POST: RE_TURN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RETURNID,RENTALID,CARNO,INSPECTORID,DRIVER_NAME,RETURN_DATE,ELAPSED_DATE,FINE")] RE_TURN rE_TURN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rE_TURN).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CARNO = new SelectList(db.CARs, "CARNO", "CAR_MAKE", rE_TURN.CARNO);
            ViewBag.DRIVER_NAME = new SelectList(db.DRIVERs, "DRIVER_NAME", "DRIVER_ADDRESS", rE_TURN.DRIVER_NAME);
            ViewBag.INSPECTORID = new SelectList(db.INSPECTORs, "INSPECTORID", "INSPECTOR_NAME", rE_TURN.INSPECTORID);
            ViewBag.RENTALID = new SelectList(db.RENTALs, "RENTALID", "CARNO", rE_TURN.RENTALID);
            return View(rE_TURN);
        }

        // GET: RE_TURN/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RE_TURN rE_TURN = await db.RE_TURN.FindAsync(id);
            if (rE_TURN == null)
            {
                return HttpNotFound();
            }
            return View(rE_TURN);
        }

        // POST: RE_TURN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            RE_TURN rE_TURN = await db.RE_TURN.FindAsync(id);
            db.RE_TURN.Remove(rE_TURN);
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
