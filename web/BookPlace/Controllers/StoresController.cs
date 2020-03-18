using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookPlace.Models;

namespace BookPlace.Controllers
{
    public class StoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stores
        public ActionResult Index(string searchText1 = null, string searchText2 = null, string searchText3 = null)
        {


            var stores = from m in db.Store select m;


            if (string.IsNullOrEmpty(searchText1) && !string.IsNullOrEmpty(searchText2) && !string.IsNullOrEmpty(searchText3))
            {

                stores = stores.Where(t => t.Address.ToLower().Contains(searchText2.ToLower())).
                                   Where(t => t.City.ToLower().Contains(searchText3.ToLower())).
                                   OrderBy(t => t.Name);
            }
            if (string.IsNullOrEmpty(searchText1) && string.IsNullOrEmpty(searchText2) && !string.IsNullOrEmpty(searchText3))
            {

                stores = stores.Where(t => t.City.ToLower().Contains(searchText3.ToLower())).
                                   OrderBy(t => t.Name);
            }

            if (!string.IsNullOrEmpty(searchText1) && string.IsNullOrEmpty(searchText2) && !string.IsNullOrEmpty(searchText3))
            {

                stores = stores.Where(t => t.Name.ToLower().Contains(searchText1.ToLower())).
                    Where(t => t.City.ToLower().Contains(searchText3.ToLower())).
                                   OrderBy(t => t.Name);
            }

            if (!string.IsNullOrEmpty(searchText1) && string.IsNullOrEmpty(searchText2) && string.IsNullOrEmpty(searchText3))
            {

                stores = stores.Where(t => t.Name.ToLower().Contains(searchText1.ToLower())).
                                   OrderBy(t => t.Name);
            }
            if (string.IsNullOrEmpty(searchText1) && !string.IsNullOrEmpty(searchText2) && string.IsNullOrEmpty(searchText3))
            {

                stores = stores.Where(t => t.Address.ToLower().Contains(searchText2.ToLower())).
                                   OrderBy(t => t.Name);
            }


            if (!string.IsNullOrEmpty(searchText1) && !string.IsNullOrEmpty(searchText2) && !string.IsNullOrEmpty(searchText3))
            {

                stores = stores.Where(t => t.Name.ToLower().Contains(searchText1.ToLower())).
                                   Where(t => t.Address.ToLower().Contains(searchText2.ToLower())).
                                   Where(t => t.City.ToLower().Contains(searchText3.ToLower())).
                                   OrderBy(t => t.Name);
            }

            //  if (!string.IsNullOrEmpty(searchText1) )
            //    stores = stores.Where(x => x.Name.Contains(searchText1));

            return View(stores.ToList());

            //return View(db.Store.ToList());
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Store.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                db.Store.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(store);
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Store.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Store.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = db.Store.Find(id);
            db.Store.Remove(store);
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
