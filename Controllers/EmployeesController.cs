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
        public ActionResult Delete(int? id)
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
