﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PointsProject.Models
{
    public class Context : DbContext
    {
        //public DbSet<User> Users { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        

        static Context()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }

        public Context()
            : base("Server=localhost;Initial Catalog=Test;Integrated Security=True;")
        {
        }

       
    }
}