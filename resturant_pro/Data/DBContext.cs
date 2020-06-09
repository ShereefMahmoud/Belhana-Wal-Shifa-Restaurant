using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;


namespace resturant_pro.Data
{
    public class MyDBContext : DbContext
    {
        public DbSet<Models.User> User { get; set; }
        public DbSet<Models.Meal> Meal { get; set; }

    }
}