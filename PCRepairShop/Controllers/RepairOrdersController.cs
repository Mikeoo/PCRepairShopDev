using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PCRepairShop.DAL;
using PCRepairShop.Models;
using PCRepairShop.ViewModels;

namespace PCRepairShop.Controllers
{
    public class RepairOrdersController : Controller
    {
        private PCRepairContext db = new PCRepairContext();

        // GET: RepairOrders
        public ActionResult Index()
        {
            var countAwaiting = db.RepairOrders.Where(o => o.Status == Status.Awaiting).Count();
            IDictionary<int, string> d = new Dictionary<int, string>();
            d.Add(new KeyValuePair<int, string>(1, countAwaiting.ToString()));

            
            
            var newvm = new RepairOrderVM()
            {
                RepairOrders = db.RepairOrders.ToList(),
                StatusCounter = new List<int>()
            };
            foreach (KeyValuePair<int, string> ele in d)
            {
                newvm.StatusCounter.Add(d.All);
            }
            
            return View(newvm); 
        }

        // GET: RepairOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairOrder repairOrder = db.RepairOrders.Find(id);
            if (repairOrder == null)
            {
                return HttpNotFound();
            }
            return View(repairOrder);
        }

        // GET: RepairOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepairOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate,Status,Counter")] RepairOrder repairOrder)
        {
            if (ModelState.IsValid)
            {
                db.RepairOrders.Add(repairOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repairOrder);
        }

        // GET: RepairOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairOrder repairOrder = db.RepairOrders.Find(id);
            if (repairOrder == null)
            {
                return HttpNotFound();
            }
            return View(repairOrder);
        }

        // POST: RepairOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate,Status,Counter")] RepairOrder repairOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repairOrder);
        }

        // GET: RepairOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairOrder repairOrder = db.RepairOrders.Find(id);
            if (repairOrder == null)
            {
                return HttpNotFound();
            }
            return View(repairOrder);
        }

        // POST: RepairOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepairOrder repairOrder = db.RepairOrders.Find(id);
            db.RepairOrders.Remove(repairOrder);
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
