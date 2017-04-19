using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PointsProject.Models
{
    public class Item{
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public DateTime ExpireDate { get; set; }
        public int HighestBid { get; set; }

    }

    public class ItemDBContext : DbContext
    {
        public DbSet<Item> Item { get; set; }
    }
}