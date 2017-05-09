using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PointsProject.Models;

namespace PointsProject.Controllers
{   [Authorize]
    public class AuctionController : Controller
    {
        private Auction db = new Auction();

        // Amjad Omar

        [NonAction]
        public List<Item> GetAuctionsList()
        {
            return new List<Item>{
                new Item
                {
                    ItemID = 1,
                    ItemName = "Wii",
                    EndDate = DateTime.Parse(DateTime.Today.ToString()),
                    HighestBid = 700
                },

                new Item
                {
                    ItemID = 2,
                    ItemName = "PS4",
                    EndDate = DateTime.Parse(DateTime.Today.ToString()),
                    HighestBid = 550
                },

                new Item
                {
                    ItemID = 3,
                    ItemName = "IPhone 7",
                    EndDate = DateTime.Parse(DateTime.Today.ToString()),
                    HighestBid = 900
                },

                new Item
                {
                    ItemID = 4,
                    ItemName = "Laptop",
                    EndDate = DateTime.Parse(DateTime.Today.ToString()),
                    HighestBid = 650
                },

            };

        }
        // GET: Auction
        public ActionResult Index()
        {
            var Auction = from e in GetAuctionsList()
                       orderby e.ItemID
                       select e;
            return View(Auction);
                    

           // return View();
        }
    }
}