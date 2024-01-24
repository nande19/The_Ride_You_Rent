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
    public class CARsController : Controller
    {
        private Entities db = new Entities();

        // GET: CARs
        public async Task<ActionResult> Index()
        {
            var cARs = db.CARs.Include(c => c.CARBODYTYPE).Include(c => c.CARMAKE);
            return View(await cARs.ToListAsync());
        }

        // GET: CARs/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAR cAR = await db.CARs.FindAsync(id);
            if (cAR == null)
            {
                return HttpNotFound();
            }
            return View(cAR);
        }

        // GET: CARs/Create
        public ActionResult Create()
        {
            ViewBag.CAR_BODYTYPE = new SelectList(db.CARBODYTYPEs, "CAR_BODYTYPE", "CAR_BODYTYPE");
            ViewBag.CAR_MAKE = new SelectList(db.CARMAKEs, "CAR_MAKE", "CAR_MAKE");
            return View();
        }

        // POST: CARs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CARNO,CAR_MAKE,CAR_MODEL,CAR_BODYTYPE,KILOMETRESTRAVELLED,SERVICEKILOMETRES,AVAILABLE")] CAR cAR)
        {
            if (ModelState.IsValid)
            {
                db.CARs.Add(cAR);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CAR_BODYTYPE = new SelectList(db.CARBODYTYPEs, "CAR_BODYTYPE", "CAR_BODYTYPE", cAR.CAR_BODYTYPE);
            ViewBag.CAR_MAKE = new SelectList(db.CARMAKEs, "CAR_MAKE", "CAR_MAKE", cAR.CAR_MAKE);
            return View(cAR);
        }

        // GET: CARs/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAR cAR = await db.CARs.FindAsync(id);
            if (cAR == null)
            {
                return HttpNotFound();
            }
            ViewBag.CAR_BODYTYPE = new SelectList(db.CARBODYTYPEs, "CAR_BODYTYPE", "CAR_BODYTYPE", cAR.CAR_BODYTYPE);
            ViewBag.CAR_MAKE = new SelectList(db.CARMAKEs, "CAR_MAKE", "CAR_MAKE", cAR.CAR_MAKE);
            return View(cAR);
        }

        // POST: CARs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CARNO,CAR_MAKE,CAR_MODEL,CAR_BODYTYPE,KILOMETRESTRAVELLED,SERVICEKILOMETRES,AVAILABLE")] CAR cAR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAR).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CAR_BODYTYPE = new SelectList(db.CARBODYTYPEs, "CAR_BODYTYPE", "CAR_BODYTYPE", cAR.CAR_BODYTYPE);
            ViewBag.CAR_MAKE = new SelectList(db.CARMAKEs, "CAR_MAKE", "CAR_MAKE", cAR.CAR_MAKE);
            return View(cAR);
        }

        // GET: CARs/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAR cAR = await db.CARs.FindAsync(id);
            if (cAR == null)
            {
                return HttpNotFound();
            }
            return View(cAR);
        }

        // POST: CARs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            CAR cAR = await db.CARs.FindAsync(id);
            db.CARs.Remove(cAR);
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
