using resturant_pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity;

namespace resturant_pro.Controllers
{
    public class AdminController : Controller
    {
        private DatabaseEntities1 db = new DatabaseEntities1();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,email,phone,address")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // Search Employee
        public ActionResult Search_Emp(string searching)
        {
            var Employees = db.Employees.Where(s => s.name.Contains(searching) || searching == null).ToList();

            return View(Employees);
        }

       

        
        // GET: Employee/Delete/5
        public ActionResult Delete_Emp(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee Emp = db.Employees.Find(id);
            if (Emp == null)
            {
                return HttpNotFound();
            }
            return View(Emp);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete_Emp")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed_Emp(int id)
        {
            Employee Emp = db.Employees.Find(id);
            db.Employees.Remove(Emp);
            db.SaveChanges();
            return RedirectToAction("Search_Emp");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Address,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            return View(user);
        }
        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Search");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Search
        public ActionResult Search(string searching)
        {
            var Users = db.Users.Where(s => s.UserName.Contains(searching) || searching == null).ToList();

            return View(Users);
        }
        // GET: User /Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
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