﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            var countProcessing = db.RepairOrders.Where(o => o.Status == Status.Processing).Count();
            var countAwaitingParts = db.RepairOrders.Where(o => o.Status == Status.AwaitingParts).Count();
            var countClosed = db.RepairOrders.Where(o => o.Status == Status.Closed).Count();
            IDictionary<string, int> d = new Dictionary<string, int>();
            d.Add(new KeyValuePair<string, int>("Awaiting", countAwaiting));
            d.Add(new KeyValuePair<string, int>("Processing", countProcessing));
            d.Add(new KeyValuePair<string, int>("AwaitingParts", countAwaitingParts));
            d.Add(new KeyValuePair<string, int>("Closed", countClosed));

            var newvm = new RepairOrderVM()
            {
                RepairOrders = db.RepairOrders.ToList(),
                StatusCounter = new Dictionary<string, int>(),
                
            };
            foreach (KeyValuePair<string, int> ele in d)
            {
                newvm.StatusCounter.Add(ele.Key, ele.Value);
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
            var newvm = new CreateOrderVM()
            {
                customers = db.Customers.ToList(),
                RepairGuys = db.RepairGuys.ToList(),

            };
            return View(newvm);
        }

        // POST: RepairOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateOrderVM createOrderVM)
        {
            if (ModelState.IsValid)
            {
                createOrderVM.RepairOrder.Customer = db.Customers.Find(createOrderVM.RepairOrder.Customer.Id);
                createOrderVM.RepairOrder.RepairGuy = db.RepairGuys.Find(createOrderVM.RepairOrder.RepairGuy.Id);
                //createOrderVM.RepairOrder.RepairGuy = db.RepairGuys.Find(createOrderVM.RepairOrder.RepairGuy.Id);
                db.RepairOrders.Add(createOrderVM.RepairOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            createOrderVM.customers = db.Customers.ToList();
            return View(createOrderVM);
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
