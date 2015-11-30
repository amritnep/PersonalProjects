using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoanManagementSystem.DAL;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Controllers
{
    public class LoanContractController : Controller
    {
        private LoanContext db = new LoanContext();

        // GET: LoanContract
        public ActionResult Index()
        {
            var loanContracts = db.LoanContracts.Include(l => l.LoanStatus);
            return View(loanContracts.ToList());
        }

        // GET: LoanContract/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanContract loanContract = db.LoanContracts.Find(id);
            if (loanContract == null)
            {
                return HttpNotFound();
            }
            return View(loanContract);
        }

        // GET: LoanContract/Create
        public ActionResult Create()
        {
            ViewBag.LoanStatusCode = new SelectList(db.LoanStatuses, "LoanStatusCode", "LoanStatusCode");
            ViewBag.Customer = new SelectList(db.Customers, "ID", "Name");
            return View();
        }

        // POST: LoanContract/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LoanStatusCode,DateContractStarts,DateContractEnds,InterestRate,LoanAmount,TermsAndCoditions")] LoanContract loanContract)
        {
            if (ModelState.IsValid)
            {
                db.LoanContracts.Add(loanContract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoanStatusCode = new SelectList(db.LoanStatuses, "LoanStatusCode", "LoanStatusCode", loanContract.LoanStatus);
            return View(loanContract);
        }

        // GET: LoanContract/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanContract loanContract = db.LoanContracts.Find(id);
            if (loanContract == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoanStatusCode = new SelectList(db.LoanStatuses, "LoanStatusCode", "LoanStatusCode", loanContract.LoanStatus);
            return View(loanContract);
        }

        // POST: LoanContract/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LoanStatusCode,DateContractStarts,DateContractEnds,InterestRate,LoanAmount,TermsAndCoditions")] LoanContract loanContract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loanContract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoanStatusCode = new SelectList(db.LoanStatuses, "LoanStatusCode", "LoanStatusCode", loanContract.LoanStatus);
            return View(loanContract);
        }

        // GET: LoanContract/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanContract loanContract = db.LoanContracts.Find(id);
            if (loanContract == null)
            {
                return HttpNotFound();
            }
            return View(loanContract);
        }

        // POST: LoanContract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoanContract loanContract = db.LoanContracts.Find(id);
            db.LoanContracts.Remove(loanContract);
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
