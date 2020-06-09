using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using resturant_pro.Models;

namespace resturant_pro.Controllers
{
    public class EmployeeController : Controller
    {
        private DatabaseEntities1 db = new DatabaseEntities1();

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string searching)
        {
            var Euser = db.Users.Where(s => s.UserName.Contains(searching) || searching == null).ToList();

            return View(Euser);
        }
        // GET: Meal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User Euser = db.Users.Find(id);
            if (Euser == null)
            {
                return HttpNotFound();
            }
            return View(Euser);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User Euser = db.Users.Find(id);
            if (Euser == null)
            {
                return HttpNotFound();
            }
            return View(Euser);
        }
        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Address,Password")] User Euser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Euser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Euser);
        }
        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User Euser = db.Users.Find(id);
            if (Euser == null)
            {
                return HttpNotFound();
            }
            return View(Euser);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User Euser = db.Users.Find(id);
            db.Users.Remove(Euser);
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
        // Log out
        public ActionResult LogOut()
        {
            //   int userID = (int)Session["UserId"];
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }

}
