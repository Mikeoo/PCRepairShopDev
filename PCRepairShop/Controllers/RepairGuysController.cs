using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PCRepairShop.DAL;
using PCRepairShop.Models;

namespace PCRepairShop.Controllers
{
    public class RepairGuysController : Controller
    {
        private PCRepairContext db = new PCRepairContext();

        // GET: RepairGuys
        public ActionResult Index()
        {
            return View(db.RepairGuys.ToList());
        }

        // GET: RepairGuys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairGuy repairGuy = db.RepairGuys.Find(id);
            if (repairGuy == null)
            {
                return HttpNotFound();
            }
            return View(repairGuy);
        }

        // GET: RepairGuys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepairGuys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] RepairGuy repairGuy)
        {
            if (ModelState.IsValid)
            {
                db.RepairGuys.Add(repairGuy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repairGuy);
        }

        // GET: RepairGuys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairGuy repairGuy = db.RepairGuys.Find(id);
            if (repairGuy == null)
            {
                return HttpNotFound();
            }
            return View(repairGuy);
        }

        // POST: RepairGuys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] RepairGuy repairGuy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairGuy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repairGuy);
        }

        // GET: RepairGuys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairGuy repairGuy = db.RepairGuys.Find(id);
            if (repairGuy == null)
            {
                return HttpNotFound();
            }
            return View(repairGuy);
        }

        // POST: RepairGuys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepairGuy repairGuy = db.RepairGuys.Find(id);
            db.RepairGuys.Remove(repairGuy);
            db.SaveChanges();
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
