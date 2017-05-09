using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PointsProject.Models;

namespace PointsProject.Controllers
{
    public class ItemsController : Controller
    {
        private ItemDBContext db = new ItemDBContext();

        [NonAction]
        public List<Item> GetItemList(){
            return new List<Item>{
                new Item
                {
                    ItemID = 1,
                    ItemName = "Wii",
                    EndDate = DateTime.Parse(DateTime.Today.ToString()),
                    HighestBid = 100000
                },

                new Item
                {
                    ItemID = 2,
                    ItemName = "PS4",
                    EndDate = DateTime.Parse(DateTime.Today.ToString()),
                    HighestBid = 110000
                },

                new Item
                {
                    ItemID = 3,
                    ItemName = "XBox",
                    EndDate = DateTime.Parse(DateTime.Today.ToString()),
                    HighestBid = 120000
                },

                new Item
                {
                    ItemID = 4,
                    ItemName = "Hydro Flask",
                    EndDate = DateTime.Parse(DateTime.Today.ToString()),
                    HighestBid = 30000
                },

            };

        }

        // GET: Items
        public ActionResult Index()
        {
            var item = from e in GetItemList()
                       orderby e.ItemID
                       select e;
            return View(item);
            //return View(db.Item.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemName,ExpireDate,HighestBid")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Item.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,ExpireDate,HighestBid")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Item.Find(id);
            db.Item.Remove(item);
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
    }
}
