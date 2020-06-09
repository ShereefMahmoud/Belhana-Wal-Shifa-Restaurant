using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using resturant_pro.Models;

namespace resturant_pro.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // GET: Home
        private DatabaseEntities1 db = new DatabaseEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(User user)
        {
            using (DatabaseEntities1 dbModel = new DatabaseEntities1())
            {
                var UserDetails = dbModel.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                if (UserDetails == null)
                {
                    user.LoginErrorMessege = "Wrong username or password";
                    return View("Index", user);
                }

                else if (UserDetails.UserName == "Admin" && UserDetails.Password == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }

                else
                {
                    Session["UserId"] = UserDetails.Id;
                    Session["UserName"] = UserDetails.UserName;
                    return RedirectToAction("Index", "User");
                }
            }
        }
    }
}