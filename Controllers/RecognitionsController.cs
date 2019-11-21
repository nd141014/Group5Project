using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group5Project.DAL;
using Group5Project.Models;
using Microsoft.AspNet.Identity;

namespace Group5Project.Controllers
{
    [Authorize]

    public class RecognitionsController : Controller
    {
        private Context db = new Context();

        // GET: Recognitions
        public ActionResult Index()
        {
            var EData = db.Recognitions.Include(e => e.RecognizingEmployee).Include(e => e.Awardee).ToList();

            return View(EData);


        }

        // GET: Recognitions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // GET: Recognitions/Create
        public ActionResult Create()
        {
            //var employees = db.Employees.OrderBy(c => c.employeeLastName);
            //ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "fullEmployeeName");

            string empID = User.Identity.GetUserId();
            SelectList employees = new SelectList(db.Employees, "employeeID", "fullEmployeeName");
            employees = new SelectList(employees.Where(x => x.Value != empID).ToList(), "Value", "Text");
            ViewBag.employeeID = employees;

            return View();
        }

        // POST: Recognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recognitionId,employeeID,RecognitionValue,recognitionDescription,recognitionPoints,RecognizeeEmployeeID")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                Guid employeeID;
                Guid.TryParse(User.Identity.GetUserId(), out employeeID);
                recognition.RecognizeeEmployeeID = employeeID;
                db.Recognitions.Add(recognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //var employees = db.Employees.OrderBy(c => c.employeeLastName).ThenBy(c => c.employeeFirstName);
            //ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeLastName");
            string empID = User.Identity.GetUserId();
            SelectList employees = new SelectList(db.Employees, "employeeID", "fullEmployeeName");
            employees = new SelectList(employees.Where(x => x.Value != empID).ToList(), "Value", "Text");
            ViewBag.employeeID = employees;
            return View(recognition);
        }

        // GET: Recognitions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // POST: Recognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recognitionId,employeeID,RecognitionValue,recognitionDescription,recognitionPoints,RecognizeeEmployeeID")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recognition);
        }

        // GET: Recognitions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // POST: Recognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Recognition recognition = db.Recognitions.Find(id);
            db.Recognitions.Remove(recognition);
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
