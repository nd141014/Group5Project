﻿using System;
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

    public class EmployeesController : Controller
    {
        private Context db = new Context();



        // GET: Employees
        public ActionResult Index(string searchString)
        {
            
         
            {
                var testusers = from u in db.Employees select u;
                if (!string.IsNullOrEmpty(searchString))
                {
                    testusers = testusers.Where(u => u.employeeLastName.Contains(searchString)
                        || u.employeeFirstName.Contains(searchString));
                    return View(testusers.ToList());
                }
                return View(db.Employees.ToList());
            }

        }

        // GET: Employees/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            var rec = db.Recognitions.Where(r => r.Awardee.employeeID == id);
            ViewBag.rec = rec.ToList();

            var totalCnt = rec.Count(); //counts all the recognitions for that person
            var rec1Cnt = rec.Where(r => r.RecognitionValue == Recognition.CoreValue.Excellence).Count();
            // counts all the Excellence recognitions
            // notice how the Enum values are references, class.enum.value
            // the next two lines show another way to do the same counting
            var rec2Cnt = rec.Count(r => r.RecognitionValue == Recognition.CoreValue.Culture);
            var rec3Cnt = rec.Count(r => r.RecognitionValue == Recognition.CoreValue.Integrity);
            var rec4Cnt = rec.Count(r => r.RecognitionValue == Recognition.CoreValue.Stewardship);
            var rec5Cnt = rec.Count(r => r.RecognitionValue == Recognition.CoreValue.Good);
            var rec6Cnt = rec.Count(r => r.RecognitionValue == Recognition.CoreValue.Innovate);
            var rec7Cnt = rec.Count(r => r.RecognitionValue == Recognition.CoreValue.Balance);

            // copy the values into the ViewBag

            ViewBag.total = totalCnt;
            ViewBag.Excellence = rec1Cnt;
            ViewBag.Culture = rec2Cnt;
            ViewBag.Integrity = rec3Cnt;
            ViewBag.Stewardship = rec4Cnt;
            ViewBag.Good = rec5Cnt;
            ViewBag.Innovate = rec6Cnt;
            ViewBag.Balance = rec7Cnt;
            
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employeeID,employeeFirstName,employeeLastName,employeeBusinessUnit,employeeHireDate,employeeTitle")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                Guid employeeID;
                Guid.TryParse(User.Identity.GetUserId(), out employeeID);
                employee.employeeID = employeeID;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(Guid? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee user = db.Employees.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            Guid employeeID;
            Guid.TryParse(User.Identity.GetUserId(), out employeeID);
            if (id == employeeID)
            {
                return View(user);
            }
            else
            {
                return View("NotAuthenticated");
            }





            
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeID,employeeFirstName,employeeLastName,employeeBusinessUnit,employeeHireDate,employeeTitle")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
