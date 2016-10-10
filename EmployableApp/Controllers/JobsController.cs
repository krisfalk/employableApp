using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployableApp.Models;
using Microsoft.AspNet.Identity;

namespace EmployableApp.Controllers
{
    public class JobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobs
        public ActionResult SavedJobs()
        {
            var userId = User.Identity.GetUserId();
            var job = db.Jobs.Include(j => j.ApplicationUser);
            return View(job.ToList());
        }

        [HttpPost]
        public ActionResult SavedJobs(IEnumerable<Job> jobs)
        {
            if (ModelState.IsValid)
            {
                foreach (var job in jobs)
                {
                    var currentJob = (from a in db.Jobs where a.JobId == job.JobId select a).FirstOrDefault();
                    if (job.Favorite == true)
                    {
                        currentJob.Favorite = true;
                    }
                    else
                    {
                        currentJob.Favorite = false;
                    }

                    if (job.AppliedFor == true)
                    {
                        currentJob.AppliedFor = true;
                    }
                    else
                    {
                        currentJob.AppliedFor = false;
                    }
                    db.SaveChanges();
                }

                return RedirectToAction("SavedJobs");
            }
            var jobList = db.Jobs.Include(j => j.ApplicationUser);
            return View(jobList.ToList());
        }


        //GET: Jobs/Details/5
        public ActionResult Details(LatLng myCoords)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Job job = db.Jobs.Find(id);
            //if (job == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(job);
            string lat = myCoords.Latitude;
            string lng = myCoords.Longitude;
            string city = myCoords.City;

            var model = new IndexViewModel
            {
                Latitude = lat,
                Longitude = lng,
                CityName = city
            };
            return View(model);
        }


        public ActionResult Search()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Serializable]
        public class JobListing
        {
            public string JobTitle { get; set; }
            public string Link { get; set; }
            public string Information { get; set; }
  
        }


        [HttpPost]
        public ActionResult SaveJobs(List<JobListing> savedJobs)
        {
            var userId = User.Identity.GetUserId();
            StringToDateConverter converter = new StringToDateConverter();
            foreach (JobListing job in savedJobs)
            {

                string[] data = job.Information.Split(',');
                DateTime dateTime = DateTime.Parse(data[4]);

                var newJob = new Job { UserId = userId, Title = job.JobTitle, Posting_Link = job.Link, Latitude = Convert.ToDouble(data[0]), Longitude = Convert.ToDouble(data[1]), CompanyName = data[2], PostingDate = dateTime };
                db.Jobs.Add(newJob);
            }
            db.SaveChanges();
            return View();
        }

        public class LatLng
        {
            public string Latitude { get; set; }
            public string Longitude { get; set; }
            public string City { get; set; }
        }
        public ActionResult MakeRoute(int? id)
        {
            return RedirectToAction("Index", "Addresses", new { id = id });
        }
        public ActionResult MakeCity(int? id)
        {
            var job = (from a in db.Jobs where a.JobId == id select a).FirstOrDefault();

            LatLng latLng = new LatLng();

            latLng.Latitude = job.Latitude.ToString();
            latLng.Longitude = job.Longitude.ToString();


            return RedirectToAction("Details", latLng);
        
            
        }
        // GET: Jobs/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobId,UserId,Title,CompanyName,AppliedFor,Favorite,Posting_Link,Latitude,Longitude")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", job.UserId);
            return View(job);
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", job.UserId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobId,UserId,Title,CompanyName,AppliedFor,Favorite,Posting_Link,Latitude,Longitude")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", job.UserId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
