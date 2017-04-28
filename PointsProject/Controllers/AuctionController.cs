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
        // GET: Auction
        public ActionResult Index()
        {
            
            return View();
        }
    }
}