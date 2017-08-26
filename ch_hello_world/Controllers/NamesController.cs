using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ch_hello_world.DAL;
using ch_hello_world.Models;

namespace ch_hello_world.Controllers
{
    public class NamesController : Controller
    {
        private Users db = new Users();

        // GET: Names
        public ActionResult Index()
        {
            return View(db.Name.ToList());
        }

        // GET: Names/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Name name = db.Name.Find(id);
            if (name == null)
            {
                return HttpNotFound();
            }
            return View(name);
        }

        // GET: Names/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Names/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName")] Name name)
        {
            if (ModelState.IsValid)
            {
                db.Name.Add(name);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(name);
        }

        // GET: Names/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Name name = db.Name.Find(id);
            if (name == null)
            {
                return HttpNotFound();
            }
            return View(name);
        }

        // POST: Names/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName")] Name name)
        {
            if (ModelState.IsValid)
            {
                db.Entry(name).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(name);
        }

        // GET: Names/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Name name = db.Name.Find(id);
            if (name == null)
            {
                return HttpNotFound();
            }
            return View(name);
        }

        // POST: Names/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Name name = db.Name.Find(id);
            db.Name.Remove(name);
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
