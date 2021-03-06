﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployableApp.Models;
using GoogleMaps.LocationServices;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace EmployableApp.Controllers
{
    public class AddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Addresses
        public ActionResult Index(int? id)
        {
            var job = (from a in db.Jobs where a.JobId == id select a).FirstOrDefault();
            ApplicationUser currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ProgramAddress userLoc = new ProgramAddress();
            ProgramAddress businessLoc = new ProgramAddress();

            userLoc = GetLatAndLng(currentUser.Address, "You Are Here!");
            businessLoc.lat = job.Latitude;
            businessLoc.lng = job.Longitude;
            businessLoc.description = job.CompanyName;

            List<ProgramAddress> myAddresses = new List<ProgramAddress>();
            myAddresses.Add(userLoc);
            myAddresses.Add(businessLoc);

            var model = new IndexViewModel
            {
                programmed = myAddresses
            };
            return View(model);
        }
        private ProgramAddress GetLatAndLng(Address address, string description)
        {
            string houseNumber = address.HouseNumber;
            string street = address.Street;
            string city = address.City;
            string state = address.State;
            int zip = address.ZipCode;
            string country = "United States";
            string fullAddress = houseNumber.ToString() + " " + street + " " + city + ", " + country + " " + state + " " + zip;
            ProgramAddress mapAddress = new ProgramAddress();
            mapAddress.description = description;
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(fullAddress);
            mapAddress.lat = point.Latitude;
            mapAddress.lng = point.Longitude;
            
            return mapAddress;
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Address address = db.Addresses.Find(id);
            //if (address == null)
            //{
            //    return HttpNotFound();
            //}

            string region = getRegion();
            string state = askSelected(region);
            string city = getCity(state);


            var model = new IndexViewModel { };
            return View(model);
        }
        public string getCity(string state)
        {
            return "";
        }
        public string askSelected(string region)
        {
            return "";
        }
        public string getRegion()
        {
            return "";
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Address_id,HouseNumber,AptNumber,Street,City,State,ZipCode")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Address_id,HouseNumber,AptNumber,Street,City,State,ZipCode")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
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
