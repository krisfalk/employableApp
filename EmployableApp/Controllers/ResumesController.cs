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
    public class ResumesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Resumes
        public ActionResult Index()
        {
            var resumes = db.Resumes.Include(r => r.ApplicationUser);
            return View(resumes.ToList());
        }

        // GET: Resumes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = db.Resumes.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        // GET: Resumes/Create
        public ActionResult Create()
        {
            var resumes = db.Resumes.Include(c => c.ApplicationUser).ToList();
            var userId = User.Identity.GetUserId();
            var currentResume = (from a in resumes where a.UserId == userId select a).FirstOrDefault();

            var user = db.Users.Where(p => p.Id == userId).FirstOrDefault();
            var currentAddress = (from b in db.Addresses where b.Address_id == user.Address_id select b).FirstOrDefault();


            var viewModel = new CreateViewModel
            {


                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Street = currentAddress.Street,
                City = currentAddress.City,
                AptNumber = currentAddress.AptNumber,
                HouseNumber = currentAddress.HouseNumber,
                State = currentAddress.State,
                ZipCode = currentAddress.ZipCode,
                 
            };
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View(viewModel);
        }

        // POST: Resumes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            var userId = User.Identity.GetUserId();

            var user = db.Users.Where(p => p.Id == userId).FirstOrDefault();

            var resume = new Resume
            {
                UserId = userId,
                JobExperienceOne = model.JobExperienceOne,
                JobExperienceTwo = model.JobExperienceTwo,
                JobExperienceThree = model.JobExperienceThree,
                College = model.College,
                HighSchool = model.HighSchool,
                OtherSchooling = model.OtherSchooling,
                Skills = model.Skills,
                ReferenceOne = model.ReferenceOne,
                ReferenceTwo = model.ReferenceTwo,
                ReferenceThree = model.ReferenceThree,
            };

            if (ModelState.IsValid)
            {

                FileWriter fileWriter = new FileWriter(model, user);

                //db.Resumes.Add(resume);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
           

            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", resume.UserId);
            return View(resume);
        }

        // GET: Resumes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = db.Resumes.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", resume.UserId);
            return View(resume);
        }

        // POST: Resumes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResumeId,UserId,JobExperienceOne,JobExperienceTwo,JobExperienceThree,HighSchool,College,OtherSchooling,Skills,ReferenceOne,ReferenceTwo,ReferenceThree")] Resume resume)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resume).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", resume.UserId);
            return View(resume);
        }

        // GET: Resumes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = db.Resumes.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        public ActionResult TestView()
        {

            string lat = "8";
            string lng = "8";
            string city = "hello";

            var model = new IndexViewModel
            {
                Latitude = lat,
                Longitude = lng,
                CityName = city
            };
            return View(model);
        }

        // POST: Resumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resume resume = db.Resumes.Find(id);
            db.Resumes.Remove(resume);
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
