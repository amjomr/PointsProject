//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using PointsProject.Models;

//namespace PointsProject.Areas.Admin.Controllers
//{
//    public class AuctionController : Controller
//    {
//        private Context db = new Context();

//        // GET: Admin/Auction
//        public ActionResult Index()
//        {
//            return View(db.Auctions.ToList());
//        }

//        // GET: Admin/Auction/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Auction auction = db.Auctions.Find(id);
//            if (auction == null)
//            {
//                return HttpNotFound();
//            }
//            return View(auction);
//        }

//        // GET: Admin/Auction/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Admin/Auction/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "AuctionId,UserId,Title,Description,HighestBid,Image,IsActive")] Auction auction)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Auctions.Add(auction);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(auction);
//        }

//        // GET: Admin/Auction/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Auction auction = db.Auctions.Find(id);
//            if (auction == null)
//            {
//                return HttpNotFound();
//            }
//            return View(auction);
//        }

//        // POST: Admin/Auction/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "AuctionId,UserId,Title,Description,HighestBid,Image,IsActive")] Auction auction)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(auction).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(auction);
//        }

//        // GET: Admin/Auction/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Auction auction = db.Auctions.Find(id);
//            if (auction == null)
//            {
//                return HttpNotFound();
//            }
//            return View(auction);
//        }

//        // POST: Admin/Auction/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Auction auction = db.Auctions.Find(id);
//            db.Auctions.Remove(auction);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
