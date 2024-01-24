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
    public class DRIVERsController : Controller
    {
        private Entities db = new Entities();

        // GET: DRIVERs
        public async Task<ActionResult> Index()
        {
            return View(await db.DRIVERs.ToListAsync());
        }

        // GET: DRIVERs/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DRIVER dRIVER = await db.DRIVERs.FindAsync(id);
            if (dRIVER == null)
            {
                return HttpNotFound();
            }
            return View(dRIVER);
        }

        // GET: DRIVERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DRIVERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DRIVER_NAME,DRIVER_ADDRESS,EMAIL,MOBILE")] DRIVER dRIVER)
        {
            if (ModelState.IsValid)
            {
                db.DRIVERs.Add(dRIVER);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dRIVER);
        }

        // GET: DRIVERs/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DRIVER dRIVER = await db.DRIVERs.FindAsync(id);
            if (dRIVER == null)
            {
                return HttpNotFound();
            }
            return View(dRIVER);
        }

        // POST: DRIVERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DRIVER_NAME,DRIVER_ADDRESS,EMAIL,MOBILE")] DRIVER dRIVER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dRIVER).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dRIVER);
        }

        // GET: DRIVERs/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DRIVER dRIVER = await db.DRIVERs.FindAsync(id);
            if (dRIVER == null)
            {
                return HttpNotFound();
            }
            return View(dRIVER);
        }

        // POST: DRIVERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            DRIVER dRIVER = await db.DRIVERs.FindAsync(id);
            db.DRIVERs.Remove(dRIVER);
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
