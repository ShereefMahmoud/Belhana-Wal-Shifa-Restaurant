using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using resturant_pro.Models;
using System.Net;
using System.Data.Entity;

namespace resturant_pro.Controllers
{
    public class UserController : Controller
    {

        private DatabaseEntities1 db = new DatabaseEntities1();

        public ActionResult Index(string searching)
        {
            var Meals = db.Meals.Where(s => s.Name.Contains(searching) || searching == null).ToList();

            return View(Meals);
        }
        // Add User
        // GET: User
        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult Add(User user)
        {
            using (DatabaseEntities1 dbModel = new DatabaseEntities1())
            {
                if (dbModel.Users.Any(x => x.UserName == user.UserName))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("Add", user);
                }
                dbModel.Users.Add(user);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("Add", new User());
        }

        // GET: Meal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        //Edit

        public ActionResult Edit(int? id )
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




        // LogOut 
        public ActionResult LogOut()
        {
            //   int userID = (int)Session["UserId"];
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}