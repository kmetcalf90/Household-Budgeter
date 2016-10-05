using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Helpers;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class TransactionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transactions
        public ActionResult Index()
        {
           
            var transactions = db.Transactions.Include(t => t.Account).Include(t => t.Category).Include(t => t.User);
            return View(transactions.ToList());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            
            var userId = User.Identity.GetUserId();
            ViewBag.AccountId = new SelectList(db.BankAccounts, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccountId,CategoryId,UserId,Description,Amount")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                transaction.Amount = Math.Abs(transaction.Amount);
                if (!TransactionHelper.CategoryIsDeposit(transaction.CategoryId))
                {
                    transaction.Amount *= -1;
                }
               
                transaction.Date = DateTime.Now;
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.BankAccounts, "Id", "Name", transaction.AccountId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", transaction.CategoryId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", transaction.UserId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.BankAccounts, "Id", "Name", transaction.AccountId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", transaction.CategoryId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", transaction.UserId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccountId,CategoryId,UserId,Reconciled,ReconciledAmount,Description,Date,Void,Amount")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.BankAccounts, "Id", "Name", transaction.AccountId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", transaction.CategoryId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", transaction.UserId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
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
