//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using PointsProject.Models;

//namespace PointsProject.Controllers
//{
//    public class ProfileController : Controller
//    {
//        private Context db = new Context();

//        // GET: Profile
//        public ActionResult Index()
//        {
//            var email = (string)Session["email"];
//            string queryCheckIN = "SELECT DATE, LOCATION, PERIOD"
//               + "FROM CHECKINS "
//               + "WHERE EMAIL = '" + email + "'";
//            string queryInfo = "SELECT EMAIL, TOTAL_POINTS"
//               + "FROM POINTS "
//               + "WHERE EMAIL = '" + email + "'";
//            string queryPurchases = "SELECT ITEMS, POINTS_SPENT"
//               + "FROM PURCHASES "
//               + "WHERE EMAIL = '" + email + "'";

//            IEnumerable<ProfileModels> data = db.Database.SqlQuery<ProfileModels>(queryInfo);
//            IEnumerable<ProfileModels> data1 = db.Database.SqlQuery<ProfileModels>(queryCheckIN);
//            IEnumerable<ProfileModels> data2 = db.Database.SqlQuery<ProfileModels>(queryPurchases);




//            return View(data.ToList());
//            //return View(db.ProfileModels.ToList());
            
//        }

//        // GET: Profile/Details/5
//        public ActionResult Details(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ProfileModels profileModels = db.ProfileModels.Find(id);
//            if (profileModels == null)
//            {
//                return HttpNotFound();
//            }

            
//            return View(profileModels);
//        }

//        // GET: Profile/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Profile/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "email,totalPoints,availablePoints,date,location,period,item,pointsSpent")] ProfileModels profileModels)
//        {
//            if (ModelState.IsValid)
//            {
//                db.ProfileModels.Add(profileModels);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(profileModels);
//        }

//        // GET: Profile/Edit/5
//        /**public ActionResult Edit(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ProfileModels profileModels = db.ProfileModels.Find(id);
//            if (profileModels == null)
//            {
//                return HttpNotFound();
//            }
//            return View(profileModels);
//        }

//        // POST: Profile/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "email,totalPoints,availablePoints,date,location,period,item,pointsSpent")] ProfileModels profileModels)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(profileModels).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(profileModels);
//        }**/

//        // GET: Profile/Delete/5
//       /** public ActionResult Delete(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ProfileModels profileModels = db.ProfileModels.Find(id);
//            if (profileModels == null)
//            {
//                return HttpNotFound();
//            }
//            return View(profileModels);
//        }**/

//        // POST: Profile/Delete/5
//       /** [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(string id)
//        {
//            ProfileModels profileModels = db.ProfileModels.Find(id);
//            db.ProfileModels.Remove(profileModels);
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
//        }**/
//    }
//}
