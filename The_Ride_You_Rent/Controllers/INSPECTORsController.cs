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
    public class INSPECTORsController : Controller
    {
        private Entities db = new Entities();

        // GET: INSPECTORs
        public async Task<ActionResult> Index()
        {
            return View(await db.INSPECTORs.ToListAsync());
        }

        // GET: INSPECTORs/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSPECTOR iNSPECTOR = await db.INSPECTORs.FindAsync(id);
            if (iNSPECTOR == null)
            {
                return HttpNotFound();
            }
            return View(iNSPECTOR);
        }

        // GET: INSPECTORs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: INSPECTORs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "INSPECTORID,INSPECTOR_NAME,EMAIL,MOBILE")] INSPECTOR iNSPECTOR)
        {
            if (ModelState.IsValid)
            {
                db.INSPECTORs.Add(iNSPECTOR);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(iNSPECTOR);
        }

        // GET: INSPECTORs/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSPECTOR iNSPECTOR = await db.INSPECTORs.FindAsync(id);
            if (iNSPECTOR == null)
            {
                return HttpNotFound();
            }
            return View(iNSPECTOR);
        }

        // POST: INSPECTORs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "INSPECTORID,INSPECTOR_NAME,EMAIL,MOBILE")] INSPECTOR iNSPECTOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNSPECTOR).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(iNSPECTOR);
        }

        // GET: INSPECTORs/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSPECTOR iNSPECTOR = await db.INSPECTORs.FindAsync(id);
            if (iNSPECTOR == null)
            {
                return HttpNotFound();
            }
            return View(iNSPECTOR);
        }

        // POST: INSPECTORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            INSPECTOR iNSPECTOR = await db.INSPECTORs.FindAsync(id);
            db.INSPECTORs.Remove(iNSPECTOR);
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
