﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication01.Models;

namespace WebApplication01.Controllers
{
    public class AlbamController : Controller
    {
        private MusicStoreDataContext db = new MusicStoreDataContext();

        // GET: Albam
        public ActionResult Index()
        {
            return View(db.Albams.ToList());
        }

        // GET: Albam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albam albam = db.Albams.Find(id);
            if (albam == null)
            {
                return HttpNotFound();
            }
            return View(albam);
        }

        // GET: Albam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albam/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbamId,Title,Price")] Albam albam)
        {
            if (ModelState.IsValid)
            {
                db.Albams.Add(albam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(albam);
        }

        // GET: Albam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albam albam = db.Albams.Find(id);
            if (albam == null)
            {
                return HttpNotFound();
            }
            return View(albam);
        }

        // POST: Albam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbamId,Title,Price")] Albam albam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(albam);
        }

        // GET: Albam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albam albam = db.Albams.Find(id);
            if (albam == null)
            {
                return HttpNotFound();
            }
            return View(albam);
        }

        // POST: Albam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Albam albam = db.Albams.Find(id);
            db.Albams.Remove(albam);
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